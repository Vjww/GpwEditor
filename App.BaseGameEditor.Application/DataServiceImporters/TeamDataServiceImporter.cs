using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.DataServices;
using App.BaseGameEditor.Domain.Models;
using App.BaseGameEditor.Infrastructure.Mappers;

namespace App.BaseGameEditor.Application.DataServiceImporters
{
    public class TeamDataServiceImporter
    {
        private const int ItemCount = 11;

        private readonly TeamDataService _dataService;
        private readonly DataContextToTeamModelMapper _mapper;

        public TeamDataServiceImporter(
            TeamDataService dataService,
            DataContextToTeamModelMapper mapper)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Import()
        {
            var items = new List<TeamModel>();
            for (var i = 0; i < ItemCount; i++)
            {
                var model = _mapper.Map(i);
                items.Add(model);
            }
            _dataService.Set(items);
        }
    }
}