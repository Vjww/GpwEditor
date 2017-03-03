using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.UnknownBEfforts
{
    public class Unknown4 : ISingleValueMapping
    {
        private const int NameIndex = 6601;

        private const int BaseOffset = 2760692;

        public int Name { get; set; }
        public int Value { get; set; }

        public Unknown4()
        {
            Name = NameIndex;
            Value = BaseOffset;
        }
    }
}
