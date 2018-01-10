using System.Collections.Generic;
using Common.Editor.Domain.Models;

namespace App.BaseGameEditor.Domain.Models
{
    public class TeamModel : IModel
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int FirstGpTrack { get; set; }
        public int FirstGpYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int CountryMapId { get; set; }
        public int LocationPointerX { get; set; }
        public int LocationPointerY { get; set; }
        public int TyreSupplierId { get; set; }
        public int ChassisHandling { get; set; }
        public int CarNumberDriver1 { get; set; }
        public int CarNumberDriver2 { get; set; }

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