using System;
using System.Collections.Generic;
using System.Linq;
using Common.Editor.Data.Repositories;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Domain.Validators;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Application.Managers.BaseGame
{
    public class TeamManager
    {
        private readonly BaseGameDataContext _dataContext;
        private readonly IValidator<ITeamModel> _validator;

        public TeamManager(
            BaseGameDataContext dataContext,
            IValidator<ITeamModel> validator)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public IEnumerable<ITeamModel> GetTeams()
        {
            // TODO: Shouldn't this map from entity to model?
            return (IEnumerable<ITeamModel>)_dataContext.Teams;
        }

        public IEnumerable<string> SetTeams(IEnumerable<ITeamModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            var validationMessages = new List<string>();

            var enumerable = models as IList<ITeamModel> ?? models.ToList();
            foreach (var item in enumerable)
            {
                validationMessages.AddRange(_validator.Validate(item));
            }

            if (validationMessages.Any())
            {
                return validationMessages;
            }

            // TODO: Shouldn't this map from model to entity?
            //_dataContext.Teams = (IEnumerable<TeamEntity>)enumerable;
            _dataContext.Teams = null;

            return validationMessages;
        }
    }
}