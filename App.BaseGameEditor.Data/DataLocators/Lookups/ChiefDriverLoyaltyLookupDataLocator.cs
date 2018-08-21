using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators.Lookups
{
    public class ChiefDriverLoyaltyLookupDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int DescriptionOffset = 5795; // "None"

        public int Description { get; set; }

        public ChiefDriverLoyaltyLookupDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Description = DescriptionOffset + _calculator.GetChiefDriverLoyaltyNameId(Id);
        }
    }
}