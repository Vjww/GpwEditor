using System;
using App.Core.Entities;
using App.Core.Identities;
using App.Shared.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipFuelDataEntity : IntegerIdentityBase, IEntity
    {
        public SponsorshipFuelDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int CashRating { get; set; }
        public bool CashRatingRandom { get; set; }
        public int RadRating { get; set; }
        public bool RadRatingRandom { get; set; }
        public bool Inactive { get; set; }

        public int Performance { get; set; }
        public int Tolerance { get; set; }

        // TODO: Remove temporary entity/sponsor fields below, as are used in aid of module development
        public int EntityType { get; set; }
        public int EntityResource { get; set; }
        public int EntityData { get; set; }
        public int SponsorId { get; set; }
        public int SponsorType { get; set; }
    }
}