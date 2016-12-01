namespace Data.Entities.EntityTypes
{
    public interface IFiveLevelValueType
    {
        string Name { get; set; }
        int Level1 { get; set; }
        int Level2 { get; set; }
        int Level3 { get; set; }
        int Level4 { get; set; }
        int Level5 { get; set; }

        int[] GetLevels();
        void SetLevels(int[] levels);
    }
}
