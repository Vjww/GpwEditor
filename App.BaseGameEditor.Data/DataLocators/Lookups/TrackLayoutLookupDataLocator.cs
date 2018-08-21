using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Data.DataLocators.Lookups
{
    public class TrackLayoutLookupDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int DescriptionOffset = 6525; // ""

        public int Description { get; set; }

        public TrackLayoutLookupDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            Description = DescriptionOffset + _calculator.GetTrackLayoutNameId(Id);
        }
    }
}