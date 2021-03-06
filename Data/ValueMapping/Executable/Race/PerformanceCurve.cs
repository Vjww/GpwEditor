﻿namespace Data.ValueMapping.Executable.Race
{
    public class PerformanceCurve
    {
        private const int BaseOffset = 2723224;
        private const int LocalOffset = 4;
        private const int ValueOffset = 0;

        public int[] Values { get; set; }

        public PerformanceCurve()
        {
            Values = new int[120];

            for (var i = 0; i < Values.Length; i++)
            {
                var stepOffset = LocalOffset * i;
                Values[i] = BaseOffset + stepOffset + ValueOffset;
            }
        }
    }
}