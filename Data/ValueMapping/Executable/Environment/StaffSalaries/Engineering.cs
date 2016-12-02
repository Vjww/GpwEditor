using Data.ValueMapping.MappingTypes;

namespace Data.ValueMapping.Executable.Environment.StaffSalaries
{
    public class Engineering : IFiveValueMapping
    {
        private const int NameIndex = 6259;

        private const int BaseOffset = 2733484;
        private const int Value01Offset = 0;
        private const int Value02Offset = 4;
        private const int Value03Offset = 8;
        private const int Value04Offset = 12;
        private const int Value05Offset = 16;

        public int Name { get; set; }
        public int Value01 { get; set; }
        public int Value02 { get; set; }
        public int Value03 { get; set; }
        public int Value04 { get; set; }
        public int Value05 { get; set; }

        public Engineering()
        {
            Name = NameIndex;
            Value01 = BaseOffset + Value01Offset;
            Value02 = BaseOffset + Value02Offset;
            Value03 = BaseOffset + Value03Offset;
            Value04 = BaseOffset + Value04Offset;
            Value05 = BaseOffset + Value05Offset;
        }
    }
}
