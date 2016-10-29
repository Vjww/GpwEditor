using Data.Entities.Language;

namespace Data.Entities.Executable.Supplier
{
    public interface IEngine
    {
        int Fuel { get; set; }
        int Heat { get; set; }
        int Power { get; set; }
        int Reliability { get; set; }
        int Response { get; set; }
        int Rigidity { get; set; }
        int Weight { get; set; }
    }

    public class Engine : IEngine, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }

        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }
    }
}
