using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntityImporters
{
    public class F1ChiefCommercialDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly F1ChiefCommercialDataLocator _dataLocator;
        private readonly DataEntityFactory<F1ChiefCommercialDataEntity> _factory;

        public F1ChiefCommercialDataEntityImporter(
            DataEndpoint dataEndpoint,
            F1ChiefCommercialDataLocator dataLocator,
            DataEntityFactory<F1ChiefCommercialDataEntity> factory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _dataLocator.Initialise(id);

            var result = _factory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(_dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(_dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(_dataLocator.Name);
            result.Ability = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Ability);
            result.Age = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Age);
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Salary);
            result.Royalty = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Royalty);
            result.Morale = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Morale);

            return result;
        }
    }
}