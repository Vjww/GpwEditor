using Data.Entities.Executable.Team;

namespace Data.ValueMapping.Executable.Team
{
    public class Team : ITeam
    {
        // Offset values
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

        // Properties
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int FirstGpTrack { get; set; }
        public int FirstGpYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int Unknown { get; set; }
        public int CountryMapId { get; set; }
        public int TyreSupplierId { get; set; }

        public Team(int id)
        {
            // Calculate step offset from zero based index
            var stepOffset = LocalOffset * id;

            LastPosition = BaseOffset + stepOffset + LastPositionOffset;
            LastPoints = BaseOffset + stepOffset + LastPointsOffset;
            FirstGpTrack = BaseOffset + stepOffset + FirstGpTrackOffset;
            FirstGpYear = BaseOffset + stepOffset + FirstGpYearOffset;
            Wins = BaseOffset + stepOffset + WinsOffset;
            YearlyBudget = BaseOffset + stepOffset + YearlyBudgetOffset;
            Unknown = BaseOffset + stepOffset + UnknownOffset;
            CountryMapId = BaseOffset + stepOffset + CountryMapIdOffset;
            TyreSupplierId = BaseOffset + stepOffset + TyreSupplierIdOffset;

        }
    }
}
