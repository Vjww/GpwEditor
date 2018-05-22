using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class CommentaryFileModel : IntegerIdentityBase, IEntity
    {
        public string FileName { get; set; }
    }
}