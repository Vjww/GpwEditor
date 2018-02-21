using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueParser<TLanguagePhrases>
        where TLanguagePhrases : class, ILanguagePhrases
    {
        // TODO: remove?
        //private const int FirstLineId = 1;
        //private const int LastLineId = 357;

        private const string DriverInPitsFileNameSuffix = "PIT.WAV";
        private const string DriverP1FileNameSuffix = "P1.WAV";
        private const string DriverP2FileNameSuffix = "P2.WAV";
        private const string DriverP3FileNameSuffix = "P3.WAV";
        private const string DriverOutFileNameSuffix = "OUT.WAV";
        private const string TeamOutFileNameSuffix = "OUT.WAV";

        private const string LeftAngleBracket = "<";
        private const string RightAngleBracket = ">";
        private const string WavFileExtension = ".WAV";

        private readonly TLanguagePhrases _languagePhrases;

        public CommentaryCatalogueParser(TLanguagePhrases languagePhrases)
        {
            _languagePhrases = languagePhrases ?? throw new ArgumentNullException(nameof(languagePhrases));
        }
        
        public string BuildFileName(CommentaryCatalogueItem catalogueItem)
        {
            if (catalogueItem == null) throw new ArgumentNullException(nameof(catalogueItem));

            return catalogueItem.CommentaryType == CommentaryType.Default
                ? catalogueItem.FileName
                : $"{catalogueItem.FileNamePrefix}{catalogueItem.FileNameSuffix}".ToUpperInvariant();
        }

        public string BuildTranscript(CommentaryCatalogueItem catalogueItem)
        {
            if (catalogueItem == null) throw new ArgumentNullException(nameof(catalogueItem));

            return catalogueItem.CommentaryType == CommentaryType.Default
                ? catalogueItem.Transcript
                : $"{catalogueItem.TranscriptPrefix} {catalogueItem.TranscriptSuffix}";
        }

        public string ExtractFileName(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            const int startIndex = 1;
            var length = IndexOfValueInText(text, WavFileExtension) + 4 - startIndex;
            return text.Substring(startIndex, length).Trim().ToUpperInvariant();
        }

        public string ExtractFileNamePrefix(string fileName, CommentaryType commentaryType)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (!Enum.IsDefined(typeof(CommentaryType), commentaryType))
                throw new InvalidEnumArgumentException(nameof(commentaryType), (int)commentaryType, typeof(CommentaryType));

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
                    throw new ArgumentOutOfRangeException(nameof(commentaryType));
            }
        }

        public string ExtractFileNameSuffix(CommentaryType commentaryType)
        {
            if (!Enum.IsDefined(typeof(CommentaryType), commentaryType))
                throw new InvalidEnumArgumentException(nameof(commentaryType), (int)commentaryType, typeof(CommentaryType));

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
                    throw new ArgumentOutOfRangeException(nameof(commentaryType));
            }
        }

        public string ExtractTranscript(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            var startIndex = IndexOfValueInText(text, WavFileExtension) + 4;
            var length = text.Length - (IndexOfValueInText(text, WavFileExtension) + 4) - 1;
            return text.Substring(startIndex, length).Trim();
        }

        public string ExtractTranscriptPrefix(string transcript, CommentaryType commentaryType)
        {
            if (transcript == null) throw new ArgumentNullException(nameof(transcript));
            if (!Enum.IsDefined(typeof(CommentaryType), commentaryType))
                throw new InvalidEnumArgumentException(nameof(commentaryType), (int)commentaryType, typeof(CommentaryType));

            switch (commentaryType)
            {
                case CommentaryType.Default:
                    return string.Empty;
                case CommentaryType.DriverInPits:
                    return transcript.Substring(0, transcript.Length - _languagePhrases.DriverInPitsSuffix.Length - 1);
                case CommentaryType.DriverOut:
                    return transcript.Substring(0, transcript.Length - _languagePhrases.DriverOutSuffix.Length - 1);
                case CommentaryType.DriverP1:
                    return transcript.Substring(0, transcript.Length - _languagePhrases.DriverP1Suffix.Length - 1);
                case CommentaryType.DriverP2:
                    return transcript.Substring(0, transcript.Length - _languagePhrases.DriverP2Suffix.Length - 1);
                case CommentaryType.DriverP3:
                    return transcript.Substring(0, transcript.Length - _languagePhrases.DriverP3Suffix.Length - 1);
                case CommentaryType.TeamOut:
                    return transcript.Substring(0, transcript.Length - _languagePhrases.TeamOutSuffix.Length - 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(commentaryType));
            }
        }

        public string ExtractTranscriptSuffix(CommentaryType commentaryType)
        {
            if (!Enum.IsDefined(typeof(CommentaryType), commentaryType))
                throw new InvalidEnumArgumentException(nameof(commentaryType), (int)commentaryType, typeof(CommentaryType));

            switch (commentaryType)
            {
                case CommentaryType.Default:
                    return string.Empty;
                case CommentaryType.DriverInPits:
                    return _languagePhrases.DriverInPitsSuffix;
                case CommentaryType.DriverOut:
                    return _languagePhrases.DriverOutSuffix;
                case CommentaryType.DriverP1:
                    return _languagePhrases.DriverP1Suffix;
                case CommentaryType.DriverP2:
                    return _languagePhrases.DriverP2Suffix;
                case CommentaryType.DriverP3:
                    return _languagePhrases.DriverP3Suffix;
                case CommentaryType.TeamOut:
                    return _languagePhrases.TeamOutSuffix;
                default:
                    throw new ArgumentOutOfRangeException(nameof(commentaryType));
            }
        }

        public CommentaryType GetCommentaryType(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

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

        public string GetLeftAngleBracket()
        {
            return LeftAngleBracket;
        }

        public string GetRightAngleBracket()
        {
            return RightAngleBracket;
        }

        public int IndexOfValueInText(string text, string value)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (value == null) throw new ArgumentNullException(nameof(value));

            // https://stackoverflow.com/a/15464440
            return Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase);
        }

        // TODO: Violates DRY, as repeated in LanguageCatalogueParser
        public bool IsValueInText(string text, string value)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (value == null) throw new ArgumentNullException(nameof(value));

            // https://stackoverflow.com/a/15464440
            return Thread.CurrentThread.CurrentCulture.CompareInfo.IndexOf(text, value, CompareOptions.IgnoreCase) >= 0;
        }

        public void Validate(string text, int lineNumber, out string validationMessage)
        {
            if (lineNumber <= 0) throw new ArgumentOutOfRangeException(nameof(lineNumber));

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