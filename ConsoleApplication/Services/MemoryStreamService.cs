using System;
using System.IO;

namespace ConsoleApplication.Services
{
    public class MemoryStreamService : IMemoryStreamService
    {
        private readonly MemoryStream _memoryStream;

        public MemoryStreamService()
        {
            _memoryStream = new MemoryStream();
        }

        public MemoryStream Get()
        {
            var memoryStream = new MemoryStream();
            _memoryStream.Seek(0, SeekOrigin.Begin);
            _memoryStream.CopyTo(memoryStream);
            return memoryStream;
        }

        public void Set(MemoryStream source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            source.Seek(0, SeekOrigin.Begin);
            source.CopyTo(_memoryStream);
        }

        public byte[] Read(long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (!Enum.IsDefined(typeof (SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            var buffer = new byte[count];
            _memoryStream.Seek(offset, seekOrigin);
            _memoryStream.Read(buffer, 0, count);
            return buffer;
        }

        public void Write(long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            Write(offset, new [] { value }, seekOrigin);
        }

        public void Write(long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (!Enum.IsDefined(typeof (SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            _memoryStream.Seek(offset, seekOrigin);
            _memoryStream.Write(values, 0, values.Length);
        }
    }
}