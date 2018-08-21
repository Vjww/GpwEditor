using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class CommentaryDriverEntityValidator : IEntityValidator<CommentaryDriverEntity>
    {
        public IEnumerable<string> Validate(CommentaryDriverEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Commentary Index (67 <-> 240?) ??? P1 -> Out/Pits

            return validationMessages;
        }
    }
}