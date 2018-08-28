using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class FuelDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 4894; // "Petrobras"

        private const int BaseOffset = 2756384;
        private const int LocalOffset = 8;
        private const int PerformanceOffset = 0;
        private const int ToleranceOffset = 4;

        public int Name { get; set; }
        public int Performance { get; set; }
        public int Tolerance { get; set; }

        public void Initialise()
        {
            Name = NameOffset + Id;

            var stepOffset = LocalOffset * Id;

            Performance = BaseOffset + stepOffset + PerformanceOffset;
            Tolerance = BaseOffset + stepOffset + ToleranceOffset;
        }
    }
}