using System.IO;

namespace App.BaseGameEditor.Data.FileResources
{
    public interface IFileResourceImporter
    {
        Stream Import(string filePath);
    }
}