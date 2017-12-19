using System.Collections.Generic;
using GpwEditor.Domain.Models;

namespace GpwEditor.Domain.Validators
{
    public interface IValidator<in TModel>
        where TModel : class, IModel
    {
        List<string> Validate(TModel model);
    }
}