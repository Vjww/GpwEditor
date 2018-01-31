using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataEntityExporters
{
    public class F1ChiefCommercialDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly F1ChiefCommercialDataLocator _dataLocator;

        public F1ChiefCommercialDataEntityExporter(DataEndpoint dataEndpoint, F1ChiefCommercialDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1ChiefCommercialDataEntity f1ChiefCommercialDataEntity)) throw new ArgumentNullException(nameof(f1ChiefCommercialDataEntity));

            _dataLocator.Initialise(f1ChiefCommercialDataEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(_dataLocator.Name, f1ChiefCommercialDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(_dataLocator.Name, f1ChiefCommercialDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(_dataLocator.Name, f1ChiefCommercialDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Ability, f1ChiefCommercialDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Age, f1ChiefCommercialDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Salary, f1ChiefCommercialDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Royalty, f1ChiefCommercialDataEntity.Royalty);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Morale, f1ChiefCommercialDataEntity.Morale);
        }
    }
}