using Common.Editor.Data.Entities;

namespace App.BaseGameEditor.Data.Entities
{
    public class CarNumberEntity : EntityBase
    {
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }
    }
}