using System.IO;

namespace Data.FileVerification
{
    public class LanguageFileVerification
    {
        private const long MinimumSupportedFileSize = 260000;
        private const long MaximumSupportedFileSize = 295000;

        public bool IsFileSupported(string filePath, out string message)
        {
            // Attempt to identify by file length
            var fileLength = new FileInfo(filePath).Length;
            if (fileLength >= MinimumSupportedFileSize && fileLength <= MaximumSupportedFileSize)
            {
                message = "The selected language file has been identified as a supported version.";
                return true;
            }

            // Unidentified
            message = $"The length {fileLength} of the selected language file is out of range ({MinimumSupportedFileSize}-{MaximumSupportedFileSize} bytes) for a supported version.";
            return false;
        }
    }
}