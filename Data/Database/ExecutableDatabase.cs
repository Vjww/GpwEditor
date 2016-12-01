using System;
using System.Linq;
using Common.Extensions;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Language;
using Data.Entities.EntityTypes;
using Data.Entities.Executable.Race;
using Data.Entities.Executable.Supplier;
using Data.Entities.Executable.Team;
using Data.Entities.Executable.Track;
using Data.Entities.Language;
using Data.FileConnection;
using StaffSalaries = Data.Entities.Executable.Environment.StaffSalaries;
using StaffSalariesMapping = Data.ValueMapping.Executable.Environment.StaffSalaries;
using RunningCosts = Data.Entities.Executable.Environment.RunningCosts;
using RunningCostsMapping = Data.ValueMapping.Executable.Environment.RunningCosts;
using ExpansionCosts = Data.Entities.Executable.Environment.ExpansionCosts;
using ExpansionCostsMapping = Data.ValueMapping.Executable.Environment.ExpansionCosts;

namespace Data.Database
{
    public class ExecutableDatabase
    {
        // Record counts
        private const int TeamCount = 11;
        private const int TeamFirstGpTrackCount = 19;
        private const int TeamTyreSupplierIdCount = 3;
        private const int DriverCount = 33;
        private const int DriverIdentityCount = 48;
        private const int DriverNationalityIdCount = 14;
        private const int EngineCount = 8;
        private const int TyreCount = 3;
        private const int FuelCount = 9;
        private const int TrackCount = 16;
        private const int TrackDesignCount = 3;

        // Language string mappings
        private const int TeamBaseResourceId = 5696;                // "No Team" - Zero based index
        private const int TeamFirstGpTrackBaseResourceId = 6006;    // "No race" - Zero based index
        private const int TeamTyreSupplierIdBaseResourceId = 4875;  // TODO TyreA -8  - Offset based index
        private const int DriverBaseResourceId = 5795;              // "None" - Zero based index
        private const int DriverNationalityIdBaseResourceId = 5952; // "None" - Zero based index
        private const int EngineBaseResourceId = 4886;              // EngineA - One based index
        private const int TyreBaseResourceId = 4883;                // TyreA - One based index
        private const int FuelBaseResourceId = 4894;                // FuelA - One based index
        private const int TrackBaseResourceId = 6043;               // "No Circuit" - Zero based index
        private const int TrackDesignBaseResourceId = 6525;         // "" - Zero based index

        // Collections
        public IdentityCollection LanguageStrings { get; set; }
        public TeamCollection Teams { get; set; }
        public IdentityCollection TeamFirstGpTrackIdentities { get; set; }
        public IdentityCollection TeamTyreSupplierIdIdentities { get; set; }
        public DriverCollection Drivers { get; set; }
        public IdentityCollection DriverIdentities { get; set; }
        public IdentityCollection DriverNationalityIdIdentities { get; set; }
        public EngineCollection Engines { get; set; }
        public TyreCollection Tyres { get; set; }
        public FuelCollection Fuels { get; set; }
        public TrackCollection Tracks { get; set; }
        public IdentityCollection TrackDesignIdentities { get; set; }
        public RacePerformance RacePerformance { get; set; }
        public FiveLevelTypeCollection StaffSalaries { get; set; }
        public FiveLevelTypeCollection FactoryRunningCosts { get; set; }
        public FiveLevelTypeCollection FactoryExpansionCosts { get; set; }

        public void ImportDataFromFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            ImportLanguageStrings(languageFileFilePath);

            ImportTeams(gameExecutableFilePath);
            ImportTeamFirstGpTrackIdentities();
            ImportTeamTyreSupplierIdIdentities();

            ImportDrivers(gameExecutableFilePath);
            ImportDriverIdentities();
            ImportDriverNationalityIdIdentities();

            ImportEngines(gameExecutableFilePath);
            ImportTyres(gameExecutableFilePath);
            ImportFuels(gameExecutableFilePath);
            ImportTracks(gameExecutableFilePath);
            ImportTrackDesignIdentities();

