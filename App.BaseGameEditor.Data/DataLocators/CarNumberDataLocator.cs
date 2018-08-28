using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class CarNumberDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int ValueABaseOffset = 466160;
        private const int ValueALocalOffset = 260;
        private const int ValueBBaseOffset = 474500;
        private const int ValueBLocalOffset = 10;

        public int ValueA { get; set; }
        public int ValueB { get; set; }

        public CarNumberDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            ValueA = ValueABaseOffset + ValueALocalOffset * _calculator.GetMultiplier0To31From0To21(Id);
            ValueB = ValueBBaseOffset + ValueBLocalOffset * Id;
        }
    }
}