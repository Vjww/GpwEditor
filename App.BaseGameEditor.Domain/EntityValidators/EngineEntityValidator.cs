using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class EngineEntityValidator : IEntityValidator<EngineEntity>
    {
        public IEnumerable<string> Validate(EngineEntity entity)
        {
            var validationMessages = new List<string>();

            const int minimum = 1;
            const int maximum = 10;

            if (entity.Fuel < 1 || entity.Fuel > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Fuel).ToLower()} rating value of {minimum}-{maximum}.");
            }

            if (entity.Heat < 1 || entity.Heat > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Heat).ToLower()} rating value of {minimum}-{maximum}.");
            }

            if (entity.Power < 1 || entity.Power > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Power).ToLower()} rating value of {minimum}-{maximum}.");
            }

            if (entity.Reliability < 1 || entity.Reliability > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Reliability).ToLower()} rating value of {minimum}-{maximum}.");
            }

            if (entity.Response < 1 || entity.Response > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Response).ToLower()} rating value of {minimum}-{maximum}.");
            }

            if (entity.Rigidity < 1 || entity.Rigidity > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Rigidity).ToLower()} rating value of {minimum}-{maximum}.");
            }

            if (entity.Weight < 1 || entity.Weight > 10)
            {
                validationMessages.Add($"{entity.Name} must have a {nameof(entity.Weight).ToLower()} rating value of {minimum}-{maximum}.");
            }

            return validationMessages;
        }
    }
}