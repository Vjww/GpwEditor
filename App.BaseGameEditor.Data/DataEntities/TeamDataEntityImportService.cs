using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityImportService : DataEntityImportServiceBase, IDataEntityImportService<TeamDataEntity>
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
            ImportLanguageCatalogueValue(_dataEndpoint, result.Name, dataLocator.Name);
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