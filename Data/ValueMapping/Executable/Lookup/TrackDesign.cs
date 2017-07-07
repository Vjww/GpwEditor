namespace Data.ValueMapping.Executable.Lookup
{
    public class TrackDesign : ILookup
    {
        private const int NameIndex = 6525; // ""

        public int Name { get; set; }

        public TrackDesign(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3
                };

            return idToResourceIdMap[id];
        }
    }
}