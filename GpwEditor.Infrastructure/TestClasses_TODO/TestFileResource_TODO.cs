using System;
using System.IO;
using Common.Editor.Infrastructure.FileResources;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestFileResource : IFileResource<MemoryStream>
    {
        private readonly MemoryStream _stream;
        readonly IFileResourceExporter<MemoryStream> _exporter;
        readonly IFileResourceImporter<MemoryStream> _importer;

        public TestFileResource(
            MemoryStream stream,
            IFileResourceExporter<MemoryStream> exporter,
            IFileResourceImporter<MemoryStream> importer)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
            _importer = importer ?? throw new ArgumentNullException(nameof(importer));
        }

        public void Import(string filePath)
        {
            _importer.Import(filePath);
        }

        public void Export(string filePath)
        {
            _exporter.Export(_stream, filePath);
        }

        public byte[] Read(MemoryStream stream, long offset, int count, SeekOrigin seekOrigin)
        {
            return _reader.Read(offset, count, seekOrigin);
        }

        public void Write(MemoryStream stream, long offset, byte value, SeekOrigin seekOrigin)
        {
            _writer.Write(offset, value, seekOrigin);
        }

        public void Write(MemoryStream stream, long offset, byte[] values, SeekOrigin seekOrigin)
        {
            _writer.Write(offset, values, seekOrigin);
        }
    }
}