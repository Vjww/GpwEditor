using Data.Enums;

namespace Data.FileConnection
{
    public interface IFileConnection
    {
        void Open(string filePath, StreamDirectionType streamDirection);
        void Close();
    }
}
