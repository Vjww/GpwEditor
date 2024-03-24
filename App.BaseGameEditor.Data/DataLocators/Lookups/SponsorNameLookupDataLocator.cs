using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators.Lookups
{
    public class SponsorNameLookupDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int DescriptionOffset = 4876; // "Buzzin Hornets"

        public int Description { get; set; }

        public void Initialise()
        {
            Description = DescriptionOffset + Id - 1;
        }
    }
}