using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryIndexTeamDataEntityImportService : IDataEntityImportService<CommentaryIndexTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<CommentaryIndexTeamDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<CommentaryIndexTeamDataLocator> _dataLocatorFactory;

        public CommentaryIndexTeamDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<CommentaryIndexTeamDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<CommentaryIndexTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public CommentaryIndexTeamDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;
            result.CommentaryIndex = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CommentaryIndex);

            return result;
        }
    }
}