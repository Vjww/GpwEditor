using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Common.Enums;
using Common.FileConnection;
using Data.Entities.Commentary;

namespace Data.FileConnection
{
    public class CommentaryResourceConnection : TextFileConnectionBase
    {
        private const string DriverInPitsSuffix = "in pits.";
        private const string DriverP1Suffix = "P1";
        private const string DriverP2Suffix = "P2";
        private const string DriverP3Suffix = "P3";
        private const string DriverOutSuffix = "out.";
        private const string TeamOutSuffix = "out.";

        private const string DriverInPitsFileNameSuffix = "PIT.WAV";
        private const string DriverP1FileNameSuffix = "P1.WAV";
        private const string DriverP2FileNameSuffix = "P2.WAV";
        private const string DriverP3FileNameSuffix = "P3.WAV";
        private const string DriverOutFileNameSuffix = "OUT.WAV";
        private const string TeamOutFileNameSuffix = "OUT.WAV";

        private const string LeftAngleBracket = "<";
        private const string RightAngleBracket = ">";
        private const string WavFileExtension = ".WAV";

        public CommentaryResourceConnection(string filePath) : base(filePath)
        {
        }

        public Collection<CommentaryResource> Load()
        {
            var lines = ReadLines();

            var collection = new Collection<CommentaryResource>();

            var counter = 0;
            foreach (var line in lines.Select(item => item.Trim()))
            {
                string validationMessage;
                Validate(line, counter + 1, out validationMessage);
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    throw new Exception(validationMessage);
                }

                var fileName = ExtractCommentaryFileName(line);
                var fileNamePrefix = ExtractCommentaryFileNamePrefix(fileName, counter);
                var fileNameSuffix = ExtractCommentaryFileNameSuffix(counter);
                var transcript = ExtractCommentaryTranscript(line);
                var transcriptPrefix = ExtractCommentaryTranscriptPrefix(transcript, counter);
                var transcriptSuffix = ExtractCommentaryTranscriptSuffix(counter);
                collection.Add(new CommentaryResource
                {
                    Id = counter,
                    FileName = fileName,
                    FileNamePrefix = fileNamePrefix,
                    FileNameSuffix = fileNameSuffix,
                    Transcript = transcript,
                    TranscriptPrefix = transcriptPrefix,
                    TranscriptSuffix = transcriptSuffix
                });
                counter++;
            }

            return collection;
        }

        public void Save(Collection<CommentaryResource> collection)
        {
            var lines = new Collection<string>();

            var counter = 0;
            foreach (var item in collection)
            {
                var fileName = ConstructCommentaryFileName(item.FileName, item.FileNamePrefix, item.FileNameSuffix, counter);
                var transcript = ConstructCommentaryTranscript(item.Transcript, item.TranscriptPrefix, item.TranscriptSuffix, counter);
                lines.Add($"{RightAngleBracket}{fileName} {transcript}{LeftAngleBracket}");
                counter++;
            }
            WriteLines(lines);
        }

        protected override string ReadLine()
        {
            if (!IsRead())
            {
                SwitchStreamDirection();
            }

            return base.ReadLine();
        }

        protected override void WriteLine(string line)
        {
            if (!IsWrite())
            {
                SwitchStreamDirection();
            }

            base.WriteLine(line);
        }

        private static string ConstructCommentaryFileName(string fileName, string fileNamePrefix, string fileNameSuffix, int index)
        {
            if (index < 67) return fileName;
            if (index < 108) return $"{fileNamePrefix}{fileNameSuffix}".ToUpperInvariant();
            if (index < 149) return $"{fileNamePrefix}{fileNameSuffix}".ToUpperInvariant();
            if (index < 190) return $"{fileNamePrefix}{fileNameSuffix}".ToUpperInvariant();
            if (index < 231) return $"{fileNamePrefix}{fileNameSuffix}".ToUpperInvariant();
            if (index < 242) return $"{fileNamePrefix}{fileNameSuffix}".ToUpperInvariant();
            if (index < 243) return fileName;
            if (index < 284) return $"{fileNamePrefix}{fileNameSuffix}".ToUpperInvariant();
            return fileName;
        }

        private static string ConstructCommentaryTranscript(string transcript, string transcriptPrefix, string transcriptSuffix, int index)
        {
            if (index < 67) return transcript;
            if (index < 108) return $"{transcriptPrefix} {transcriptSuffix}";
            if (index < 149) return $"{transcriptPrefix} {transcriptSuffix}";
            if (index < 190) return $"{transcriptPrefix} {transcriptSuffix}";
            if (index < 231) return $"{transcriptPrefix} {transcriptSuffix}";
            if (index < 242) return $"{transcriptPrefix} {transcriptSuffix}";
            if (index < 243) return transcript;
            if (index < 284) return $"{transcriptPrefix} {transcriptSuffix}";
            return transcript;
        }

