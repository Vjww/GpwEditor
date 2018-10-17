using System;
using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorshipTyreDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 4883; // "Bridgestone"

        private const int TyreASupplierBaseOffset = 2010493;
        private const int TyreATeamBaseOffset = 2010355;
        private const int TyreBSupplierBaseOffset = 2009688;
        private const int TyreBTeamBaseOffset = 2009550;
        private const int TyreCSupplierBaseOffset = 2011818;
        private const int TyreCTeamBaseOffset = 2011160;

        public int Name { get; set; }
        public int DryHardGripSupplier { get; set; }
        public int DryHardResilienceSupplier { get; set; }
        public int DryHardStiffnessSupplier { get; set; }
        public int DryHardTemperatureSupplier { get; set; }
        public int DrySoftGripSupplier { get; set; }
        public int DrySoftResilienceSupplier { get; set; }
        public int DrySoftStiffnessSupplier { get; set; }
        public int DrySoftTemperatureSupplier { get; set; }
        public int IntermediateGripSupplier { get; set; }
        public int IntermediateResilienceSupplier { get; set; }
        public int IntermediateStiffnessSupplier { get; set; }
        public int IntermediateTemperatureSupplier { get; set; }
        public int WetWeatherGripSupplier { get; set; }
        public int WetWeatherResilienceSupplier { get; set; }
        public int WetWeatherStiffnessSupplier { get; set; }
        public int WetWeatherTemperatureSupplier { get; set; }

        public int DryHardGripTeam { get; set; }
        public int DryHardResilienceTeam { get; set; }
        public int DryHardStiffnessTeam { get; set; }
        public int DryHardTemperatureTeam { get; set; }
        public int DrySoftGripTeam { get; set; }
        public int DrySoftResilienceTeam { get; set; }
        public int DrySoftStiffnessTeam { get; set; }
        public int DrySoftTemperatureTeam { get; set; }
        public int IntermediateGripTeam { get; set; }
        public int IntermediateResilienceTeam { get; set; }
        public int IntermediateStiffnessTeam { get; set; }
        public int IntermediateTemperatureTeam { get; set; }
        public int WetWeatherGripTeam { get; set; }
        public int WetWeatherResilienceTeam { get; set; }
        public int WetWeatherStiffnessTeam { get; set; }
        public int WetWeatherTemperatureTeam { get; set; }

        // TODO: Remove temporary entity fields below, as are used in aid of module development
        private const int EntityBaseOffset = 0x004E7B46 - 0x00400C00;
        private const int EntityLocalOffset = 40;
        private const int EntityTypeValueOffset = 6;
        private const int EntityResourceValueOffset = 8;
        private const int EntityDataValueOffset = 27;
        public int EntityTypeValue;
        public int EntityResourceValue;
        public int EntityDataValue;

        private const int CashRatingBaseOffset = 0x004E89C4 - 0x00400C00;
        private const int CashRatingLocalOffset = 16;
        private const int CashRatingValueOffset = 6;
        public int CashRatingInstruction;
        public int CashRatingValue;

        private const int RadRatingBaseOffset = 0x004E8DCA - 0x00400C00;
        private const int RadRatingLocalOffset = 16;
        private const int RadRatingValueOffset = 6;
        public int RadRatingInstruction;
        public int RadRatingValue;

        private const int InactiveBaseOffset = 0x004E8F0A - 0x00400C00;
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

            int baseOffset;
            int stepOffset;
            int tyreOffset;

            switch (Id)
            {
                case 0:
                    tyreOffset = 200;

                    baseOffset = TyreASupplierBaseOffset;
                    stepOffset = 10;
                    DryHardGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 0;
                    DryHardResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 0;
                    DryHardStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 0;
                    DryHardTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 0;
                    DrySoftGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 1;
                    DrySoftResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 1;
                    DrySoftStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 1;
                    DrySoftTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 1;
                    IntermediateGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 2;
                    IntermediateResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 2;
                    IntermediateStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 2;
                    IntermediateTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 2;
                    WetWeatherGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 3;
                    WetWeatherResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 3;
                    WetWeatherStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 3;
                    WetWeatherTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 3;

                    baseOffset = TyreATeamBaseOffset;
                    stepOffset = 32;
                    DryHardGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 0;
                    DryHardResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 0;
                    DryHardStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 0;
                    DryHardTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 0;
                    DrySoftGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 1;
                    DrySoftResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 1;
                    DrySoftStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 1;
                    DrySoftTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 1;
                    IntermediateGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 2;
                    IntermediateResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 2;
                    IntermediateStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 2;
                    IntermediateTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 2;
                    WetWeatherGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 3;
                    WetWeatherResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 3;
                    WetWeatherStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 3;
                    WetWeatherTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 3;
                    break;
                case 1:
                    tyreOffset = 200;

                    baseOffset = TyreBSupplierBaseOffset;
                    stepOffset = 10;
                    DryHardGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 0;
                    DryHardResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 0;
                    DryHardStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 0;
                    DryHardTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 0;
                    DrySoftGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 1;
                    DrySoftResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 1;
                    DrySoftStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 1;
                    DrySoftTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 1;
                    IntermediateGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 2;
                    IntermediateResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 2;
                    IntermediateStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 2;
                    IntermediateTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 2;
                    WetWeatherGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 3;
                    WetWeatherResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 3;
                    WetWeatherStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 3;
                    WetWeatherTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 3;

                    baseOffset = TyreBTeamBaseOffset;
                    stepOffset = 32;
                    DryHardGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 0;
                    DryHardResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 0;
                    DryHardStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 0;
                    DryHardTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 0;
                    DrySoftGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 1;
                    DrySoftResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 1;
                    DrySoftStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 1;
                    DrySoftTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 1;
                    IntermediateGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 2;
                    IntermediateResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 2;
                    IntermediateStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 2;
                    IntermediateTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 2;
                    WetWeatherGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 3;
                    WetWeatherResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 3;
                    WetWeatherStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 3;
                    WetWeatherTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 3;
                    break;
                case 2:
                    tyreOffset = 40;

                    baseOffset = TyreCSupplierBaseOffset;
                    stepOffset = 10;
                    DryHardGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 0;
                    DryHardResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 0;
                    DryHardStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 0;
                    DryHardTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 0;
                    DrySoftGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 1;
                    DrySoftResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 1;
                    DrySoftStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 1;
                    DrySoftTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 1;
                    IntermediateGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 2;
                    IntermediateResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 2;
                    IntermediateStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 2;
                    IntermediateTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 2;
                    WetWeatherGripSupplier = baseOffset + stepOffset * 0 + tyreOffset * 3;
                    WetWeatherResilienceSupplier = baseOffset + stepOffset * 1 + tyreOffset * 3;
                    WetWeatherStiffnessSupplier = baseOffset + stepOffset * 2 + tyreOffset * 3;
                    WetWeatherTemperatureSupplier = baseOffset + stepOffset * 3 + tyreOffset * 3;

                    tyreOffset = 160;

                    baseOffset = TyreCTeamBaseOffset;
                    stepOffset = 32;
                    DryHardGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 0;
                    DryHardResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 0;
                    DryHardStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 0;
                    DryHardTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 0;
                    DrySoftGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 1;
                    DrySoftResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 1;
                    DrySoftStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 1;
                    DrySoftTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 1;
                    IntermediateGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 2;
                    IntermediateResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 2;
                    IntermediateStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 2;
                    IntermediateTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 2;
                    WetWeatherGripTeam = baseOffset + stepOffset * 0 + tyreOffset * 3;
                    WetWeatherResilienceTeam = baseOffset + stepOffset * 1 + tyreOffset * 3;
                    WetWeatherStiffnessTeam = baseOffset + stepOffset * 2 + tyreOffset * 3;
                    WetWeatherTemperatureTeam = baseOffset + stepOffset * 3 + tyreOffset * 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Id));
            }

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