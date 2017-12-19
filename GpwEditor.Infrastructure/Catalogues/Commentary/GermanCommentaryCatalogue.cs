using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public class GermanCommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>
    {
        public GermanCommentaryCatalogue(
            ICatalogueExporter<CommentaryCatalogueItem> catalogueExporter,
            ICatalogueImporter<CommentaryCatalogueItem> catalogueImporter,
            ICatalogueReader catalogueReader,
            ICatalogueWriter catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }
    }
}