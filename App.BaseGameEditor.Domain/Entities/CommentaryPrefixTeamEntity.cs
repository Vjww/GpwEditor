using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class CommentaryPrefixTeamEntity : IntegerIdentityBase, IEntity
    {
        public int CommentaryIndex { get; set; }
        public string FileNamePrefix { get; set; }
    }
}