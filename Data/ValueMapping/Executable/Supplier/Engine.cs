namespace Data.ValueMapping.Executable.Supplier
{
    public class Engine : IEngine
    {
        private const int NameIndex = 4886; // "EngineA"

        private const int BaseOffset = 2756160;
        private const int LocalOffset = 28;
        private const int FuelOffset = 0;
        private const int HeatOffset = 4;
        private const int PowerOffset = 8;
        private const int ReliabilityOffset = 12;
        private const int ResponseOffset = 16;
        private const int RigidityOffset = 20;
        private const int WeightOffset = 24;

        public int Name { get; set; }
        public int Fuel { get; set; }
        public int Heat { get; set; }
        public int Power { get; set; }
        public int Reliability { get; set; }
        public int Response { get; set; }
        public int Rigidity { get; set; }
        public int Weight { get; set; }

        public Engine(int id)
        {
            Name = NameIndex + GetLocalResourceId(id) - 1;

            var stepOffset = LocalOffset * id;

            Fuel = BaseOffset + stepOffset + FuelOffset;
            Heat = BaseOffset + stepOffset + HeatOffset;
            Power = BaseOffset + stepOffset + PowerOffset;
            Reliability = BaseOffset + stepOffset + ReliabilityOffset;
            Response = BaseOffset + stepOffset + ResponseOffset;
            Rigidity = BaseOffset + stepOffset + RigidityOffset;
            Weight = BaseOffset + stepOffset + WeightOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8
                };

            return idToResourceIdMap[id];
        }
    }
}
