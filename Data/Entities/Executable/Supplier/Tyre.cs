using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using SupplierMapping = Data.ValueMapping.Executable.Supplier;

namespace Data.Entities.Executable.Supplier
{
    public class Tyre : ITyre, IIdentity, IDataConnection
    {
        private readonly SupplierMapping.Tyre _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Supplier Name", Description = "The name of the tyre supplier, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Dry Hard Grip", Description = "The grip rating of the dry hard tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DryHardGrip { get; set; }
        [Display(Name = "Dry Hard Resilience", Description = "The resilience rating of the dry hard tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DryHardResilience { get; set; }
        [Display(Name = "Dry Hard Stiffness", Description = "The stiffness rating of the dry hard tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DryHardStiffness { get; set; }
        [Display(Name = "Dry Hard Temperature", Description = "The temperature rating of the dry hard tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DryHardTemperature { get; set; }
        [Display(Name = "Dry Soft Grip", Description = "The grip rating of the dry soft tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DrySoftGrip { get; set; }
        [Display(Name = "Dry Soft Resilience", Description = "The resilience rating of the dry soft tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DrySoftResilience { get; set; }
        [Display(Name = "Dry Soft Stiffness", Description = "The stiffness rating of the dry soft tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DrySoftStiffness { get; set; }
        [Display(Name = "Dry Soft Temperature", Description = "The temperature rating of the dry soft tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int DrySoftTemperature { get; set; }
        [Display(Name = "Intermediate Grip", Description = "The grip rating of the intermediate tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int IntermediateGrip { get; set; }
        [Display(Name = "Intermediate Resilience", Description = "The resilience rating of the intermediate tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int IntermediateResilience { get; set; }
        [Display(Name = "Intermediate Stiffness", Description = "The stiffness rating of the intermediate tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int IntermediateStiffness { get; set; }
        [Display(Name = "Intermediate Temperature", Description = "The temperature rating of the intermediate tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int IntermediateTemperature { get; set; }
        [Display(Name = "Wet Weather Grip", Description = "The grip rating of the wet weather tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int WetWeatherGrip { get; set; }
        [Display(Name = "Wet Weather Resilience", Description = "The resilience rating of the wet weather tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int WetWeatherResilience { get; set; }
        [Display(Name = "Wet Weather Stiffness", Description = "The stiffness rating of the wet weather tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int WetWeatherStiffness { get; set; }
        [Display(Name = "Wet Weather Temperature", Description = "The temperature rating of the wet weather tyre.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int WetWeatherTemperature { get; set; }

        public Tyre(SupplierMapping.Tyre valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = SupplierMapping.Tyre.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.DryHardGripSupplier, DryHardGrip);
            executableConnection.WriteInteger(_valueMapping.DryHardResilienceSupplier, DryHardResilience);
            executableConnection.WriteInteger(_valueMapping.DryHardStiffnessSupplier, DryHardStiffness);
            executableConnection.WriteInteger(_valueMapping.DryHardTemperatureSupplier, DryHardTemperature);
            executableConnection.WriteInteger(_valueMapping.DrySoftGripSupplier, DrySoftGrip);
            executableConnection.WriteInteger(_valueMapping.DrySoftResilienceSupplier, DrySoftResilience);
            executableConnection.WriteInteger(_valueMapping.DrySoftStiffnessSupplier, DrySoftStiffness);
            executableConnection.WriteInteger(_valueMapping.DrySoftTemperatureSupplier, DrySoftTemperature);
            executableConnection.WriteInteger(_valueMapping.IntermediateGripSupplier, IntermediateGrip);
            executableConnection.WriteInteger(_valueMapping.IntermediateResilienceSupplier, IntermediateResilience);
            executableConnection.WriteInteger(_valueMapping.IntermediateStiffnessSupplier, IntermediateStiffness);
            executableConnection.WriteInteger(_valueMapping.IntermediateTemperatureSupplier, IntermediateTemperature);
            executableConnection.WriteInteger(_valueMapping.WetWeatherGripSupplier, WetWeatherGrip);
            executableConnection.WriteInteger(_valueMapping.WetWeatherResilienceSupplier, WetWeatherResilience);
            executableConnection.WriteInteger(_valueMapping.WetWeatherStiffnessSupplier, WetWeatherStiffness);
            executableConnection.WriteInteger(_valueMapping.WetWeatherTemperatureSupplier, WetWeatherTemperature);

            executableConnection.WriteInteger(_valueMapping.DryHardGripTeam, DryHardGrip);
            executableConnection.WriteInteger(_valueMapping.DryHardResilienceTeam, DryHardResilience);
            executableConnection.WriteInteger(_valueMapping.DryHardStiffnessTeam, DryHardStiffness);
            executableConnection.WriteInteger(_valueMapping.DryHardTemperatureTeam, DryHardTemperature);
            executableConnection.WriteInteger(_valueMapping.DrySoftGripTeam, DrySoftGrip);
            executableConnection.WriteInteger(_valueMapping.DrySoftResilienceTeam, DrySoftResilience);
            executableConnection.WriteInteger(_valueMapping.DrySoftStiffnessTeam, DrySoftStiffness);
            executableConnection.WriteInteger(_valueMapping.DrySoftTemperatureTeam, DrySoftTemperature);
            executableConnection.WriteInteger(_valueMapping.IntermediateGripTeam, IntermediateGrip);
            executableConnection.WriteInteger(_valueMapping.IntermediateResilienceTeam, IntermediateResilience);
            executableConnection.WriteInteger(_valueMapping.IntermediateStiffnessTeam, IntermediateStiffness);
            executableConnection.WriteInteger(_valueMapping.IntermediateTemperatureTeam, IntermediateTemperature);
            executableConnection.WriteInteger(_valueMapping.WetWeatherGripTeam, WetWeatherGrip);
            executableConnection.WriteInteger(_valueMapping.WetWeatherResilienceTeam, WetWeatherResilience);
            executableConnection.WriteInteger(_valueMapping.WetWeatherStiffnessTeam, WetWeatherStiffness);
            executableConnection.WriteInteger(_valueMapping.WetWeatherTemperatureTeam, WetWeatherTemperature);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            DryHardGrip = executableConnection.ReadInteger(_valueMapping.DryHardGripSupplier);
            DryHardResilience = executableConnection.ReadInteger(_valueMapping.DryHardResilienceSupplier);
            DryHardStiffness = executableConnection.ReadInteger(_valueMapping.DryHardStiffnessSupplier);
            DryHardTemperature = executableConnection.ReadInteger(_valueMapping.DryHardTemperatureSupplier);
            DrySoftGrip = executableConnection.ReadInteger(_valueMapping.DrySoftGripSupplier);
            DrySoftResilience = executableConnection.ReadInteger(_valueMapping.DrySoftResilienceSupplier);
            DrySoftStiffness = executableConnection.ReadInteger(_valueMapping.DrySoftStiffnessSupplier);
            DrySoftTemperature = executableConnection.ReadInteger(_valueMapping.DrySoftTemperatureSupplier);
            IntermediateGrip = executableConnection.ReadInteger(_valueMapping.IntermediateGripSupplier);
            IntermediateResilience = executableConnection.ReadInteger(_valueMapping.IntermediateResilienceSupplier);
            IntermediateStiffness = executableConnection.ReadInteger(_valueMapping.IntermediateStiffnessSupplier);
            IntermediateTemperature = executableConnection.ReadInteger(_valueMapping.IntermediateTemperatureSupplier);
            WetWeatherGrip = executableConnection.ReadInteger(_valueMapping.WetWeatherGripSupplier);
            WetWeatherResilience = executableConnection.ReadInteger(_valueMapping.WetWeatherResilienceSupplier);
            WetWeatherStiffness = executableConnection.ReadInteger(_valueMapping.WetWeatherStiffnessSupplier);
            WetWeatherTemperature = executableConnection.ReadInteger(_valueMapping.WetWeatherTemperatureSupplier);
        }
    }
}
