namespace App.BaseGameEditor.Data.Calculators
{
    public class IdentityCalculator
    {
        public int GetMultiplier0To21From0To32(int id)
        {
            // Generate a multiplier of 0..21 from id of 0..32
            return id / 3 * 2 + id % 3; // 0..10 * 2 + 0..1
        }

        public int GetMultiplier0To31From0To21(int id)
        {
            // Generate a multiplier of 0,1,3,4..30,31 from id of 0,1,2,3..20,21 
            return id / 2 * 3 + id % 2; // 0..10 * 3 + 0..1
        }

        public int GetTeamAlphabeticalId(int id)
        {
            var idToAlphabeticalIdMap = new[]
            {
                10, 2, 1, 4, 3, 6, 7, 0, 8, 9, 5
            };

            return idToAlphabeticalIdMap[id];
        }

        public int GetF1ChiefCommercialNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                2, 10, 18, 26, 34, 42, 50, 58, 66, 74, 82
            };

            return idToResourceIdMap[id];
        }

        public int GetF1ChiefDesignerNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                3, 11, 19, 27, 35, 43, 51, 59, 67, 75, 83
            };

            return idToResourceIdMap[id];
        }

        public int GetF1ChiefEngineerNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                4, 12, 20, 28, 36, 44, 52, 60, 68, 76, 84
            };

            return idToResourceIdMap[id];
        }

        public int GetF1ChiefMechanicNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                5, 13, 21, 29, 37, 45, 53, 61, 69, 77, 85
            };

            return idToResourceIdMap[id];
        }

        public int GetF1DriverNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32,
                38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64,
                70, 71, 72, 78, 79, 80, 86, 87, 88
            };

            return idToResourceIdMap[id];
        }

        public int GetNonF1ChiefCommercialNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                89, 90, 91, 92, 93, 94, 95, 96, 97, 98
            };

            return idToResourceIdMap[id];
        }

        public int GetNonF1ChiefDesignerNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                99, 100, 101, 102, 103, 104, 105, 106, 107, 108
            };

            return idToResourceIdMap[id];
        }

        public int GetNonF1ChiefEngineerNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                109, 110, 111, 112, 113, 114, 115, 116, 117, 118
            };

            return idToResourceIdMap[id];
        }

        public int GetNonF1ChiefMechanicNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                119, 120, 121, 122, 123, 124, 125, 126, 127, 128
            };

            return idToResourceIdMap[id];
        }

        public int GetNonF1DriverNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139
            };

            return idToResourceIdMap[id];
        }
    }
}