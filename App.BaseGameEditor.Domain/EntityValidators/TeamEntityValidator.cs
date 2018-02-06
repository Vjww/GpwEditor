using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class TeamEntityValidator : IEntityValidator<TeamEntity>
    {
        public IEnumerable<string> Validate(TeamEntity entity)
        {
            var validationMessages = new List<string>();

            if (entity.TeamId < 1 || entity.TeamId > 11)
            {
                validationMessages.Add($"Field {nameof(entity.TeamId)} is out of range and must be a value from 1 to 11.");
            }

            return validationMessages;
        }
    }
}