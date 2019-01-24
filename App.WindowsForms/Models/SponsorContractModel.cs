using System;
using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class SponsorContractModel : IntegerIdentityBase, IEntity
    {
        public int TeamId { get; set; }
        public int SlotId { get; set; }
        public string SlotDescription
        {
            get
            {
                switch (SlotId)
                {
                    case 1:
                        return "Team/Cash Sponsor";
                    case 2:
                        return "Engine Supplier";
                    case 3:
                        return "Tyre Supplier";
                    case 4:
                        return "Fuel Supplier";
                    case 5:
                        return "Cash Sponsor 1";
                    case 6:
                        return "Cash Sponsor 2";
                    case 7:
                        return "Cash Sponsor 3";
                    case 8:
                        return "Cash Sponsor 4";
                    case 9:
                        return "Cash Sponsor 5";
                    case 10:
                        return "Cash Sponsor 6";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int SlotTypeId { get; set; }
        public int SponsorId { get; set; }

        public int Cash { get; set; }
        public int DealId { get; set; }
        public int TermsId { get; set; }
    }
}