using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryPrefixTeamDataEntityImportService : IDataEntityImportService<CommentaryPrefixTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryPrefixTeamDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixTeamDataLocator> _dataLocatorFactory;

        public CommentaryPrefixTeamDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryPrefixTeamDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public CommentaryPrefixTeamDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.CommentaryIndex = dataLocator.CommentaryIndexOut;
            result.FileNamePrefix = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexOut).FileNamePrefix;

            return result;
        }
    }
}