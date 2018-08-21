using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1DriverDataEntityImportService : IDataEntityImportService<NonF1DriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1DriverDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1DriverDataLocator> _dataLocatorFactory;

        public NonF1DriverDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1DriverDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<NonF1DriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public NonF1DriverDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Salary);
            result.RaceBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.RaceBonus);
            result.ChampionshipBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ChampionshipBonus);
            result.Age = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Age);
            result.Nationality = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Nationality);
            result.UnknownA = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.UnknownA);

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