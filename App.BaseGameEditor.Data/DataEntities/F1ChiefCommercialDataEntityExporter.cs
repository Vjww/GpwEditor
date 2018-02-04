using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefCommercialDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataLocatorFactory<F1ChiefCommercialDataLocator> _dataLocatorFactory;

        public F1ChiefCommercialDataEntityExporter(
            DataEndpoint dataEndpoint,
            IDataLocatorFactory<F1ChiefCommercialDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1ChiefCommercialDataEntity f1ChiefCommercialDataEntity)) throw new ArgumentNullException(nameof(f1ChiefCommercialDataEntity));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(f1ChiefCommercialDataEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, f1ChiefCommercialDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, f1ChiefCommercialDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, f1ChiefCommercialDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, f1ChiefCommercialDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, f1ChiefCommercialDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, f1ChiefCommercialDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Royalty, f1ChiefCommercialDataEntity.Royalty);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, f1ChiefCommercialDataEntity.Morale);
        }
    }
}