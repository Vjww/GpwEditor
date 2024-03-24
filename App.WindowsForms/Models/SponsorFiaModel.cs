using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class SponsorFiaModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Cash { get; set; }
    }
}