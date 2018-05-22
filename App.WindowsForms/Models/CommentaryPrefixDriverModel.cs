using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class CommentaryPrefixDriverModel : IntegerIdentityBase, IEntity
    {
        public int CommentaryIndex { get; set; }
        public string FileNamePrefix { get; set; }
    }
}