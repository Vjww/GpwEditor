using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryPrefixDriverDataEntity : IntegerIdentityBase, IEntity
    {
        public int CommentaryIndex { get; set; }
        public string FileNamePrefix { get; set; }
    }
}