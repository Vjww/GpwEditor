using Common.Editor.Data.Catalogues;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class LanguageCatalogue : CatalogueBase<LanguageCatalogueItem>
    {
        public LanguageType LanguageType { get; set; }

        public LanguageCatalogue(
            ICatalogueExporter<LanguageCatalogueItem> catalogueExporter,
            ICatalogueImporter<LanguageCatalogueItem> catalogueImporter,
            ICatalogueReader catalogueReader,
            ICatalogueWriter catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }
    }
}