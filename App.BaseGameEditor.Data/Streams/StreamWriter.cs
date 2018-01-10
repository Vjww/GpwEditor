using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.Streams
{
    public class StreamWriter : IStreamWriter
    {
        private readonly IStreamFactory _streamFactory;

        public StreamWriter(IStreamFactory streamFactory)
        {
            _streamFactory = streamFactory ?? throw new ArgumentNullException(nameof(streamFactory));
        }

        public void Write(Stream stream, long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin)
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

        public void WriteStringList(Stream stream, IEnumerable list)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (list == null) throw new ArgumentNullException(nameof(list));

            var streamCopy = _streamFactory.Create();
            stream.CopyTo(streamCopy);
            stream.Seek(0, SeekOrigin.Begin);

            // TODO: Remove the dependancy on the CLI StreamWriter class
            using (var streamWriter = new System.IO.StreamWriter(streamCopy, Encoding.Default))
            {
                foreach (var item in list)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }
    }
}