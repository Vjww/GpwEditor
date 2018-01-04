using System;
using Common.Editor.Data.DataLocators;
using GpwEditor.Infrastructure.Calculators;

namespace GpwEditor.Infrastructure.DataLocators
{
    public class ChassisHandlingDataLocator : IDataLocator
    {
        private const int BaseOffset = 1094126;
        private const int LocalOffset = 30;
        private const int ValueOffset = 0;

        private readonly IdentityCalculator _identityCalculator;

        public int Id { get; set; }
        public int Value { get; set; }

        public ChassisHandlingDataLocator(IdentityCalculator identityCalculator)
        {
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public void Initialise(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;

            var stepOffset = LocalOffset * _identityCalculator.GetTeamAlphabeticalId(Id);

            Value = BaseOffset + stepOffset + ValueOffset;
        }
    }
}