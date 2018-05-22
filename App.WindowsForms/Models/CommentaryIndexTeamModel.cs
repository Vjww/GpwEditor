using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class CommentaryIndexTeamModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int CommentaryIndex { get; set; }
    }
}