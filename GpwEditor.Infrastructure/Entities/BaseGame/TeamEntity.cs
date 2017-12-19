using System;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.Catalogues.Language;

namespace GpwEditor.Infrastructure.Entities.BaseGame
{
    public class TeamEntity : EntityBase
    {
        public TeamEntity(LanguageCatalogueString languageCatalogueString)
        {
            Name = languageCatalogueString ?? throw new ArgumentNullException(nameof(languageCatalogueString));
        }

        public LanguageCatalogueString Name { get; set; }
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