using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using System.ComponentModel.DataAnnotations;
using Mapping = Data.ValueMapping.Executable.Race;

namespace Data.Entities.Executable.Race
{
    public class ChassisHandling : IIdentity, IDataConnection
    {
        private readonly Mapping.ChassisHandling _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Team Name", Description = "The name of the team, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Chassis Handling Rating", Description = "The handling rating of the chassis at the start of the game.")]
        [Range(0, 119, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Value { get; set; }

        public ChassisHandling(Mapping.ChassisHandling valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = Mapping.ChassisHandling.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Value, Value);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Value = executableConnection.ReadInteger(_valueMapping.Value);
        }
    }
}