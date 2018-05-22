using System;
using System.Collections.ObjectModel;
using System.IO;

namespace App.BaseGameEditor.Application.Validators
{
    public class GameFolderValidator
    {
        public void Validate(string gameFolderPath, string resolutionMessage)
        {
            var isValid = IsFolderSupported(gameFolderPath, out var validationMessage);

            if (isValid) return;

            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{validationMessage}");
        }

        private static bool IsFolderSupported(string folderPath, out string validationMessage)
        {
            var internalGameFolders = new Collection<string>
            {
                "bmp",
                "car",
                "edy",
                "speeche",
                "text",
                "textbl",
                "tga",
                "track",
                "wav",
                "wavst",
                "wheel",
                "xdata"
            };

            // Attempt to identify by folder contents
            if (Directory.Exists(folderPath))
            {
                var isSupported = true;
                foreach (var internalGameFolder in internalGameFolders)
                {
                    var folderExists = Directory.Exists(Path.Combine(folderPath, internalGameFolder));
                    if (!folderExists)
                    {
                        isSupported = false;
                        break;
                    }
                }

                if (isSupported)
                {
                    validationMessage = "The selected game folder has been identified as a valid Grand Prix World installation.";
                    return true;
                }
            }

            // Unidentified
            validationMessage = "The selected game folder does not appear to contain the folders expected in a Grand Prix World installation.";
            return false;
        }
    }
}