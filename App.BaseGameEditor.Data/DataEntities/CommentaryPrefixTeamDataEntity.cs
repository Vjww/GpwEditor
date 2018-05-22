using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CommentaryPrefixTeamDataEntity : IntegerIdentityBase, IEntity
    {
        public int CommentaryIndex { get; set; }
        public string FileNamePrefix { get; set; }
    }
}