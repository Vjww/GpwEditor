using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class GameYearModel : IntegerIdentityBase, IEntity
    {
        public int Value { get; set; }
        public string Description { get; set; }
    }
}