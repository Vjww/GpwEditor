using Common.Editor.Infrastructure.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues
{
    public class LanguageCatalogue : CatalogueBase<LanguageCatalogueItem>
    {
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