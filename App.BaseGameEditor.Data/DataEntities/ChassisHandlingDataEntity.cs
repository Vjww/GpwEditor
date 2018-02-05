using App.Core.Entities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntity : EntityBase, IDataEntity
    {
        public int TeamId { get; set; }
        public int Value { get; set; }
    }
}