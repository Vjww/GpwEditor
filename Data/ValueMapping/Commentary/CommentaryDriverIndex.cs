namespace Data.ValueMapping.Commentary
{
    public class CommentaryDriverIndex
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 474720;
        private const int LocalOffset = 10;

        public int Name { get; set; }
        public int CommentaryIndex { get; set; }

        public CommentaryDriverIndex(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            CommentaryIndex = BaseOffset + stepOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139
            };

            return idToResourceIdMap[id];
        }
    }
}