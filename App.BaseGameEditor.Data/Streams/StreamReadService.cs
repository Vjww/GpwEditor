using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.Streams
{
    public class StreamReadService
    {
        private readonly IStreamFactory _streamFactory;

        public StreamReadService(IStreamFactory streamFactory)
        {
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
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

            var list = new List<string>();

            var streamCopy = _streamFactory.Create();
            stream.CopyTo(streamCopy);
            streamCopy.Seek(0, SeekOrigin.Begin);

            // TODO: Remove the dependancy on the CLI StreamReader class
            using (var streamReader = new StreamReader(streamCopy, Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return list;
        }
    }
}