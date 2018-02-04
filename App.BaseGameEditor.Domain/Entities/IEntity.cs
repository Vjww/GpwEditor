using System.Collections.Generic;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public interface IEntity : IIntegerIdentity
    {
        IEnumerable<string> Validate();
    }
}