using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class PerformanceCurveDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int BaseOffset = 2723224;
        private const int LocalOffset = 4;
        private const int ValueOffset = 0;

        public int Value { get; set; }

        public void Initialise()
        {
            var stepOffset = LocalOffset * Id;

            Value = BaseOffset + stepOffset + ValueOffset;
        }
    }
}