using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class PerformanceCurveDataEntityExportService : IDataEntityExportService<PerformanceCurveDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<PerformanceCurveDataLocator> _dataLocatorFactory;

        public PerformanceCurveDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<PerformanceCurveDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(PerformanceCurveDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is PerformanceCurveDataEntity performanceCurveDataEntity)) throw new ArgumentNullException(nameof(performanceCurveDataEntity));

            var dataLocator = _dataLocatorFactory.Create(performanceCurveDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Value, performanceCurveDataEntity.Value);
        }
    }
}