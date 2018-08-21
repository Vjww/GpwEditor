using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using App.Shared.Data.Factories;
using App.Shared.Data.Services;

namespace App.Shared.Data.Streams
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
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            var result = new byte[count];
            stream.Seek(offset, seekOrigin);
            stream.Read(result, 0, count);
            return result;
        }

        public IEnumerable ReadStringList(Stream stream, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            var result = new List<string>();

            var alternateStream = _streamFactory.Create();
            stream.Seek(0, seekOrigin);
            stream.CopyTo(alternateStream);
            alternateStream.Seek(0, SeekOrigin.Begin);

            using (var streamReader = _streamReaderService.Reader(alternateStream, Encoding.Default))
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