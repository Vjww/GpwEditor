using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1DriverDataEntityExportService : IDataEntityExportService<F1DriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<F1DriverDataLocator> _dataLocatorFactory;

        public F1DriverDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<F1DriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(F1DriverDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1DriverDataEntity f1DriverDataEntity)) throw new ArgumentNullException(nameof(f1DriverDataEntity));

            var dataLocator = _dataLocatorFactory.Create(f1DriverDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, f1DriverDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, f1DriverDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, f1DriverDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, f1DriverDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, f1DriverDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, f1DriverDataEntity.ChampionshipBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.PayRating, f1DriverDataEntity.PayRating);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.PositiveSalary, f1DriverDataEntity.PositiveSalary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastChampionshipPosition, f1DriverDataEntity.LastChampionshipPosition);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Role, f1DriverDataEntity.Role);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, f1DriverDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Nationality, f1DriverDataEntity.Nationality);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerChampionships, f1DriverDataEntity.CareerChampionships);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerRaces, f1DriverDataEntity.CareerRaces);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerWins, f1DriverDataEntity.CareerWins);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerPoints, f1DriverDataEntity.CareerPoints);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerFastestLaps, f1DriverDataEntity.CareerFastestLaps);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerPointsFinishes, f1DriverDataEntity.CareerPointsFinishes);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CareerPolePositions, f1DriverDataEntity.CareerPolePositions);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Speed, f1DriverDataEntity.Speed);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Skill, f1DriverDataEntity.Skill);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Overtaking, f1DriverDataEntity.Overtaking);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeather, f1DriverDataEntity.WetWeather);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Concentration, f1DriverDataEntity.Concentration);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Experience, f1DriverDataEntity.Experience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Stamina, f1DriverDataEntity.Stamina);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, f1DriverDataEntity.Morale);
        }
    }
}