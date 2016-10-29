using Data.Entities.Executable.Supplier;

namespace Data.ValueMapping.Executable.Supplier
{
    public class Engine : IEngine
    {
        // Offset values
        private const int BaseOffset = 0; // TODO
        private const int LocalOffset = 0; // TODO
        private const int ExampleOffset = 0; // TODO

        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }

        public Engine(int id)
        {
            // Calculate step offset from zero based index
            var stepOffset = LocalOffset * id;

            //Example = BaseOffset + stepOffset + ExampleOffset; // TODO
        }
    }
}
