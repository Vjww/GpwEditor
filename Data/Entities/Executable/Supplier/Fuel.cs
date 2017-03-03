using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using SupplierMapping = Data.ValueMapping.Executable.Supplier;

namespace Data.Entities.Executable.Supplier
{
    public class Fuel : IFuel, IIdentity, IDataConnection
    {
        private readonly SupplierMapping.Fuel _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Supplier Name", Description = "The name of the fuel supplier, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Performance", Description = "The performance rating of the fuel.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Performance { get; set; }
        [Display(Name = "Tolerance", Description = "The tolerance rating of the fuel.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Tolerance { get; set; }

        public Fuel(SupplierMapping.Fuel valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = SupplierMapping.Fuel.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Performance, Performance);
            executableConnection.WriteInteger(_valueMapping.Tolerance, Tolerance);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Performance = executableConnection.ReadInteger(_valueMapping.Performance);
            Tolerance = executableConnection.ReadInteger(_valueMapping.Tolerance);
        }
    }
}
