using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Data.ValueMapping.Generic;

namespace Data.Entities.Generic
{
    public class FiveRatingBase : IFiveValue, IIdentity, IDataConnection
    {
        private readonly IFiveValueMapping _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Name", Description = "The name of the item that has five rating values.")]
        public string ResourceText { get; set; }

        [Display(Name = "⬛⬜⬜⬜⬜", Description = "Rating value 1 out of 5.")]
        public int Value01 { get; set; }
        [Display(Name = "⬛⬛⬜⬜⬜", Description = "Rating value 2 out of 5.")]
        public int Value02 { get; set; }
        [Display(Name = "⬛⬛⬛⬜⬜", Description = "Rating value 3 out of 5.")]
        public int Value03 { get; set; }
        [Display(Name = "⬛⬛⬛⬛⬜", Description = "Rating value 4 out of 5.")]
        public int Value04 { get; set; }
        [Display(Name = "⬛⬛⬛⬛⬛", Description = "Rating value 5 out of 5.")]
        public int Value05 { get; set; }

        protected FiveRatingBase(IFiveValueMapping valueMapping)
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

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, _valueMapping.Name.BuildResourceId(), ResourceText);
            executableConnection.WriteInteger(_valueMapping.Value01, Value01);
            executableConnection.WriteInteger(_valueMapping.Value02, Value02);
            executableConnection.WriteInteger(_valueMapping.Value03, Value03);
            executableConnection.WriteInteger(_valueMapping.Value04, Value04);
            executableConnection.WriteInteger(_valueMapping.Value05, Value05);
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
    }
}
