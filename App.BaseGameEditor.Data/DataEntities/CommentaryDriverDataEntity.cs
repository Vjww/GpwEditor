using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryDriverDataEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public string FileNamePrefix { get; set; }
    }
}