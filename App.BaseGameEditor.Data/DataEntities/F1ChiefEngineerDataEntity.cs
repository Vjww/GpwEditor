﻿using System;
using App.BaseGameEditor.Data.Catalogues.Language;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefEngineerDataEntity : DataEntityBase
    {
        public F1ChiefEngineerDataEntity(LanguageCatalogueValue languageCatalogueValue)
        {
            Name = languageCatalogueValue ?? throw new ArgumentNullException(nameof(languageCatalogueValue));
        }

        public LanguageCatalogueValue Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int DriverLoyalty { get; set; }
        public int Morale { get; set; }
    }
}