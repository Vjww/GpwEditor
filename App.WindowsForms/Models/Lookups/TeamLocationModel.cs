using App.Core.Entities;
using App.Core.Entities.Lookups;
using App.Core.Identities;

namespace App.WindowsForms.Models.Lookups
{
    public class TeamLocationLookupModel : IntegerIdentityBase, ILookup, IEntity
    {
        public int Value { get; set; }
        public string Description { get; set; }
    }
}