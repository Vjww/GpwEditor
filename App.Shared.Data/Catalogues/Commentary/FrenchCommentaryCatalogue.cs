using App.Shared.Data.Enums;
using Common.Editor.Data.Catalogues;

namespace App.Shared.Data.Catalogues.Commentary
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