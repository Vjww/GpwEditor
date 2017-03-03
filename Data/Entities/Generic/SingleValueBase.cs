using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Data.ValueMapping.Generic;

namespace Data.Entities.Generic
{
    public class SingleValueBase : ISingleValue, IIdentity, IDataConnection
    {
        private readonly ISingleValueMapping _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Name", Description = "The name of the item that has one value.")]
        public string ResourceText { get; set; }

        [Display(Name = "Value", Description = "The value of the item.")]
        public int Value { get; set; }

        protected SingleValueBase(ISingleValueMapping valueMapping)
        {
            _valueMapping = valueMapping;
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, _valueMapping.Name.BuildResourceId(), ResourceText);
            executableConnection.WriteInteger(_valueMapping.Value, Value);
        }

        public virtual void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, _valueMapping.Name.BuildResourceId());
            Value = executableConnection.ReadInteger(_valueMapping.Value);
        }
    }
}
