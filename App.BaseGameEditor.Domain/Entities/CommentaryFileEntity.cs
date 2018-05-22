using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class CommentaryFileEntity : IntegerIdentityBase, IEntity
    {
        public string FileName { get; set; }
    }
}