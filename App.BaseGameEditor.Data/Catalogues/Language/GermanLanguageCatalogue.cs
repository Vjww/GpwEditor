using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class GermanLanguageCatalogue : CatalogueBase<LanguageCatalogueItem>, ILanguageCatalogue
    {
        public GermanLanguageCatalogue(
            ICatalogueExporter<LanguageCatalogueItem> catalogueExporter,
            ICatalogueImporter<LanguageCatalogueItem> catalogueImporter,
            ICatalogueReader<LanguageCatalogueItem> catalogueReader,
            ICatalogueWriter<LanguageCatalogueItem> catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.German;
    }
}