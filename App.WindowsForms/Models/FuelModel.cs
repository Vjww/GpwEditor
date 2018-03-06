using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class FuelModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Performance { get; set; }
        public int Tolerance { get; set; }
    }
}