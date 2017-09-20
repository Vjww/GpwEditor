using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GpwEditor.Infrastructure.Services
{
    public class CommentaryResourceService : ITextResourceService
    {
        // TODO: remove?
        //private const int FirstLineId = 1;
        //private const int LastLineId = 357;

        private const string EnglishDriverInPitsSuffix = "in pits.";
        private const string EnglishDriverP1Suffix = "P1";
        private const string EnglishDriverP2Suffix = "P2";
        private const string EnglishDriverP3Suffix = "P3";
        private const string EnglishDriverOutSuffix = "out.";
        private const string EnglishTeamOutSuffix = "out.";

        private const string FrenchDriverInPitsSuffix = "aux stands.";
        private const string FrenchDriverP1Suffix = "1er";
        private const string FrenchDriverP2Suffix = "2ème";
        private const string FrenchDriverP3Suffix = "3ème";
        private const string FrenchDriverOutSuffix = "hors course.";
        private const string FrenchTeamOutSuffix = "hors course.";

        private const string GermanDriverInPitsSuffix = "an der Box.";
        private const string GermanDriverP1Suffix = "Platz 1";
        private const string GermanDriverP2Suffix = "Platz 2";
        private const string GermanDriverP3Suffix = "Platz 3";
        private const string GermanDriverOutSuffix = "ist raus.";
        private const string GermanTeamOutSuffix = "ist raus.";

        private const string DriverInPitsFileNameSuffix = "PIT.WAV";
        private const string DriverP1FileNameSuffix = "P1.WAV";
        private const string DriverP2FileNameSuffix = "P2.WAV";
        private const string DriverP3FileNameSuffix = "P3.WAV";
        private const string DriverOutFileNameSuffix = "OUT.WAV";
        private const string TeamOutFileNameSuffix = "OUT.WAV";

        private const string LeftAngleBracket = "<";
        private const string RightAngleBracket = ">";
        private const string WavFileExtension = ".WAV";

        public LanguageType LanguageType { get; }
        public List<CommentaryResource> ResourceList;

        public CommentaryResourceService(LanguageType languageType)
        {
            LanguageType = languageType;
            ResourceList = new List<CommentaryResource>();
        }

        public void LoadFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Argument is null or whitespace", nameof(filePath));

            try
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    using (var streamReader = new StreamReader(fileStream, Encoding.Default))
                    {
                        var id = 0;

                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            line = line.Trim();

                            string validationMessage;
                            Validate(line, id + 1, out validationMessage);
                            if (!string.IsNullOrWhiteSpace(validationMessage))
                            {
                                throw new Exception(validationMessage);
                            }

                            var commentaryType = GetCommentaryType(id);
                            var fileName = ExtractFileName(line);
                            var fileNamePrefix = ExtractFileNamePrefix(fileName, commentaryType);
                            var fileNameSuffix = ExtractFileNameSuffix(commentaryType);
                            var transcript = ExtractTranscript(line);
                            var transcriptPrefix = ExtractTranscriptPrefix(transcript, commentaryType, LanguageType);
                            var transcriptSuffix = ExtractTranscriptSuffix(commentaryType, LanguageType);
                            var commentaryResource = new CommentaryResource
                            {
                                Id = id,
                                FileName = fileName,
                                FileNamePrefix = fileNamePrefix,
                                FileNameSuffix = fileNameSuffix,
                                Transcript = transcript,
                                TranscriptPrefix = transcriptPrefix,
                                TranscriptSuffix = transcriptSuffix,
                                CommentaryType = commentaryType
                            };
                            ResourceList.Add(commentaryResource);

                            id++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to import all values from commentary resource.", ex);
            }
        }

        public void SaveToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Argument is null or whitespace", nameof(filePath));

            try
            {
                using (var fileStream = File.OpenWrite(filePath))
                {
                    using (var streamWriter = new StreamWriter(fileStream, Encoding.Default))
                    {
                        foreach (var item in ResourceList)
                        {
                            var fileName = BuildFileName(item);
                            var transcript = BuildTranscript(item);
                            streamWriter.WriteLine($"{RightAngleBracket}{fileName} {transcript}{LeftAngleBracket}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to export all values to commentary resource.", ex);
            }
        }

        public string Read(int id)
        {
            var resource = ResourceList.Single(x => x.Id == id);
            return resource.Transcript;
        }

        public void Write(int id, string value)
        {
            var resource = ResourceList.Single(x => x.Id == id);
            if (resource.CommentaryType == CommentaryType.Default) resource.Transcript = value;
            else resource.TranscriptPrefix = value;
        }

        private static string BuildFileName(CommentaryResource resource)
        {
            return resource.CommentaryType == CommentaryType.Default
                ? resource.FileName
                : $"{resource.FileNamePrefix}{resource.FileNameSuffix}".ToUpperInvariant();
        }

        private static string BuildTranscript(CommentaryResource resource)
        {
            return resource.CommentaryType == CommentaryType.Default
                ? resource.Transcript
                : $"{resource.TranscriptPrefix} {resource.TranscriptSuffix}";
        }

        private static CommentaryType GetCommentaryType(int id)
        {
            if (id < 67) return CommentaryType.Default;
            if (id < 108) return CommentaryType.DriverP1;
            if (id < 149) return CommentaryType.DriverP2;
            if (id < 190) return CommentaryType.DriverP3;
            if (id < 231) return CommentaryType.DriverOut;
            if (id < 242) return CommentaryType.TeamOut;
            if (id < 243) return CommentaryType.Default;
            if (id < 284) return CommentaryType.DriverInPits;
            return CommentaryType.Default;
        }

        private static string ExtractFileName(string text)
        {
            const int startIndex = 1;
            var length = IndexOfValueInText(text, WavFileExtension) + 4 - startIndex;
            return text.Substring(startIndex, length).Trim().ToUpperInvariant();
        }

        private static string ExtractFileNamePrefix(string fileName, CommentaryType commentaryType)
        {
            switch (commentaryType)
            {
                case CommentaryType.Default:
                    return string.Empty;
                case CommentaryType.DriverInPits:
                    return fileName.Substring(0, fileName.Length - DriverInPitsFileNameSuffix.Length);
                case CommentaryType.DriverOut:
                    return fileName.Substring(0, fileName.Length - DriverOutFileNameSuffix.Length);
                case CommentaryType.DriverP1:
                    return fileName.Substring(0, fileName.Length - DriverP1FileNameSuffix.Length);
                case CommentaryType.DriverP2:
                    return fileName.Substring(0, fileName.Length - DriverP2FileNameSuffix.Length);
                case CommentaryType.DriverP3:
                    return fileName.Substring(0, fileName.Length - DriverP3FileNameSuffix.Length);
                case CommentaryType.TeamOut:
                    return fileName.Substring(0, fileName.Length - TeamOutFileNameSuffix.Length);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string ExtractFileNameSuffix(CommentaryType commentaryType)
        {
            switch (commentaryType)
            {
                case CommentaryType.Default:
                    return string.Empty;
                case CommentaryType.DriverInPits:
                    return DriverInPitsFileNameSuffix;
                case CommentaryType.DriverOut:
                    return DriverOutFileNameSuffix;
                case CommentaryType.DriverP1:
                    return DriverP1FileNameSuffix;
                case CommentaryType.DriverP2:
                    return DriverP2FileNameSuffix;
                case CommentaryType.DriverP3:
                    return DriverP3FileNameSuffix;
                case CommentaryType.TeamOut:
                    return TeamOutFileNameSuffix;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string ExtractTranscript(string text)
        {
            var startIndex = IndexOfValueInText(text, WavFileExtension) + 4;
            var length = text.Length - (IndexOfValueInText(text, WavFileExtension) + 4) - 1;
            return text.Substring(startIndex, length).Trim();
        }

        private static string ExtractTranscriptPrefix(string transcript, CommentaryType commentaryType, LanguageType languageType)
        {
            // Local variables used to store language specific suffix text (not prefix text)
            string driverP1Suffix;
            string driverP2Suffix;
            string driverP3Suffix;
            string driverOutSuffix;
            string teamOutSuffix;
            string driverInPitsSuffix;

            switch (languageType)
            {
                case LanguageType.English:
                    driverP1Suffix = EnglishDriverP1Suffix;
                    driverP2Suffix = EnglishDriverP2Suffix;
                    driverP3Suffix = EnglishDriverP3Suffix;
                    driverOutSuffix = EnglishDriverOutSuffix;
                    teamOutSuffix = EnglishTeamOutSuffix;
                    driverInPitsSuffix = EnglishDriverInPitsSuffix;
                    break;
                case LanguageType.French:
                    driverP1Suffix = FrenchDriverP1Suffix;
                    driverP2Suffix = FrenchDriverP2Suffix;
                    driverP3Suffix = FrenchDriverP3Suffix;
                    driverOutSuffix = FrenchDriverOutSuffix;
                    teamOutSuffix = FrenchTeamOutSuffix;
                    driverInPitsSuffix = FrenchDriverInPitsSuffix;
                    break;
                case LanguageType.German:
                    driverP1Suffix = GermanDriverP1Suffix;
                    driverP2Suffix = GermanDriverP2Suffix;
                    driverP3Suffix = GermanDriverP3Suffix;
                    driverOutSuffix = GermanDriverOutSuffix;
                    teamOutSuffix = GermanTeamOutSuffix;
                    driverInPitsSuffix = GermanDriverInPitsSuffix;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (commentaryType)
            {
                case CommentaryType.Default:
                    return string.Empty;
                case CommentaryType.DriverInPits:
                    return transcript.Substring(0, transcript.Length - driverInPitsSuffix.Length - 1);
                case CommentaryType.DriverOut:
                    return transcript.Substring(0, transcript.Length - driverOutSuffix.Length - 1);
                case CommentaryType.DriverP1:
                    return transcript.Substring(0, transcript.Length - driverP1Suffix.Length - 1);
                case CommentaryType.DriverP2:
                    return transcript.Substring(0, transcript.Length - driverP2Suffix.Length - 1);
                case CommentaryType.DriverP3:
                    return transcript.Substring(0, transcript.Length - driverP3Suffix.Length - 1);
                case CommentaryType.TeamOut:
                    return transcript.Substring(0, transcript.Length - teamOutSuffix.Length - 1);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string ExtractTranscriptSuffix(CommentaryType commentaryType, LanguageType languageType)
        {
            // Local variables used to store language specific suffix text
            string driverP1Suffix;
            string driverP2Suffix;
            string driverP3Suffix;
            string driverOutSuffix;
            string teamOutSuffix;
            string driverInPitsSuffix;

            switch (languageType)
            {
                case LanguageType.English:
                    driverP1Suffix = EnglishDriverP1Suffix;
                    driverP2Suffix = EnglishDriverP2Suffix;
                    driverP3Suffix = EnglishDriverP3Suffix;
                    driverOutSuffix = EnglishDriverOutSuffix;
                    teamOutSuffix = EnglishTeamOutSuffix;
                    driverInPitsSuffix = EnglishDriverInPitsSuffix;
                    break;
                case LanguageType.French:
                    driverP1Suffix = FrenchDriverP1Suffix;
                    driverP2Suffix = FrenchDriverP2Suffix;
                    driverP3Suffix = FrenchDriverP3Suffix;
                    driverOutSuffix = FrenchDriverOutSuffix;
                    teamOutSuffix = FrenchTeamOutSuffix;
                    driverInPitsSuffix = FrenchDriverInPitsSuffix;
                    break;
                case LanguageType.German:
                    driverP1Suffix = GermanDriverP1Suffix;
                    driverP2Suffix = GermanDriverP2Suffix;
                    driverP3Suffix = GermanDriverP3Suffix;
                    driverOutSuffix = GermanDriverOutSuffix;
                    teamOutSuffix = GermanTeamOutSuffix;
                    driverInPitsSuffix = GermanDriverInPitsSuffix;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (commentaryType)
            {
                case CommentaryType.Default:
                    return string.Empty;
                case CommentaryType.DriverInPits:
                    return driverInPitsSuffix;
                case CommentaryType.DriverOut:
                    return driverOutSuffix;
                case CommentaryType.DriverP1:
                    return driverP1Suffix;
                case CommentaryType.DriverP2:
                    return driverP2Suffix;
                case CommentaryType.DriverP3:
                    return driverP3Suffix;
                case CommentaryType.TeamOut:
                    return teamOutSuffix;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static int IndexOfValueInText(string text, string value)
        {
            // https://stackoverflow.com/a/15464440
            return Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase);
        }

        private static bool IsValueInText(string text, string value)
        {
            // https://stackoverflow.com/a/15464440
            return Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase) >= 0;
        }

        private static void Validate(string text, int lineNumber, out string validationMessage)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text contains an insufficient number of characters.";
                return;
            }

            if (text.Length < 9) // Must meet minimim expectation of ">x.wav y<"
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text contains an insufficient number of characters.";
                return;
            }

            if (!IsValueInText(text, RightAngleBracket) && !IsValueInText(text, LeftAngleBracket))
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text does not contain angle brackets to start and finish the line.";
                return;
            }

            if (!IsValueInText(text, RightAngleBracket))
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text does not contain a right angle bracket to start the line.";
                return;
            }

            if (!IsValueInText(text, LeftAngleBracket))
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text does not contain a left angle bracket to finish the line.";
                return;
            }

            if (!IsValueInText(text, WavFileExtension))
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text does not contain a wav file extension.";
                return;
            }

            if (text[0].ToString() != RightAngleBracket)
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The first character must be a right angle bracket to start the line.";
                return;
            }

            if (text[text.Length - 1].ToString() != LeftAngleBracket)
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The last character must be a left angle bracket to finish the line.";
                return;
            }

            var commentaryFileName = ExtractFileName(text);
            if (commentaryFileName.Length <= 4)
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The commentary filename contains an insufficient number of characters.";
                return;
            }

            var commentaryTranscript = ExtractTranscript(text);
            if (commentaryTranscript.Length < 1)
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The commentary transcript contains an insufficient number of characters.";
                return;
            }

            validationMessage = string.Empty;
        }
    }
}