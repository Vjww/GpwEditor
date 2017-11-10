using Common.Editor.Infrastructure.Locators;

namespace GpwEditor.Infrastructure.Locators.BaseGame
{
    public class ChassisHandlingLocator : LocatorBase
    {
        private const int BaseOffset = 1094126;
        private const int LocalOffset = 30;
        private const int ValueOffset = 0;

        public int Value { get; set; }

        public override void Initialise()
        {
            base.Initialise();

            var stepOffset = LocalOffset * GetTeamAlphabeticalId(Id);

            Value = BaseOffset + stepOffset + ValueOffset;
        }
    }
}