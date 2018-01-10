using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class EnglishCommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>, ICommentaryCatalogue
    {
        public EnglishCommentaryCatalogue(
            ICatalogueExporter<CommentaryCatalogueItem> catalogueExporter,
            ICatalogueImporter<CommentaryCatalogueItem> catalogueImporter,
            ICatalogueReader<CommentaryCatalogueItem> catalogueReader,
            ICatalogueWriter<CommentaryCatalogueItem> catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.English;
    }
}