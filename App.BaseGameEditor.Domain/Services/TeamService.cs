using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class TeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
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

            var validationFailureMessages = new List<string>();

            var list = teams as IList<TeamEntity> ?? teams.ToList();
            foreach (var item in list)
            {
                var messages = item.Validate();
                validationFailureMessages.AddRange(messages);
            }

            if (validationFailureMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _repository.Set(list);
        }

        public void SetTeam(TeamEntity team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));

            var validationFailureMessages = new List<string>();

            var messages = team.Validate();
            validationFailureMessages.AddRange(messages);

            if (validationFailureMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _repository.SetById(team);
        }

        // TODO: Remove, currently implemented as an example of business logic
        public void IncrementWinsForAllTeams()
        {
            var teams = _repository.Get();
            var list = teams as IList<TeamEntity> ?? teams.ToList();
            foreach (var item in list)
            {
                item.Wins++;
            }
            _repository.Set(list);
        }
    }
}