using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Application.AutoMapper;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.AutoMapperMaps;
using AutoMapper;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelImportService
    {
        private const int ItemCount = 11;

        private readonly TeamService _service;
        private readonly DataService _dataService;
        private readonly CarNumberEntitiesToCarNumbersObjectMapper _carNumbersMapper;

        public TeamDomainModelImportService(
            TeamService service,
            DataService dataService,
            CarNumberEntitiesToCarNumbersObjectMapper carNumbersMapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _carNumbersMapper = carNumbersMapper ?? throw new ArgumentNullException(nameof(carNumbersMapper));
        }

        public void Import()
        {
            var teams = new List<TeamEntity>();
            for (var i = 0; i < ItemCount; i++)
            {
                var id = i;

                // Map three into one
                var team = Mapper.Map<TeamEntity>(_dataService.Teams.Get(x => x.Id == id).Single())
                    .Map(_dataService.ChassisHandlings.Get(x => x.TeamId == id).Single())
                    .Map(_carNumbersMapper.Map(_dataService.CarNumbers.Get(x => x.TeamId == id)));

                teams.Add(team);
            }
            _service.SetTeams(teams);
        }
    }
}