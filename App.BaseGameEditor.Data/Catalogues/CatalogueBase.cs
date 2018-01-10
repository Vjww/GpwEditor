using System;
using System.Collections.Generic;

namespace App.BaseGameEditor.Data.Catalogues
{
    public class CatalogueBase<TCatalogueItem> : List<TCatalogueItem>, ICatalogue
        where TCatalogueItem : class, ICatalogueItem
    {
        private readonly ICatalogueExporter<TCatalogueItem> _catalogueExporter;
        private readonly ICatalogueImporter<TCatalogueItem> _catalogueImporter;
        private readonly ICatalogueReader<TCatalogueItem> _catalogueReader;
        private readonly ICatalogueWriter<TCatalogueItem> _catalogueWriter;

        protected CatalogueBase(
            ICatalogueExporter<TCatalogueItem> catalogueExporter,
            ICatalogueImporter<TCatalogueItem> catalogueImporter,
            ICatalogueReader<TCatalogueItem> catalogueReader,
            ICatalogueWriter<TCatalogueItem> catalogueWriter)
        {
            _catalogueExporter = catalogueExporter ?? throw new ArgumentNullException(nameof(catalogueExporter));
            _catalogueImporter = catalogueImporter ?? throw new ArgumentNullException(nameof(catalogueImporter));
            _catalogueReader = catalogueReader ?? throw new ArgumentNullException(nameof(catalogueReader));
            _catalogueWriter = catalogueWriter ?? throw new ArgumentNullException(nameof(catalogueWriter));
        }

        public void Export(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _catalogueExporter.Export(this, filePath);
        }

        public void Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            Clear();
            AddRange(_catalogueImporter.Import(filePath));
        }

        public string Read(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _catalogueReader.Read(this, id);
        }

        public void Write(int id, string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _catalogueWriter.Write(this, id, value);
        }
    }
}