namespace Data
{
    public class LevelTypeBase : ILevelType
    {
        public string Name { get; set; }
        public int Level1 { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
        public int Level4 { get; set; }
        public int Level5 { get; set; }

        protected LevelTypeBase(string name)
        {
            Name = name;
        }

        public int[] Get()
        {
            return new[] { Level1, Level2, Level3, Level4, Level5 };
        }

        public void Set(int[] levels)
        {
            Level1 = levels[0];
            Level2 = levels[1];
            Level3 = levels[2];
            Level4 = levels[3];
            Level5 = levels[4];
        }
    }
}
