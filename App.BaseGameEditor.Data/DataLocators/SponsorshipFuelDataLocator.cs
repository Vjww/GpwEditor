using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorshipFuelDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 4894; // "Petrobras"

        private const int BaseOffset = 2756384;
        private const int LocalOffset = 8;
        private const int PerformanceOffset = 0;
        private const int ToleranceOffset = 4;

        public int Name { get; set; }
        public int Performance { get; set; }
        public int Tolerance { get; set; }

        // TODO: Remove temporary entity fields below, as are used in aid of module development
        private const int EntityBaseOffset = 0x004E7CFE - 0x00400C00;
        private const int EntityLocalOffset = 40;
        private const int EntityTypeValueOffset = 6;
        private const int EntityResourceValueOffset = 8;
        private const int EntityDataValueOffset = 27;
        public int EntityTypeValue;
        public int EntityResourceValue;
        public int EntityDataValue;

        private const int CashRatingBaseOffset = 0x004E8A74 - 0x00400C00;
        private const int CashRatingLocalOffset = 16;
        private const int CashRatingValueOffset = 6;
        public int CashRatingInstruction;
        public int CashRatingValue;

        private const int RadRatingBaseOffset = 0x004E8E7A - 0x00400C00;
        private const int RadRatingLocalOffset = 16;
        private const int RadRatingValueOffset = 6;
        public int RadRatingInstruction;
        public int RadRatingValue;

        private const int InactiveBaseOffset = 0x004E8F78 - 0x00400C00;
        private const int InactiveLocalOffset = 10;
        private const int InactiveInstructionOffset = 0;
        private const int InactiveAddressOffset = 2;
        private const int InactiveValueOffset = 6;
        public int InactiveInstruction;
        public int InactiveAddress;
        public int InactiveValue;

        public void Initialise()
        {
            Name = NameOffset + Id;

            var stepOffset = LocalOffset * Id;

            Performance = BaseOffset + stepOffset + PerformanceOffset;
            Tolerance = BaseOffset + stepOffset + ToleranceOffset;

            var entityCalculatedOffset = EntityBaseOffset + EntityLocalOffset * Id;
            var cashRatingCalculatedOffset = CashRatingBaseOffset + CashRatingLocalOffset * Id;
            var radRatingCalculatedOffset = RadRatingBaseOffset + RadRatingLocalOffset * Id;
            var inactiveCalculatedOffset = InactiveBaseOffset + InactiveLocalOffset * Id;

            EntityTypeValue = entityCalculatedOffset + EntityTypeValueOffset;
            EntityResourceValue = entityCalculatedOffset + EntityResourceValueOffset;
            EntityDataValue = entityCalculatedOffset + EntityDataValueOffset;

            CashRatingInstruction = cashRatingCalculatedOffset;
            CashRatingValue = CashRatingInstruction + CashRatingValueOffset;

            RadRatingInstruction = radRatingCalculatedOffset;
            RadRatingValue = CashRatingInstruction + RadRatingValueOffset;

            InactiveInstruction = inactiveCalculatedOffset + InactiveInstructionOffset;
            InactiveAddress = inactiveCalculatedOffset + InactiveAddressOffset;
            InactiveValue = inactiveCalculatedOffset + InactiveValueOffset;
        }
    }
}