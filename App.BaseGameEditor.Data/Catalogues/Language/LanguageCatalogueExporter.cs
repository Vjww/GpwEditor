﻿using System;
using System.Collections.Generic;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.FileResources;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public class LanguageCatalogueExporter : ICatalogueExporter<LanguageCatalogueItem>
    {
        private readonly IFileResource _fileResource;

        public LanguageCatalogueExporter(IFileResource fileResource)
        {
            _fileResource = fileResource ?? throw new ArgumentNullException(nameof(fileResource));
        }

        public void Export(IEnumerable<LanguageCatalogueItem> catalogue, string filePath)
        {
            if (catalogue == null) throw new ArgumentNullException(nameof(catalogue));
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            var list = new List<string>();
            foreach (var item in catalogue)
            {
                list.Add($"{item.Key} \"{item.Value}\"");
            }

            _fileResource.WriteStringList(list);
            _fileResource.Export(filePath);
        }
    }
}