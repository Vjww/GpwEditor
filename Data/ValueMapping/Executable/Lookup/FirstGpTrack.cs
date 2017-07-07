namespace Data.ValueMapping.Executable.Lookup
{
    public class FirstGpTrack : ILookup
    {
        private const int NameIndex = 6006; // "No race"

        public int Name { get; set; }

        public FirstGpTrack(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
                };

            return idToResourceIdMap[id];
        }
    }
}