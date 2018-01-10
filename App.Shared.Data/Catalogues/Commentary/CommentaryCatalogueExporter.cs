using System;
using System.Collections.Generic;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.FileResources;

namespace App.Shared.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueExporter : ICatalogueExporter<CommentaryCatalogueItem>
    {
        private readonly CommentaryCatalogueParser _catalogueParser;
        private readonly IFileResource _fileResource;

        public CommentaryCatalogueExporter(
            CommentaryCatalogueParser catalogueParser,
            IFileResource fileResource)
        {
            _catalogueParser = catalogueParser ?? throw new ArgumentNullException(nameof(catalogueParser));
            _fileResource = fileResource ?? throw new ArgumentNullException(nameof(fileResource));
        }

        public void Export(IEnumerable<CommentaryCatalogueItem> catalogue, string filePath)
        {
            if (catalogue == null) throw new ArgumentNullException(nameof(catalogue));
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            var list = new List<string>();
            foreach (var item in catalogue)
            {
                var fileName = _catalogueParser.BuildFileName(item);
                var transcript = _catalogueParser.BuildTranscript(item);
                list.Add($"{_catalogueParser.GetRightAngleBracket()}{fileName} {transcript}{_catalogueParser.GetLeftAngleBracket()}");
            }

            _fileResource.WriteStringList(list);
            _fileResource.Export(filePath);
        }
    }
}