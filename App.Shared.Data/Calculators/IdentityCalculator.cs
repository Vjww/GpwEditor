using System;

namespace App.Shared.Data.Calculators
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

        public int GetF1AndNonF1DriverNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139
            };

            return idToResourceIdMap[id];
        }

        public int GetChiefDriverLoyaltyNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                0, 6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64,
                70, 71, 72, 78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139,
            };

            return idToResourceIdMap[id];
        }

        public int GetDriverNationalityNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
            };

            return idToResourceIdMap[id];
        }

        public int GetDriverRoleNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                1, 2, 3, 4
            };

            return idToResourceIdMap[id];
        }

        public int GetTeamNameId(int id)
        {
            var idToAlphabeticalIdMap = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
            };

            return idToAlphabeticalIdMap[id];
        }

        public int GetTeamDebutGrandPrixNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
            };

            return idToResourceIdMap[id];
        }

        public int GetTrackDriverNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 200, 201, 202, 203
            };

            return idToResourceIdMap[id];
        }

        public int GetTrackTeamNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
            };

            return idToResourceIdMap[id];
        }

        public int GetTrackLayoutNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                1, 2, 3
            };

            return idToResourceIdMap[id];
        }

        public int GetTyreSupplierNameId(int id)
        {
            var idToResourceIdMap = new[]
            {
                8, 9, 10
            };

            return idToResourceIdMap[id];
        }

        public int GetCommentaryDriverIndex(int id)
        {
            var idToResourceIdMap = new[]
            {
                // Driver P1
                67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86,
                87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107,

                // Driver P2
                108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127,
                128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148,

                // Driver P3
                149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168,
                169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189,

                // Driver Out
                190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209,
                210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230,

                // Driver Pit
                243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262,
                263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281, 282, 283
            };

            return idToResourceIdMap[id];
        }

        public int GetCommentaryTeamIndex(int id)
        {
            var idToResourceIdMap = new[]
            {
                // Team Out
                231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241
            };

            return idToResourceIdMap[id];
        }

        public int GetSponsorId(int id)
        {
            switch (GetSponsorType(id))
            {
                case 1: // Team Sponsor
                    return id + 1;
                case 3: // Tyre Supplier
                    return id + 1 - 7;
                case 2: // Engine Supplier
                    return id + 1 - 10;
                case 4: // Fuel Supplier
                    return id + 1 - 18;
                case 5: // Cash Sponsor
                    return id + 1 - 27;
                default:
                    throw new ArgumentOutOfRangeException(nameof(id));
            }
        }

        // TODO: Review whether this method is used
        public int GetSponsorType(int id)
        {
            switch (id)
            {
                case int n when (n >= 0 && n < 7):
                    return 1; // Team Sponsor
                case int n when (n >= 7 && n < 10):
                    return 3; // Tyre Supplier
                case int n when (n >= 10 && n < 18):
                    return 2; // Engine Supplier
                case int n when (n >= 18 && n < 27):
                    return 4; // Fuel Supplier
                case int n when (n >= 27 && n < 98):
                    return 5; // Cash Sponsor
                default:
                    throw new ArgumentOutOfRangeException(nameof(id));
            }
        }
    }
}