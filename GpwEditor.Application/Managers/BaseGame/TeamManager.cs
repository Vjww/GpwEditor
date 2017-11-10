using System;
using System.Collections.Generic;
using System.Linq;
using GpwEditor.Application.Models.BaseGame;
using GpwEditor.Domain.Validators;
using GpwEditor.Infrastructure.Databases;

namespace GpwEditor.Application.Managers.BaseGame
{
    internal class TeamManager
    {
        private readonly BaseGameDatabase _database;
        private readonly IValidator<TeamModel> _validator;

        public TeamManager(
            BaseGameDatabase database,
            IValidator<TeamModel> validator)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public IEnumerable<TeamModel> GetTeams()
        {
            // TODO: return base.Get<T>(BaseGameDatabase.TeamRecordCount)

            var result = new List<TeamModel>();

            for (var i = 0; i < BaseGameDatabase.TeamRecordCount; i++)
            {
                var model = new TeamModel(_database, i);
                model.Get();
                result.Add(model);
            }

            return result;
        }

        public IEnumerable<string> SetTeams(IEnumerable<TeamModel> models)
        {
            // TODO: base.Set<T>(models, BaseGameDatabase.TeamRecordCount)

            if (models == null) throw new ArgumentNullException(nameof(models));

            var modelsList = models.ToList();
            if (modelsList.Count() != BaseGameDatabase.TeamRecordCount) throw new ArgumentOutOfRangeException(nameof(models));

            var validationMessages = new List<string>();

            foreach (var item in modelsList)
            {
                validationMessages.AddRange(_validator.Validate(item));
            }

            if (validationMessages.Any())
            {
                return validationMessages;
            }

            for (var i = 0; i < BaseGameDatabase.TeamRecordCount; i++)
            {
                var model = new TeamModel(_database, i);
                model.Set();
            }

            return validationMessages;
        }
    }
}