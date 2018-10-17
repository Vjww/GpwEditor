using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorshipTeamDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 4876; // "Buzzin Hornets"

        public int Name { get; set; }

        // TODO: Remove temporary entity fields below, as are used in aid of module development
        private const int EntityBaseOffset = 0x004E7A2E - 0x00400C00;
        private const int EntityLocalOffset = 40;
        private const int EntityTypeValueOffset = 6;
        private const int EntityResourceValueOffset = 8;
        private const int EntityDataValueOffset = 27;
        public int EntityTypeValue;
        public int EntityResourceValue;
        public int EntityDataValue;

        private const int CashRatingBaseOffset = 0x004E897E - 0x00400C00;
        private const int CashRatingLocalOffset = 10;
        private const int CashRatingValueOffset = 6;
        public int CashRatingInstruction;
        public int CashRatingValue;

        public void Initialise()
        {
            Name = NameOffset + Id;

            var entityCalculatedOffset = EntityBaseOffset + EntityLocalOffset * Id;
            var cashRatingCalculatedOffset = CashRatingBaseOffset + CashRatingLocalOffset * Id;

            EntityTypeValue = entityCalculatedOffset + EntityTypeValueOffset;
            EntityResourceValue = entityCalculatedOffset + EntityResourceValueOffset;
            EntityDataValue = entityCalculatedOffset + EntityDataValueOffset;

            CashRatingInstruction = cashRatingCalculatedOffset;
            CashRatingValue = CashRatingInstruction + CashRatingValueOffset;
        }
    }
}