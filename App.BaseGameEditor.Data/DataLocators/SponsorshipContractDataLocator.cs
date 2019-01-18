using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorshipContractDataLocator : IntegerIdentityBase, IDataLocator
    {
        //    0x00001E90 (7824) between each team block

        //Slot Base Address for Williams: 01205270 (sponsor 1)
        //- initialise blocks where required
        //- values in the 98 sponsor addresses per team

        //Cash Base Address for Williams: 0120513C(sponsor 1)
        //Team + 0
        //Engine + 4
        //Tyre + 8
        //Fuel + 12
        //Cash + 16, 20, 24, 28, 32, 36
        //FIA + 700

        //FIA Base Address for Williams: 012053F8
        //FIA Base Address for Williams: 009C8134

        //- Ferrari 01207288 +1E90
        //- Ferrari 009C8138 +4



        // TODO: The fields below are the fields we need to fulfill in the entity
        // TODO: So we need to know where we can find this data or provide the importer/exporter with clues to find the data
        //public int TeamId { get; set; }
        //public int SlotId { get; set; }
        //public int SponsorTypeId { get; set; }
        //public int SponsorId { get; set; }
        //public int ContractValue { get; set; }
        //public int ContractDeal { get; set; }
        //public int ContractTerms { get; set; }

        private const int SlotBaseOffset = 0x00401984 - 0x00400C00;

        private const int SlotTeamOffset = 7824;
        private const int SlotLocalOffset = 10;
        private const int SlotInstructionOffset = 0;
        private const int SlotAddressOffset = 2;
        private const int SlotValueOffset = 6;

        public int SlotInstruction(int teamId, int recordId) => SlotBaseOffset + SlotTeamOffset * (teamId - 1) + SlotLocalOffset * (recordId - 1) + SlotInstructionOffset;
        public int SlotAddress(int teamId, int recordId) => SlotBaseOffset + SlotTeamOffset * (teamId - 1) + SlotLocalOffset * (recordId - 1) + SlotAddressOffset;
        public int SlotValue(int teamId, int recordId) => SlotBaseOffset + SlotTeamOffset * (teamId - 1) + SlotLocalOffset * (recordId - 1) + SlotValueOffset;

        private const int CashSponsorshipBaseOffset = 0x00401DD0 - 0x00400C00;

        private const int CashSponsorshipTeamOffset = 100;
        private const int CashSponsorshipLocalOffset = 10;
        private const int CashSponsorshipValueOffset = 6;

        public int CashSponsorshipValue(int teamId, int recordId) => CashSponsorshipBaseOffset + CashSponsorshipTeamOffset * (teamId - 1) + CashSponsorshipLocalOffset * (recordId - 1) + CashSponsorshipValueOffset;

        public void Initialise()
        {
        }
    }
}

//using System;
//using App.Core.Identities;
//using App.Shared.Data.DataLocators;

//namespace App.BaseGameEditor.Data.DataLocators
//{
//    public class SponsorshipContractDataLocator : IntegerIdentityBase, IDataLocator
//    {
//        private const int BaseOffset = 0x00401000 - 0x00400300; // TODO: Get location of where module instructions start;

//        public int EntityTypeId;

//        // Contract
//        private const int TeamContractBaseOffset = BaseOffset;
//        private const int TyreContractBaseOffset = TeamContractBaseOffset + 70;
//        private const int EngineContractBaseOffset = TyreContractBaseOffset + 550;
//        private const int FuelContractBaseOffset = EngineContractBaseOffset + 550;
//        private const int CashContractBaseOffset = FuelContractBaseOffset + 550;
//        private const int TeamContractLocalOffset = 10;
//        private const int TyreContractLocalOffset = 50;
//        private const int EngineContractLocalOffset = 50;
//        private const int FuelContractLocalOffset = 50;
//        private const int CashContractLocalOffset = 10;
//        private const int ContractTeamIdInstructionOffset = 0;
//        private const int ContractTeamIdAddressOffset = 2;
//        private const int ContractTeamIdValueOffset = 6;
//        private const int ContractDealAInstructionOffset = 10;
//        private const int ContractDealAAddressOffset = 12;
//        private const int ContractDealAValueOffset = 16;
//        private const int ContractDealBInstructionOffset = 20;
//        private const int ContractDealBAddressOffset = 22;
//        private const int ContractDealBValueOffset = 26;
//        private const int ContractTermsAInstructionOffset = 30;
//        private const int ContractTermsAAddressOffset = 32;
//        private const int ContractTermsAValueOffset = 36;
//        private const int ContractTermsBInstructionOffset = 40;
//        private const int ContractTermsBAddressOffset = 42;
//        private const int ContractTermsBValueOffset = 46;
//        public int ContractTeamIdInstruction;
//        public int ContractTeamIdAddress;
//        public int ContractTeamIdValue;
//        public int SupplierContractDealAInstruction;
//        public int SupplierContractDealAAddress;
//        public int SupplierContractDealAValue;
//        public int SupplierContractDealBInstruction;
//        public int SupplierContractDealBAddress;
//        public int SupplierContractDealBValue;
//        public int SupplierContractTermsAInstruction;
//        public int SupplierContractTermsAAddress;
//        public int SupplierContractTermsAValue;
//        public int SupplierContractTermsBInstruction;
//        public int SupplierContractTermsBAddress;
//        public int SupplierContractTermsBValue;

