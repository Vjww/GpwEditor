using System.Collections.Generic;
using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class FrenchCommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>, ICatalogueLanguage
    {
        public FrenchCommentaryCatalogue(
            List<CommentaryCatalogueItem> list,
            // ReSharper disable once SuggestBaseTypeForParameter
            CommentaryCatalogueExporter<FrenchLanguagePhrases> catalogueExporter,
            // ReSharper disable once SuggestBaseTypeForParameter
            CommentaryCatalogueImporter<FrenchLanguagePhrases> catalogueImporter,
            CommentaryCatalogueReader catalogueReader,
            CommentaryCatalogueWriter catalogueWriter)
            : base(list, catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.French;
    }
}