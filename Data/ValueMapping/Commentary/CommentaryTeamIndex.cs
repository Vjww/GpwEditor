namespace Data.ValueMapping.Commentary
{
    public class CommentaryTeamIndex
    {
        private const int NameIndex = 5696; // "No Team"

        private const int BaseOffset = 1182835;
        private const int LocalOffset = 12;

        public int Name { get; set; }
        public int CommentaryIndex { get; set; }

        public CommentaryTeamIndex(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;
            
            CommentaryIndex = BaseOffset + stepOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
            };

            return idToResourceIdMap[id];
        }
    }
}