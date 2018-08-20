using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class PerformanceCurveDomainModelExportService
    {
        private readonly PerformanceCurveDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<PerformanceCurveDataEntity> _performanceCurveDataEntityFactory;
        private readonly IMapperService _mapperService;

        public PerformanceCurveDomainModelExportService(
            PerformanceCurveDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<PerformanceCurveDataEntity> performanceCurveDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _performanceCurveDataEntityFactory = performanceCurveDataEntityFactory ?? throw new ArgumentNullException(nameof(performanceCurveDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            var entities = _domainService.GetPerformanceCurves();
            foreach (var item in entities)
            {
                var dataEntity = _performanceCurveDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.PerformanceCurveValues.SetById(dataEntity);
            }
        }
    }
}