using Data.Entities.Language;

namespace Data.Entities.Executable.Supplier
{
    public interface IFuel
    {
        int Performance { get; set; }
        int Tolerance { get; set; }
    }

    public class Fuel : IFuel, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }

        public int Performance { get; set; }
        public int Tolerance { get; set; }
    }
}
