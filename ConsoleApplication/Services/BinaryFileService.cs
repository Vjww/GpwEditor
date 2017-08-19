using System.IO;

namespace ConsoleApplication.Services
{
    public class BinaryFileService : IFileService
    {
        public MemoryStream LoadFromFileIntoMemoryStream(string filePath)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                using (var binaryReader = new BinaryReader(fileStream))
                {
                    var memoryStream = new MemoryStream();
                    binaryReader.BaseStream.CopyTo(memoryStream);
                    return memoryStream;
                }
            }
        }

        public void SaveFromMemoryStreamIntoFile(string filePath, MemoryStream memoryStream)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                using (var binaryWriter = new BinaryWriter(fileStream))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(binaryWriter.BaseStream);
                }
            }
        }
    }
}