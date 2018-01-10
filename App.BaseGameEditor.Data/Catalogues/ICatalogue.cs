namespace App.BaseGameEditor.Data.Catalogues
{
    public interface ICatalogue
    {
        void Export(string filePath);
        void Import(string filePath);
        string Read(int id);
        void Write(int id, string value);
    }
}