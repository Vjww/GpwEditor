namespace Data
{
    public class Commentary
    {
        public int[] DefaultDriverIndices { get; }
        public string[] DefaultDriverCodes { get; }
        public string[] AnonymousDriverCodes { get; }

        public int[] DefaultTeamIndices { get; }
        public string[] DefaultTeamCodes { get; }
        public string[] AnonymousTeamCodes { get; }

        public Commentary()
        {
            DefaultDriverIndices = new[]
            {
                67,
                68,
                69,
                70,
                71,
                72,
                73,
                74,
                75,
                76,
                77,
                78,
                79,
                80,
                81,
                82,
                83,
                84,
                85,
                86,
                87,
                88,
                89,
                90,
                91,
                92,
                93,
                94,
                95,
                96,
                97,
                98,
                99,
                100,
                101,
                102,
                103,
                104,
                105,
                106,
                107, // Shared
                107, // Shared
                107, // Shared
                107  // Shared
            };

            DefaultDriverCodes = new[]
            {
                "NEWH",
                "FREN",
                "TOY",
                "SCHU",
                "IRV",
                "BAD",
                "FIS",
                "WURZ",
                "ANON",
                "HAK",
                "COUL",
                "ZON",
                "HIL",
                "RALF",
                "ANON",
                "PAN",
                "TRU",
                "SAR",
                "ALES",
                "HERB",
                "MULL",
                "DIN",
                "SAL",
                "COL",
                "BARI",
                "MAG",
                "ANON",
                "TAK",
                "ROS",
                "MONT",
                "NAK",
                "TUER",
                "RED",
                "ELL",
                "MAR",
                "RAIM",
                "TAN",
                "EBE",
                "PAT",
                "FELL",
                "LAUR",
                "EIS",
                "WILL",
                "MOR"
            };

            AnonymousDriverCodes = new string[44];
            for (var i = 0; i < AnonymousDriverCodes.Length; i++)
            {
                AnonymousDriverCodes[i] = "ANON";
            }

            DefaultTeamIndices = new[]
            {
                231,
                232,
                233,
                234,
                235,
                236,
                237,
                238,
                239,
                240,
                241
            };

            DefaultTeamCodes = new[]
            {
                "WIL",
                "FER",
                "BEN",
                "MCL",
                "JOR",
                "PRO",
                "SAU",
                "ARR",
                "STEW",
                "TYR",
                "MIN",
            };

            AnonymousTeamCodes = new string[11];
            for (var i = 0; i < AnonymousTeamCodes.Length; i++)
            {
                AnonymousTeamCodes[i] = "ANON";
            }
        }
    }
}