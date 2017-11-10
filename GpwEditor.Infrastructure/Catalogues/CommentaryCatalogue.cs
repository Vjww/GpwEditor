using Common.Editor.Infrastructure.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues
{
    public class CommentaryCatalogue : CatalogueBase<CommentaryCatalogueItem>
    {
        public CommentaryCatalogue(
            ICatalogueExporter<CommentaryCatalogueItem> catalogueExporter,
            ICatalogueImporter<CommentaryCatalogueItem> catalogueImporter,
            ICatalogueReader catalogueReader,
            ICatalogueWriter catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }
    }
}