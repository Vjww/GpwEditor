using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class CommentaryDriverEntity : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public string FileNamePrefix { get; set; }
    }
}