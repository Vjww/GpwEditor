using System;
using System.Collections;
using System.IO;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResource : IFileResource
    {
        private Stream _stream;

        private readonly IFileResourceExporter _fileResourceExporter;
        private readonly IFileResourceImporter _fileResourceImporter;
        private readonly IFileResourceReader _fileResourceReader;
        private readonly IFileResourceWriter _fileResourceWriter;

        public FileResource(
            IFileResourceExporter fileResourceExporter,
            IFileResourceImporter fileResourceImporter,
            IFileResourceReader fileResourceReader,
            IFileResourceWriter fileResourceWriter,
            IStreamFactory streamFactory)
        {
            _fileResourceExporter = fileResourceExporter ?? throw new ArgumentNullException(nameof(fileResourceExporter));
            _fileResourceImporter = fileResourceImporter ?? throw new ArgumentNullException(nameof(fileResourceImporter));
            _fileResourceReader = fileResourceReader ?? throw new ArgumentNullException(nameof(fileResourceReader));
            _fileResourceWriter = fileResourceWriter ?? throw new ArgumentNullException(nameof(fileResourceWriter));
            if (streamFactory == null) throw new ArgumentNullException(nameof(streamFactory));
            _stream = streamFactory.Create();
        }

        public void Export(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _fileResourceExporter.Export(_stream, filePath);
        }

        public void Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _stream = _fileResourceImporter.Import(filePath);
        }

        public int ReadInteger(int offset)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            return _fileResourceReader.ReadInteger(_stream, offset);
        }

        public void WriteInteger(int offset, int value)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            _fileResourceWriter.WriteInteger(_stream, offset, value);
        }

        public IEnumerable ReadStringList()
        {
            return _fileResourceReader.ReadStringList(_stream);
        }

        public void WriteStringList(IEnumerable list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            _fileResourceWriter.WriteStringList(_stream, list);
        }
    }
}