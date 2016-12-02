using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Data.ValueMapping.MappingTypes;

namespace Data.Entities.EntityTypes
{
    public class FiveValueBase : IFiveValue, IIdentity, IDataConnection
    {
        private readonly IFiveValueMapping _valueMapping;

        [Display(Name = "Id", Description = "Id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "Id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "Resource Id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Name", Description = "Name of the item that has five values.")]
        public string ResourceText { get; set; }

        [Display(Name = "Value 1", Description = "Value 1 out of 5.")]
        public int Value01 { get; set; }
        [Display(Name = "Value 2", Description = "Value 2 out of 5.")]
        public int Value02 { get; set; }
        [Display(Name = "Value 3", Description = "Value 3 out of 5.")]
        public int Value03 { get; set; }
        [Display(Name = "Value 4", Description = "Value 4 out of 5.")]
        public int Value04 { get; set; }
        [Display(Name = "Value 5", Description = "Value 5 out of 5.")]
        public int Value05 { get; set; }

        protected FiveValueBase(IFiveValueMapping valueMapping)
        {
            _valueMapping = valueMapping;
        }

        public int[] GetValues()
        {
            return new[] { Value01, Value02, Value03, Value04, Value05 };
        }

        public void SetValues(int[] values)
        {
            Value01 = values[0];
            Value02 = values[1];
            Value03 = values[2];
            Value04 = values[3];
            Value05 = values[4];
        }

        public virtual void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, _valueMapping.Name.BuildResourceId());
            Value01 = executableConnection.ReadInteger(_valueMapping.Value01);
            Value02 = executableConnection.ReadInteger(_valueMapping.Value02);
            Value03 = executableConnection.ReadInteger(_valueMapping.Value03);
            Value04 = executableConnection.ReadInteger(_valueMapping.Value04);
            Value05 = executableConnection.ReadInteger(_valueMapping.Value05);
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, _valueMapping.Name.BuildResourceId(), ResourceText);
            executableConnection.WriteInteger(_valueMapping.Value01, Value01);
            executableConnection.WriteInteger(_valueMapping.Value02, Value02);
            executableConnection.WriteInteger(_valueMapping.Value03, Value03);
            executableConnection.WriteInteger(_valueMapping.Value04, Value04);
            executableConnection.WriteInteger(_valueMapping.Value05, Value05);
        }
    }
}
