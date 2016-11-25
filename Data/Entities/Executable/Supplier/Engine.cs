using System.ComponentModel.DataAnnotations;
using Data.Entities.Language;

namespace Data.Entities.Executable.Supplier
{
    public interface IEngine
    {
        int Fuel { get; set; }
        int Heat { get; set; }
        int Power { get; set; }
        int Reliability { get; set; }
        int Response { get; set; }
        int Rigidity { get; set; }
        int Weight { get; set; }
    }

    public class Engine : IEngine, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        [Display(Name = "Supplier Name", Description = "The name of the engine supplier, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Fuel", Description = "The engine's Fuel attribute rating.")]
        public int Fuel { get; set; }
        [Display(Name = "Heat", Description = "The engine's Heat attribute rating.")]
        public int Heat { get; set; }
        [Display(Name = "Power", Description = "The engine's Power attribute rating.")]
        public int Power { get; set; }
        [Display(Name = "Reliability", Description = "The engine's Reliability attribute rating.")]
        public int Reliability { get; set; }
        [Display(Name = "Response", Description = "The engine's Response attribute rating.")]
        public int Response { get; set; }
        [Display(Name = "Rigidity", Description = "The engine's Rigidity attribute rating.")]
        public int Rigidity { get; set; }
        [Display(Name = "Weight", Description = "The engine's Weight attribute rating.")]
        public int Weight { get; set; }
    }
}
