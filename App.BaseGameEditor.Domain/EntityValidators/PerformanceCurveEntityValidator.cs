using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class PerformanceCurveEntityValidator : IEntityValidator<PerformanceCurveEntity>
    {
        public IEnumerable<string> Validate(PerformanceCurveEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}