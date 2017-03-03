namespace Data.ValueMapping.Executable.Lookup
{
    public class DriverNationality : ILookup
    {
        private const int NameIndex = 5952; // "None"

        public int Name { get; set; }

        public DriverNationality(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
                };

            return idToResourceIdMap[id];
        }
    }
}
