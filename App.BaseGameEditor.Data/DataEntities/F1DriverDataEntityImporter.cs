using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1DriverDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataEntityFactory<F1DriverDataEntity> _dataEntityFactory;
        private readonly IDataLocatorFactory<F1DriverDataLocator> _dataLocatorFactory;

        public F1DriverDataEntityImporter(
            DataEndpoint dataEndpoint,
            IDataEntityFactory<F1DriverDataEntity> dataEntityFactory,
            IDataLocatorFactory<F1DriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(id);

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Salary);
            result.RaceBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.RaceBonus);
            result.ChampionshipBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ChampionshipBonus);
            result.PayRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.PayRating);
            result.PositiveSalary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.PositiveSalary);
            result.LastChampionshipPosition = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastChampionshipPosition);
            result.DriverRole = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DriverRole);
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