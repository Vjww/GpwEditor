using System;

namespace App.BaseGameEditor.Application.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the game year value in the game.
    /// </summary>
    public class GameYearUpdate
    {
        private const int GameStartDateOffset = 0x0046DC82 - 0x00400C00;      // The 8 in Sunday 8th March 1998 (0x0006D082)
        private const int GameStartDayOfWeekOffset = 0x005A1654 - 0x00400C00; // The Thursday in Thursday 1st January 1998 (0x001A0A54)

        private const int GameYear199601Offset = 0x0058D7AD - 0x00400C00; // SID007157                 (0x0018CBAD)
        private const int GameYear199602Offset = 0x0058DA74 - 0x00400C00; // SID007162                 (0x0018CE74)
        private const int GameYear199603Offset = 0x0058DE7F - 0x00400C00; // SID004089                 (0x0018D27F)
        private const int GameYear199604Offset = 0x0058E182 - 0x00400C00; // SID004089                 (0x0018D582)
        private const int GameYear199605Offset = 0x005F8FF0 - 0x00400C00; // SID000420                 (0x001F83F0)

        private const int GameYear199701Offset = 0x00481547 - 0x00400C00; // References dword_14C74A8  (0x00080947)
        private const int GameYear199702Offset = 0x004EF0A1 - 0x00400C00; // References dword_14C74A8  (0x000EE4A1)
        private const int GameYear199703Offset = 0x005093FD - 0x00400C00; // SID000352                 (0x001087FD)
        private const int GameYear199704Offset = 0x0051263F - 0x00400C00; // References dword_14C74A8  (0x00111A3F)
        private const int GameYear199705Offset = 0x0058D583 - 0x00400C00; // SID004088                 (0x0018C983)
        private const int GameYear199706Offset = 0x0058D782 - 0x00400C00; // SID007156                 (0x0018CB82)
        private const int GameYear199707Offset = 0x0058DA49 - 0x00400C00; // SID007161                 (0x0018CE49)
        private const int GameYear199708Offset = 0x0058DD32 - 0x00400C00; // SID004082                 (0x0018D132)
        private const int GameYear199709Offset = 0x0058DE54 - 0x00400C00; // SID004088                 (0x0018D254)
        private const int GameYear199710Offset = 0x0058E157 - 0x00400C00; // SID004088                 (0x0018D557)
        private const int GameYear199711Offset = 0x005A16D4 - 0x00400C00; // Calendar logic            (0x001A0AD4)
        private const int GameYear199712Offset = 0x005A1885 - 0x00400C00; // Calendar logic            (0x001A0C85)
        private const int GameYear199713Offset = 0x005B1AA1 - 0x00400C00; // SID004852                 (0x001B0EA1)
        private const int GameYear199714Offset = 0x005B1F18 - 0x00400C00; // SID004863                 (0x001B1318)
        private const int GameYear199715Offset = 0x005C2EE4 - 0x00400C00; // References dword_14C74A8  (0x001C22E4)
        private const int GameYear199716Offset = 0x005CC8DA - 0x00400C00; // References dword_14C74A8  (0x001CBCDA)
        private const int GameYear199717Offset = 0x005D9A6B - 0x00400C00; // SID000420                 (0x001D8E6B)
        private const int GameYear199718Offset = 0x005F5A24 - 0x00400C00; // References dword_14C74A8  (0x001F4E24)
        private const int GameYear199719Offset = 0x00662FFF - 0x00400C00; // SID001476                 (0x002623FF)
        private const int GameYear199720Offset = 0x00663040 - 0x00400C00; // SID001476                 (0x00262440)
        private const int GameYear199721Offset = 0x00665ED4 - 0x00400C00; // SID004307                 (0x002652D4)
        private const int GameYear199722Offset = 0x006664B5 - 0x00400C00; // SID004323                 (0x002658B5)
        private const int GameYear199723Offset = 0x0066657F - 0x00400C00; // SID004325                 (0x0026597F)
        private const int GameYear199724Offset = 0x00666705 - 0x00400C00; // SID004329                 (0x00265B05)
        private const int GameYear199725Offset = 0x00668363 - 0x00400C00; // SID004498                 (0x00267763)
        private const int GameYear199726Offset = 0x0066C397 - 0x00400C00; // SID004839                 (0x0026B797)
        private const int GameYear199727Offset = 0x0066C3D8 - 0x00400C00; // SID004839                 (0x0026B7D8)
        private const int GameYear199728Offset = 0x0066F4DC - 0x00400C00; // SID004234                 (0x0026E8DC)
        private const int GameYear199729Offset = 0x0066F51D - 0x00400C00; // SID004234                 (0x0026E91D)

        private const int GameYear199801Offset = 0x0046DC7B - 0x00400C00; // Calendar logic            (0x0006D07B) 
        private const int GameYear199802Offset = 0x0050939C - 0x00400C00; // SID000351                 (0x0010879C) 
        private const int GameYear199803Offset = 0x0050AF58 - 0x00400C00; // SID000420                 (0x0010A358) 
        private const int GameYear199804Offset = 0x0051145C - 0x00400C00; // References dword_F4DB08   (0x0011085C) 
        private const int GameYear199805Offset = 0x00511631 - 0x00400C00; // References dword_14C74A8  (0x00110A31) 
        private const int GameYear199806Offset = 0x00511EB6 - 0x00400C00; // References dword_14C74A8  (0x001112B6) 
        private const int GameYear199807Offset = 0x005A1636 - 0x00400C00; // Calendar logic            (0x001A0A36) 
        private const int GameYear199808Offset = 0x005A165E - 0x00400C00; // Calendar logic            (0x001A0A5E) 
        private const int GameYear199809Offset = 0x005A1855 - 0x00400C00; // Calendar logic            (0x001A0C55) 
        private const int GameYear199810Offset = 0x005D9A04 - 0x00400C00; // SID000419                 (0x001D8E04) 
        private const int GameYear199811Offset = 0x005F2A12 - 0x00400C00; // References dword_14C74A8  (0x001F1E12) 
        private const int GameYear199812Offset = 0x005F2F92 - 0x00400C00; // References dword_14C74A8  (0x001F2392) 
        private const int GameYear199813Offset = 0x005F34FA - 0x00400C00; // References dword_14C74A8  (0x001F28FA) 
        private const int GameYear199814Offset = 0x005F3A62 - 0x00400C00; // References dword_14C74A8  (0x001F2E62) 
        private const int GameYear199815Offset = 0x005F3FC6 - 0x00400C00; // References dword_14C74A8  (0x001F33C6) 
        private const int GameYear199816Offset = 0x005F452E - 0x00400C00; // References dword_14C74A8  (0x001F392E) 
        private const int GameYear199817Offset = 0x005F4A92 - 0x00400C00; // References dword_14C74A8  (0x001F3E92) 
        private const int GameYear199818Offset = 0x0060D279 - 0x00400C00; // References dword_877100   (0x0020C679) 
        private const int GameYear199819Offset = 0x0060D349 - 0x00400C00; // References local variable (0x0020C749) 
        private const int GameYear199820Offset = 0x0060D593 - 0x00400C00; // References dword_877100   (0x0020C993) 
        private const int GameYear199821Offset = 0x0060D744 - 0x00400C00; // References dword_877100   (0x0020CB44) 

        private const int GameYear199901Offset = 0x004E902E - 0x00400C00; // References dword_7E603C   (0x000E842E)
        private const int GameYear199902Offset = 0x0050AEF7 - 0x00400C00; // References dword_14C74A8  (0x0010A2F7)

        private const int GameYear200001Offset = 0x005A1723 - 0x00400C00; // Calendar logic            (0x001A0B23)
        private const int GameYear200002Offset = 0x005A18D4 - 0x00400C00; // Calendar logic            (0x001A0CD4)
        private const int GameYear200003Offset = 0x005A1CC7 - 0x00400C00; // Calendar logic            (0x001A10C7)

        private const int GameYear200101Offset = 0x005A168D - 0x00400C00; // Calendar logic            (0x001A0A8D)

        private const int GameYear200401Offset = 0x005A1733 - 0x00400C00; // Calendar logic            (0x001A0B33)
        private const int GameYear200402Offset = 0x005A18E4 - 0x00400C00; // Calendar logic            (0x001A0CE4)
        private const int GameYear200403Offset = 0x005A1CD4 - 0x00400C00; // Calendar logic            (0x001A10D4)

        private const int GameYear200501Offset = 0x005A169D - 0x00400C00; // Calendar logic            (0x001A0A9D)

        private const int GameYear200701Offset = 0x005A1673 - 0x00400C00; // Calendar logic            (0x001A0A73)
        private const int GameYear200702Offset = 0x005A186A - 0x00400C00; // Calendar logic            (0x001A0C6A)

        private const int GameYear200801Offset = 0x005A1CE1 - 0x00400C00; // Calendar logic            (0x001A10E1)

        private const int GameYear201201Offset = 0x005A1CEE - 0x00400C00; // Calendar logic            (0x001A10EE)

        public int GetGameYear(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                var result = executableConnection.ReadInteger(GameYear199801Offset);
                return result;
            }
        }

        public void SetGameYear(int gameYear, string gameExecutableFilePath)
        {
            // Calculate adjustment and invert sign
            // e.g. if changing game year from 1998 to 2001, 1998-2001 = -3 = 3
            // e.g. if changing game year from 1998 to 1995, 1998-1995 = 3 = -3
            var adjustment = 1998 - gameYear;
            adjustment = -adjustment;

            // Game year of 2001 will now have an adjustment value of 3
            // Game year of 1995 will now have an adjustment value of -3

            var year1996 = 1996 + adjustment; // Effective game year value for 1996 is 1993/1999
            var year1997 = 1997 + adjustment; // Effective game year value for 1997 is 1994/2000
            var year1998 = 1998 + adjustment; // Effective game year value for 1998 is 1995/2001
            var year1999 = 1999 + adjustment; // Effective game year value for 1999 is 1996/2002
            var year2007 = 2007 + adjustment;

            // Get first leap year from game starting year
            var firstLeapYear = 0;
            for (var i = gameYear; i < gameYear + 10; i++)
            {
                if (DateTime.IsLeapYear(i))
                {
                    firstLeapYear = i;
                    break;
                }
            }
            var secondLeapYear = firstLeapYear + 4;
            var thirdLeapYear = secondLeapYear + 4;
            var fourthLeapYear = thirdLeapYear + 4;

            var yearAfterFirstLeapYear = firstLeapYear + 1;
            var yearAfterSecondLeapYear = secondLeapYear + 1;

            var gameStartDayOfWeek = (int)new DateTime(gameYear, 1, 1).DayOfWeek;
            if (gameStartDayOfWeek == 0) // If Sunday
            {
                gameStartDayOfWeek = 7; // Make Sunday the 7th day to match DayOfWeek logic used in the game
            }

            int gameStartDate;
            var date = 8; // The 8 in Sunday 8th March 1998 (default game start date)
            while (true)
            {
                // If the game start date using new gameYear value is not a Sunday, increment date
                // e.g. for 1999, the next Sunday after 8th March is 14th March
                if (new DateTime(gameYear, 3, date).DayOfWeek != DayOfWeek.Sunday)
                {
                    date++;
                }
                else
                {
                    // Set start date to be a date that is a Sunday 
                    gameStartDate = date;
                    break;
                }
            }

            // The day of the week naturally increments each year for 1st January (e.g 1998 = Thursday, 1999 = Friday)
            // But when the year follows a leap year, the day of the week should be incremented by two.
            // e.g. if 2000 is a leap year and started on a Saturday, then 2001 starts on a Monday
            // e.g. if 2004 is a leap year and started on a Thursday, then 2005 starts on a Saturday
            // Note, where there are three leap years in a ten-year period, the day of the week will
            // fall behind by one day as the game code only increments the day of the week twice, as
            // it was assumed that there would only ever be two leap years between 1998-2007.

            // Update all values affected by change in game year
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                executableConnection.WriteByte(GameStartDateOffset, (byte)gameStartDate);
                executableConnection.WriteInteger(GameStartDayOfWeekOffset, gameStartDayOfWeek);

                executableConnection.WriteInteger(GameYear199601Offset, year1996);
                executableConnection.WriteInteger(GameYear199602Offset, year1996);
                executableConnection.WriteInteger(GameYear199603Offset, year1996);
                executableConnection.WriteInteger(GameYear199604Offset, year1996);
                executableConnection.WriteInteger(GameYear199605Offset, year1996);

                executableConnection.WriteInteger(GameYear199701Offset, year1997);
                executableConnection.WriteInteger(GameYear199702Offset, year1997);
                executableConnection.WriteInteger(GameYear199703Offset, year1997);
                executableConnection.WriteInteger(GameYear199704Offset, year1997);
                executableConnection.WriteInteger(GameYear199705Offset, year1997);
                executableConnection.WriteInteger(GameYear199706Offset, year1997);
                executableConnection.WriteInteger(GameYear199707Offset, year1997);
                executableConnection.WriteInteger(GameYear199708Offset, year1997);
                executableConnection.WriteInteger(GameYear199709Offset, year1997);
                executableConnection.WriteInteger(GameYear199710Offset, year1997);
                executableConnection.WriteInteger(GameYear199711Offset, year1997);
                executableConnection.WriteInteger(GameYear199712Offset, year1997);
                executableConnection.WriteInteger(GameYear199713Offset, year1997);
                executableConnection.WriteInteger(GameYear199714Offset, year1997);
                executableConnection.WriteInteger(GameYear199715Offset, year1997);
                executableConnection.WriteInteger(GameYear199716Offset, year1997);
                executableConnection.WriteInteger(GameYear199717Offset, year1997);
                executableConnection.WriteInteger(GameYear199718Offset, year1997);
                executableConnection.WriteInteger(GameYear199719Offset, year1997);
                executableConnection.WriteInteger(GameYear199720Offset, year1997);
                executableConnection.WriteInteger(GameYear199721Offset, year1997);
                executableConnection.WriteInteger(GameYear199722Offset, year1997);
                executableConnection.WriteInteger(GameYear199723Offset, year1997);
                executableConnection.WriteInteger(GameYear199724Offset, year1997);
                executableConnection.WriteInteger(GameYear199725Offset, year1997);
                executableConnection.WriteInteger(GameYear199726Offset, year1997);
                executableConnection.WriteInteger(GameYear199727Offset, year1997);
                executableConnection.WriteInteger(GameYear199728Offset, year1997);
                executableConnection.WriteInteger(GameYear199729Offset, year1997);

                executableConnection.WriteInteger(GameYear199801Offset, year1998);
                executableConnection.WriteInteger(GameYear199802Offset, year1998);
                executableConnection.WriteInteger(GameYear199803Offset, year1998);
                executableConnection.WriteInteger(GameYear199804Offset, year1998);
                executableConnection.WriteInteger(GameYear199805Offset, year1998);
                executableConnection.WriteInteger(GameYear199806Offset, year1998);
                executableConnection.WriteInteger(GameYear199807Offset, year1998);
                executableConnection.WriteInteger(GameYear199808Offset, year1998);
                executableConnection.WriteInteger(GameYear199809Offset, year1998);
                executableConnection.WriteInteger(GameYear199810Offset, year1998);
                executableConnection.WriteInteger(GameYear199811Offset, year1998);
                executableConnection.WriteInteger(GameYear199812Offset, year1998);
                executableConnection.WriteInteger(GameYear199813Offset, year1998);
                executableConnection.WriteInteger(GameYear199814Offset, year1998);
                executableConnection.WriteInteger(GameYear199815Offset, year1998);
                executableConnection.WriteInteger(GameYear199816Offset, year1998);
                executableConnection.WriteInteger(GameYear199817Offset, year1998);
                executableConnection.WriteInteger(GameYear199818Offset, year1998);
                executableConnection.WriteInteger(GameYear199819Offset, year1998);
                executableConnection.WriteInteger(GameYear199820Offset, year1998);
                executableConnection.WriteInteger(GameYear199821Offset, year1998);

                executableConnection.WriteInteger(GameYear199901Offset, year1999);
                executableConnection.WriteInteger(GameYear199902Offset, year1999);

                executableConnection.WriteInteger(GameYear200001Offset, firstLeapYear);
                executableConnection.WriteInteger(GameYear200002Offset, firstLeapYear);
                executableConnection.WriteInteger(GameYear200003Offset, firstLeapYear);

                executableConnection.WriteInteger(GameYear200101Offset, yearAfterFirstLeapYear);

                executableConnection.WriteInteger(GameYear200401Offset, secondLeapYear);
                executableConnection.WriteInteger(GameYear200402Offset, secondLeapYear);
                executableConnection.WriteInteger(GameYear200403Offset, secondLeapYear);

                executableConnection.WriteInteger(GameYear200501Offset, yearAfterSecondLeapYear);

                executableConnection.WriteInteger(GameYear200701Offset, year2007);
                executableConnection.WriteInteger(GameYear200702Offset, year2007);

                executableConnection.WriteInteger(GameYear200801Offset, thirdLeapYear);

                executableConnection.WriteInteger(GameYear201201Offset, fourthLeapYear);
            }
        }
    }
}