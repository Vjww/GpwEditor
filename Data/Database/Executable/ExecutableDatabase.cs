using System;
using System.Linq;
using Core.Collections;
using Core.Collections.Executable.Supplier;
using Core.Collections.Executable.Team;
using Core.Collections.Executable.Track;
using Core.Entities;
using Core.Entities.Executable.Team;
using Core.Entities.Executable.Track;
using Core.Extensions;
using Data.Enums;
using Data.FileConnection;

namespace Data.Database.Executable
{
    public class ExecutableDatabase
    {
        private ExecutableConnection _executableConnection;
        private LanguageConnection _languageConnection;

        private const int TeamCount = 11;
        private const int DriverCount = 33;
        private const int DriverIdentityCount = 48;
        private const int TrackCount = 16;

        private const int TeamBaseResourceId = 5696;
        private const int DriverBaseResourceId = 5795;
        private const int TrackBaseResourceId = 6043;

        public TeamCollection Teams { get; set; }
        public DriverCollection Drivers { get; set; }
        public IdentityCollection DriverIdentities { get; set; }
        public EngineCollection Engines { get; set; }
        public TyreCollection Tyres { get; set; }
        public FuelCollection Fuels { get; set; }
        public TrackCollection Tracks { get; set; }

        public IdentityCollection StringTable { get; set; }

        public static byte[] GetCheckboxInstructions()
        {
            return new byte[] { 0x90, 0x90 };
        }

        public static bool DoesExeUseMyInstructions(ExecutableConnection executableConnection)
        {
            var exeValues = executableConnection.ReadByteArray(0, 2);
            return exeValues.SequenceEqual(GetCheckboxInstructions());
        }

        public bool ImportDataFromFile(string executableFilePath, string languageFilePath)
        {
            try
            {
                // Open file and read
                _executableConnection = new ExecutableConnection();
                _executableConnection.Open(executableFilePath, StreamDirectionType.Read);

                _languageConnection = new LanguageConnection();
                _languageConnection.Open(languageFilePath, StreamDirectionType.Read);
                StringTable = _languageConnection.Load();

                ImportTeams();
                ImportDrivers();
                ImportTracks();
            }
            finally
            {
                if (_executableConnection != null)
                {
                    _executableConnection.Close();
                }

                if (_languageConnection != null)
                {
                    _languageConnection.Close();
                }
            }

            return true;
        }

        public bool ExportDataToFile(string executableFilePath, string languageFilePath)
        {
            try
            {
                // Open file and write
                _executableConnection = new ExecutableConnection();
                _executableConnection.Open(executableFilePath, StreamDirectionType.Write);

                ExportTeams();
                ExportDrivers();
                ExportTracks();

                _languageConnection = new LanguageConnection();
                _languageConnection.Open(languageFilePath, StreamDirectionType.Write);
                _languageConnection.Save(StringTable);
            }
            finally
            {
                if (_executableConnection != null)
                {
                    _executableConnection.Close();
                }

                if (_languageConnection != null)
                {
                    _languageConnection.Close();
                }
            }

            return true;
        }

        private void ImportTeams()
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

