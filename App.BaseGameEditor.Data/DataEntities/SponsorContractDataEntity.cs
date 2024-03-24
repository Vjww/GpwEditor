using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorContractDataEntity : IntegerIdentityBase, IEntity
    {
        public int TeamId { get; set; }
        public int SlotId { get; set; }
        public int SlotTypeId { get; set; }
        public int SponsorId { get; set; }

        public int Cash { get; set; }
        public int DealId { get; set; }
        public int TermsId { get; set; }
    }
}