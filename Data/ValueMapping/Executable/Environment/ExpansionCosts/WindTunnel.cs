using Data.ValueMapping.MappingTypes;

namespace Data.ValueMapping.Executable.Environment.ExpansionCosts
{
    public class WindTunnel : IFiveLevelMappingType
    {
        private const int NameIndex = 6615;

        private const int BaseOffset = 1118204;
        private const int ValueOffset1 = 0;
        private const int ValueOffset2 = 10;
        private const int ValueOffset3 = 20;
        private const int ValueOffset4 = 27;
        private const int ValueOffset5 = 34;

        public int Name { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public int Level4 { get; set; }
        public int Level5 { get; set; }

        public WindTunnel()
        {
            Name = NameIndex;
            Level1 = BaseOffset + ValueOffset1;
            Level2 = BaseOffset + ValueOffset2;
            Level3 = BaseOffset + ValueOffset3;
            Level4 = BaseOffset + ValueOffset4;
            Level5 = BaseOffset + ValueOffset5;
        }
    }
}
