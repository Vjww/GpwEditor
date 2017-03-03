using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.EngineeringCosts
{
    public class BuildThisYearCar : ITenValueMapping
    {
        private const int NameIndex = 2132;

        private const int BaseOffset = 2760440;
        private const int Value01Offset = 0;
        private const int Value02Offset = 4;
        private const int Value03Offset = 8;
        private const int Value04Offset = 12;
        private const int Value05Offset = 16;
        private const int Value06Offset = 20;
        private const int Value07Offset = 24;
        private const int Value08Offset = 28;
        private const int Value09Offset = 32;
        private const int Value10Offset = 36;

        public int Name { get; set; }
        public int Value01 { get; set; }
        public int Value02 { get; set; }
        public int Value03 { get; set; }
        public int Value04 { get; set; }
        public int Value05 { get; set; }
        public int Value06 { get; set; }
        public int Value07 { get; set; }
        public int Value08 { get; set; }
        public int Value09 { get; set; }
        public int Value10 { get; set; }

        public BuildThisYearCar()
        {
            Name = NameIndex;
            Value01 = BaseOffset + Value01Offset;
            Value02 = BaseOffset + Value02Offset;
            Value03 = BaseOffset + Value03Offset;
            Value04 = BaseOffset + Value04Offset;
            Value05 = BaseOffset + Value05Offset;
            Value06 = BaseOffset + Value06Offset;
            Value07 = BaseOffset + Value07Offset;
            Value08 = BaseOffset + Value08Offset;
            Value09 = BaseOffset + Value09Offset;
            Value10 = BaseOffset + Value10Offset;
        }
    }
}
