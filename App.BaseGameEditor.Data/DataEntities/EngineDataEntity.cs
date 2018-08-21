using System;
using App.Core.Entities;
using App.Core.Identities;
using App.Shared.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class EngineDataEntity : IntegerIdentityBase, IEntity
    {
        public EngineDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }
    }
}