using App.Core.Entities;
using App.Core.Identities;

namespace App.BaseGameEditor.Domain.Entities
{
    public class TeamEntity : IntegerIdentityBase, IEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int DebutGrandPrix { get; set; }
        public int DebutYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int UnknownA { get; set; }
        public int Location { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int TyreSupplier { get; set; }
        public int ChassisHandling { get; set; }
        public int CarNumberDriver1 { get; set; }
        public int CarNumberDriver2 { get; set; }
    }
}