using System.Collections.Generic;
using Common.Editor.Infrastructure.Catalogues;
using Common.Editor.Infrastructure.FileResources;

namespace GpwEditor.Infrastructure.Catalogues
{
    public class CommentaryCatalogueImporter : ICatalogueImporter<CommentaryCatalogueItem>
    {
        private IFileResource _fileResource;
        private readonly IFileResourceImporter _fileResourceImporter;

        public CommentaryCatalogueImporter(
            IFileResource fileResource,
            IFileResourceImporter fileResourceImporter)
        {
            _fileResource = fileResource;
            _fileResourceImporter = fileResourceImporter;
        }

        public IEnumerable<CommentaryCatalogueItem> Import(string filePath)
        {
            _fileResource = _fileResourceImporter.Import(filePath);

            // TODO: Do import logic here

            return null;
        }
    }
}