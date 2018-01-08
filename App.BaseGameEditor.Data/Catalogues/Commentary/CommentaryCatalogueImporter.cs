using System;
using System.Collections.Generic;
using System.Linq;
using Common.Editor.Data.Catalogues;
using Common.Editor.Data.FileResources;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public class CommentaryCatalogueImporter : ICatalogueImporter<CommentaryCatalogueItem>
    {
        private readonly CommentaryCatalogueParser _catalogueParser;
        private readonly IFileResource _fileResource;

        public CommentaryCatalogueImporter(
            CommentaryCatalogueParser catalogueParser,
            IFileResource fileResource)
        {
            _catalogueParser = catalogueParser ?? throw new ArgumentNullException(nameof(catalogueParser));
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
                var commentaryCatalogueItem = new CommentaryCatalogueItem
                {
                    Id = id,
                    FileName = fileName,
                    FileNamePrefix = fileNamePrefix,
                    FileNameSuffix = fileNameSuffix,
                    Transcript = transcript,
                    TranscriptPrefix = transcriptPrefix,
                    TranscriptSuffix = transcriptSuffix,
                    CommentaryType = commentaryType
                };

                catalogue.Add(commentaryCatalogueItem);

                id++;
            }

            return catalogue;
        }
    }
}