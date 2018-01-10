using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class FrenchCommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>, ICommentaryCatalogue
    {
        public FrenchCommentaryCatalogue(
            ICatalogueExporter<CommentaryCatalogueItem> catalogueExporter,
            ICatalogueImporter<CommentaryCatalogueItem> catalogueImporter,
            ICatalogueReader<CommentaryCatalogueItem> catalogueReader,
            ICatalogueWriter<CommentaryCatalogueItem> catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageType Language { get; } = LanguageType.French;
    }
}