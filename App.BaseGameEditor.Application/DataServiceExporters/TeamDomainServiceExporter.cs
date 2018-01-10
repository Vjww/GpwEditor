using System;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Mappers;

namespace App.BaseGameEditor.Application.DataServiceExporters
{
    public class TeamDomainServiceExporter
    {
        private readonly TeamService _service;
        private readonly TeamEntityToDataContextMapper _mapper;

        public TeamDomainServiceExporter(
            TeamService service,
            TeamEntityToDataContextMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Export()
        {
            var teams = _service.GetTeams();
            foreach (var team in teams)
            {
                _mapper.Map(team);
            }
        }
    }
}