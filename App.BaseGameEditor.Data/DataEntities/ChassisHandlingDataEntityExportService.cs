using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntityExportService : IDataEntityExportService<ChassisHandlingDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<ChassisHandlingDataLocator> _dataLocatorFactory;

        public ChassisHandlingDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<ChassisHandlingDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(ChassisHandlingDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is ChassisHandlingDataEntity chassisHandlingDataEntity)) throw new ArgumentNullException(nameof(chassisHandlingDataEntity));

            var dataLocator = _dataLocatorFactory.Create(chassisHandlingDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Value, chassisHandlingDataEntity.Value);
        }
    }
}