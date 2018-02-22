using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class PerformanceCurveDataEntityImportService : IDataEntityImportService<PerformanceCurveDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<PerformanceCurveDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<PerformanceCurveDataLocator> _dataLocatorFactory;

        public PerformanceCurveDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<PerformanceCurveDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<PerformanceCurveDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public PerformanceCurveDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Value = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Value);

            return result;
        }
    }
}