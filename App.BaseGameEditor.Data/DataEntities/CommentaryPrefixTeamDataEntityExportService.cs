using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryPrefixTeamDataEntityExportService : IDataEntityExportService<CommentaryPrefixTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryPrefixTeamDataLocator> _dataLocatorFactory;

        public CommentaryPrefixTeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryPrefixTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CommentaryPrefixTeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CommentaryPrefixTeamDataEntity commentaryPrefixTeamDataEntity)) throw new ArgumentNullException(nameof(commentaryPrefixTeamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(commentaryPrefixTeamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItemOut = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut);
            var frenchCatalogueItemOut = _dataEndpoint.FrenchCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut);
            var germanCatalogueItemOut = _dataEndpoint.GermanCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut);

            englishCatalogueItemOut.FileNamePrefix = commentaryPrefixTeamDataEntity.FileNamePrefix;
            frenchCatalogueItemOut.FileNamePrefix = commentaryPrefixTeamDataEntity.FileNamePrefix;
            germanCatalogueItemOut.FileNamePrefix = commentaryPrefixTeamDataEntity.FileNamePrefix;

            _dataEndpoint.EnglishCommentaryCatalogue.Write(dataLocator.CommentaryIndexOut, englishCatalogueItemOut);
            _dataEndpoint.FrenchCommentaryCatalogue.Write(dataLocator.CommentaryIndexOut, frenchCatalogueItemOut);
            _dataEndpoint.GermanCommentaryCatalogue.Write(dataLocator.CommentaryIndexOut, germanCatalogueItemOut);
        }
    }
}