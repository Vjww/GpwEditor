using System;
using System.IO;
using System.Text;

namespace App.Shared.Data.Services
{
    public class StreamWriterService
    {
        public StreamWriter Writer(Stream stream, Encoding encoding)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            return new StreamWriter(stream, encoding);
        }
    }
}