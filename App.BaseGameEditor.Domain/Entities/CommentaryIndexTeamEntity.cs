using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class CommentaryIndexTeamEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int CommentaryIndex { get; set; }
    }
}