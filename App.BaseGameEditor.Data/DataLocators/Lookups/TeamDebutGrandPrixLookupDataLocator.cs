using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators.Lookups
{
    public class TeamDebutGrandPrixLookupDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int DescriptionOffset = 6006; // "No race"

        public int Description { get; set; }

        public TeamDebutGrandPrixLookupDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Description = DescriptionOffset + _calculator.GetTeamDebutGrandPrixNameId(Id);
        }
    }
}