            ImportRacePerformance(gameExecutableFilePath);

            ImportStaffSalaries(gameExecutableFilePath);
            ImportFactoryRunningCosts(gameExecutableFilePath);
            ImportFactoryExpansionCosts(gameExecutableFilePath);
        }

        public void ExportDataToFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            ExportTeams(gameExecutableFilePath);
            ExportDrivers(gameExecutableFilePath);

            ExportEngines(gameExecutableFilePath);
            ExportTyres(gameExecutableFilePath);
            ExportFuels(gameExecutableFilePath);
            ExportTracks(gameExecutableFilePath);

            ExportRacePerformance(gameExecutableFilePath);

            ExportStaffSalaries(gameExecutableFilePath);
            ExportFactoryRunningCosts(gameExecutableFilePath);
            ExportFactoryExpansionCosts(gameExecutableFilePath);

            ExportLanguageStrings(languageFileFilePath);
        }

        private void ImportLanguageStrings(string languageFileFilePath)
        {
            using (var languageConnection = new LanguageConnection(languageFileFilePath))
            {
                LanguageStrings = languageConnection.Load();
            }
        }

        private void ExportLanguageStrings(string languageFileFilePath)
        {
            using (var languageConnection = new LanguageConnection(languageFileFilePath))
            {
                languageConnection.Save(LanguageStrings);
            }
        }

        private void ImportTeams(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                Teams = new TeamCollection();
                for (var id = 0; id < TeamCount; id++)
                {
                    var valueMapping = new ValueMapping.Executable.Team.Team(id);
                    var team = new Team
                    {
                        Id = id,
                        LocalResourceId = GetTeamResourceId(id),
                        ResourceId = GetResourceId(TeamBaseResourceId, GetTeamResourceId(id)),
                        ResourceText = GetResourceText(GetResourceId(TeamBaseResourceId, GetTeamResourceId(id))),

                        LastPosition = executableConnection.ReadInteger(valueMapping.LastPosition),
                        LastPoints = executableConnection.ReadInteger(valueMapping.LastPoints),
                        FirstGpTrack = executableConnection.ReadInteger(valueMapping.FirstGpTrack),
                        FirstGpYear = executableConnection.ReadInteger(valueMapping.FirstGpYear),
                        Wins = executableConnection.ReadInteger(valueMapping.Wins),
                        YearlyBudget = executableConnection.ReadInteger(valueMapping.YearlyBudget),
                        Unknown = executableConnection.ReadInteger(valueMapping.Unknown),
                        CountryMapId = executableConnection.ReadInteger(valueMapping.CountryMapId),
                        TyreSupplierId = executableConnection.ReadInteger(valueMapping.TyreSupplierId)
                    };
                    Teams.Add(team);
                }
            }
        }

        private void ExportTeams(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                foreach (var team in Teams)
                {
                    SetResourceText(team.ResourceId, team.ResourceText);

                    var valueMapping = new ValueMapping.Executable.Team.Team(team.Id);
                    executableConnection.WriteInteger(valueMapping.LastPosition, team.LastPosition);
                    executableConnection.WriteInteger(valueMapping.LastPoints, team.LastPoints);
                    executableConnection.WriteInteger(valueMapping.FirstGpTrack, team.FirstGpTrack);
                    executableConnection.WriteInteger(valueMapping.FirstGpYear, team.FirstGpYear);
                    executableConnection.WriteInteger(valueMapping.Wins, team.Wins);
                    executableConnection.WriteInteger(valueMapping.YearlyBudget, team.YearlyBudget);
                    executableConnection.WriteInteger(valueMapping.Unknown, team.Unknown);
                    executableConnection.WriteInteger(valueMapping.CountryMapId, team.CountryMapId);
                    executableConnection.WriteInteger(valueMapping.TyreSupplierId, team.TyreSupplierId);
                }
            }
        }

        private static int GetTeamResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
                };

            return idToResourceIdMap[id];
        }

        private void ImportTeamFirstGpTrackIdentities()
        {
            // Import from file
            TeamFirstGpTrackIdentities = new IdentityCollection();
            for (var id = 0; id < TeamFirstGpTrackCount; id++)
            {
                var teamFirstGpTrackIdentity = new Identity
                {
                    Id = id,
                    LocalResourceId = GetTeamFirstGpTrackResourceId(id),
                    ResourceId = GetResourceId(TeamFirstGpTrackBaseResourceId, GetTeamFirstGpTrackResourceId(id)),
                    ResourceText = GetResourceText(GetResourceId(TeamFirstGpTrackBaseResourceId, GetTeamFirstGpTrackResourceId(id)))
                };
                TeamFirstGpTrackIdentities.Add(teamFirstGpTrackIdentity);
            }
        }

        private static int GetTeamFirstGpTrackResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
                };

            return idToResourceIdMap[id];
        }

        private void ImportTeamTyreSupplierIdIdentities()
        {
            // Import from file
            TeamTyreSupplierIdIdentities = new IdentityCollection();
            for (var id = 0; id < TeamTyreSupplierIdCount; id++)
            {
                var teamTyreSupplierIdIdentity = new Identity
                {
                    Id = id,
                    LocalResourceId = GetTeamTyreSupplierIdResourceId(id),
                    ResourceId = GetResourceId(TeamTyreSupplierIdBaseResourceId, GetTeamTyreSupplierIdResourceId(id)),
                    ResourceText = GetResourceText(GetResourceId(TeamTyreSupplierIdBaseResourceId, GetTeamTyreSupplierIdResourceId(id)))
                };
                TeamTyreSupplierIdIdentities.Add(teamTyreSupplierIdIdentity);
            }
        }

        private static int GetTeamTyreSupplierIdResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    8, 9, 10
                };

            return idToResourceIdMap[id];
        }

        private void ImportDrivers(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                Drivers = new DriverCollection();
                for (var id = 0; id < DriverCount; id++)
                {
                    var valueMapping = new ValueMapping.Executable.Team.Driver(id);
                    var driver = new Driver
                    {
                        Id = id,
                        LocalResourceId = GetDriverResourceId(id),
                        ResourceId = GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true),
                        ResourceText = GetResourceText(GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true)),

                        Salary = executableConnection.ReadInteger(valueMapping.Salary),
                        RaceBonus = executableConnection.ReadInteger(valueMapping.RaceBonus),
                        ChampionshipBonus = executableConnection.ReadInteger(valueMapping.ChampionshipBonus),
                        PayRating = executableConnection.ReadInteger(valueMapping.PayRating),
                        PositiveSalary = executableConnection.ReadInteger(valueMapping.PositiveSalary),
                        LastChampionshipPosition = executableConnection.ReadInteger(valueMapping.LastChampionshipPosition),
                        DriverRole = executableConnection.ReadInteger(valueMapping.DriverRole),
                        CarNumber = executableConnection.ReadInteger(valueMapping.CarNumber),
                        Age = executableConnection.ReadInteger(valueMapping.Age),
                        Nationality = executableConnection.ReadInteger(valueMapping.Nationality),
                        CareerChampionships = executableConnection.ReadInteger(valueMapping.CareerChampionships),
                        CareerRaces = executableConnection.ReadInteger(valueMapping.CareerRaces),
                        CareerWins = executableConnection.ReadInteger(valueMapping.CareerWins),
                        CareerPoints = executableConnection.ReadInteger(valueMapping.CareerPoints),
                        CareerFastestLaps = executableConnection.ReadInteger(valueMapping.CareerFastestLaps),
                        CareerPointsFinishes = executableConnection.ReadInteger(valueMapping.CareerPointsFinishes),
                        CareerPolePositions = executableConnection.ReadInteger(valueMapping.CareerPolePositions),
                        Speed = executableConnection.ReadInteger(valueMapping.Speed),
                        Skill = executableConnection.ReadInteger(valueMapping.Skill),
                        Overtaking = executableConnection.ReadInteger(valueMapping.Overtaking),
                        WetWeather = executableConnection.ReadInteger(valueMapping.WetWeather),
                        Concentration = executableConnection.ReadInteger(valueMapping.Concentration),
                        Experience = executableConnection.ReadInteger(valueMapping.Experience),
                        Stamina = executableConnection.ReadInteger(valueMapping.Stamina),
                        Morale = executableConnection.ReadInteger(valueMapping.Morale).ConvertToOneToFiveStepOne()
                    };
                    Drivers.Add(driver);
                }
            }
        }

        private void ImportDriverIdentities()
        {
            // Generate driver identity records
            DriverIdentities = new IdentityCollection();
            foreach (var driver in Drivers)
            {
                var driverIdentity = new Identity()
                {
                    Id = driver.Id,
                    LocalResourceId = driver.LocalResourceId,
                    ResourceId = driver.ResourceId,
                    ResourceText = driver.ResourceText
                };
                DriverIdentities.Add(driverIdentity);
            }

            // Add additional driver identity records
            for (var id = DriverCount; id < DriverIdentityCount; id++)
            {
                var driverIdentity = new Identity()
                {
                    Id = id,
                    LocalResourceId = GetDriverResourceId(id),
                    ResourceId = GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true),
                    ResourceText = GetResourceText(GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true))
                };
                DriverIdentities.Add(driverIdentity);
            }
        }

        private void ExportDrivers(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                foreach (var driver in Drivers)
                {
                    SetResourceText(driver.ResourceId, driver.ResourceText);

                    var valueMapping = new ValueMapping.Executable.Team.Driver(driver.Id);
                    executableConnection.WriteInteger(valueMapping.Salary, driver.Salary);
                    executableConnection.WriteInteger(valueMapping.RaceBonus, driver.RaceBonus);
                    executableConnection.WriteInteger(valueMapping.ChampionshipBonus, driver.ChampionshipBonus);
                    executableConnection.WriteInteger(valueMapping.PayRating, driver.PayRating);
                    executableConnection.WriteInteger(valueMapping.PositiveSalary, driver.PositiveSalary);
                    executableConnection.WriteInteger(valueMapping.LastChampionshipPosition, driver.LastChampionshipPosition);
                    executableConnection.WriteInteger(valueMapping.DriverRole, driver.DriverRole);
                    executableConnection.WriteInteger(valueMapping.CarNumber, driver.CarNumber);
                    executableConnection.WriteInteger(valueMapping.Age, driver.Age);
                    executableConnection.WriteInteger(valueMapping.Nationality, driver.Nationality);
                    executableConnection.WriteInteger(valueMapping.CareerChampionships, driver.CareerChampionships);
                    executableConnection.WriteInteger(valueMapping.CareerRaces, driver.CareerRaces);
                    executableConnection.WriteInteger(valueMapping.CareerWins, driver.CareerWins);
                    executableConnection.WriteInteger(valueMapping.CareerPoints, driver.CareerPoints);
                    executableConnection.WriteInteger(valueMapping.CareerFastestLaps, driver.CareerFastestLaps);
                    executableConnection.WriteInteger(valueMapping.CareerPointsFinishes, driver.CareerPointsFinishes);
                    executableConnection.WriteInteger(valueMapping.CareerPolePositions, driver.CareerPolePositions);
                    executableConnection.WriteInteger(valueMapping.Speed, driver.Speed);
                    executableConnection.WriteInteger(valueMapping.Skill, driver.Skill);
                    executableConnection.WriteInteger(valueMapping.Overtaking, driver.Overtaking);
                    executableConnection.WriteInteger(valueMapping.WetWeather, driver.WetWeather);
                    executableConnection.WriteInteger(valueMapping.Concentration, driver.Concentration);
                    executableConnection.WriteInteger(valueMapping.Experience, driver.Experience);
                    executableConnection.WriteInteger(valueMapping.Stamina, driver.Stamina);
                    executableConnection.WriteInteger(valueMapping.Morale, driver.Morale.ConvertToTwentyToHundredStepTwenty());
                }
            }
        }

        private static int GetDriverResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                    78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 200, 201, 202, 203
                };

            return idToResourceIdMap[id];
        }

        private void ImportDriverNationalityIdIdentities()
        {
            // Import from file
            DriverNationalityIdIdentities = new IdentityCollection();
            for (var id = 0; id < DriverNationalityIdCount; id++)
            {
                var driverNationalityIdIdentity = new Identity
                {
                    Id = id,
                    LocalResourceId = GetDriverNationalityIdResourceId(id),
                    ResourceId = GetResourceId(DriverNationalityIdBaseResourceId, GetDriverNationalityIdResourceId(id)),
                    ResourceText = GetResourceText(GetResourceId(DriverNationalityIdBaseResourceId, GetDriverNationalityIdResourceId(id)))
                };
                DriverNationalityIdIdentities.Add(driverNationalityIdIdentity);
            }
        }

        private static int GetDriverNationalityIdResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
                };

            return idToResourceIdMap[id];
        }

        private void ImportEngines(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                Engines = new EngineCollection();
                for (var id = 0; id < EngineCount; id++)
                {
                    var valueMapping = new ValueMapping.Executable.Supplier.Engine(id);
                    var engine = new Engine
                    {
                        Id = id,
                        LocalResourceId = GetEngineResourceId(id),
                        ResourceId = GetResourceId(EngineBaseResourceId, GetEngineResourceId(id)),
                        ResourceText = GetResourceText(GetResourceId(EngineBaseResourceId, GetEngineResourceId(id))),

                        Fuel = executableConnection.ReadInteger(valueMapping.Fuel),
                        Heat = executableConnection.ReadInteger(valueMapping.Heat),
                        Power = executableConnection.ReadInteger(valueMapping.Power),
                        Reliability = executableConnection.ReadInteger(valueMapping.Reliability),
                        Response = executableConnection.ReadInteger(valueMapping.Response),
                        Rigidity = executableConnection.ReadInteger(valueMapping.Rigidity),
                        Weight = executableConnection.ReadInteger(valueMapping.Weight)
                    };
                    Engines.Add(engine);
                }
            }
        }

        private void ExportEngines(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                foreach (var engine in Engines)
                {
                    SetResourceText(engine.ResourceId, engine.ResourceText);

                    var valueMapping = new ValueMapping.Executable.Supplier.Engine(engine.Id);
                    executableConnection.WriteInteger(valueMapping.Fuel, engine.Fuel);
                    executableConnection.WriteInteger(valueMapping.Heat, engine.Heat);
                    executableConnection.WriteInteger(valueMapping.Power, engine.Power);
                    executableConnection.WriteInteger(valueMapping.Reliability, engine.Reliability);
                    executableConnection.WriteInteger(valueMapping.Response, engine.Response);
                    executableConnection.WriteInteger(valueMapping.Rigidity, engine.Rigidity);
                    executableConnection.WriteInteger(valueMapping.Weight, engine.Weight);
                }
            }
        }

        private static int GetEngineResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    0, 1, 2, 3, 4, 5, 6, 7 // TODO check that 0 based index is correct
                };

            return idToResourceIdMap[id];
        }

        private void ImportTyres(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                Tyres = new TyreCollection();
                for (var id = 0; id < TyreCount; id++)
                {
                    var valueMapping = new ValueMapping.Executable.Supplier.Tyre(id);
                    var tyre = new Tyre
                    {
                        Id = id,
                        LocalResourceId = GetTyreResourceId(id),
                        ResourceId = GetResourceId(TyreBaseResourceId, GetTyreResourceId(id)),
                        ResourceText = GetResourceText(GetResourceId(TyreBaseResourceId, GetTyreResourceId(id)))

                        // TODO
                    };
                    Tyres.Add(tyre);
                }
            }
        }

        private void ExportTyres(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                foreach (var tyre in Tyres)
                {
                    SetResourceText(tyre.ResourceId, tyre.ResourceText);

                    var valueMapping = new ValueMapping.Executable.Supplier.Tyre(tyre.Id);

                    // TODO
                }
            }
        }

        private static int GetTyreResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    0, 1, 2 // TODO check that 0 based index is correct
                };

            return idToResourceIdMap[id];
        }

        private void ImportFuels(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                Fuels = new FuelCollection();
                for (var id = 0; id < FuelCount; id++)
                {
                    var valueMapping = new ValueMapping.Executable.Supplier.Fuel(id);
                    var fuel = new Fuel
                    {
                        Id = id,
                        LocalResourceId = GetFuelResourceId(id),
                        ResourceId = GetResourceId(FuelBaseResourceId, GetFuelResourceId(id)),
                        ResourceText = GetResourceText(GetResourceId(FuelBaseResourceId, GetFuelResourceId(id))),

                        Performance = executableConnection.ReadInteger(valueMapping.Performance),
                        Tolerance = executableConnection.ReadInteger(valueMapping.Tolerance)
                    };
                    Fuels.Add(fuel);
                }
            }
        }

        private void ExportFuels(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                foreach (var fuel in Fuels)
                {
                    SetResourceText(fuel.ResourceId, fuel.ResourceText);

                    var valueMapping = new ValueMapping.Executable.Supplier.Fuel(fuel.Id);
                    executableConnection.WriteInteger(valueMapping.Performance, fuel.Performance);
                    executableConnection.WriteInteger(valueMapping.Tolerance, fuel.Tolerance);
                }
            }
        }

        private static int GetFuelResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8 // TODO check that 0 based index is correct
                };

            return idToResourceIdMap[id];
        }

        private void ImportTracks(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                Tracks = new TrackCollection();
                for (var id = 0; id < TrackCount; id++)
                {
                    var valueMapping = new ValueMapping.Executable.Track.Track(id);
                    var track = new Track
                    {
                        Id = id,
                        LocalResourceId = GetTrackResourceId(id),
                        ResourceId = GetResourceId(TrackBaseResourceId, GetTrackResourceId(id)),
                        ResourceText = GetResourceText(GetResourceId(TrackBaseResourceId, GetTrackResourceId(id))),

                        Laps = executableConnection.ReadInteger(valueMapping.Laps),
                        Design = executableConnection.ReadInteger(valueMapping.Design),
                        LapRecordDriver = executableConnection.ReadInteger(valueMapping.LapRecordDriver),
                        LapRecordTeam = executableConnection.ReadInteger(valueMapping.LapRecordTeam),
                        LapRecordTime = executableConnection.ReadInteger(valueMapping.LapRecordTime),
                        LapRecordMph = executableConnection.ReadInteger(valueMapping.LapRecordMph),
                        LapRecordYear = executableConnection.ReadInteger(valueMapping.LapRecordYear),
                        LastRaceDriver = executableConnection.ReadInteger(valueMapping.LastRaceDriver),
                        LastRaceTeam = executableConnection.ReadInteger(valueMapping.LastRaceTeam),
                        LastRaceYear = executableConnection.ReadInteger(valueMapping.LastRaceYear),
                        LastRaceTime = executableConnection.ReadInteger(valueMapping.LastRaceTime),
                        Speed = executableConnection.ReadInteger(valueMapping.Speed),
                        Grip = executableConnection.ReadInteger(valueMapping.Grip),
                        Surface = executableConnection.ReadInteger(valueMapping.Surface),
                        Tarmac = executableConnection.ReadInteger(valueMapping.Tarmac),
                        Dust = executableConnection.ReadInteger(valueMapping.Dust),
                        Overtaking = executableConnection.ReadInteger(valueMapping.Overtaking),
                        Braking = executableConnection.ReadInteger(valueMapping.Braking),
                        Rain = executableConnection.ReadInteger(valueMapping.Rain),
                        Heat = executableConnection.ReadInteger(valueMapping.Heat),
                        Wind = executableConnection.ReadInteger(valueMapping.Wind)
                    };
                    Tracks.Add(track);
                }
            }
        }

        private void ExportTracks(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                foreach (var track in Tracks)
                {
                    SetResourceText(track.ResourceId, track.ResourceText);

                    var valueMapping = new ValueMapping.Executable.Track.Track(track.Id);
                    executableConnection.WriteInteger(valueMapping.Laps, track.Laps);
                    executableConnection.WriteInteger(valueMapping.Design, track.Design);
                    executableConnection.WriteInteger(valueMapping.LapRecordDriver, track.LapRecordDriver);
                    executableConnection.WriteInteger(valueMapping.LapRecordTeam, track.LapRecordTeam);
                    executableConnection.WriteInteger(valueMapping.LapRecordTime, track.LapRecordTime);
                    executableConnection.WriteInteger(valueMapping.LapRecordMph, track.LapRecordMph);
                    executableConnection.WriteInteger(valueMapping.LapRecordYear, track.LapRecordYear);
                    executableConnection.WriteInteger(valueMapping.LastRaceDriver, track.LastRaceDriver);
                    executableConnection.WriteInteger(valueMapping.LastRaceTeam, track.LastRaceTeam);
                    executableConnection.WriteInteger(valueMapping.LastRaceYear, track.LastRaceYear);
                    executableConnection.WriteInteger(valueMapping.LastRaceTime, track.LastRaceTime);
                    executableConnection.WriteInteger(valueMapping.Speed, track.Speed);
                    executableConnection.WriteInteger(valueMapping.Grip, track.Grip);
                    executableConnection.WriteInteger(valueMapping.Surface, track.Surface);
                    executableConnection.WriteInteger(valueMapping.Tarmac, track.Tarmac);
                    executableConnection.WriteInteger(valueMapping.Dust, track.Dust);
                    executableConnection.WriteInteger(valueMapping.Overtaking, track.Overtaking);
                    executableConnection.WriteInteger(valueMapping.Braking, track.Braking);
                    executableConnection.WriteInteger(valueMapping.Rain, track.Rain);
                    executableConnection.WriteInteger(valueMapping.Heat, track.Heat);
                    executableConnection.WriteInteger(valueMapping.Wind, track.Wind);
                }
            }
        }

        private static int GetTrackResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
                };

            return idToResourceIdMap[id];
        }

        private void ImportTrackDesignIdentities()
        {
            // Import from file
            TrackDesignIdentities = new IdentityCollection();
            for (var id = 0; id < TrackDesignCount; id++)
            {
                var trackDesignIdentity = new Identity
                {
                    Id = id,
                    LocalResourceId = GetTrackDesignResourceId(id),
                    ResourceId = GetResourceId(TrackDesignBaseResourceId, GetTrackDesignResourceId(id)),
                    ResourceText = GetResourceText(GetResourceId(TrackDesignBaseResourceId, GetTrackDesignResourceId(id)))
                };
                TrackDesignIdentities.Add(trackDesignIdentity);
            }
        }

        private static int GetTrackDesignResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3
                };

            return idToResourceIdMap[id];
        }

        private void ImportRacePerformance(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Import from file
                var valueMapping = new ValueMapping.Executable.Race.RacePerformance();
                RacePerformance = new RacePerformance();

                for (var i = 0; i < RacePerformance.Values.Length; i++)
                {
                    RacePerformance.Values[i] = executableConnection.ReadInteger(valueMapping.Values[i]);
                }
            }
        }

        private void ExportRacePerformance(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                // Export to file
                var valueMapping = new ValueMapping.Executable.Race.RacePerformance();

                for (var i = 0; i < RacePerformance.Values.Length; i++)
                {
                    executableConnection.WriteInteger(valueMapping.Values[i], RacePerformance.Values[i]);
                }
            }
        }

        private void ImportStaffSalaries(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                StaffSalaries = new FiveLevelTypeCollection
                {
                    new StaffSalaries.Commercial("Commercial", new StaffSalariesMapping.Commercial()),
                    new StaffSalaries.Design("Design", new StaffSalariesMapping.Design()),
                    new StaffSalaries.Engineering("Engineering", new StaffSalariesMapping.Engineering()),
                    new StaffSalaries.Mechanics("Mechanics", new StaffSalariesMapping.Mechanics()),
                };
                foreach (var item in StaffSalaries)
                {
                    item.ImportData(executableConnection, null);
                }
            }
        }

        private void ExportStaffSalaries(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                foreach (var item in StaffSalaries)
                {
                    item.ExportData(executableConnection, null);
                }
            }
        }

        private void ImportFactoryRunningCosts(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                FactoryRunningCosts = new FiveLevelTypeCollection
                {
                    new RunningCosts.Factory("Factory", new RunningCostsMapping.Factory()),
                    new RunningCosts.WindTunnel("Wind Tunnel", new RunningCostsMapping.WindTunnel())
                };
                foreach (var item in FactoryRunningCosts)
                {
                    item.ImportData(executableConnection, null);
                }
            }
        }

        private void ExportFactoryRunningCosts(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                foreach (var item in FactoryRunningCosts)
                {
                    item.ExportData(executableConnection, null);
                }
            }
        }

        private void ImportFactoryExpansionCosts(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                FactoryExpansionCosts = new FiveLevelTypeCollection
                {
                    new ExpansionCosts.Factory("Factory", new ExpansionCostsMapping.Factory()),
                    new ExpansionCosts.WindTunnel("Wind Tunnel", new ExpansionCostsMapping.WindTunnel()),
                    new ExpansionCosts.Supercomputer("Supercomputer", new ExpansionCostsMapping.Supercomputer()),
                    new ExpansionCosts.Cam("CAM", new ExpansionCostsMapping.Cam()),
                    new ExpansionCosts.Cad("CAD", new ExpansionCostsMapping.Cad()),
                    new ExpansionCosts.Workshop("Workshop", new ExpansionCostsMapping.Workshop()),
                    new ExpansionCosts.TestRig("Test Rig", new ExpansionCostsMapping.TestRig())
                };
                foreach (var item in FactoryExpansionCosts)
                {
                    item.ImportData(executableConnection, null);
                }
            }
        }

        private void ExportFactoryExpansionCosts(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                foreach (var item in FactoryExpansionCosts)
                {
                    item.ExportData(executableConnection, null);
                }
            }
        }

        private static string GetResourceId(int baseResourceId, int localResourceId, bool isDriver = false)
        {
            if (!isDriver)
            {
                return (baseResourceId + localResourceId).BuildStringTableId();
            }

            // Special consideration for driver names that are not actually drivers in the game
            // e.g. Used for displaying historic fastest lap records in the game
            int recalculatedLocalResourceId;
            if ((localResourceId >= 200) && (localResourceId <= 203))
            {
                // Recalculate virtual position in game to real position in language file
                recalculatedLocalResourceId = 535 + localResourceId;
            }
            else
            {
                recalculatedLocalResourceId = localResourceId;
            }

            return (baseResourceId + recalculatedLocalResourceId).BuildStringTableId();
        }

        private string GetResourceText(string resourceId)
        {
            var resource = LanguageStrings.SingleOrDefault(x => x.ResourceId == resourceId);

            if (resource == null)
            {
                throw new Exception($"Unable to find a language string matching the resource id {resourceId}.");
            }

            return resource.ResourceText;
        }

        private void SetResourceText(string resourceId, string resourceText)
        {
            var resource = LanguageStrings.SingleOrDefault(x => x.ResourceId == resourceId);

            if (resource == null)
            {
                throw new Exception($"Unable to find a language string matching the resource id {resourceId}.");
            }

            resource.ResourceText = resourceText;
        }
    }
}
