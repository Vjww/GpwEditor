using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryDriverDataEntityExportService : IDataEntityExportService<CommentaryDriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryDriverDataLocator> _dataLocatorFactory;

        public CommentaryDriverDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryDriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CommentaryDriverDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CommentaryDriverDataEntity commentaryDriverDataEntity)) throw new ArgumentNullException(nameof(commentaryDriverDataEntity));

            var dataLocator = _dataLocatorFactory.Create(commentaryDriverDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndex);
            var frenchCatalogueItem = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndex);
            var germanCatalogueItem = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndex);

            englishCatalogueItem.TranscriptPrefix = commentaryDriverDataEntity.Name;
            frenchCatalogueItem.TranscriptPrefix = commentaryDriverDataEntity.Name;
            germanCatalogueItem.TranscriptPrefix = commentaryDriverDataEntity.Name;

            englishCatalogueItem.FileNamePrefix = commentaryDriverDataEntity.FileNamePrefix;
            frenchCatalogueItem.FileNamePrefix = commentaryDriverDataEntity.FileNamePrefix;
            germanCatalogueItem.FileNamePrefix = commentaryDriverDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndex, englishCatalogueItem);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndex, frenchCatalogueItem);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndex, germanCatalogueItem);
        }
    }
}