                    LastPosition = _executableConnection.ReadInteger(valueMapping.LastPosition),
                    LastPoints = _executableConnection.ReadInteger(valueMapping.LastPoints),
                    FirstGpTrack = _executableConnection.ReadInteger(valueMapping.FirstGpTrack),
                    FirstGpYear = _executableConnection.ReadInteger(valueMapping.FirstGpYear),
                    Wins = _executableConnection.ReadInteger(valueMapping.Wins),
                    YearlyBudget = _executableConnection.ReadInteger(valueMapping.YearlyBudget),
                    Unknown = _executableConnection.ReadInteger(valueMapping.Unknown),
                    CountryMapId = _executableConnection.ReadInteger(valueMapping.CountryMapId),
                    TyreSupplierId = _executableConnection.ReadInteger(valueMapping.TyreSupplierId)
                };
                Teams.Add(team);
            }
        }

        private void ExportTeams()
        {
            // Export to file
            foreach (var team in Teams)
            {
                SetResourceText(team.ResourceId, team.ResourceText);

                var valueMapping = new ValueMapping.Executable.Team.Team(team.Id);
                _executableConnection.WriteInteger(valueMapping.LastPosition, team.LastPosition);
                _executableConnection.WriteInteger(valueMapping.LastPoints, team.LastPoints);
                _executableConnection.WriteInteger(valueMapping.FirstGpTrack, team.FirstGpTrack);
                _executableConnection.WriteInteger(valueMapping.FirstGpYear, team.FirstGpYear);
                _executableConnection.WriteInteger(valueMapping.Wins, team.Wins);
                _executableConnection.WriteInteger(valueMapping.YearlyBudget, team.YearlyBudget);
                _executableConnection.WriteInteger(valueMapping.Unknown, team.Unknown);
                _executableConnection.WriteInteger(valueMapping.CountryMapId, team.CountryMapId);
                _executableConnection.WriteInteger(valueMapping.TyreSupplierId, team.TyreSupplierId);
            }
        }

        private static int GetTeamResourceId(int id)
        {
            var idToResourceIdMap = new int[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
                };

            return idToResourceIdMap[id];
        }

        private void ImportDrivers()
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

                    Salary = _executableConnection.ReadInteger(valueMapping.Salary),
                    RaceBonus = _executableConnection.ReadInteger(valueMapping.RaceBonus),
                    ChampionshipBonus = _executableConnection.ReadInteger(valueMapping.ChampionshipBonus),
                    PayRating = _executableConnection.ReadInteger(valueMapping.PayRating),
                    PositiveSalary = _executableConnection.ReadInteger(valueMapping.PositiveSalary),
                    LastChampionshipPosition = _executableConnection.ReadInteger(valueMapping.LastChampionshipPosition),
                    DriverRole = _executableConnection.ReadInteger(valueMapping.DriverRole),
                    CarNumber = _executableConnection.ReadInteger(valueMapping.CarNumber),
                    Age = _executableConnection.ReadInteger(valueMapping.Age),
                    Nationality = _executableConnection.ReadInteger(valueMapping.Nationality),
                    CareerChampionships = _executableConnection.ReadInteger(valueMapping.CareerChampionships),
                    CareerRaces = _executableConnection.ReadInteger(valueMapping.CareerRaces),
                    CareerWins = _executableConnection.ReadInteger(valueMapping.CareerWins),
                    CareerPoints = _executableConnection.ReadInteger(valueMapping.CareerPoints),
                    CareerFastestLaps = _executableConnection.ReadInteger(valueMapping.CareerFastestLaps),
                    CareerPointsFinishes = _executableConnection.ReadInteger(valueMapping.CareerPointsFinishes),
                    CareerPolePositions = _executableConnection.ReadInteger(valueMapping.CareerPolePositions),
                    Speed = _executableConnection.ReadInteger(valueMapping.Speed),
                    Skill = _executableConnection.ReadInteger(valueMapping.Skill),
                    Overtaking = _executableConnection.ReadInteger(valueMapping.Overtaking),
                    WetWeather = _executableConnection.ReadInteger(valueMapping.WetWeather),
                    Concentration = _executableConnection.ReadInteger(valueMapping.Concentration),
                    Experience = _executableConnection.ReadInteger(valueMapping.Experience),
                    Stamina = _executableConnection.ReadInteger(valueMapping.Stamina),
                    Morale = _executableConnection.ReadInteger(valueMapping.Morale).ConvertToOneToFiveStepOne()
                };
                Drivers.Add(driver);
            }

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
                    ResourceText = GetResourceText(GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true)),
                };
                DriverIdentities.Add(driverIdentity);
            }
        }

        private void ExportDrivers()
        {
            // Export to file
            foreach (var driver in Drivers)
            {
                SetResourceText(driver.ResourceId, driver.ResourceText);

                var valueMapping = new ValueMapping.Executable.Team.Driver(driver.Id);
                _executableConnection.WriteInteger(valueMapping.Salary, driver.Salary);
                _executableConnection.WriteInteger(valueMapping.RaceBonus, driver.RaceBonus);
                _executableConnection.WriteInteger(valueMapping.ChampionshipBonus, driver.ChampionshipBonus);
                _executableConnection.WriteInteger(valueMapping.PayRating, driver.PayRating);
                _executableConnection.WriteInteger(valueMapping.PositiveSalary, driver.PositiveSalary);
                _executableConnection.WriteInteger(valueMapping.LastChampionshipPosition, driver.LastChampionshipPosition);
                _executableConnection.WriteInteger(valueMapping.DriverRole, driver.DriverRole);
                _executableConnection.WriteInteger(valueMapping.CarNumber, driver.CarNumber);
                _executableConnection.WriteInteger(valueMapping.Age, driver.Age);
                _executableConnection.WriteInteger(valueMapping.Nationality, driver.Nationality);
                _executableConnection.WriteInteger(valueMapping.CareerChampionships, driver.CareerChampionships);
                _executableConnection.WriteInteger(valueMapping.CareerRaces, driver.CareerRaces);
                _executableConnection.WriteInteger(valueMapping.CareerWins, driver.CareerWins);
                _executableConnection.WriteInteger(valueMapping.CareerPoints, driver.CareerPoints);
                _executableConnection.WriteInteger(valueMapping.CareerFastestLaps, driver.CareerFastestLaps);
                _executableConnection.WriteInteger(valueMapping.CareerPointsFinishes, driver.CareerPointsFinishes);
                _executableConnection.WriteInteger(valueMapping.CareerPolePositions, driver.CareerPolePositions);
                _executableConnection.WriteInteger(valueMapping.Speed, driver.Speed);
                _executableConnection.WriteInteger(valueMapping.Skill, driver.Skill);
                _executableConnection.WriteInteger(valueMapping.Overtaking, driver.Overtaking);
                _executableConnection.WriteInteger(valueMapping.WetWeather, driver.WetWeather);
                _executableConnection.WriteInteger(valueMapping.Concentration, driver.Concentration);
                _executableConnection.WriteInteger(valueMapping.Experience, driver.Experience);
                _executableConnection.WriteInteger(valueMapping.Stamina, driver.Stamina);
                _executableConnection.WriteInteger(valueMapping.Morale, driver.Morale.ConvertToTwentyToHundredStepTwenty());
            }
        }

        private static int GetDriverResourceId(int id)
        {
            var idToResourceIdMap = new int[]
                {
                    6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                    78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 200, 201, 202, 203
                };

            return idToResourceIdMap[id];
        }

        private void ImportTracks()
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

                    Laps = _executableConnection.ReadInteger(valueMapping.Laps),
                    Design = _executableConnection.ReadInteger(valueMapping.Design),
                    Unknown1 = _executableConnection.ReadInteger(valueMapping.Unknown1),
                    Unknown2 = _executableConnection.ReadInteger(valueMapping.Unknown2),
                    Unknown3 = _executableConnection.ReadInteger(valueMapping.Unknown3),
                    LastRaceYear = _executableConnection.ReadInteger(valueMapping.LastRaceYear),
                    LastRaceTime = _executableConnection.ReadInteger(valueMapping.LastRaceTime),
                    LapRecordDriver = _executableConnection.ReadInteger(valueMapping.LapRecordDriver),
                    LapRecordTeam = _executableConnection.ReadInteger(valueMapping.LapRecordTeam),
                    LapRecordTime = _executableConnection.ReadInteger(valueMapping.LapRecordTime),
                    LapRecordYear = _executableConnection.ReadInteger(valueMapping.LapRecordYear),
                    Speed = _executableConnection.ReadInteger(valueMapping.Speed),
                    Grip = _executableConnection.ReadInteger(valueMapping.Grip),
                    Surface = _executableConnection.ReadInteger(valueMapping.Surface),
                    Tarmac = _executableConnection.ReadInteger(valueMapping.Tarmac),
                    Dust = _executableConnection.ReadInteger(valueMapping.Dust),
                    Overtaking = _executableConnection.ReadInteger(valueMapping.Overtaking),
                    Braking = _executableConnection.ReadInteger(valueMapping.Braking),
                    Rain = _executableConnection.ReadInteger(valueMapping.Rain),
                    Heat = _executableConnection.ReadInteger(valueMapping.Heat),
                    Wind = _executableConnection.ReadInteger(valueMapping.Wind),
                };
                Tracks.Add(track);
            }
        }

        private void ExportTracks()
        {
            // Export to file
            foreach (var track in Tracks)
            {
                SetResourceText(track.ResourceId, track.ResourceText);

                var valueMapping = new ValueMapping.Executable.Track.Track(track.Id);
                _executableConnection.WriteInteger(valueMapping.Laps, track.Laps);
                _executableConnection.WriteInteger(valueMapping.Design, track.Design);
                _executableConnection.WriteInteger(valueMapping.Unknown1, track.Unknown1);
                _executableConnection.WriteInteger(valueMapping.Unknown2, track.Unknown2);
                _executableConnection.WriteInteger(valueMapping.Unknown3, track.Unknown3);
                _executableConnection.WriteInteger(valueMapping.LastRaceYear, track.LastRaceYear);
                _executableConnection.WriteInteger(valueMapping.LastRaceTime, track.LastRaceTime);
                _executableConnection.WriteInteger(valueMapping.LapRecordDriver, track.LapRecordDriver);
                _executableConnection.WriteInteger(valueMapping.LapRecordTeam, track.LapRecordTeam);
                _executableConnection.WriteInteger(valueMapping.LapRecordTime, track.LapRecordTime);
                _executableConnection.WriteInteger(valueMapping.LapRecordYear, track.LapRecordYear);
                _executableConnection.WriteInteger(valueMapping.Speed, track.Speed);
                _executableConnection.WriteInteger(valueMapping.Grip, track.Grip);
                _executableConnection.WriteInteger(valueMapping.Surface, track.Surface);
                _executableConnection.WriteInteger(valueMapping.Tarmac, track.Tarmac);
                _executableConnection.WriteInteger(valueMapping.Dust, track.Dust);
                _executableConnection.WriteInteger(valueMapping.Overtaking, track.Overtaking);
                _executableConnection.WriteInteger(valueMapping.Braking, track.Braking);
                _executableConnection.WriteInteger(valueMapping.Rain, track.Rain);
                _executableConnection.WriteInteger(valueMapping.Heat, track.Heat);
                _executableConnection.WriteInteger(valueMapping.Wind, track.Wind);
            }
        }

        private static int GetTrackResourceId(int id)
        {
            var idToResourceIdMap = new int[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
                };

            return idToResourceIdMap[id];
        }

        private string GetResourceId(int baseResourceId, int localResourceId, bool isDriver = false)
        {
            if (!isDriver)
                return (baseResourceId + localResourceId).BuildStringTableId();

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
            var resource = StringTable.SingleOrDefault(x => x.ResourceId == resourceId);
            if (resource == null)
                throw new Exception(String.Format("Unable to find an string table entry matching the resource id {0}.", resourceId));

            return resource.ResourceText;
        }

        private void SetResourceText(string resourceId, string resourceText)
        {
            var resource = StringTable.SingleOrDefault(x => x.ResourceId == resourceId);
            
            if (resource == null)
                throw new Exception(String.Format("Unable to find an string table entry matching the resource id {0}.", resourceId));

            resource.ResourceText = resourceText;
        }
    }
}
