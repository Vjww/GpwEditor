using System;
using System.Collections;
using System.IO;
using App.BaseGameEditor.Data.Streams;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceWriter : IFileResourceWriter
    {
        private readonly IStreamWriter _streamWriter;

        public FileResourceWriter(IStreamWriter streamWriter)
        {
            _streamWriter = streamWriter ?? throw new ArgumentNullException(nameof(streamWriter));
        }

        public void WriteInteger(Stream stream, int offset, int value)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var bytes = BitConverter.GetBytes(value);
            _streamWriter.Write(stream, offset, bytes, SeekOrigin.Begin);
        }

        public void WriteStringList(Stream stream, IEnumerable list)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (list == null) throw new ArgumentNullException(nameof(list));

            _streamWriter.WriteStringList(stream, list);
        }
    }
}