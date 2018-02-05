using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class TeamService
    {
        private readonly IRepository<TeamEntity> _repository;

        public TeamService(IRepository<TeamEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<TeamEntity> GetTeams()
        {
            return _repository.Get();
        }

        public void SetTeams(IEnumerable<TeamEntity> teams)
        {
            if (teams == null) throw new ArgumentNullException(nameof(teams));

            var validationMessages = new List<string>();

            var list = teams as IList<TeamEntity> ?? teams.ToList();
            foreach (var item in list)
            {
                var messages = item.Validate();
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _repository.Set(list);
        }

        public void SetTeam(TeamEntity team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));

            var validationMessages = new List<string>();

            var messages = team.Validate();
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _repository.SetById(team);
        }
    }
}