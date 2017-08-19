using System.IO;

namespace ConsoleApplication.Services
{
    public interface IFileService
    {
        MemoryStream LoadFromFileIntoMemoryStream(string filePath);
        void SaveFromMemoryStreamIntoFile(string filePath, MemoryStream memoryStream);
    }
}