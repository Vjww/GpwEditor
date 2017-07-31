using System.ComponentModel.DataAnnotations;
using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Mapping = Data.ValueMapping.Commentary;

namespace Data.Entities.Commentary
{
    public class CommentaryDriverIndex : IIdentity, IDataConnection
    {
        private readonly Mapping.CommentaryDriverIndex _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Driver Name", Description = "The name of the driver, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Commentary Index", Description = "The index of the commentary sound/text of the driver.")]
        [Range(67, 107, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int CommentaryIndex { get; set; }

        public CommentaryDriverIndex(Mapping.CommentaryDriverIndex valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = Mapping.CommentaryDriverIndex.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.CommentaryIndex, CommentaryIndex);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            CommentaryIndex = executableConnection.ReadInteger(_valueMapping.CommentaryIndex);
        }
    }
}