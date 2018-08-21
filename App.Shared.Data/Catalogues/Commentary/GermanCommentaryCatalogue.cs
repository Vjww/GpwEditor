using System.Collections.Generic;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Catalogues.Commentary
{
    public class GermanCommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>, ICatalogueLanguage
    {
        public GermanCommentaryCatalogue(
            List<CommentaryCatalogueItem> list,
            // ReSharper disable once SuggestBaseTypeForParameter
            CommentaryCatalogueExporter<GermanLanguagePhrases> catalogueExporter,
            // ReSharper disable once SuggestBaseTypeForParameter
            CommentaryCatalogueImporter<GermanLanguagePhrases> catalogueImporter,
            CommentaryCatalogueReader catalogueReader,
            CommentaryCatalogueWriter catalogueWriter)
            : base(list, catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.German;
    }
}