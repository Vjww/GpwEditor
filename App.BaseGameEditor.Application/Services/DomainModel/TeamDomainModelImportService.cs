﻿using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Application.Maps.Manual;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class TeamDomainModelImportService
    {
        private const int ItemCount = 11;

        private readonly TeamDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<TeamEntity> _teamEntityFactory;
        private readonly IMapperService _mapperService;
        private readonly CarNumberDataEntitiesToCarNumbersObjectMapper _carNumbersMapper;

        public TeamDomainModelImportService(
            TeamDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<TeamEntity> teamEntityFactory,
            IMapperService mapperService,
            CarNumberDataEntitiesToCarNumbersObjectMapper carNumbersMapper)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _teamEntityFactory = teamEntityFactory ?? throw new ArgumentNullException(nameof(teamEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
            _carNumbersMapper = carNumbersMapper ?? throw new ArgumentNullException(nameof(carNumbersMapper));
        }

        public void Import()
        {
            var teams = new List<TeamEntity>();
            for (var i = 0; i < ItemCount; i++)
            {
                var id = i;

                var teamDataEntity = _dataService.Teams.Get(x => x.Id == id).Single();
                var chassisHandlingDataEntity = _dataService.ChassisHandlings.Get(x => x.Id == id).Single();
                var carNumberDataEntities = _dataService.CarNumbers.Get(x => x.Id / 2 == id);

                // Map three into one
                var team = _teamEntityFactory.Create(id);
                team = _mapperService.Map(teamDataEntity, team);
                team = _mapperService.Map(chassisHandlingDataEntity, team);
                team = _mapperService.Map(_carNumbersMapper.Map(carNumberDataEntities), team);

                teams.Add(team);
            }
            _domainService.SetTeams(teams);
        }
    }
}