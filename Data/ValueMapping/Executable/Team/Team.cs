namespace Data.ValueMapping.Executable.Team
{
    public class Team : ITeam
    {
        private const int NameIndex = 5696; // "No Team"

        private const int BaseOffset = 460837;
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
        public int Unknown { get; set; }
        public int CountryMapId { get; set; }
        public int LocationPointerX { get; set; }
        public int LocationPointerY { get; set; }
        public int TyreSupplierId { get; set; }

        public Team(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            LastPosition = BaseOffset + stepOffset + LastPositionOffset;
            LastPoints = BaseOffset + stepOffset + LastPointsOffset;
            FirstGpTrack = BaseOffset + stepOffset + FirstGpTrackOffset;
            FirstGpYear = BaseOffset + stepOffset + FirstGpYearOffset;
            Wins = BaseOffset + stepOffset + WinsOffset;
            YearlyBudget = BaseOffset + stepOffset + YearlyBudgetOffset;
            Unknown = BaseOffset + stepOffset + UnknownOffset;
            CountryMapId = BaseOffset + stepOffset + CountryMapIdOffset;
            LocationPointerX = LocationPointerBaseOffset + LocationPointerLocalOffset * id + LocationPointerXOffset;
            LocationPointerY = LocationPointerBaseOffset + LocationPointerLocalOffset * id + LocationPointerYOffset;
            TyreSupplierId = BaseOffset + stepOffset + TyreSupplierIdOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
                };

            return idToResourceIdMap[id];
        }
    }
}
