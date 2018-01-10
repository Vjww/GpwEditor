using System.Collections;
using System.IO;

namespace App.BaseGameEditor.Data.FileResources
{
    public interface IFileResourceReader
    {
        int ReadInteger(Stream stream, int offset);
        IEnumerable ReadStringList(Stream stream);
    }
}