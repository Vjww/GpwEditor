using System;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TrackDataEntity : IntegerIdentityBase, IEntity
    {
        public TrackDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int Laps { get; set; }
        public int Layout { get; set; }
        public int LapRecordDriver { get; set; }
        public int LapRecordTeam { get; set; }
        public int LapRecordTime { get; set; }
        public int LapRecordMph { get; set; }
        public int LapRecordYear { get; set; }
        public int LastRaceDriver { get; set; }
        public int LastRaceTeam { get; set; }
        public int LastRaceYear { get; set; }
        public int LastRaceTime { get; set; }
        public int Hospitality { get; set; }
        public int Speed { get; set; }
        public int Grip { get; set; }
        public int Surface { get; set; }
        public int Tarmac { get; set; }
        public int Dust { get; set; }
        public int Overtaking { get; set; }
        public int Braking { get; set; }
        public int Rain { get; set; }
        public int Heat { get; set; }
        public int Wind { get; set; }
    }
}