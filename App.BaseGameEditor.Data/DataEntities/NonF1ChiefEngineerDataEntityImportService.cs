﻿using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1ChiefEngineerDataEntityImportService : DataEntityImportServiceBase, IDataEntityImportService<NonF1ChiefEngineerDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1ChiefEngineerDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefEngineerDataLocator> _dataLocatorFactory;

        public NonF1ChiefEngineerDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1ChiefEngineerDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefEngineerDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public NonF1ChiefEngineerDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            ImportLanguageCatalogueValue(_dataEndpoint, result.Name, dataLocator.Name);
            result.Ability = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Ability);
            result.Age = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Age);
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Salary);
            result.RaceBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.RaceBonus);
            result.ChampionshipBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ChampionshipBonus);

            return result;
        }
    }
}