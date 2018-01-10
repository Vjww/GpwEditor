using System.Collections.Generic;
using Common.Editor.Domain.Identities;

namespace Common.Editor.Domain.Models
{
    public interface IModel : IIntegerIdentity
    {
        IEnumerable<string> Validate();
    }
}