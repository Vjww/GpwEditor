using System;
using System.Collections;
using System.IO;
using App.Shared.Data.Streams;

namespace App.Shared.Data.FileResources
{
    public class FileResourceReader
    {
        private readonly StreamReadService _streamReadService;

        public FileResourceReader(StreamReadService streamReadService)
        {
            _streamReadService = streamReadService ?? throw new ArgumentNullException(nameof(streamReadService));
        }

        public int ReadInteger(Stream stream, int offset)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var bytes = _streamReadService.Read(stream, offset, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        public IEnumerable ReadStringList(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            return _streamReadService.ReadStringList(stream);
        }
    }
}