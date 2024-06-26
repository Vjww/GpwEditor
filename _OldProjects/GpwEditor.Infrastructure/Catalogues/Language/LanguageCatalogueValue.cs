﻿namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class LanguageCatalogueValue : ILanguageCatalogueValue
    {
        public string All
        {
            get => English;
            set
            {
                English = value;
                French = value;
                German = value;
            }
        }
        public string English { get; set; }
        public string French { get; set; }
        public string German { get; set; }
    }
}