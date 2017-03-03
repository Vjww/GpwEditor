namespace Data.ValueMapping.Executable.Lookup
{
    public class FastestLapDriverIdAsStaffId : ILookup
    {
        private const int NameIndex = 5795; // "None"

        public int Name { get; set; }

        public FastestLapDriverIdAsStaffId(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                    78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 200, 201, 202, 203
                };

            return idToResourceIdMap[id];
        }
    }
}
