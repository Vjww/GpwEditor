using System.Collections.Generic;
using App.BaseGameEditor.Domain.Identities;

namespace App.BaseGameEditor.Domain.Models
{
    public interface IModel : IIntegerIdentity
    {
        IEnumerable<string> Validate();
    }
}