//        // TODO: // Slot
//        // TODO: private const int SlotBaseOffset = CashContractBaseOffset + 710; // Plus length of CashContract instructions
//        // TODO: private const int SlotLocalOffset = 10;
//        // TODO: private const int SlotInstructionOffset = 0;
//        // TODO: private const int SlotAddressOffset = 2;
//        // TODO: private const int SlotValueOffset = 6;
//        // TODO: public int SlotInstruction;
//        // TODO: public int SlotAddress;
//        // TODO: public int SlotValue;

//        // Cash Sponsorship
//        // TODO:

//        // Fia Sponsorship
//        // TODO:

//        public void Initialise()
//        {
//            int contractCalculatedOffset;

//            switch (Id)
//            {
//                case int n when (n >= 0 && n < 7):
//                    EntityTypeId = 1; // Team Sponsor
//                    contractCalculatedOffset = TeamContractBaseOffset + TeamContractLocalOffset * Id;
//                    break;
//                case int n when (n >= 7 && n < 10):
//                    EntityTypeId = 3; // Tyre Supplier
//                    contractCalculatedOffset = TyreContractBaseOffset + TyreContractLocalOffset * (Id - 7);
//                    break;
//                case int n when (n >= 10 && n < 18):
//                    EntityTypeId = 2; // Engine Supplier
//                    contractCalculatedOffset = EngineContractBaseOffset + EngineContractLocalOffset * (Id - 10);
//                    break;
//                case int n when (n >= 18 && n < 27):
//                    EntityTypeId = 4; // Fuel Supplier
//                    contractCalculatedOffset = FuelContractBaseOffset + FuelContractLocalOffset * (Id - 18);
//                    break;
//                case int n when (n >= 27 && n < 98):
//                    EntityTypeId = 5; // Cash Sponsor
//                    contractCalculatedOffset = CashContractBaseOffset + CashContractLocalOffset * (Id - 27);
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException(nameof(Id));
//            }

//            ContractTeamIdInstruction = contractCalculatedOffset + ContractTeamIdInstructionOffset;
//            ContractTeamIdAddress = contractCalculatedOffset + ContractTeamIdAddressOffset;
//            ContractTeamIdValue = contractCalculatedOffset + ContractTeamIdValueOffset;
//            SupplierContractDealAInstruction = contractCalculatedOffset + ContractDealAInstructionOffset;
//            SupplierContractDealAAddress = contractCalculatedOffset + ContractDealAAddressOffset;
//            SupplierContractDealAValue = contractCalculatedOffset + ContractDealAValueOffset;
//            SupplierContractDealBInstruction = contractCalculatedOffset + ContractDealBInstructionOffset;
//            SupplierContractDealBAddress = contractCalculatedOffset + ContractDealBAddressOffset;
//            SupplierContractDealBValue = contractCalculatedOffset + ContractDealBValueOffset;
//            SupplierContractTermsAInstruction = contractCalculatedOffset + ContractTermsAInstructionOffset;
//            SupplierContractTermsAAddress = contractCalculatedOffset + ContractTermsAAddressOffset;
//            SupplierContractTermsAValue = contractCalculatedOffset + ContractTermsAValueOffset;
//            SupplierContractTermsBInstruction = contractCalculatedOffset + ContractTermsBInstructionOffset;
//            SupplierContractTermsBAddress = contractCalculatedOffset + ContractTermsBAddressOffset;
//            SupplierContractTermsBValue = contractCalculatedOffset + ContractTermsBValueOffset;

//            // TODO: Calculate below values
//            // TODO: Slots

//            // TODO: Calculate below values
//            // TODO: Cash sponsorship

//            // TODO: Calculate below values
//            // TODO: Fia sponsorship
//        }

//        /*
//        private const int BaseAddress = 0x0120513C; // TODO: No conversion required, as address, not offset
//        private const int LocalAddressOffset = 7824;
//        private const int FundsAddressOffset = 0;
//        private const int SlotAddressOffset = 308;
//        private const int FiaFundsAddressOffset = 700;

//        private const int SecondaryFiaFundsBaseAddress = 0x009C8134;
//        private const int SecondaryFiaFundsAddressOffset = 4;

//        private const int BaseAddress = 0x0120513C; // Convert
//        private const int LocalOffset = 7824
//        private const int CashOffset = 0
//        private const int SlotOffset = 308
//        private const int FiaCash1Offset = 700
//        private const int FiaCash2BaseAddress = 0x009C8134

//            Where SponsorId = 1 to 98

//            SlotId - 1 * 4		Value = CashVlaue
//        SponsorId - 1 * 4		Value = SlotId (1-10)

//                TeamId -1 * 4


//         // How to write entity data
//        public int SponsorEntitiesBaseOffset = 0x00401000 - 0x00400300; // TODO: Get location of where module instructions start
//        public int SponsorEntitiesAddressLocalOffset = 1556;
//        public int SponsorshipTypeBaseAddress = 0x007E62C6;

//        // Move (SponsorshipTypeBaseAddress + SponsorEntitiesAddressLocalOffset * Id) into BaseOffset + 2 + Id * StructSize
//        // Move SponsorshipType into BaseAddress 7E62C6 at BaseOffset

//         */
//    }
//}