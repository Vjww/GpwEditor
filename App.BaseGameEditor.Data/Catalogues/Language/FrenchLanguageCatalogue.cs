using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class FrenchLanguageCatalogue : CatalogueBase<LanguageCatalogueItem>, ILanguageCatalogue
    {
        public FrenchLanguageCatalogue(
            ICatalogueExporter<LanguageCatalogueItem> catalogueExporter,
            ICatalogueImporter<LanguageCatalogueItem> catalogueImporter,
            ICatalogueReader<LanguageCatalogueItem> catalogueReader,
            ICatalogueWriter<LanguageCatalogueItem> catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.French;
    }
}