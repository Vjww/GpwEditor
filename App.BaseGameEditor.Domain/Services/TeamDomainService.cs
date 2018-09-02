using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Entities;
using App.Core.Repositories;
using App.Core.Services;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.Services
{
    public class TeamDomainService
    {
        private readonly IRepository<TeamEntity> _teamRepository;
        private readonly IEntityValidator<TeamEntity> _teamEntityValidator;
        private readonly RandomService _randomService;

        public TeamDomainService(
            IRepository<TeamEntity> teamRepository,
            IEntityValidator<TeamEntity> teamEntityValidator,
            RandomService randomService)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            _teamEntityValidator = teamEntityValidator ?? throw new ArgumentNullException(nameof(teamEntityValidator));
            _randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
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

        public IEnumerable<TeamEntity> GetChassisHandlingValuesFromOriginalValues(IEnumerable<TeamEntity> teams)
        {
            if (teams == null) throw new ArgumentNullException(nameof(teams));

            var values = new[]
            {
                75,
                80,
                70,
                90,
                55,
                30,
                45,
                50,
                40,
                25,
                20
            };

            var teamEntities = teams.ToList();

            for (var i = 0; i < teamEntities.Count; i++)
            {
                var id = i;
                teamEntities.Single(x => x.Id == id).ChassisHandling = values[id];
            }

            return teamEntities;
        }

        public IEnumerable<TeamEntity> GetChassisHandlingValuesFromRandomisedModifiedDesignCalculation(
            IEnumerable<TeamEntity> teams,
            IEnumerable<F1ChiefDesignerEntity> chiefDesigners,
            IEnumerable<F1ChiefEngineerEntity> chiefEngineers)
        {
            if (teams == null) throw new ArgumentNullException(nameof(teams));
            if (chiefDesigners == null) throw new ArgumentNullException(nameof(chiefDesigners));
            if (chiefEngineers == null) throw new ArgumentNullException(nameof(chiefEngineers));

            const int designerFactor = 5;
            const int engineerFactor = 15;

            var teamEntities = teams.ToList();
            var f1ChiefDesignerEntities = chiefDesigners.ToList();
            var f1ChiefEngineerEntities = chiefEngineers.ToList();

            for (var i = 0; i < teamEntities.Count; i++)
            {
                var id = i;
                var team = teamEntities.Single(x => x.Id == id);
                var designerAbility = f1ChiefDesignerEntities.Single(x => x.TeamId == team.TeamId).Ability;
                var engineerAbility = f1ChiefEngineerEntities.Single(x => x.TeamId == team.TeamId).Ability;
                var randomFactor = _randomService.Next(0, 21); // 0..20

                var recalculatedValue = designerFactor * (designerAbility - 1) +
                                  engineerFactor * (engineerAbility - 1) +
                                  (31 - team.LastPosition - randomFactor);

                teamEntities.Single(x => x.Id == id).ChassisHandling = recalculatedValue;
            }

            return teamEntities;
        }

        public IEnumerable<TeamEntity> GetChassisHandlingValuesFromRecommendedValues(IEnumerable<TeamEntity> teams)
        {
            if (teams == null) throw new ArgumentNullException(nameof(teams));

            var values = new[]
            {
                44,
                50,
                45,
                66,
                37,
                26,
                34,
                23,
                22,
                13,
                13
            };

            var teamEntities = teams.ToList();

            for (var i = 0; i < teamEntities.Count; i++)
            {
                var id = i;
                teamEntities.Single(x => x.Id == id).ChassisHandling = values[id];
            }

            return teamEntities;
        }
    }
}