using System.Collections.Generic;
using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class GermanLanguageCatalogue : CatalogueBase<LanguageCatalogueItem>, ICatalogueLanguage
    {
        public GermanLanguageCatalogue(
            List<LanguageCatalogueItem> list,
            LanguageCatalogueExporter catalogueExporter,
            LanguageCatalogueImporter catalogueImporter,
            LanguageCatalogueReader catalogueReader,
            LanguageCatalogueWriter catalogueWriter)
            : base(list, catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.German;
    }
}