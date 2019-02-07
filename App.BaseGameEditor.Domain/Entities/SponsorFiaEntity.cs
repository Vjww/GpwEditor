using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class SponsorFiaEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Cash { get; set; }
    }
}