namespace Data.ValueMapping.Executable.Race
{
    public class ChassisHandling
    {
        private const int NameIndex = 5696; // "No Team"

        private const int BaseOffset = 1094126;
        private const int LocalOffset = 30;
        private const int ValueOffset = 0;

        public int Name { get; set; }
        public int Value { get; set; }

        public ChassisHandling(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * GetAlphabeticalId(id);

            Value = BaseOffset + stepOffset + ValueOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
                };

            return idToResourceIdMap[id];
        }

        public static int GetAlphabeticalId(int id)
        {
            var idToAlphabeticalIdMap = new[]
            {
                10, 2, 1, 4, 3, 6, 7, 0, 8, 9, 5
            };

            return idToAlphabeticalIdMap[id];
        }
    }
}