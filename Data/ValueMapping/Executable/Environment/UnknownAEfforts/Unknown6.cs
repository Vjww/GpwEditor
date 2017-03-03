using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.UnknownAEfforts
{
    public class Unknown6 : ISingleValueMapping
    {
        private const int NameIndex = 6601;

        private const int BaseOffset = 2760436;

        public int Name { get; set; }
        public int Value { get; set; }

        public Unknown6()
        {
            Name = NameIndex;
            Value = BaseOffset;
        }
    }
}
