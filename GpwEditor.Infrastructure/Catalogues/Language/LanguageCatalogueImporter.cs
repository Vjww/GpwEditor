using System;
using System.Collections.Generic;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.FileResources;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class LanguageCatalogueImporter : ICatalogueImporter<LanguageCatalogueItem>
    {
        private readonly IFileResource _fileResource;

        public LanguageCatalogueImporter(IFileResource fileResource)
        {
            _fileResource = fileResource ?? throw new ArgumentNullException(nameof(fileResource));
        }

        public IEnumerable<LanguageCatalogueItem> Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _fileResource.Import(filePath);

            // TODO: Do import transformation logic here
            throw new NotImplementedException();

            return null;
        }
    }
}