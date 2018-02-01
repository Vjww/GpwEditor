using System;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class TeamDataLocator : DataLocatorBase
    {
        private const int NameOffset = 5696 + 1; // "No Team" -> "Williams"

        private const int BaseOffset = 462070;
        private const int LocalOffset = 90;
        private const int LastPositionOffset = 0;
        private const int LastPointsOffset = 10;
        private const int FirstGpTrackOffset = 20;
        private const int FirstGpYearOffset = 30;
        private const int WinsOffset = 40;
        private const int YearlyBudgetOffset = 50;
        private const int UnknownOffset = 60;
        private const int CountryMapIdOffset = 70;
        private const int TyreSupplierIdOffset = 80;

        private const int LocationPointerBaseOffset = 1400590;
        private const int LocationPointerLocalOffset = 20;
        private const int LocationPointerXOffset = 0;
        private const int LocationPointerYOffset = 10;

        public int Name { get; set; }
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int FirstGpTrack { get; set; }
        public int FirstGpYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int UnknownA { get; set; }
        public int CountryMapId { get; set; }
        public int LocationPointerX { get; set; }
        public int LocationPointerY { get; set; }
        public int TyreSupplierId { get; set; }

        public override void Initialise(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
            Name = NameOffset + Id;

            var stepOffset = LocalOffset * Id;

            LastPosition = BaseOffset + stepOffset + LastPositionOffset;
            LastPoints = BaseOffset + stepOffset + LastPointsOffset;
            FirstGpTrack = BaseOffset + stepOffset + FirstGpTrackOffset;
            FirstGpYear = BaseOffset + stepOffset + FirstGpYearOffset;
            Wins = BaseOffset + stepOffset + WinsOffset;
            YearlyBudget = BaseOffset + stepOffset + YearlyBudgetOffset;
            UnknownA = BaseOffset + stepOffset + UnknownOffset;
            CountryMapId = BaseOffset + stepOffset + CountryMapIdOffset;
            LocationPointerX = LocationPointerBaseOffset + LocationPointerLocalOffset * Id + LocationPointerXOffset;
            LocationPointerY = LocationPointerBaseOffset + LocationPointerLocalOffset * Id + LocationPointerYOffset;
            TyreSupplierId = BaseOffset + stepOffset + TyreSupplierIdOffset;
        }
    }
}