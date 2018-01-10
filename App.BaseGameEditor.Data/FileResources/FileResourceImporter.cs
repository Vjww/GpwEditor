using System;
using System.IO;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceImporter : IFileResourceImporter
    {
        private readonly IFile _fileResourceService;
        private readonly IStreamFactory _streamFactory;

        public FileResourceImporter(
            IFile fileResourceService,
            IStreamFactory streamFactory)
        {
            _fileResourceService = fileResourceService ?? throw new ArgumentNullException(nameof(fileResourceService));
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
        }

        public Stream Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            var stream = _streamFactory.Create();
            using (var fileStream = _fileResourceService.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}