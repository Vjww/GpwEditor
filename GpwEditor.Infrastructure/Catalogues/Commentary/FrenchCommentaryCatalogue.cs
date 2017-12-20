using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public class FrenchCommentaryCatalogue : Catalogue<CommentaryCatalogueItem>, ICommentaryCatalogue
    {
        public FrenchCommentaryCatalogue(
            ICatalogueExporter<CommentaryCatalogueItem> catalogueExporter,
            ICatalogueImporter<CommentaryCatalogueItem> catalogueImporter,
            ICatalogueReader<CommentaryCatalogueItem> catalogueReader,
            ICatalogueWriter<CommentaryCatalogueItem> catalogueWriter)
            : base(catalogueExporter, catalogueImporter, catalogueReader, catalogueWriter)
        {
        }

        public LanguageEnum Language { get; } = LanguageEnum.French;
    }
}