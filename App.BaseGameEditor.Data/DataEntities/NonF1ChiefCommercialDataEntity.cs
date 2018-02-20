using System;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1ChiefCommercialDataEntity : IntegerIdentityBase, IEntity
    {
        public NonF1ChiefCommercialDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }
    }
}