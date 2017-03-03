namespace Data.Entities.Executable.Race
{
    public class RacePerformance : IRacePerformance
    {
        public int[] Values { get; set; }

        public RacePerformance()
        {
            Values = new int[120];
        }
    }
}
