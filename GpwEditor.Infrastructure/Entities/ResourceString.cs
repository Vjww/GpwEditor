namespace GpwEditor.Infrastructure.Entities
{
    public class ResourceString
    {
        public string All {
            get
            {
                return English;
            }
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