using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class CommentaryIndexDriverEntityValidator : IEntityValidator<CommentaryIndexDriverEntity>
    {
        public IEnumerable<string> Validate(CommentaryIndexDriverEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Commentary Index (67 <-> 107)

            return validationMessages;
        }
    }
}