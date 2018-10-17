using System;
using App.Core.Entities;
using App.Core.Identities;
using App.Shared.Data.Calculators;
using App.Shared.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipEngineDataEntity : IntegerIdentityBase, IEntity
    {
        public SponsorshipEngineDataEntity(
            LanguageCatalogueValue languageCatalogueValue,
            IdentityCalculator identityCalculator)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
            if (identityCalculator == null) throw new ArgumentNullException(nameof(identityCalculator));

            SponsorId = identityCalculator.GetSponsorId(Id);
            SponsorType = identityCalculator.GetSponsorType(Id);
        }

        public LanguageCatalogueValue Name { get; set; }
        public int CashRating { get; set; }
        public bool CashRatingRandom { get; set; }
        public int RadRating { get; set; }
        public bool RadRatingRandom { get; set; }
        public bool Inactive { get; set; }

        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }

        // TODO: Remove temporary entity/sponsor fields below, as are used in aid of module development
        public int EntityType { get; set; }
        public int EntityResource { get; set; }
        public int EntityData { get; set; }
        public int SponsorId { get; set; }
        public int SponsorType { get; set; }
    }
}