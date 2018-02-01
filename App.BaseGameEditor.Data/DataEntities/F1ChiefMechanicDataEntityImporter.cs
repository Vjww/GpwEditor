using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefMechanicDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly DataEntityFactory<F1ChiefMechanicDataEntity> _dataEntityFactory;
        private readonly DataLocatorFactory<F1ChiefMechanicDataLocator> _dataLocatorFactory;

        public F1ChiefMechanicDataEntityImporter(
            DataEndpoint dataEndpoint,
            DataEntityFactory<F1ChiefMechanicDataEntity> dataEntityFactory,
            DataLocatorFactory<F1ChiefMechanicDataLocator> dataLocatorFactory)
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
            result.Ability = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Ability);
            result.Age = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Age);
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Salary);
            result.RaceBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.RaceBonus);
            result.ChampionshipBonus = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ChampionshipBonus);
            result.DriverLoyalty = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DriverLoyalty);
            result.Morale = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Morale);

            return result;
        }
    }
}