namespace Data.Entities.EntityTypes
{
    public interface IFiveValue
    {
        int Value01 { get; set; }
        int Value02 { get; set; }
        int Value03 { get; set; }
        int Value04 { get; set; }
        int Value05 { get; set; }

        int[] GetValues();
        void SetValues(int[] values);
    }
}
