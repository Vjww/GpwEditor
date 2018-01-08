using System.Collections.Generic;
using App.BaseGameEditor.Presentation.ViewModels;

namespace App.BaseGameEditor.Presentation.Validators
{
    public interface IViewModelValidator<in TViewModel>
        where TViewModel : class, IViewModel
    {
        IEnumerable<string> Validate(TViewModel viewModel);
    }
}