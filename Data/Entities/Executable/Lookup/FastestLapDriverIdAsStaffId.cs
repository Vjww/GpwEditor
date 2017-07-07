using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Mapping = Data.ValueMapping.Executable.Lookup;

namespace Data.Entities.Executable.Lookup
{
    public class FastestLapDriverIdAsStaffId : IIdentity, IDataConnection
    {
        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Driver Name", Description = "The name of the driver, as specified in the language file.")]
        public string ResourceText { get; set; }

        public FastestLapDriverIdAsStaffId(Mapping.ILookup valueMapping, int id)
        {
            Id = id;
            LocalResourceId = Mapping.FastestLapDriverIdAsStaffId.GetLocalResourceId(Id);

            // Special consideration for mapping specific indices to resource strings
            var nameResourceIdMapping = valueMapping.Name;
            if ((LocalResourceId >= 200) && (LocalResourceId <= 203))
            {
                // Add offset for retired fastest lap drivers (language file index 6530 to 6533)
                nameResourceIdMapping += 535;
            }
            ResourceId = nameResourceIdMapping.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
        }
    }
}