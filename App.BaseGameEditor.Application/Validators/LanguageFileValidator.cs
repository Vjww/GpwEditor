using System;
using System.IO;

namespace App.BaseGameEditor.Application.Validators
{
    public class LanguageFileValidator
    {
        private const long MinimumSupportedFileSize = 260000;
        private const long MaximumSupportedFileSize = 295000;

        public void Validate(string languageFilePath, string resolutionMessage)
        {
            var isValid = IsFileSupported(languageFilePath, out var validationMessage);

            if (isValid) return;

            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{validationMessage}");
        }

        private static bool IsFileSupported(string filePath, out string validationMessage)
        {
            // Attempt to identify by file length
            var fileLength = new FileInfo(filePath).Length;
            if (fileLength >= MinimumSupportedFileSize && fileLength <= MaximumSupportedFileSize)
            {
                validationMessage = "The selected language file has been identified as a supported version.";
                return true;
            }

            // Unidentified
            validationMessage = $"The length {fileLength} of the selected language file is out of range ({MinimumSupportedFileSize}-{MaximumSupportedFileSize} bytes) for a supported version.";
            return false;
        }
    }
}