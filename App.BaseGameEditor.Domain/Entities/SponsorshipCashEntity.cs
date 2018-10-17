﻿using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class SponsorshipCashEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int CashRating { get; set; }

        // TODO: Remove temporary entity/sponsor fields below, as are used in aid of module development
        public int EntityType { get; set; }
        public int EntityResource { get; set; }
        public int EntityData { get; set; }
        public int SponsorId { get; set; }
        public int SponsorType { get; set; }
    }
}