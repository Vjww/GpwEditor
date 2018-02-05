using System.Collections.Generic;
using App.BaseGameEditor.Domain.Services;
using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class F1ChiefEngineerEntity : IntegerIdentityBase, IEntity, IEntityValidationService<F1ChiefEngineerEntity>
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int DriverLoyalty { get; set; }
        public int Morale { get; set; }

        public IEnumerable<string> Validate()
        {
            var validationMessages = new List<string>();

            if (TeamId < 1 || TeamId > 11)
            {
                validationMessages.Add($"Field {nameof(TeamId)} is out of range and must be a value from 1 to 11.");
            }

            return validationMessages;
        }
    }
}