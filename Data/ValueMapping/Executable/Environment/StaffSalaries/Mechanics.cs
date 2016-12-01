using Data.ValueMapping.MappingTypes;

namespace Data.ValueMapping.Executable.Environment.StaffSalaries
{
    public class Mechanics : IFiveLevelMappingType
    {
        private const int NameIndex = 6260;

        private const int BaseOffset = 2733508;
        private const int ValueOffset1 = 0;
        private const int ValueOffset2 = 4;
        private const int ValueOffset3 = 8;
        private const int ValueOffset4 = 12;
        private const int ValueOffset5 = 16;

        public int Name { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public int Level4 { get; set; }
        public int Level5 { get; set; }

        public Mechanics()
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
