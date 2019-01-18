using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class SponsorContractModel : IntegerIdentityBase, IEntity
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