using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryTeamDataEntityExportService : IDataEntityExportService<CommentaryTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryTeamDataLocator> _dataLocatorFactory;

        public CommentaryTeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CommentaryTeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CommentaryTeamDataEntity commentaryTeamDataEntity)) throw new ArgumentNullException(nameof(commentaryTeamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(commentaryTeamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndex);
            var frenchCatalogueItem = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndex);
            var germanCatalogueItem = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndex);

            englishCatalogueItem.TranscriptPrefix = commentaryTeamDataEntity.Name;
            frenchCatalogueItem.TranscriptPrefix = commentaryTeamDataEntity.Name;
            germanCatalogueItem.TranscriptPrefix = commentaryTeamDataEntity.Name;

            englishCatalogueItem.FileNamePrefix = commentaryTeamDataEntity.FileNamePrefix;
            frenchCatalogueItem.FileNamePrefix = commentaryTeamDataEntity.FileNamePrefix;
            germanCatalogueItem.FileNamePrefix = commentaryTeamDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndex, englishCatalogueItem);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndex, frenchCatalogueItem);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndex, germanCatalogueItem);
        }
    }
}