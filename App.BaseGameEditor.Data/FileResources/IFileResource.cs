using System.Collections;

namespace App.BaseGameEditor.Data.FileResources
{
    public interface IFileResource
    {
        void Export(string filePath);
        void Import(string filePath);
        int ReadInteger(int offset);
        void WriteInteger(int offset, int value);
        IEnumerable ReadStringList();
        void WriteStringList(IEnumerable list);
    }
}