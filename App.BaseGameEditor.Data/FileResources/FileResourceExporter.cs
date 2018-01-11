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

            using (var fileStream = _fileService.Open(filePath, FileMode.Truncate, FileAccess.Write))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }
    }
}