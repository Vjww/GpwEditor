using System.Collections.Generic;
using GpwEditor.Domain.Objects.BaseGame;

namespace GpwEditor.Domain.Validators.BaseGame
{
    public class TeamValidator : IValidator<ITeamObject>
    {
        public List<string> Validate(ITeamObject @object)
        {
            var validationMessages = new List<string>();

            if (@object.TeamId < 1 || @object.TeamId > 11)
            {
                validationMessages.Add($"Field {nameof(@object.TeamId)} is out of range and must be a value from 1 to 11.");
            }

            return new List<string>();
        }
    }
}