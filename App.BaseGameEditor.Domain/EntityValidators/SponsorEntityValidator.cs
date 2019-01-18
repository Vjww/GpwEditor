using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorEntityValidator : IEntityValidator<SponsorEntity>
    {
        public IEnumerable<string> Validate(SponsorEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Implement all sponsor validation, only engine attributes included so far.

            if (entity.SponsorTypeId == 2)
            {
                const int engineAttributeMinimum = 1;
                const int engineAttributeMaximum = 10;

                if (entity.Fuel < 1 || entity.Fuel > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Fuel).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }

                if (entity.Heat < 1 || entity.Heat > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Heat).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }

                if (entity.Power < 1 || entity.Power > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Power).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }

                if (entity.Reliability < 1 || entity.Reliability > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Reliability).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }

                if (entity.Response < 1 || entity.Response > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Response).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }

                if (entity.Rigidity < 1 || entity.Rigidity > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Rigidity).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }

                if (entity.Weight < 1 || entity.Weight > 10)
                {
                    validationMessages.Add($"{entity.Name} must have a {nameof(entity.Weight).ToLower()} rating value of {engineAttributeMinimum}-{engineAttributeMaximum}.");
                }
            }

            return validationMessages;
        }
    }
}