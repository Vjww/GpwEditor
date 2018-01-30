using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.FileResources;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class LanguageCatalogueImporter : ICatalogueImporter<LanguageCatalogueItem>
    {
        private readonly LanguageCatalogueParser _catalogueParser;
        private readonly FileResource _fileResource;

        public LanguageCatalogueImporter(
            LanguageCatalogueParser catalogueParser,
            FileResource fileResource)
        {
            _catalogueParser = catalogueParser ?? throw new ArgumentNullException(nameof(catalogueParser));
            _fileResource = fileResource ?? throw new ArgumentNullException(nameof(fileResource));
        }

        public IEnumerable<LanguageCatalogueItem> Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _fileResource.Import(filePath);

            var list = _fileResource.ReadStringList();
            var enumerable = list as IList<string> ?? list.Cast<string>().ToList();

            var id = 0;
            var catalogue = new List<LanguageCatalogueItem>();
            foreach (var item in enumerable)
            {
                var line = item.Trim();

                var key = _catalogueParser.BuildResourceId(id);

                if (!_catalogueParser.IsValueInText(line, key)) continue;

                var value = line.Split(new[] { '"' }, 3)[1];

                // TODO: Use factory
                var languageCatalogueItem = new LanguageCatalogueItem
                {
                    Id = id,
                    Key = key,
                    Value = value
                };

                catalogue.Add(languageCatalogueItem);

                id++;
            }

            return catalogue;
        }
    }
}