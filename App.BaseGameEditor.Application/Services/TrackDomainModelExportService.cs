using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services
{
    public class TrackDomainModelExportService
    {
        private readonly TrackDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<TrackDataEntity> _trackDataEntityFactory;
        private readonly IMapperService _mapperService;

        public TrackDomainModelExportService(
            TrackDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<TrackDataEntity> trackDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _trackDataEntityFactory = trackDataEntityFactory ?? throw new ArgumentNullException(nameof(trackDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            var entities = _domainService.GetTracks();
            foreach (var item in entities)
            {
                var dataEntity = _trackDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.Tracks.SetById(dataEntity);
            }
        }
    }
}