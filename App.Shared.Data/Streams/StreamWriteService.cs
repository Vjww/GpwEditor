using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using App.Shared.Data.Factories;
using App.Shared.Data.Services;

namespace App.Shared.Data.Streams
{
    public class StreamWriteService
    {
        private readonly IStreamFactory _streamFactory;
        private readonly StreamWriterService _streamWriterService;

        public StreamWriteService(
            IStreamFactory streamFactory,
            StreamWriterService streamWriterService)
        {
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
            _streamWriterService = streamWriterService ?? throw new ArgumentNullException(nameof(streamWriterService));
        }

        public void Write(Stream stream, long offset, byte value, SeekOrigin seekOrigin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            Write(stream, offset, new[] { value }, seekOrigin);
        }

        public void Write(Stream stream, long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(values));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            stream.Seek(offset, seekOrigin);
            stream.Write(values, 0, values.Length);
        }

        public void WriteStringList(Stream stream, IEnumerable items, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            var alternateStream = _streamFactory.Create();
            using (var streamWriter = _streamWriterService.Writer(alternateStream, Encoding.Default))
            {
                foreach (var item in items)
                {
                    streamWriter.WriteLine(item);
                }
                streamWriter.Flush();

                stream.Seek(0, seekOrigin);
                alternateStream.Seek(0, SeekOrigin.Begin);
                alternateStream.CopyTo(stream);
            }
        }
    }
}