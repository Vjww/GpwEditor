using System.Collections.Generic;
using App.BaseGameEditor.Domain.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public interface IEntity : IIntegerIdentity
    {
        IEnumerable<string> Validate();
    }
}