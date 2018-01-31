using System;
using App.BaseGameEditor.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefCommercialDataEntity : DataEntityBase
    {
        public F1ChiefCommercialDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }
        public int Morale { get; set; }
    }
}