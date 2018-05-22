using System;
using System.Collections;
using System.IO;
using App.BaseGameEditor.Data.Streams;

namespace App.BaseGameEditor.Data.FileResources
{
    public class FileResourceWriter
    {
        private readonly StreamWriteService _streamWriteService;

        public FileResourceWriter(StreamWriteService streamWriteService)
        {
            _streamWriteService = streamWriteService ?? throw new ArgumentNullException(nameof(streamWriteService));
        }

        public void WriteInteger(Stream stream, int offset, int value)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var bytes = BitConverter.GetBytes(value);
            _streamWriteService.Write(stream, offset, bytes);
        }

        public void WriteStringList(Stream stream, IEnumerable list)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (list == null) throw new ArgumentNullException(nameof(list));

            _streamWriteService.WriteStringList(stream, list);
        }
    }
}