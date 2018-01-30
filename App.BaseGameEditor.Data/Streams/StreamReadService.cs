using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Data.Streams
{
    public class StreamReadService
    {
        private readonly IStreamFactory _streamFactory;
        private readonly StreamReaderService _streamReaderService;

        public StreamReadService(
            IStreamFactory streamFactory,
            StreamReaderService streamReaderService)
        {
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
            _streamReaderService = streamReaderService ?? throw new ArgumentNullException(nameof(streamReaderService));
        }

        public byte[] Read(Stream stream, long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            var buffer = new byte[count];
            stream.Seek(offset, seekOrigin);
            stream.Read(buffer, 0, count);
            return buffer;
        }

        public IEnumerable ReadStringList(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            var result = new List<string>();

            var streamCopy = _streamFactory.Create();
            stream.CopyTo(streamCopy);
            streamCopy.Seek(0, SeekOrigin.Begin);

            using (var streamReader = _streamReaderService.Reader(streamCopy, Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}