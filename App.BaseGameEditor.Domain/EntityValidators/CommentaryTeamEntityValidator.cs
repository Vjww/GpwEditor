using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class CommentaryTeamEntityValidator : IEntityValidator<CommentaryTeamEntity>
    {
        public IEnumerable<string> Validate(CommentaryTeamEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Commentary Index (231 <-> 241?) -> Out

            return validationMessages;
        }
    }
}