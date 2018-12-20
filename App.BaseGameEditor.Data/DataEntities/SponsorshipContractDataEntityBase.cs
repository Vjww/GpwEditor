using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public abstract class SponsorshipContractDataEntityBase : IntegerIdentityBase, IEntity
    {
        public int TeamId { get; set; }
        public int SlotId { get; set; }
        public int SponsorType { get; set; }
        public int SponsorId { get; set; }

        public int ContractValue { get; set; }
        public int ContractDeal { get; set; }
        public int ContractTerms { get; set; }
    }
}