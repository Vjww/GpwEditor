using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using SupplierMapping = Data.ValueMapping.Executable.Supplier;

namespace Data.Entities.Executable.Supplier
{
    public class Engine : IIdentity, IDataConnection
    {
        private readonly SupplierMapping.Engine _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Supplier Name", Description = "The name of the engine supplier, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Fuel", Description = "The fuel rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Fuel { get; set; }
        [Display(Name = "Heat", Description = "The heat rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Heat { get; set; }
        [Display(Name = "Power", Description = "The power rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Power { get; set; }
        [Display(Name = "Reliability", Description = "The reliability rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Reliability { get; set; }
        [Display(Name = "Response", Description = "The response rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Response { get; set; }
        [Display(Name = "Rigidity", Description = "The rigidity rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Rigidity { get; set; }
        [Display(Name = "Weight", Description = "The weight rating of the engine.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Weight { get; set; }

        public Engine(SupplierMapping.Engine valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = SupplierMapping.Engine.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Fuel, Fuel);
            executableConnection.WriteInteger(_valueMapping.Heat, Heat);
            executableConnection.WriteInteger(_valueMapping.Power, Power);
            executableConnection.WriteInteger(_valueMapping.Reliability, Reliability);
            executableConnection.WriteInteger(_valueMapping.Response, Response);
            executableConnection.WriteInteger(_valueMapping.Rigidity, Rigidity);
            executableConnection.WriteInteger(_valueMapping.Weight, Weight);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Fuel = executableConnection.ReadInteger(_valueMapping.Fuel);
            Heat = executableConnection.ReadInteger(_valueMapping.Heat);
            Power = executableConnection.ReadInteger(_valueMapping.Power);
            Reliability = executableConnection.ReadInteger(_valueMapping.Reliability);
            Response = executableConnection.ReadInteger(_valueMapping.Response);
            Rigidity = executableConnection.ReadInteger(_valueMapping.Rigidity);
            Weight = executableConnection.ReadInteger(_valueMapping.Weight);
        }
    }
}