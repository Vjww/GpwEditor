using System.IO;

namespace App.BaseGameEditor.Data.FileResources
{
    public interface IFileResourceExporter
    {
        void Export(Stream stream, string filePath);
    }
}