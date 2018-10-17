//using System;
//using App.Core.Identities;
//using App.Shared.Data.DataLocators;

//namespace App.BaseGameEditor.Data.DataLocators
//{
//    public class SponsorshipContractDataLocator : IntegerIdentityBase, IDataLocator
//    {
//        private const int BaseOffset = 0x00401000 - 0x00400300; // TODO: Get location of where module instructions start;

//        public int EntityType;

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
//                    EntityType = 1; // Team Sponsor
//                    contractCalculatedOffset = TeamContractBaseOffset + TeamContractLocalOffset * Id;
//                    break;
//                case int n when (n >= 7 && n < 10):
//                    EntityType = 3; // Tyre Supplier
//                    contractCalculatedOffset = TyreContractBaseOffset + TyreContractLocalOffset * (Id - 7);
//                    break;
//                case int n when (n >= 10 && n < 18):
//                    EntityType = 2; // Engine Supplier
//                    contractCalculatedOffset = EngineContractBaseOffset + EngineContractLocalOffset * (Id - 10);
//                    break;
//                case int n when (n >= 18 && n < 27):
//                    EntityType = 4; // Fuel Supplier
//                    contractCalculatedOffset = FuelContractBaseOffset + FuelContractLocalOffset * (Id - 18);
//                    break;
//                case int n when (n >= 27 && n < 98):
//                    EntityType = 5; // Cash Sponsor
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