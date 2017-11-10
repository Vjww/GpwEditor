using System.Collections.Generic;
using Common.Editor.Infrastructure.Catalogues;
using Common.Editor.Infrastructure.FileResources;

namespace GpwEditor.Infrastructure.Catalogues
{
    public class LanguageCatalogueExporter : ICatalogueExporter<LanguageCatalogueItem>
    {
        private IFileResource _fileResource;
        private readonly IFileResourceExporter _fileResourceExporter;

        public LanguageCatalogueExporter(
            IFileResource fileResource,
            IFileResourceExporter fileResourceExporter)
        {
            _fileResource = fileResource;
            _fileResourceExporter = fileResourceExporter;
        }

        public void Export(IEnumerable<LanguageCatalogueItem> catalogue, string filePath)
        {
            // TODO: Do export logic here

            _fileResourceExporter.Export(_fileResource, filePath);
        }
    }
}