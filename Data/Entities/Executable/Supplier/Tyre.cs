using System.ComponentModel.DataAnnotations;
using Data.Entities.Language;

namespace Data.Entities.Executable.Supplier
{
    public interface ITyre
    {
        int DryHardGrip { get; set; }
        int DryHardResilience { get; set; }
        int DryHardStiffness { get; set; }
        int DryHardTemperature { get; set; }
        int DrySoftGrip { get; set; }
        int DrySoftResilience { get; set; }
        int DrySoftStiffness { get; set; }
        int DrySoftTemperature { get; set; }
        int IntermediateGrip { get; set; }
        int IntermediateResilience { get; set; }
        int IntermediateStiffness { get; set; }
        int IntermediateTemperature { get; set; }
        int WetWeatherGrip { get; set; }
        int WetWeatherResilience { get; set; }
        int WetWeatherStiffness { get; set; }
        int WetWeatherTemperature { get; set; }
    }

    public class Tyre : ITyre, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        [Display(Name = "Supplier Name", Description = "The name of the tyre supplier, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Dry Hard Grip", Description = "The tyre's Grip attribute rating for the Dry Hard tyre compound.")]
        public int DryHardGrip { get; set; }
        [Display(Name = "Dry Hard Resilience", Description = "The tyre's Resilience attribute rating for the Dry Hard tyre compound.")]
        public int DryHardResilience { get; set; }
        [Display(Name = "Dry Hard Stiffness", Description = "The tyre's Stiffness attribute rating for the Dry Hard tyre compound.")]
        public int DryHardStiffness { get; set; }
        [Display(Name = "Dry Hard Temperature", Description = "The tyre's Temperature attribute rating for the Dry Hard tyre compound.")]
        public int DryHardTemperature { get; set; }

        [Display(Name = "Dry Soft Grip", Description = "The tyre's Grip attribute rating for the Dry Soft tyre compound.")]
        public int DrySoftGrip { get; set; }
        [Display(Name = "Dry Soft Resilience", Description = "The tyre's Resilience attribute rating for the Dry Soft tyre compound.")]
        public int DrySoftResilience { get; set; }
        [Display(Name = "Dry Soft Stiffness", Description = "The tyre's Stiffness attribute rating for the Dry Soft tyre compound.")]
        public int DrySoftStiffness { get; set; }
        [Display(Name = "Dry Soft Temperature", Description = "The tyre's Temperature attribute rating for the Dry Soft tyre compound.")]
        public int DrySoftTemperature { get; set; }

        [Display(Name = "Intermediate Grip", Description = "The tyre's Grip attribute rating for the Intermediate tyre compound.")]
        public int IntermediateGrip { get; set; }
        [Display(Name = "Intermediate Resilience", Description = "The tyre's Resilience attribute rating for the Intermediate tyre compound.")]
        public int IntermediateResilience { get; set; }
        [Display(Name = "Intermediate Stiffness", Description = "The tyre's Stiffness attribute rating for the Intermediate tyre compound.")]
        public int IntermediateStiffness { get; set; }
        [Display(Name = "Intermediate Temperature", Description = "The tyre's Temperature attribute rating for the Intermediate tyre compound.")]
        public int IntermediateTemperature { get; set; }

        [Display(Name = "Wet Weather Grip", Description = "The tyre's Grip attribute rating for the Wet Weather tyre compound.")]
        public int WetWeatherGrip { get; set; }
        [Display(Name = "Wet Weather Resilience", Description = "The tyre's Resilience attribute rating for the Wet Weather tyre compound.")]
        public int WetWeatherResilience { get; set; }
        [Display(Name = "Wet Weather Stiffness", Description = "The tyre's Stiffness attribute rating for the Wet Weather tyre compound.")]
        public int WetWeatherStiffness { get; set; }
        [Display(Name = "Wet Weather Temperature", Description = "The tyre's Temperature attribute rating for the Wet Weather tyre compound.")]
        public int WetWeatherTemperature { get; set; }
    }
}
