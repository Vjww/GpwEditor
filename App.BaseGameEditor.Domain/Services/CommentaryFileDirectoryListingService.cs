using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App.BaseGameEditor.Domain.Services
{
    public class CommentaryFileDirectoryListingService
    {
        public List<string> GetCommentaryFiles(string gameFolderPath)
        {
            // Select files from folder
            var speecheFolderPath = $@"{gameFolderPath}\SPEECHE";
            var p1WavFiles = Directory.GetFiles(speecheFolderPath, "*P1.WAV");
            var p2WavFiles = Directory.GetFiles(speecheFolderPath, "*P2.WAV");
            var p3WavFiles = Directory.GetFiles(speecheFolderPath, "*P3.WAV");
            var outWavFiles = Directory.GetFiles(speecheFolderPath, "*OUT.WAV");
            var pitWavFiles = Directory.GetFiles(speecheFolderPath, "*PIT.WAV");

            // Add selected files to list, remove invalid selections, and sort
            var fileList = new List<string>();
            fileList.AddRange(BuildFileNames(p1WavFiles));
            fileList.AddRange(BuildFileNames(p2WavFiles));
            fileList.AddRange(BuildFileNames(p3WavFiles));
            fileList.AddRange(BuildFileNames(outWavFiles));
            fileList.AddRange(BuildFileNames(pitWavFiles));
            RemoveInvalidFiles(fileList, new List<string>
            {
                "AUTOPIT.WAV",
                "FLYLAP1.WAV",
                "FLYLAP2.WAV",
                "FLYLAP3.WAV",
                "IMOUT.WAV",
                "WEREOUT.WAV"
            });
            fileList.Sort((x, y) => string.Compare(x, y, StringComparison.Ordinal));
            return fileList;
        }

        private static IEnumerable<string> BuildFileNames(IEnumerable<string> list)
        {
            return list.Select(Path.GetFileName).ToList(); // TODO: Check if this is redundant - convert string list to string list
        }

        private static void RemoveInvalidFiles(IList<string> fileList, IReadOnlyList<string> invalidFileList)
        {
            for (var i = 0; i < fileList.Count; i++)
            {
                var file = fileList[i];
                for (var j = 0; j < invalidFileList.Count; j++)
                {
                    var invalidFile = invalidFileList[j];
                    if (file.Equals(invalidFile, StringComparison.OrdinalIgnoreCase))
                    {
                        fileList.Remove(file);
                    }
                }
            }
        }
    }
}