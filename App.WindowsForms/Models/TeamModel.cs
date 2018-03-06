using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class TeamModel : IntegerIdentityBase, IEntity
    {
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
    }
}