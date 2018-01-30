using System;
using System.IO;
using System.Text;

namespace App.BaseGameEditor.Data.Services
{
    public class StreamReaderService
    {
        public StreamReader Reader(Stream stream, Encoding encoding)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            return new StreamReader(stream, encoding);
        }
    }
}