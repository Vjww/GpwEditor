using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class TrackDomainModelImportService
    {
        private const int TrackItemCount = 16;

        private readonly TrackDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<TrackEntity> _trackEntityFactory;
        private readonly IMapperService _mapperService;

        public TrackDomainModelImportService(
            TrackDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<TrackEntity> trackEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _trackEntityFactory = trackEntityFactory ?? throw new ArgumentNullException(nameof(trackEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            var entities = new List<TrackEntity>();
            for (var i = 0; i < TrackItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Tracks.Get(x => x.Id == id).Single();

                var entity = _trackEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTracks(entities);
        }
    }
}