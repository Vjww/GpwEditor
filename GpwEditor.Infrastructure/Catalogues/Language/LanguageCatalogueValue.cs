namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public class LanguageCatalogueValue
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
        public string English;
        public string French;
        public string German;
    }
}