using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryPrefixDriverDataEntityImportService : IDataEntityImportService<CommentaryPrefixDriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryPrefixDriverDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryPrefixDriverDataLocator> _dataLocatorFactory;

        public CommentaryPrefixDriverDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryPrefixDriverDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<CommentaryPrefixDriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public CommentaryPrefixDriverDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.CommentaryIndex = dataLocator.CommentaryIndexP1;
            result.FileNamePrefix = _dataEndpoint.EnglishCommentaryCatalogue.Read(dataLocator.CommentaryIndexP1).FileNamePrefix;

            return result;
        }
    }
}