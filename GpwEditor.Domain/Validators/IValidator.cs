using System.Collections.Generic;
using GpwEditor.Domain.Objects;

namespace GpwEditor.Domain.Validators
{
    public interface IValidator<in T>
        where T : class, IObject
    {
        List<string> Validate(T @object);
    }
}