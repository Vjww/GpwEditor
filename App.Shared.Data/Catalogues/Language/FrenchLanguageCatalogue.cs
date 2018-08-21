using System.Collections.Generic;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Catalogues.Language
{
    public class FrenchLanguageCatalogue : CatalogueBase<LanguageCatalogueItem>, ICatalogueLanguage
    {
        public FrenchLanguageCatalogue(
            List<LanguageCatalogueItem> list,
            LanguageCatalogueExporter catalogueExporter,
            LanguageCatalogueImporter catalogueImporter,
            LanguageCatalogueReader catalogueReader,
            LanguageCatalogueWriter catalogueWriter)
            : base(list, catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.French;
    }
}