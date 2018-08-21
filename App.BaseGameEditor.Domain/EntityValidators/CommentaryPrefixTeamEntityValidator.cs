using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class CommentaryPrefixTeamEntityValidator : IEntityValidator<CommentaryPrefixTeamEntity>
    {
        public IEnumerable<string> Validate(CommentaryPrefixTeamEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Commentary Index (231 <-> 241) ???

            return validationMessages;
        }
    }
}