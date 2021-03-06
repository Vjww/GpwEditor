﻿using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<TeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TeamDataLocator> _dataLocatorFactory;

        public TeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(TeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is TeamDataEntity teamDataEntity)) throw new ArgumentNullException(nameof(teamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(teamDataEntity.Id);
            dataLocator.Initialise();

            ExportLanguageCatalogueValue(_dataEndpoint, teamDataEntity.Name, dataLocator.Name);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastPosition, teamDataEntity.LastPosition);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastPoints, teamDataEntity.LastPoints);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DebutGrandPrix, teamDataEntity.DebutGrandPrix);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DebutYear, teamDataEntity.DebutYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Wins, teamDataEntity.Wins);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.YearlyBudget, teamDataEntity.YearlyBudget);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.UnknownA, teamDataEntity.UnknownA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Location, teamDataEntity.Location);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LocationX, teamDataEntity.LocationX);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LocationY, teamDataEntity.LocationY);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.TyreSupplier, teamDataEntity.TyreSupplier);
        }
    }
}