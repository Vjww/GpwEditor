using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefDesignerDataEntityImportService : IDataEntityImportService<F1ChiefDesignerDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataEntityFactory<F1ChiefDesignerDataEntity> _dataEntityFactory;
        private readonly IDataLocatorFactory<F1ChiefDesignerDataLocator> _dataLocatorFactory;

        public F1ChiefDesignerDataEntityImportService(
            DataEndpoint dataEndpoint,
            IDataEntityFactory<F1ChiefDesignerDataEntity> dataEntityFactory,
            IDataLocatorFactory<F1ChiefDesignerDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public F1ChiefDesignerDataEntity Import(int id)
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