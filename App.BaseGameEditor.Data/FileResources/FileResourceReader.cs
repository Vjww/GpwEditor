using System;
using System.Collections;
using System.IO;
using App.BaseGameEditor.Data.Streams;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceReader : IFileResourceReader
    {
        private readonly IStreamReader _streamReader;

        public FileResourceReader(IStreamReader streamReader)
        {
            _streamReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
        }

        public int ReadInteger(Stream stream, int offset)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var bytes = _streamReader.Read(stream, offset, 4, SeekOrigin.Begin);
            return BitConverter.ToInt32(bytes, 0);
        }

        public IEnumerable ReadStringList(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            return _streamReader.ReadStringList(stream);
        }
    }
}