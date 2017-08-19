using System.IO;

namespace ConsoleApplication.Services
{
    public class TextFileService : IFileService
    {
        public MemoryStream LoadFromFileIntoMemoryStream(string filePath)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream)) // TODO: Add parameters for Encoding, BOM
                {
                    var memoryStream = new MemoryStream();
                    streamReader.BaseStream.CopyTo(memoryStream);
                    return memoryStream;
                }
            }
        }

        public void SaveFromMemoryStreamIntoFile(string filePath, MemoryStream memoryStream)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                using (var streamWriter = new StreamWriter(fileStream)) // TODO: Add parameters for Encoding, BOM
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(streamWriter.BaseStream);
                }
            }
        }
    }
}