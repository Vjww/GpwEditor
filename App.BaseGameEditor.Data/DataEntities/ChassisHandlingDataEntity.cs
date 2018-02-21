using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntity : IntegerIdentityBase, IEntity
    {
        public int Value { get; set; }
    }
}