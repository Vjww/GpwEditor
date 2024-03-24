using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorContractDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int SlotBaseOffset = 0x00401984 - 0x00400C00;
        private const int SlotLocalOffset = 10;
        private const int SlotInstructionOffset = 0;
        private const int SlotAddressOffset = 2;
        private const int SlotValueOffset = 6;
        private const int CashBaseOffset = 0x00401DD0 - 0x00400C00;
        private const int CashLocalOffset = 10;
        private const int CashInstructionOffset = 0;
        private const int CashValueOffset = 6;

        public int SlotInstruction { get; set; }
        public int SlotAddress { get; set; }
        public int SlotValue { get; set; }
        public int CashInstruction { get; set; }
        public int CashValue { get; set; }

        public void Initialise()
        {
            var slotStepOffset = SlotLocalOffset * Id;
            SlotInstruction = SlotBaseOffset + slotStepOffset + SlotInstructionOffset;
            SlotAddress = SlotBaseOffset + slotStepOffset + SlotAddressOffset;
            SlotValue = SlotBaseOffset + slotStepOffset + SlotValueOffset;

            var cashStepOffset = CashLocalOffset * Id;
            CashInstruction = CashBaseOffset + cashStepOffset + CashInstructionOffset;
            CashValue = CashBaseOffset + cashStepOffset + CashValueOffset;
        }
    }
}