using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class FuelEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Performance { get; set; }
        public int Tolerance { get; set; }
    }
}