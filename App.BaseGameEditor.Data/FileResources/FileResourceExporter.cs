using System;
using System.IO;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceExporter
    {
        private readonly FileService _fileService;

        public FileResourceExporter(FileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void Export(Stream stream, string filePath)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            // FileMode.Create is equivalent to requesting that if the file does not exist, use CreateNew; otherwise, use Truncate.
            // https://msdn.microsoft.com/en-us/library/system.io.filemode(v=vs.110).aspx

            using (var fileStream = _fileService.Open(filePath, FileMode.Create, FileAccess.Write))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }
    }
}