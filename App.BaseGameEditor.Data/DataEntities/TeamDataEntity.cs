using System;
using App.Core.Entities;
using App.Core.Identities;
using App.Shared.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntity : IntegerIdentityBase, IEntity
    {
        public TeamDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int DebutGrandPrix { get; set; }
        public int DebutYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int UnknownA { get; set; }
        public int Location { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int TyreSupplier { get; set; }
    }
}