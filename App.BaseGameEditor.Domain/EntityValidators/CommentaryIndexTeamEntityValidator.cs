using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class CommentaryIndexTeamEntityValidator : IEntityValidator<CommentaryIndexTeamEntity>
    {
        public IEnumerable<string> Validate(CommentaryIndexTeamEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Commentary Index (231 <-> 241)

            return validationMessages;
        }
    }
}