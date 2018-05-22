using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class CommentaryPrefixTeamModel : IntegerIdentityBase, IEntity
    {
        public int CommentaryIndex { get; set; }
        public string FileNamePrefix { get; set; }
    }
}