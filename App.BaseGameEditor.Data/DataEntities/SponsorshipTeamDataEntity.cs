using System;
using App.Core.Entities;
using App.Core.Identities;
using App.Shared.Data.Calculators;
using App.Shared.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipTeamDataEntity : IntegerIdentityBase, IEntity
    {
        public SponsorshipTeamDataEntity(
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

        // TODO: Remove temporary entity/sponsor fields below, as are used in aid of module development
        public int EntityType { get; set; }
        public int EntityResource { get; set; }
        public int EntityData { get; set; }
        public int SponsorId { get; set; }
        public int SponsorType { get; set; }
    }
}