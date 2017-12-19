using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class LanguageCatalogueItem : ICatalogueItem
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}