        private static void Validate(string text, int lineNumber, out string validationMessage)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The text contains an insufficient number of characters.";
                return;
            }

            if (text.Length < 9) // Must meet minimim expectation of ">x.wav x<"
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

            var commentaryFileName = ExtractCommentaryFileName(text);
            if (commentaryFileName.Length <= 4)
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The commentary filename contains an insufficient number of characters.";
                return;
            }

            var commentaryTranscript = ExtractCommentaryTranscript(text);
            if (commentaryTranscript.Length < 1)
            {
                validationMessage = $"Unable to validate commentary resource on line number {lineNumber}. The commentary transcript contains an insufficient number of characters.";
                return;
            }

            validationMessage = string.Empty;
        }

        private static string ExtractCommentaryFileName(string text)
        {
            const int startIndex = 1;
            var length = IndexOfValueInText(text, WavFileExtension) + 4 - startIndex;
            return text.Substring(startIndex, length).Trim().ToUpperInvariant();
        }

        private static string ExtractCommentaryFileNamePrefix(string fileName, int index)
        {
            if (index < 67) return string.Empty;
            if (index < 108) return fileName.Substring(0, fileName.Length - DriverP1FileNameSuffix.Length);
            if (index < 149) return fileName.Substring(0, fileName.Length - DriverP2FileNameSuffix.Length);
            if (index < 190) return fileName.Substring(0, fileName.Length - DriverP3FileNameSuffix.Length);
            if (index < 231) return fileName.Substring(0, fileName.Length - DriverOutFileNameSuffix.Length);
            if (index < 242) return fileName.Substring(0, fileName.Length - TeamOutFileNameSuffix.Length);
            if (index < 243) return string.Empty;
            if (index < 284) return fileName.Substring(0, fileName.Length - DriverInPitsFileNameSuffix.Length);
            return string.Empty;
        }

        private static string ExtractCommentaryFileNameSuffix(int index)
        {
            if (index < 67) return string.Empty;
            if (index < 108) return DriverP1FileNameSuffix;
            if (index < 149) return DriverP2FileNameSuffix;
            if (index < 190) return DriverP3FileNameSuffix;
            if (index < 231) return DriverOutFileNameSuffix;
            if (index < 242) return TeamOutFileNameSuffix;
            if (index < 243) return string.Empty;
            if (index < 284) return DriverInPitsFileNameSuffix;
            return string.Empty;
        }

        private static string ExtractCommentaryTranscript(string text)
        {
            var startIndex = IndexOfValueInText(text, WavFileExtension) + 4;
            var length = text.Length - (IndexOfValueInText(text, WavFileExtension) + 4) - 1;
            return text.Substring(startIndex, length).Trim();
        }

        private static string ExtractCommentaryTranscriptPrefix(string transcript, int index)
        {
            if (index < 67) return string.Empty;
            if (index < 108) return transcript.Substring(0, transcript.Length - DriverP1Suffix.Length - 1);
            if (index < 149) return transcript.Substring(0, transcript.Length - DriverP2Suffix.Length - 1);
            if (index < 190) return transcript.Substring(0, transcript.Length - DriverP3Suffix.Length - 1);
            if (index < 231) return transcript.Substring(0, transcript.Length - DriverOutSuffix.Length - 1);
            if (index < 242) return transcript.Substring(0, transcript.Length - TeamOutSuffix.Length - 1);
            if (index < 243) return string.Empty;
            if (index < 284) return transcript.Substring(0, transcript.Length - DriverInPitsSuffix.Length - 1);
            return string.Empty;
        }

        private static string ExtractCommentaryTranscriptSuffix(int index)
        {
            if (index < 67) return string.Empty;
            if (index < 108) return DriverP1Suffix;
            if (index < 149) return DriverP2Suffix;
            if (index < 190) return DriverP3Suffix;
            if (index < 231) return DriverOutSuffix;
            if (index < 242) return TeamOutSuffix;
            if (index < 243) return string.Empty;
            if (index < 284) return DriverInPitsSuffix;
            return string.Empty;
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

        private bool IsRead()
        {
            return StreamDirection == StreamDirectionType.Read;
        }

        private bool IsWrite()
        {
            return StreamDirection == StreamDirectionType.Write;
        }

        private void SwitchStreamDirection()
        {
            // Switch read to write
            if (IsRead())
            {
                Close();
                Open(StreamDirectionType.Write, FileMode.Truncate);
                return;
            }

            // Switch write to read
            if (IsWrite())
            {
                Close();
                Open(StreamDirectionType.Read);
                return;
            }

            throw new Exception("Unable to switch stream direction, as stream direction not defined.");
        }
    }
}