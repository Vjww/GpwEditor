namespace GpwEditor.Infrastructure.Mappers.BaseGame
{
    public class CarNumberMapper : MapperBase
    {
        private const int ValueABaseOffset = 466160;
        private const int ValueALocalOffset = 260;
        private const int ValueBBaseOffset = 474500;
        private const int ValueBLocalOffset = 10;

        public int ValueA { get; set; }
        public int ValueB { get; set; }

        public override void Map()
        {
            base.Map();

            ValueA = ValueABaseOffset + ValueALocalOffset * GetMultiplier0To31From0To21(Id);
            ValueB = ValueBBaseOffset + ValueBLocalOffset * Id;
        }
    }
}