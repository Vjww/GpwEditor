using App.Core.Identities;
using App.Shared.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class TeamDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 5696 + 1; // "No Team" -> "Williams"

        private const int BaseOffset = 462070;
        private const int LocalOffset = 90;
        private const int LastPositionOffset = 0;
        private const int LastPointsOffset = 10;
        private const int DebutGrandPrixOffset = 20;
        private const int DebutYearOffset = 30;
        private const int WinsOffset = 40;
        private const int YearlyBudgetOffset = 50;
        private const int UnknownAOffset = 60;
        private const int LocationOffset = 70;
        private const int TyreSupplierOffset = 80;

        private const int LocationXyBaseOffset = 1400590;
        private const int LocationXyLocalOffset = 20;
        private const int LocationXOffset = 0;
        private const int LocationYOffset = 10;

        public int Name { get; set; }
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

        public void Initialise()
        {
            Name = NameOffset + Id;

            var stepOffset = LocalOffset * Id;

            LastPosition = BaseOffset + stepOffset + LastPositionOffset;
            LastPoints = BaseOffset + stepOffset + LastPointsOffset;
            DebutGrandPrix = BaseOffset + stepOffset + DebutGrandPrixOffset;
            DebutYear = BaseOffset + stepOffset + DebutYearOffset;
            Wins = BaseOffset + stepOffset + WinsOffset;
            YearlyBudget = BaseOffset + stepOffset + YearlyBudgetOffset;
            UnknownA = BaseOffset + stepOffset + UnknownAOffset;
            Location = BaseOffset + stepOffset + LocationOffset;
            LocationX = LocationXyBaseOffset + LocationXyLocalOffset * Id + LocationXOffset;
            LocationY = LocationXyBaseOffset + LocationXyLocalOffset * Id + LocationYOffset;
            TyreSupplier = BaseOffset + stepOffset + TyreSupplierOffset;
        }
    }
}