using System.IO;

namespace ConsoleApplication.Services
{
    public interface IStreamService<T> where T : Stream
    {
        #region Disabled Get Method
        //T Get();
        #endregion
        #region Disabled Set Method
        //void Set(T source);
        #endregion
        void LoadFromFile(string filePath);
        void SaveToFile(string filePath);
        byte[] Read(long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin);
        void Write(long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin);
        void Write(long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin);
    }
}