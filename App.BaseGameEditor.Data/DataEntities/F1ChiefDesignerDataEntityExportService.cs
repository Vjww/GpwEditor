﻿using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefDesignerDataEntityExportService : DataEntityExportServiceBase, IDataEntityExportService<F1ChiefDesignerDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<F1ChiefDesignerDataLocator> _dataLocatorFactory;

        public F1ChiefDesignerDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<F1ChiefDesignerDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(F1ChiefDesignerDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1ChiefDesignerDataEntity f1ChiefDesignerDataEntity)) throw new ArgumentNullException(nameof(f1ChiefDesignerDataEntity));

            var dataLocator = _dataLocatorFactory.Create(f1ChiefDesignerDataEntity.Id);
            dataLocator.Initialise();

            ExportLanguageCatalogueValue(_dataEndpoint, f1ChiefDesignerDataEntity.Name, dataLocator.Name);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, f1ChiefDesignerDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, f1ChiefDesignerDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, f1ChiefDesignerDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, f1ChiefDesignerDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, f1ChiefDesignerDataEntity.ChampionshipBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DriverLoyalty, f1ChiefDesignerDataEntity.DriverLoyalty);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, f1ChiefDesignerDataEntity.Morale);
        }
    }
}