using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.ExpansionCosts
{
    public class Supercomputer : IFiveValueMapping
    {
        private const int NameIndex = 6616;

        private const int BaseOffset = 1118252;
        private const int Value01Offset = 0;
        private const int Value02Offset = 7;
        private const int Value03Offset = 14;
        private const int Value04Offset = 21;
        private const int Value05Offset = 28;

        public int Name { get; set; }
        public int Value01 { get; set; }
        public int Value02 { get; set; }
        public int Value03 { get; set; }
        public int Value04 { get; set; }
        public int Value05 { get; set; }

        public Supercomputer()
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
