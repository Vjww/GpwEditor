using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class CommentaryPrefixDriverEntityValidator : IEntityValidator<CommentaryPrefixDriverEntity>
    {
        public IEnumerable<string> Validate(CommentaryPrefixDriverEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Commentary Index (67 <-> 107) ???

            return validationMessages;
        }
    }
}