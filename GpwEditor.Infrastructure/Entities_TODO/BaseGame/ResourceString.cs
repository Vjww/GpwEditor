namespace GpwEditor.Infrastructure.Entities.BaseGame
{
    public class ResourceString
    {
        public string All {
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