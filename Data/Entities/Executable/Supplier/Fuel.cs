using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Supplier Name", Description = "The name of the fuel supplier, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Performance", Description = "The fuel's Performance attribute rating.")]
        public int Performance { get; set; }
        [Display(Name = "Tolerance", Description = "The fuel's Tolerance attribute rating.")]
        public int Tolerance { get; set; }
    }
}
