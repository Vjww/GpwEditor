using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.UnknownBEfforts
{
    public class Unknown2 : ISingleValueMapping
    {
        private const int NameIndex = 6601;

        private const int BaseOffset = 2760684;

        public int Name { get; set; }
        public int Value { get; set; }

        public Unknown2()
        {
            Name = NameIndex;
            Value = BaseOffset;
        }
    }
}
