using Common.Editor.Infrastructure.Locators;

namespace GpwEditor.Infrastructure.Locators.BaseGame
{
    public class CarNumberLocator : LocatorBase
    {
        private const int ValueABaseOffset = 466160;
        private const int ValueALocalOffset = 260;
        private const int ValueBBaseOffset = 474500;
        private const int ValueBLocalOffset = 10;

        public int ValueA { get; set; }
        public int ValueB { get; set; }

        public override void Initialise()
        {
            base.Initialise();

            ValueA = ValueABaseOffset + ValueALocalOffset * GetMultiplier0To31From0To21(Id);
            ValueB = ValueBBaseOffset + ValueBLocalOffset * Id;
        }
    }
}