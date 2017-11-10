using System.Collections.Generic;
using GpwEditor.Domain.Objects;

namespace GpwEditor.Domain.Validators
{
    public interface IValidator<in TObject>
        where TObject : class, IObject
    {
        List<string> Validate(TObject @object);
    }
}