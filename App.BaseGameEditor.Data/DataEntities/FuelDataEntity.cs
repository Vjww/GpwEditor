using System;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class FuelDataEntity : IntegerIdentityBase, IEntity
    {
        public FuelDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int Performance { get; set; }
        public int Tolerance { get; set; }
    }
}