namespace Data.Entities.Executable.Race
{
    public interface IRacePerformance
    {
        int[] Values { get; set; }
    }

    public class RacePerformance : IRacePerformance
    {
        public int[] Values { get; set; }

        public RacePerformance()
        {
            Values = new int[120];
        }
    }
}
