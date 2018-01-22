namespace App.BaseGameEditor.Data.DataEntities
{
    public class CarNumberDataEntity : DataEntityBase
    {
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }
    }
}