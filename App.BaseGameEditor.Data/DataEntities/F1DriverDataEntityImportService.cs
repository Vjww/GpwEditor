﻿using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.DataEntities;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1DriverDataEntityImportService : DataEntityImportServiceBase, IDataEntityImportService<F1DriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<F1DriverDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<F1DriverDataLocator> _dataLocatorFactory;

        public F1DriverDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<F1DriverDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<F1DriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public F1DriverDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            ImportLanguageCatalogueValue(_dataEndpoint, result.Name, dataLocator.Name);
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Salary);
            result.RaceBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.RaceBonus);
            result.ChampionshipBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ChampionshipBonus);
            result.PayRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.PayRating);
            result.PositiveSalary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.PositiveSalary);
            result.LastChampionshipPosition = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastChampionshipPosition);
            result.Role = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Role);
            result.Age = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Age);
            result.Nationality = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Nationality);

            result.CareerChampionships = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerChampionships);
            result.CareerRaces = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerRaces);
            result.CareerWins = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerWins);
            result.CareerPoints = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerPoints);
            result.CareerFastestLaps = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerFastestLaps);
            result.CareerPointsFinishes = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerPointsFinishes);
            result.CareerPolePositions = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CareerPolePositions);

            result.Speed = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Speed);
            result.Skill = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Skill);
            result.Overtaking = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Overtaking);
            result.WetWeather = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeather);
            result.Concentration = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Concentration);
            result.Experience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Experience);
            result.Stamina = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Stamina);
            result.Morale = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Morale);

            return result;
        }
    }
}