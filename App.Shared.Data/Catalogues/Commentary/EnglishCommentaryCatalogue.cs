using System.Collections.Generic;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Catalogues.Commentary
{
    public class EnglishCommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>, ICatalogueLanguage
    {
        public EnglishCommentaryCatalogue(
            List<CommentaryCatalogueItem> list,
            // ReSharper disable once SuggestBaseTypeForParameter
            CommentaryCatalogueExporter<EnglishLanguagePhrases> catalogueExporter,
            // ReSharper disable once SuggestBaseTypeForParameter
            CommentaryCatalogueImporter<EnglishLanguagePhrases> catalogueImporter,
            CommentaryCatalogueReader catalogueReader,
            CommentaryCatalogueWriter catalogueWriter)
            : base(list, catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.English;
    }
}