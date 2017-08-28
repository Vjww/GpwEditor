using System;
using System.IO;

namespace ConsoleApplication.Services
{
    public class StreamService<T> : IStreamService<T> where T : Stream, new()
    {
        private readonly T _stream;

        public StreamService(T stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            _stream = stream;
        }

        #region Disabled Get Method
        //public T Get()
        //{
        //    var stream = new T();
        //    _stream.Seek(0, SeekOrigin.Begin);
        //    _stream.CopyTo(stream);
        //    return stream;
        //}
        #endregion

        #region Disabled Set Method
        //public void Set(T source)
        //{
        //    if (source == null) throw new ArgumentNullException(nameof(source));
        //    source.Seek(0, SeekOrigin.Begin);
        //    source.CopyTo(_stream);
        //}
        #endregion

        public void LoadFromFile(string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(_stream);
            }
        }

        public void SaveToFile(string filePath)
        {
            using (var fileStream = File.OpenWrite(filePath))
            {
                _stream.Seek(0, SeekOrigin.Begin);
                _stream.CopyTo(fileStream);
            }
        }

        public byte[] Read(long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            var buffer = new byte[count];
            _stream.Seek(offset, seekOrigin);
            _stream.Read(buffer, 0, count);
            return buffer;
        }

        public void Write(long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            Write(offset, new[] { value }, seekOrigin);
        }

        public void Write(long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            _stream.Seek(offset, seekOrigin);
            _stream.Write(values, 0, values.Length);
        }
    }
}