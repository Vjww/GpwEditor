using System;
using App.BaseGameEditor.Data.Calculators;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators.Lookups
{
    public class TrackFastestLapDriverLookupDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _calculator;

        private const int DescriptionOffset = 5795; // "None"

        public int Description { get; set; }

        public TrackFastestLapDriverLookupDataLocator(IdentityCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void Initialise()
        {
            const int specialOffset = 535;

            var nameId = _calculator.GetTrackFastestLapDriverNameId(Id);

            if (nameId >= 200 && nameId <= 203)
            {
                // Use special offset for retired fastest lap drivers (language file index 6530 to 6533)
                Description = DescriptionOffset + nameId + specialOffset;
            }
            else
            {
                Description = DescriptionOffset + nameId;
            }
        }
    }
}