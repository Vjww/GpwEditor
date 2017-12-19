﻿using System;
using System.Collections.Generic;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.FileResources;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public class CommentaryCatalogueExporter : ICatalogueExporter<CommentaryCatalogueItem>
    {
        private readonly CommentaryCatalogueParser _commentaryCatalogueParser;
        private readonly IFileResource _fileResource;

        public CommentaryCatalogueExporter(
            CommentaryCatalogueParser commentaryCatalogueParser,
            IFileResource fileResource)
        {
            _commentaryCatalogueParser = commentaryCatalogueParser ?? throw new ArgumentNullException(nameof(commentaryCatalogueParser));
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
                var fileName = _commentaryCatalogueParser.BuildFileName(item);
                var transcript = _commentaryCatalogueParser.BuildTranscript(item);
                list.Add($"{_commentaryCatalogueParser.GetRightAngleBracket()}{fileName} {transcript}{_commentaryCatalogueParser.GetLeftAngleBracket()}");
            }

            _fileResource.WriteStringList(list);
            _fileResource.Export(filePath);
        }
    }
}