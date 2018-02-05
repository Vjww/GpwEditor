using App.Core.Entities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CarNumberDataEntity : EntityBase, IDataEntity
    {
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }
    }
}