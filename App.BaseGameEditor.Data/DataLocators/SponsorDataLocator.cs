using System;
using App.Core.Identities;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorDataLocator : IntegerIdentityBase, IDataLocator
    {
        private readonly IdentityCalculator _identityCalculator;

        private const int NameOffset = 4876; // "Buzzin Hornets"

        private const int EntityBaseOffset = 0x004E7A2E - 0x00400C00;
        private const int EntityLocalOffset = 40;
        private const int EntityTypeValueOffset = 6;
        private const int EntityResourceValueOffset = 8;
        private const int EntityDataValueOffset = 27;
        private const int CashRatingTeamBaseOffset = 0x004E897E - 0x00400C00;
        private const int CashRatingTeamLocalOffset = 10;
        private const int CashRatingEngineBaseOffset = 0x004E89F4 - 0x00400C00;
        private const int CashRatingEngineLocalOffset = 16;
        private const int CashRatingTyreBaseOffset = 0x004E89C4 - 0x00400C00;
        private const int CashRatingTyreLocalOffset = 16;
        private const int CashRatingFuelBaseOffset = 0x004E8A74 - 0x00400C00;
        private const int CashRatingFuelLocalOffset = 16;
        private const int CashRatingCashBaseOffset = 0x004E8B04 - 0x00400C00;
        private const int CashRatingCashLocalOffset = 10;
        private const int CashRatingValueOffset = 6;
        private const int RadRatingEngineBaseOffset = 0x004E8DFA - 0x00400C00;
        private const int RadRatingEngineLocalOffset = 16;
        private const int RadRatingTyreBaseOffset = 0x004E8DCA - 0x00400C00;
        private const int RadRatingTyreLocalOffset = 16;
        private const int RadRatingFuelBaseOffset = 0x004E8E7A - 0x00400C00;
        private const int RadRatingFuelLocalOffset = 16;
        private const int RadRatingValueOffset = 6;
        private const int InactiveEngineBaseOffset = 0x004E8F28 - 0x00400C00;
        private const int InactiveEngineLocalOffset = 10;
        private const int InactiveTyreBaseOffset = 0x004E8F0A - 0x00400C00;
        private const int InactiveTyreLocalOffset = 10;
        private const int InactiveFuelBaseOffset = 0x004E8F78 - 0x00400C00;
        private const int InactiveFuelLocalOffset = 10;
        private const int InactiveInstructionOffset = 0;
        private const int InactiveAddressOffset = 2;
        private const int InactiveValueOffset = 6;
        private const int ContractTeamBaseOffset = 0x00401007 - 0x00400C00;
        private const int ContractTeamLocalOffset = 10;
        private const int ContractEngineBaseOffset = 0x00401272 - 0x00400C00;
        public const int ContractEngineLocalOffset = 50; // Intentionally scoped as public for import/export logic to utilise.
        private const int ContractTyreBaseOffset = 0x0040104C - 0x00400C00;
        public const int ContractTyreLocalOffset = 50; // Intentionally scoped as public for import/export logic to utilise.
        private const int ContractFuelBaseOffset = 0x00401498 - 0x00400C00;
        public const int ContractFuelLocalOffset = 50; // Intentionally scoped as public for import/export logic to utilise.
        private const int ContractCashBaseOffset = 0x004016BF - 0x00400C00;
        private const int ContractCashLocalOffset = 10;
        private const int ContractTeamIdAddressOffset = 2;
        private const int ContractTeamIdValueOffset = 6;
        private const int ContractDealIdSponsorAddressOffset = 12;
        private const int ContractDealIdSponsorValueOffset = 16;
        private const int ContractDealIdTeamAddressOffset = 22;
        private const int ContractDealIdTeamValueOffset = 26;
        private const int ContractTermsIdSponsorAddressOffset = 32;
        private const int ContractTermsIdSponsorValueOffset = 36;
        private const int ContractTermsIdTeamAddressOffset = 42;
        private const int ContractTermsIdTeamValueOffset = 46;

        private const int EngineBaseOffset = 2756160;
        private const int EngineLocalOffset = 28;
        private const int EngineFuelOffset = 0;
        private const int EngineHeatOffset = 4;
        private const int EnginePowerOffset = 8;
        private const int EngineReliabilityOffset = 12;
        private const int EngineResponseOffset = 16;
        private const int EngineRigidityOffset = 20;
        private const int EngineWeightOffset = 24;
        private const int TyreASupplierBaseOffset = 2010493;
        private const int TyreATeamBaseOffset = 2010355;
        private const int TyreBSupplierBaseOffset = 2009688;
        private const int TyreBTeamBaseOffset = 2009550;
        private const int TyreCSupplierBaseOffset = 2011818;
        private const int TyreCTeamBaseOffset = 2011160;
        private const int FuelBaseOffset = 2756384;
        private const int FuelLocalOffset = 8;
        private const int FuelPerformanceOffset = 0;
        private const int FuelToleranceOffset = 4;

        public int Name { get; set; }

        public int EntityTypeValue { get; set; }
        public int EntityResourceValue { get; set; }
        public int EntityDataValue { get; set; }
        public int CashRatingInstruction { get; set; }
        public int CashRatingValue { get; set; }
        public int RadRatingInstruction { get; set; }
        public int RadRatingValue { get; set; }
        public int InactiveInstruction { get; set; }
        public int InactiveAddress { get; set; }
        public int InactiveValue { get; set; }

        public int ContractTeamAddress { get; set; }
        public int ContractTeamValue { get; set; }
        public int ContractEngineTeamIdAddress { get; set; }
        public int ContractEngineTeamIdValue { get; set; }
        public int ContractEngineDealIdSponsorAddress { get; set; }
        public int ContractEngineDealIdSponsorValue { get; set; }
        public int ContractEngineDealIdTeamAddress { get; set; }
        public int ContractEngineDealIdTeamValue { get; set; }
        public int ContractEngineTermsIdSponsorAddress { get; set; }
        public int ContractEngineTermsIdSponsorValue { get; set; }
        public int ContractEngineTermsIdTeamAddress { get; set; }
        public int ContractEngineTermsIdTeamValue { get; set; }
        public int ContractTyreTeamIdAddress { get; set; }
        public int ContractTyreTeamIdValue { get; set; }
        public int ContractTyreDealIdSponsorAddress { get; set; }
        public int ContractTyreDealIdSponsorValue { get; set; }
        public int ContractTyreDealIdTeamAddress { get; set; }
        public int ContractTyreDealIdTeamValue { get; set; }
        public int ContractTyreTermsIdSponsorAddress { get; set; }
        public int ContractTyreTermsIdSponsorValue { get; set; }
        public int ContractTyreTermsIdTeamAddress { get; set; }
        public int ContractTyreTermsIdTeamValue { get; set; }
        public int ContractFuelTeamIdAddress { get; set; }
        public int ContractFuelTeamIdValue { get; set; }
        public int ContractFuelDealIdSponsorAddress { get; set; }
        public int ContractFuelDealIdSponsorValue { get; set; }
        public int ContractFuelDealIdTeamAddress { get; set; }
        public int ContractFuelDealIdTeamValue { get; set; }
        public int ContractFuelTermsIdSponsorAddress { get; set; }
        public int ContractFuelTermsIdSponsorValue { get; set; }
        public int ContractFuelTermsIdTeamAddress { get; set; }
        public int ContractFuelTermsIdTeamValue { get; set; }
        public int ContractCashAddress { get; set; }
        public int ContractCashValue { get; set; }

        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }
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
        public int Performance { get; set; }
        public int Tolerance { get; set; }

        public SponsorDataLocator(IdentityCalculator identityCalculator)
        {
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public void Initialise()
        {
            Name = NameOffset + Id;

            var localId = _identityCalculator.GetSponsorId(Id) - 1;
            var localTypeId = _identityCalculator.GetSponsorTypeId(Id);

            // Initialise Entity fields
            var entityCalculatedOffset = EntityBaseOffset + EntityLocalOffset * Id;
            EntityTypeValue = entityCalculatedOffset + EntityTypeValueOffset;
            EntityResourceValue = entityCalculatedOffset + EntityResourceValueOffset;
            EntityDataValue = entityCalculatedOffset + EntityDataValueOffset;

            switch (localTypeId)
            {
                case 1: // Team Sponsor
                case 5: // Cash Sponsor
                    InitialiseCashRatingFields(localId, localTypeId);
                    InitialiseContractFields(localId, localTypeId);
                    break;
                case 2: // Engine Supplier
                case 3: // Tyre Supplier
                case 4: // Fuel Supplier
                    InitialiseCashRatingFields(localId, localTypeId);
                    InitialiseRadRatingFields(localId, localTypeId);
                    InitialiseInactiveFields(localId, localTypeId);
                    InitialiseContractFields(localId, localTypeId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localTypeId));
            }

            switch (localTypeId)
            {
                case 1: // Team Sponsor
                    break;
                case 2: // Engine Supplier
                    InitialiseEngineAttributeFields(localId);
                    break;
                case 3: // Tyre Supplier
                    InitialiseTyreAttributeFields(localId);
                    break;
                case 4: // Fuel Supplier
                    InitialiseFuelAttributeFields(localId);
                    break;
                case 5: // Cash Sponsor
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localTypeId));
            }
        }

        private void InitialiseCashRatingFields(int localId, int localTypeId)
        {
            int cashRatingCalculatedOffset;
            switch (localTypeId)
            {
                case 1: // Team Sponsor
                    cashRatingCalculatedOffset = CashRatingTeamBaseOffset + CashRatingTeamLocalOffset * localId;
                    break;
                case 2: // Engine Supplier
                    cashRatingCalculatedOffset = CashRatingEngineBaseOffset + CashRatingEngineLocalOffset * localId;
                    break;
                case 3: // Tyre Supplier
                    cashRatingCalculatedOffset = CashRatingTyreBaseOffset + CashRatingTyreLocalOffset * localId;
                    break;
                case 4: // Fuel Supplier
                    cashRatingCalculatedOffset = CashRatingFuelBaseOffset + CashRatingFuelLocalOffset * localId;
                    break;
                case 5: // Cash Sponsor
                    cashRatingCalculatedOffset = CashRatingCashBaseOffset + CashRatingCashLocalOffset * localId;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localTypeId));
            }

            CashRatingInstruction = cashRatingCalculatedOffset;
            CashRatingValue = cashRatingCalculatedOffset + CashRatingValueOffset;
        }

        private void InitialiseRadRatingFields(int localId, int localTypeId)
        {
            int radRatingCalculatedOffset;
            switch (localTypeId)
            {
                case 2: // Engine Supplier
                    radRatingCalculatedOffset = RadRatingEngineBaseOffset + RadRatingEngineLocalOffset * localId;
                    break;
                case 3: // Tyre Supplier
                    radRatingCalculatedOffset = RadRatingTyreBaseOffset + RadRatingTyreLocalOffset * localId;
                    break;
                case 4: // Fuel Supplier
                    radRatingCalculatedOffset = RadRatingFuelBaseOffset + RadRatingFuelLocalOffset * localId;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localTypeId));
            }

            RadRatingInstruction = radRatingCalculatedOffset;
            RadRatingValue = radRatingCalculatedOffset + RadRatingValueOffset;
        }

        private void InitialiseInactiveFields(int localId, int localTypeId)
        {
            int inactiveCalculatedOffset;
            switch (localTypeId)
            {
                case 2: // Engine Supplier
                    inactiveCalculatedOffset = InactiveEngineBaseOffset + InactiveEngineLocalOffset * localId;
                    break;
                case 3: // Tyre Supplier
                    inactiveCalculatedOffset = InactiveTyreBaseOffset + InactiveTyreLocalOffset * localId;
                    break;
                case 4: // Fuel Supplier
                    inactiveCalculatedOffset = InactiveFuelBaseOffset + InactiveFuelLocalOffset * localId;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localTypeId));
            }

            InactiveInstruction = inactiveCalculatedOffset + InactiveInstructionOffset;
            InactiveAddress = inactiveCalculatedOffset + InactiveAddressOffset;
            InactiveValue = inactiveCalculatedOffset + InactiveValueOffset;
        }

        private void InitialiseContractFields(int localId, int localTypeId)
        {
            int contractCalculatedOffset;
            switch (localTypeId)
            {
                case 1: // Team Sponsor
                    contractCalculatedOffset = ContractTeamBaseOffset + ContractTeamLocalOffset * localId;
                    ContractTeamAddress = contractCalculatedOffset + ContractTeamIdAddressOffset;
                    ContractTeamValue = contractCalculatedOffset + ContractTeamIdValueOffset;
                    break;
                case 2: // Engine Supplier
                    // Calculated offset intentionally excludes local offset multiplier. Offsets should be managed by the import/export logic.
                    // Contracts are not guaranteed to be ordered by supplier, as a supplier can have multiple contract records.
                    contractCalculatedOffset = ContractEngineBaseOffset;

                    ContractEngineTeamIdAddress = contractCalculatedOffset + ContractTeamIdAddressOffset;
                    ContractEngineTeamIdValue = contractCalculatedOffset + ContractTeamIdValueOffset;
                    ContractEngineDealIdSponsorAddress = contractCalculatedOffset + ContractDealIdSponsorAddressOffset;
                    ContractEngineDealIdSponsorValue = contractCalculatedOffset + ContractDealIdSponsorValueOffset;
                    ContractEngineDealIdTeamAddress = contractCalculatedOffset + ContractDealIdTeamAddressOffset;
                    ContractEngineDealIdTeamValue = contractCalculatedOffset + ContractDealIdTeamValueOffset;
                    ContractEngineTermsIdSponsorAddress = contractCalculatedOffset + ContractTermsIdSponsorAddressOffset;
                    ContractEngineTermsIdSponsorValue = contractCalculatedOffset + ContractTermsIdSponsorValueOffset;
                    ContractEngineTermsIdTeamAddress = contractCalculatedOffset + ContractTermsIdTeamAddressOffset;
                    ContractEngineTermsIdTeamValue = contractCalculatedOffset + ContractTermsIdTeamValueOffset;
                    break;
                case 3: // Tyre Supplier
                    // Calculated offset intentionally excludes local offset multiplier. Offsets should be managed by the import/export logic.
                    // Contracts are not guaranteed to be ordered by supplier, as a supplier can have multiple contract records.
                    contractCalculatedOffset = ContractTyreBaseOffset;

                    ContractTyreTeamIdAddress = contractCalculatedOffset + ContractTeamIdAddressOffset;
                    ContractTyreTeamIdValue = contractCalculatedOffset + ContractTeamIdValueOffset;
                    ContractTyreDealIdSponsorAddress = contractCalculatedOffset + ContractDealIdSponsorAddressOffset;
                    ContractTyreDealIdSponsorValue = contractCalculatedOffset + ContractDealIdSponsorValueOffset;
                    ContractTyreDealIdTeamAddress = contractCalculatedOffset + ContractDealIdTeamAddressOffset;
                    ContractTyreDealIdTeamValue = contractCalculatedOffset + ContractDealIdTeamValueOffset;
                    ContractTyreTermsIdSponsorAddress = contractCalculatedOffset + ContractTermsIdSponsorAddressOffset;
                    ContractTyreTermsIdSponsorValue = contractCalculatedOffset + ContractTermsIdSponsorValueOffset;
                    ContractTyreTermsIdTeamAddress = contractCalculatedOffset + ContractTermsIdTeamAddressOffset;
                    ContractTyreTermsIdTeamValue = contractCalculatedOffset + ContractTermsIdTeamValueOffset;
                    break;
                case 4: // Fuel Supplier
                    // Calculated offset intentionally excludes local offset multiplier. Offsets should be managed by the import/export logic.
                    // Contracts are not guaranteed to be ordered by supplier, as a supplier can have multiple contract records.
                    contractCalculatedOffset = ContractFuelBaseOffset;

                    ContractFuelTeamIdAddress = contractCalculatedOffset + ContractTeamIdAddressOffset;
                    ContractFuelTeamIdValue = contractCalculatedOffset + ContractTeamIdValueOffset;
                    ContractFuelDealIdSponsorAddress = contractCalculatedOffset + ContractDealIdSponsorAddressOffset;
                    ContractFuelDealIdSponsorValue = contractCalculatedOffset + ContractDealIdSponsorValueOffset;
                    ContractFuelDealIdTeamAddress = contractCalculatedOffset + ContractDealIdTeamAddressOffset;
                    ContractFuelDealIdTeamValue = contractCalculatedOffset + ContractDealIdTeamValueOffset;
                    ContractFuelTermsIdSponsorAddress = contractCalculatedOffset + ContractTermsIdSponsorAddressOffset;
                    ContractFuelTermsIdSponsorValue = contractCalculatedOffset + ContractTermsIdSponsorValueOffset;
                    ContractFuelTermsIdTeamAddress = contractCalculatedOffset + ContractTermsIdTeamAddressOffset;
                    ContractFuelTermsIdTeamValue = contractCalculatedOffset + ContractTermsIdTeamValueOffset;
                    break;
                case 5: // Cash Sponsor
                    contractCalculatedOffset = ContractCashBaseOffset + ContractCashLocalOffset * localId;
                    ContractCashAddress = contractCalculatedOffset + ContractTeamIdAddressOffset;
                    ContractCashValue = contractCalculatedOffset + ContractTeamIdValueOffset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(localTypeId));
            }
        }

        private void InitialiseEngineAttributeFields(int localId)
        {
            var stepOffset = EngineLocalOffset * localId;

            Fuel = EngineBaseOffset + stepOffset + EngineFuelOffset;
            Heat = EngineBaseOffset + stepOffset + EngineHeatOffset;
            Power = EngineBaseOffset + stepOffset + EnginePowerOffset;
            Reliability = EngineBaseOffset + stepOffset + EngineReliabilityOffset;
            Response = EngineBaseOffset + stepOffset + EngineResponseOffset;
            Rigidity = EngineBaseOffset + stepOffset + EngineRigidityOffset;
            Weight = EngineBaseOffset + stepOffset + EngineWeightOffset;
        }

        private void InitialiseTyreAttributeFields(int localId)
        {
            int baseOffset;
            int stepOffset;
            int tyreOffset;

            switch (localId)
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
                    throw new ArgumentOutOfRangeException(nameof(localId));
            }
        }

        private void InitialiseFuelAttributeFields(int localId)
        {
            var stepOffset = FuelLocalOffset * localId;

            Performance = FuelBaseOffset + stepOffset + FuelPerformanceOffset;
            Tolerance = FuelBaseOffset + stepOffset + FuelToleranceOffset;
        }
    }
}