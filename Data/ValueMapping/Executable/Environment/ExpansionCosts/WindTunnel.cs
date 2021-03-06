﻿using Data.ValueMapping.Generic;

namespace Data.ValueMapping.Executable.Environment.ExpansionCosts
{
    public class WindTunnel : IFiveValueMapping
    {
        private const int NameIndex = 6615;

        private const int BaseOffset = 1118204;
        private const int Value01Offset = 0;
        private const int Value02Offset = 10;
        private const int Value03Offset = 20;
        private const int Value04Offset = 27;
        private const int Value05Offset = 34;

        public int Name { get; set; }
        public int Value01 { get; set; }
        public int Value02 { get; set; }
        public int Value03 { get; set; }
        public int Value04 { get; set; }
        public int Value05 { get; set; }

        public WindTunnel()
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
