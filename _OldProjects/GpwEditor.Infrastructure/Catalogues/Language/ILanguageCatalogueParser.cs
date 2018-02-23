namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public interface ILanguageCatalogueParser
    {
        string BuildResourceId(int id);
        bool IsValueInText(string text, string value);
    }
}