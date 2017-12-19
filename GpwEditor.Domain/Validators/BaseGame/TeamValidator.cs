using System.Collections.Generic;
using GpwEditor.Domain.Models.BaseGame;

namespace GpwEditor.Domain.Validators.BaseGame
{
    public class TeamValidator : IValidator<ITeamModel>
    {
        public List<string> Validate(ITeamModel model)
        {
            var validationMessages = new List<string>();

            if (model.TeamId < 1 || model.TeamId > 11)
            {
                validationMessages.Add($"Field {nameof(model.TeamId)} is out of range and must be a value from 1 to 11.");
            }

            return validationMessages;
        }
    }
}