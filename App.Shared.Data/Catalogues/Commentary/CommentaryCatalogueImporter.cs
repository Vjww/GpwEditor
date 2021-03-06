﻿using System;
using System.Collections.Generic;
using System.Linq;
using App.Shared.Data.FileResources;

namespace App.Shared.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueImporter<TLanguagePhrases> : ICatalogueImporter<CommentaryCatalogueItem>
        where TLanguagePhrases : class, ILanguagePhrases
    {
        private readonly CommentaryCatalogueParser<TLanguagePhrases> _catalogueParser;
        private readonly Func<CommentaryCatalogueItem> _catalogueItemFactory;
        private readonly FileResource _fileResource;

        public CommentaryCatalogueImporter(
            CommentaryCatalogueParser<TLanguagePhrases> catalogueParser,
            Func<CommentaryCatalogueItem> catalogueItemFactory,
            FileResource fileResource)
        {
            _catalogueParser = catalogueParser ?? throw new ArgumentNullException(nameof(catalogueParser));
            _catalogueItemFactory = catalogueItemFactory ?? throw new ArgumentNullException(nameof(catalogueItemFactory));
            _fileResource = fileResource ?? throw new ArgumentNullException(nameof(fileResource));
        }

        public IEnumerable<CommentaryCatalogueItem> Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _fileResource.Import(filePath);

            var list = _fileResource.ReadStringList();
            var enumerable = list as IList<string> ?? list.Cast<string>().ToList();

            var id = 0;
            var catalogue = new List<CommentaryCatalogueItem>();
            foreach (var item in enumerable)
            {
                var line = item.Trim();

                _catalogueParser.Validate(line, id + 1, out var validationMessage);
                if (!string.IsNullOrWhiteSpace(validationMessage))
                {
                    throw new Exception(validationMessage);
                }

                var commentaryType = _catalogueParser.GetCommentaryType(id);
                var fileName = _catalogueParser.ExtractFileName(line);
                var fileNamePrefix = _catalogueParser.ExtractFileNamePrefix(fileName, commentaryType);
                var fileNameSuffix = _catalogueParser.ExtractFileNameSuffix(commentaryType);
                var transcript = _catalogueParser.ExtractTranscript(line);
                var transcriptPrefix = _catalogueParser.ExtractTranscriptPrefix(transcript, commentaryType);
                var transcriptSuffix = _catalogueParser.ExtractTranscriptSuffix(commentaryType);

                var commentaryCatalogueItem = _catalogueItemFactory.Invoke();
                commentaryCatalogueItem.Id = id;
                commentaryCatalogueItem.FileName = fileName;
                commentaryCatalogueItem.FileNamePrefix = fileNamePrefix;
                commentaryCatalogueItem.FileNameSuffix = fileNameSuffix;
                commentaryCatalogueItem.Transcript = transcript;
                commentaryCatalogueItem.TranscriptPrefix = transcriptPrefix;
                commentaryCatalogueItem.TranscriptSuffix = transcriptSuffix;
                commentaryCatalogueItem.CommentaryType = commentaryType;

                catalogue.Add(commentaryCatalogueItem);

                id++;
            }

            return catalogue;
        }
    }
}