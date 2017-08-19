using System.IO;

namespace ConsoleApplication.Services
{
    public interface IMemoryStreamService
    {
        MemoryStream Get();
        void Set(MemoryStream source);
        byte[] Read(long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin);
        void Write(long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin);
        void Write(long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin);
    }
}