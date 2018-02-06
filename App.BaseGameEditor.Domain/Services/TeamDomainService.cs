using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.EntityValidators;
using App.Core.Repositories;

namespace App.BaseGameEditor.Domain.Services
{
    public class TeamDomainService
    {
        private readonly IRepository<TeamEntity> _teamRepository;
        private readonly IEntityValidator<TeamEntity> _teamEntityValidator;

        public TeamDomainService(
            IRepository<TeamEntity> teamRepository,
            IEntityValidator<TeamEntity> teamEntityValidator
        )
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _teamEntityValidator = teamEntityValidator ?? throw new ArgumentNullException(nameof(teamEntityValidator));
        }

        public IEnumerable<TeamEntity> GetTeams()
        {
            return _teamRepository.Get();
        }

        public void SetTeams(IEnumerable<TeamEntity> teams)
        {
            if (teams == null) throw new ArgumentNullException(nameof(teams));

            var validationMessages = new List<string>();

            var list = teams as IList<TeamEntity> ?? teams.ToList();
            foreach (var item in list)
            {
                var messages = _teamEntityValidator.Validate(item);
                validationMessages.AddRange(messages);
            }

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _teamRepository.Set(list);
        }

        public void SetTeam(TeamEntity team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));

            var validationMessages = new List<string>();

            var messages = _teamEntityValidator.Validate(team);
            validationMessages.AddRange(messages);

            if (validationMessages.Any())
            {
                // TODO: Handle validation failures gracefully.
                throw new ArgumentException();
            }

            _teamRepository.SetById(team);
        }
    }
}