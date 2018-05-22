using System;
using System.IO;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceImporter
    {
        private readonly FileService _fileService;
        private readonly IStreamFactory _streamFactory;

        public FileResourceImporter(
            FileService fileService,
            IStreamFactory streamFactory)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
        }

        public Stream Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            var stream = _streamFactory.Create();
            using (var fileStream = _fileService.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public Stream Import(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            var result = _streamFactory.Create();

            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(result);

            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
    }
}