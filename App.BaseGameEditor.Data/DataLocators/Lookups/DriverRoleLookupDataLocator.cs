using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators.Lookups
{
    public class DriverRoleLookupDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int DescriptionOffset = 2862; // "-"

        public int Description { get; set; }

        public DriverRoleLookupDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Description = DescriptionOffset + _calculator.GetDriverRoleNameId(Id);
        }
    }
}