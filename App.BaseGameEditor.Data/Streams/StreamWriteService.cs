using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.Streams
{
    public class StreamWriteService
    {
        private readonly IStreamFactory _streamFactory;

        public StreamWriteService(IStreamFactory streamFactory)
        {
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
        }

        public void Write(Stream stream, long offset, byte value, SeekOrigin seekOrigin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            Write(stream, offset, new[] { value }, seekOrigin);
        }

        public void Write(Stream stream, long offset, byte[] values, SeekOrigin seekOrigin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(values));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            stream.Seek(offset, seekOrigin);
            stream.Write(values, 0, values.Length);
        }

        public void WriteStringList(Stream stream, IEnumerable items)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (items == null) throw new ArgumentNullException(nameof(items));

            var streamCopy = _streamFactory.Create();
            stream.CopyTo(streamCopy);
            stream.Seek(0, SeekOrigin.Begin);

            // TODO: Remove the dependancy on the CLI StreamWriter class
            using (var streamWriter = new StreamWriter(streamCopy, Encoding.Default))
            {
                foreach (var item in items)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }
    }
}