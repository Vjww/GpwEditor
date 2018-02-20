using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntity : IntegerIdentityBase, IEntity
    {
        // public int TeamId { get; set; } // TODO: Remove?
        public int Value { get; set; }
    }
}