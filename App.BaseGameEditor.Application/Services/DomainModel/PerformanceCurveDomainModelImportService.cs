using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class PerformanceCurveDomainModelImportService
    {
        private const int PerformanceCurveItemCount = 120;

        private readonly PerformanceCurveDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<PerformanceCurveEntity> _performanceCurveEntityFactory;
        private readonly IMapperService _mapperService;

        public PerformanceCurveDomainModelImportService(
            PerformanceCurveDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<PerformanceCurveEntity> performanceCurveEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _performanceCurveEntityFactory = performanceCurveEntityFactory ?? throw new ArgumentNullException(nameof(performanceCurveEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            var entities = new List<PerformanceCurveEntity>();
            for (var i = 0; i < PerformanceCurveItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.PerformanceCurveValues.Get(x => x.Id == id).Single();

                var entity = _performanceCurveEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetPerformanceCurves(entities);
        }
    }
}