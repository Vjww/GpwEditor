using System;
using System.IO;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceExporter : IFileResourceExporter
    {
        private readonly IFile _fileResourceService;

        public FileResourceExporter(IFile fileResourceService)
        {
            _fileResourceService = fileResourceService ?? throw new ArgumentNullException(nameof(fileResourceService));
        }

        public void Export(Stream stream, string filePath)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            using (var fileStream = _fileResourceService.Open(filePath, FileMode.Truncate, FileAccess.Write))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }
    }
}