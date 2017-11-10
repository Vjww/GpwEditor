using Common.Editor.Infrastructure.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues
{
    public class LanguageCatalogueItem : ICatalogueItem
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}