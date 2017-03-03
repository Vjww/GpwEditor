using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Data.ValueMapping.Generic;

namespace Data.Entities.Generic
{
    public class TenValueBase : ITenValue, IIdentity, IDataConnection
    {
        private readonly ITenValueMapping _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Name", Description = "The name of the item that has ten values.")]
        public string ResourceText { get; set; }

        [Display(Name = "Value 1", Description = "Value 1 out of 10.")]
        public int Value01 { get; set; }
        [Display(Name = "Value 2", Description = "Value 2 out of 10.")]
        public int Value02 { get; set; }
        [Display(Name = "Value 3", Description = "Value 3 out of 10.")]
        public int Value03 { get; set; }
        [Display(Name = "Value 4", Description = "Value 4 out of 10.")]
        public int Value04 { get; set; }
        [Display(Name = "Value 5", Description = "Value 5 out of 10.")]
        public int Value05 { get; set; }
        [Display(Name = "Value 6", Description = "Value 6 out of 10.")]
        public int Value06 { get; set; }
        [Display(Name = "Value 7", Description = "Value 7 out of 10.")]
        public int Value07 { get; set; }
        [Display(Name = "Value 8", Description = "Value 8 out of 10.")]
        public int Value08 { get; set; }
        [Display(Name = "Value 9", Description = "Value 9 out of 10.")]
        public int Value09 { get; set; }
        [Display(Name = "Value 10", Description = "Value 10 out of 10.")]
        public int Value10 { get; set; }

        protected TenValueBase(ITenValueMapping valueMapping)
        {
            _valueMapping = valueMapping;
        }

        public int[] GetValues()
        {
            return new[] { Value01, Value02, Value03, Value04, Value05, Value06, Value07, Value08, Value09, Value10 };
        }

        public void SetValues(int[] values)
        {
            Value01 = values[0];
            Value02 = values[1];
            Value03 = values[2];
            Value04 = values[3];
            Value05 = values[4];
            Value06 = values[5];
            Value07 = values[6];
            Value08 = values[7];
            Value09 = values[8];
            Value10 = values[9];
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, _valueMapping.Name.BuildResourceId(), ResourceText);
            executableConnection.WriteInteger(_valueMapping.Value01, Value01);
            executableConnection.WriteInteger(_valueMapping.Value02, Value02);
            executableConnection.WriteInteger(_valueMapping.Value03, Value03);
            executableConnection.WriteInteger(_valueMapping.Value04, Value04);
            executableConnection.WriteInteger(_valueMapping.Value05, Value05);
            executableConnection.WriteInteger(_valueMapping.Value06, Value06);
            executableConnection.WriteInteger(_valueMapping.Value07, Value07);
            executableConnection.WriteInteger(_valueMapping.Value08, Value08);
            executableConnection.WriteInteger(_valueMapping.Value09, Value09);
            executableConnection.WriteInteger(_valueMapping.Value10, Value10);
        }

        public virtual void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, _valueMapping.Name.BuildResourceId());
            Value01 = executableConnection.ReadInteger(_valueMapping.Value01);
            Value02 = executableConnection.ReadInteger(_valueMapping.Value02);
            Value03 = executableConnection.ReadInteger(_valueMapping.Value03);
            Value04 = executableConnection.ReadInteger(_valueMapping.Value04);
            Value05 = executableConnection.ReadInteger(_valueMapping.Value05);
            Value06 = executableConnection.ReadInteger(_valueMapping.Value06);
            Value07 = executableConnection.ReadInteger(_valueMapping.Value07);
            Value08 = executableConnection.ReadInteger(_valueMapping.Value08);
            Value09 = executableConnection.ReadInteger(_valueMapping.Value09);
            Value10 = executableConnection.ReadInteger(_valueMapping.Value10);
        }
    }
}
