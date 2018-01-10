using System;
using App.BaseGameEditor.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.Entities
{
    public class TeamEntity : EntityBase
    {
        public TeamEntity(ILanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public ILanguageCatalogueValue Name { get; set; }
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int FirstGpTrack { get; set; }
        public int FirstGpYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int UnknownA { get; set; }
        public int CountryMapId { get; set; }
        public int LocationPointerX { get; set; }
        public int LocationPointerY { get; set; }
        public int TyreSupplierId { get; set; }
    }
}