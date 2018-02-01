﻿using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefMechanicDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly DataLocatorFactory<F1ChiefMechanicDataLocator> _dataLocatorFactory;

        public F1ChiefMechanicDataEntityExporter(
            DataEndpoint dataEndpoint,
            DataLocatorFactory<F1ChiefMechanicDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1ChiefMechanicDataEntity f1ChiefMechanicDataEntity)) throw new ArgumentNullException(nameof(f1ChiefMechanicDataEntity));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(f1ChiefMechanicDataEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, f1ChiefMechanicDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, f1ChiefMechanicDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, f1ChiefMechanicDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, f1ChiefMechanicDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, f1ChiefMechanicDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, f1ChiefMechanicDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, f1ChiefMechanicDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, f1ChiefMechanicDataEntity.ChampionshipBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DriverLoyalty, f1ChiefMechanicDataEntity.DriverLoyalty);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, f1ChiefMechanicDataEntity.Morale);
        }
    }
}