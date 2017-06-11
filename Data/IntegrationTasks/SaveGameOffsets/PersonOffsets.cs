namespace Data.IntegrationTasks.SaveGameOffsets
{
    class PersonOffsets
    {
        // Base offset = 97824
        // Struct offset = 3576
        // 
        // Any reference made to the player represents that the offset is only          
        // applicable to those staff members in the player's team.                      
        //
        // * Pay driver's cash contribution (salary) for next year. Stored as a
        //   positive value but appears as a negative value in the game.
        //
        // ** Pay driver's cash contribution rating (1-5) for next year.
        // 
        //      The following is assumed (needs clarification):
        //        5 star = Between $9m and $11m
        //        4 star = Between $7m and  $9m
        //        3 star = Between $5m and  $7m
        //        2 star = Between $3m and  $5m
        //        1 star = Between $1m and  $3m
        // 
        // *******************************************************************
        // ABBREVIATIONS                                                                
        //                                                                              
        // F1TP = F1 Team Principal                                                     
        // F1SM = F1 Sponsorship Manager (a.k.a. F1 Commercial Manager)                 
        // F1CD = F1 Chief Designer                                                     
        // F1TD = F1 Technical Director                                                 
        // F1CM = F1 Chief Mechanic                                                     
        // F1DR = F1 Race Driver                                                        
        // F1DT = F1 Test Driver                                                        
        // F1DN = F1 No Driver
        // F1DP = F1 Pay Driver                                                         
        // NF1SM = Non-F1 Sponsorship Manager (a.k.a. Non-F1 Commercial Manager)        
        // NF1CD = Non-F1 Chief Designer                                                
        // NF1TD = Non-F1 Technical Director                                            
        // NF1CM = Non-F1 Chief Mechanic                                                
        // NF1DR = Non-F1 Race Driver                                                   
        // NF1DP = Non-F1 Pay Driver                                                    
        //                                                                              
        // *******************************************************************

        // Personal (11)
        const int OffsetCurrentTeamA = 8;        // All except Non-F1
        const int OffsetCurrentTeamB = 12;       // All except Non-F1
        const int OffsetPositionA = 0;           // All (position in team hierarchy)
        const int OffsetPositionB = 3340;        // All??? (position in team hierarchy) Old: Only F1DR, F1DT, F1DP
        const int OffsetPositionC = 3356;        // All??? (position in team hierarchy) Old: Only F1DR, F1DT, F1DP of player
        const int OffsetName = 4;                // All (string index of name in language file)
        const int OffsetAge = 24;                // All
        const int OffsetNationality = 168;       // All drivers (string index of nationality in language file)
        const int OffsetAbility = 40;            // All chiefs
        const int OffsetMorale = 3160;           // All
        const int OffsetDriverLoyalty = 172;     // All chiefs except Commercial (string index of driver in language file)

        // Contractual (9)
        const int OffsetSalary = 20;             // Salary (All except F1TP, F1DN)
        const int OffsetRaceBonus = 28;          // Race bonus (All except F1TP, F1SM, F1DN, NF1SM)
        const int OffsetChampionshipBonus = 32;  // Championship bonus (All except F1TP, F1SM, F1DN, NF1SM)
        const int OffsetRoyalty = 36;            // Royalty percentage (Only F1SM, NF1SM)
        const int OffsetYearsRemaining = 176;    // Years remaining on the contract, including current year (All except NF1SM, NF1CD, NF1TD, NF1CM, NF1DR, NF1DP)
        const int OffsetTotalYears = 192;        // Total years of the contract, including past, current and future years (All)
        const int OffsetFinalYear = 196;         // Final year of the contract (All except NF1SM, NF1CD, NF1TD, NF1CM, NF1DR, NF1DP)
        const int OffsetNextYearPaySalaryCashValue = 3176;   // * Absolute value of next year's salary (Only F1DP, NF1DP)
        const int OffsetNextYearPaySalaryRatingValue = 3180; // ** The "five square" importance value of next year's salary (Only F1DP, NF1DP)

        // Racing
        const int OffsetSpeed = 3136;                           // All drivers
        const int OffsetSkill = 3168;                           // All drivers
        const int OffsetOvertaking = 3140;                      // All drivers
        const int OffsetWetWeather = 3144;                      // All drivers
        const int OffsetConcentration = 3148;                   // All drivers
        const int OffsetExperience = 3152;                      // All drivers
        const int OffsetStamina = 3156;                         // All drivers
        const int OffsetChampionships = 3192;                   // All drivers
        const int OffsetRaces = 3196;                           // All drivers
        const int OffsetWins = 60;                              // All drivers
        const int OffsetPoints = 48;                            // All drivers
        const int OffsetFastestLaps = 3208;                     // All drivers
        const int OffsetPointsFinishes = 3204;                  // All drivers
        const int OffsetPolePositions = 64;                     // All drivers
        const int OffsetCarNumber = 3508;                       // All competing drivers???
        const int OffsetDriverNumber = 3516;                    // All competing drivers???

        // Driver orders
        const int OffsetDriverOrderAcceleration = 3444;         // All competing drivers???
        const int OffsetDriverOrderBraking = 3448;              // All competing drivers???
        const int OffsetDriverOrderTopSpeed = 3452;             // All competing drivers???
        const int OffsetDriverOrderKerbUse = 3456;              // All competing drivers???
        const int OffsetDriverOrderOffRacingLine = 3460;        // All competing drivers???
        const int OffsetDriverOrderLineDefence = 3464;          // All competing drivers???
        const int OffsetDriverOrderOvertakePosition = 3468;     // All competing drivers???
        const int OffsetDriverOrderOvertakeBackmarkers = 3472;  // All competing drivers???

        // Other (7)
        const int OffsetNonRacingvsRacingA = 52;     // Non-racing vs Racing flag (All)
        const int OffsetNonRacingvsRacingB = 3548;   // Non-racing vs Racing flag (All)
        const int OffsetF1vsNonF1 = 3188;            // F1 vs Non-F1 flag (All)
        const int OffsetChampionshipPosition = 56;   // Championship position after the last race (Only F1DR, F1DT, F1DP, NF1DR, NF1DP)
        const int OffsetRoleSetByPlayer = 3184;      // Driver orders' role, set by player (Only F1DR, F1DT, F1DP of player)
        const int OffsetRoleSetByContractA = 3344;   // Driver orders' role, set by contract (Only F1DR, F1DT, F1DP)
        const int OffsetRoleSetByContractB = 3352;   // Driver orders' role, set by contract (Only F1DR, F1DT, F1DP of player)
    }
}
