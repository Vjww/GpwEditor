using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityImportService : IDataEntityImportService<TeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TeamDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<TeamDataLocator> _dataLocatorFactory;

        public TeamDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TeamDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<TeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public TeamDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;
            result.LastPosition = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastPosition);
            result.LastPoints = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastPoints);
            result.DebutGrandPrix = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DebutGrandPrix);
            result.DebutYear = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DebutYear);
            result.Wins = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Wins);
            result.YearlyBudget = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.YearlyBudget);
            result.UnknownA = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.UnknownA);
            result.Location = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Location);
            result.LocationX = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LocationX);
            result.LocationY = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LocationY);
            result.TyreSupplier = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.TyreSupplier);

            return result;
        }
    }
}