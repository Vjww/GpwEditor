using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Models;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamService
    {
        private readonly Domain.Services.TeamService _service;

        public TeamService(Domain.Services.TeamService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IEnumerable<TeamModel> Get()
        {
            var models = _service.Get();
            return models;
        }

        public void Set(IEnumerable<TeamModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            var validationFailureMessages = new List<string>();
            var teamModels = models as IList<TeamModel> ?? models.ToList();
            foreach (var teamModel in teamModels)
            {
                var messages = teamModel.Validate();
                validationFailureMessages.AddRange(messages);
            }

            if (validationFailureMessages.Any())
            {
                // TODO: handle validation failure
                return;
            }

            _service.Set(teamModels);
        }
    }
}