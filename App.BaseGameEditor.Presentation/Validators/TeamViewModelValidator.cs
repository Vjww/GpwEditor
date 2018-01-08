using System.Collections.Generic;
using App.BaseGameEditor.Presentation.ViewModels;

namespace App.BaseGameEditor.Presentation.Validators
{
    public class TeamViewModelValidator : IViewModelValidator<TeamViewModel>
    {
        public IEnumerable<string> Validate(TeamViewModel viewModel)
        {
            var validationMessages = new List<string>();

            if (viewModel.TeamId < 1 || viewModel.TeamId > 11)
            {
                validationMessages.Add($"Field {nameof(viewModel.TeamId)} is out of range and must be a value from 1 to 11.");
            }

            return validationMessages;
        }
    }
}