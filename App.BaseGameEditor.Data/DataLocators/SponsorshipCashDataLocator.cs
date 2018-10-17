using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorshipCashDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 4903; // "Brastemp"

        public int Name { get; set; }

        // TODO: Remove temporary entity fields below, as are used in aid of module development
        private const int EntityBaseOffset = 0x004E7E66 - 0x00400C00;
        private const int EntityLocalOffset = 40;
        private const int EntityTypeValueOffset = 6;
        private const int EntityResourceValueOffset = 8;
        private const int EntityDataValueOffset = 27;
        public int EntityTypeValue;
        public int EntityResourceValue;
        public int EntityDataValue;

        private const int CashCashRatingBaseOffset = 0x004E8B04 - 0x00400C00;
        private const int CashCashRatingLocalOffset = 10;
        private const int CashRatingValueOffset = 6;
        public int CashRatingInstruction;
        public int CashRatingValue;

        public void Initialise()
        {
            Name = NameOffset + Id;

            var entityCalculatedOffset = EntityBaseOffset + EntityLocalOffset * Id;
            var cashRatingCalculatedOffset = CashCashRatingBaseOffset + CashCashRatingLocalOffset * Id;

            EntityTypeValue = entityCalculatedOffset + EntityTypeValueOffset;
            EntityResourceValue = entityCalculatedOffset + EntityResourceValueOffset;
            EntityDataValue = entityCalculatedOffset + EntityDataValueOffset;

            CashRatingInstruction = cashRatingCalculatedOffset;
            CashRatingValue = CashRatingInstruction + CashRatingValueOffset;
        }
    }
}