// TODO: Is this redundant? Superseded by SponsorDataEntity?

//using System;
//using App.Core.Entities;
//using App.Core.Identities;
//using App.Shared.Data.Catalogues.Language;

//namespace App.BaseGameEditor.Data.DataEntities
//{
//    public class SponsorshipTeamDataEntity : IntegerIdentityBase, IEntity
//    {
//        public SponsorshipTeamDataEntity(LanguageCatalogueValue languageCatalogueValue)
//        {
//            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
//        }

//        public LanguageCatalogueValue Name { get; set; }
//        public int SponsorId { get; set; }
//        public int SponsorType { get; set; }
//        public int EntityType { get; set; }
//        public int EntityResource { get; set; }
//        public int EntityData { get; set; }
//        public int CashRating { get; set; }
//    }
//}