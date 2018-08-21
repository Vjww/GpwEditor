using System;
using System.Collections.Generic;

namespace App.Shared.Data.Catalogues
{
    public abstract class CatalogueBase<TCatalogueItem>
        where TCatalogueItem : class, ICatalogueItem
    {
        private readonly List<TCatalogueItem> _list;
        private readonly ICatalogueExporter<TCatalogueItem> _catalogueExporter;
        private readonly ICatalogueImporter<TCatalogueItem> _catalogueImporter;
        private readonly ICatalogueReader<TCatalogueItem> _catalogueReader;
        private readonly ICatalogueWriter<TCatalogueItem> _catalogueWriter;

        protected CatalogueBase(
            List<TCatalogueItem> list,
            ICatalogueExporter<TCatalogueItem> catalogueExporter,
            ICatalogueImporter<TCatalogueItem> catalogueImporter,
            ICatalogueReader<TCatalogueItem> catalogueReader,
            ICatalogueWriter<TCatalogueItem> catalogueWriter)
        {
            _list = list;
            _catalogueExporter = catalogueExporter ?? throw new ArgumentNullException(nameof(catalogueExporter));
            _catalogueImporter = catalogueImporter ?? throw new ArgumentNullException(nameof(catalogueImporter));
            _catalogueReader = catalogueReader ?? throw new ArgumentNullException(nameof(catalogueReader));
            _catalogueWriter = catalogueWriter ?? throw new ArgumentNullException(nameof(catalogueWriter));
        }

        public void Export(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _catalogueExporter.Export(_list, filePath);
        }

        public void Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            var items = _catalogueImporter.Import(filePath);

            _list.Clear();
            _list.AddRange(items);
            _list.TrimExcess();
        }

        public TCatalogueItem Read(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _catalogueReader.Read(_list, id);
        }

        public void Write(int id, TCatalogueItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _catalogueWriter.Write(_list, id, item);
        }
    }
}