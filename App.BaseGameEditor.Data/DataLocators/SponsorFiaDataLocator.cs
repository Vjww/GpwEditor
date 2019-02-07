using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class SponsorFiaDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 5696 + 1; // "No Team" -> "Williams"

        private const int BaseOffset = 0x0040221C - 0x00400C00;
        private const int LocalOffset = 20;
        private const int CashValueAOffset = 6;
        private const int CashValueBOffset = 16;

        public int Name { get; set; }
        public int CashValueA { get; set; }
        public int CashValueB { get; set; }

        public void Initialise()
        {
            Name = NameOffset + Id;

            var stepOffset = LocalOffset * Id;

            CashValueA = BaseOffset + stepOffset + CashValueAOffset;
            CashValueB = BaseOffset + stepOffset + CashValueBOffset;
        }
    }
}