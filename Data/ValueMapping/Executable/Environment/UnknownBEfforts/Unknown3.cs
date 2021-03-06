﻿using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.UnknownBEfforts
{
    public class Unknown3 : ISingleValueMapping
    {
        private const int NameIndex = 6601;

        private const int BaseOffset = 2760688;

        public int Name { get; set; }
        public int Value { get; set; }

        public Unknown3()
        {
            Name = NameIndex;
            Value = BaseOffset;
        }
    }
}
