using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class TrackEntityValidator : IEntityValidator<TrackEntity>
    {
        public IEnumerable<string> Validate(TrackEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}