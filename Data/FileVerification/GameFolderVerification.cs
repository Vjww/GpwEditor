using System.Collections.ObjectModel;
using System.IO;

namespace Data.FileVerification
{
    public class GameFolderVerification
    {
        public bool IsFolderSupported(string folderPath, out string message)
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
                    message = "The selected game folder has been identified as a valid Grand Prix World installation.";
                    return true;
                }
            }

            // Unidentified
            message = "The selected game folder does not appear to contain the folders expected in a Grand Prix World installation.";
            return false;
        }
    }
}