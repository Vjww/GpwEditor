using System;
using Common.Editor.Data.DataLocators;
using GpwEditor.Infrastructure.Calculators;

namespace GpwEditor.Infrastructure.DataLocators
{
    public class CarNumberDataLocator : IDataLocator
    {
        private readonly IdentityCalculator _identityCalculator;

        private const int ValueABaseOffset = 466160;
        private const int ValueALocalOffset = 260;
        private const int ValueBBaseOffset = 474500;
        private const int ValueBLocalOffset = 10;

        public int Id { get; set; }
        public int ValueA { get; set; }
        public int ValueB { get; set; }

        public CarNumberDataLocator(IdentityCalculator identityCalculator)
        {
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public void Map(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;

            ValueA = ValueABaseOffset + ValueALocalOffset * _identityCalculator.GetMultiplier0To31From0To21(Id);
            ValueB = ValueBBaseOffset + ValueBLocalOffset * Id;
        }
    }
}