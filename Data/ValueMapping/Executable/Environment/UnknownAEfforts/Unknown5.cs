using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.UnknownAEfforts
{
    public class Unknown5 : ISingleValueMapping
    {
        private const int NameIndex = 6601;

        private const int BaseOffset = 2760432;

        public int Name { get; set; }
        public int Value { get; set; }

        public Unknown5()
        {
            Name = NameIndex;
            Value = BaseOffset;
        }
    }
}
