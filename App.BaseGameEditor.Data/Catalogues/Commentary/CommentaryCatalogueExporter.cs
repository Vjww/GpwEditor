using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.FileResources;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueExporter<TLanguagePhrases> : ICatalogueExporter<CommentaryCatalogueItem>
        where TLanguagePhrases : class, ILanguagePhrases
    {
        private readonly CommentaryCatalogueParser<TLanguagePhrases> _catalogueParser;
        private readonly FileResource _fileResource;

        public CommentaryCatalogueExporter(
            CommentaryCatalogueParser<TLanguagePhrases> catalogueParser,
            FileResource fileResource)
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