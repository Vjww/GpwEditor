using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class FrenchLanguageCatalogue : Catalogue<LanguageCatalogueItem>, ILanguageCatalogue
    {
        public FrenchLanguageCatalogue(
            ICatalogueExporter<LanguageCatalogueItem> catalogueExporter,
            ICatalogueImporter<LanguageCatalogueItem> catalogueImporter,
            ICatalogueReader<LanguageCatalogueItem> catalogueReader,
            ICatalogueWriter<LanguageCatalogueItem> catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageEnum Language { get; } = LanguageEnum.French;
    }
}