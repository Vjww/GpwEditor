namespace ConsoleApplication.Mappers.BaseGame
{
    public class CarNumberMapper : MapperBase
    {
        private const int CarNumberABaseOffset = 466160;
        private const int CarNumberALocalOffset = 260;
        private const int CarNumberBBaseOffset = 474500;
        private const int CarNumberBLocalOffset = 10;

        public int CarNumberA { get; set; }
        public int CarNumberB { get; set; }

        public override void Map()
        {
            base.Map();

            CarNumberA = CarNumberABaseOffset + CarNumberALocalOffset * GetMultiplierForCarNumberA(Id);
            CarNumberB = CarNumberBBaseOffset + CarNumberBLocalOffset * Id;
        }

        public static int GetMultiplierForCarNumberA(int id)
        {
            // Generate a multiplier of 0,1,3,4..30,31 from id of 0,1,2,3..20,21 
            return id / 2 * 3 + id % 2; // 0..10 * 3 + 0..1
        }
    }
}