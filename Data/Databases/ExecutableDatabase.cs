using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Common.Extensions;
using Data.Collections.Executable.Lookup;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Generic;
using Data.Collections.Language;
using Data.Entities.Executable.Race;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using Data.Patchers.Enhancements.Units;
using EnvironmentEntities = Data.Entities.Executable.Environment;
using EnvironmentMapping = Data.ValueMapping.Executable.Environment;
using LookupEntities = Data.Entities.Executable.Lookup;
using LookupMapping = Data.ValueMapping.Executable.Lookup;
using TeamEntities = Data.Entities.Executable.Team;
using TeamMapping = Data.ValueMapping.Executable.Team;
using SupplierEntities = Data.Entities.Executable.Supplier;
using SupplierMapping = Data.ValueMapping.Executable.Supplier;
using TrackEntities = Data.Entities.Executable.Track;
using TrackMapping = Data.ValueMapping.Executable.Track;

namespace Data.Databases
{
    public class ExecutableDatabase
    {
        // TODO Remove comments
        //private const int TeamCount = 11;
        //private const int TeamFirstGpTrackCount = 19;
        //private const int TeamTyreSupplierIdCount = 3;
        //private const int DriverCount = 33;
        //private const int DriverIdentityCount = 48;
        //private const int DriverNationalityIdCount = 14;
        //private const int EngineCount = 8;
        //private const int TyreCount = 3;
        //private const int FuelCount = 9;
        //private const int TrackCount = 16;
        //private const int TrackDesignCount = 3;

        //private const int TeamBaseResourceId = 5696;                // "No Team" - Zero based index
        //private const int TeamFirstGpTrackBaseResourceId = 6006;    // "No race" - Zero based index
        //private const int TeamTyreSupplierIdBaseResourceId = 4875;  // TyreA -8  - Offset based index
        //private const int DriverBaseResourceId = 5795;              // "None" - Zero based index
        //private const int DriverNationalityIdBaseResourceId = 5952; // "None" - Zero based index
        //private const int EngineBaseResourceId = 4886;              // EngineA - One based index
        //private const int TyreBaseResourceId = 4883;                // TyreA - One based index
        //private const int FuelBaseResourceId = 4894;                // FuelA - One based index
        //private const int TrackBaseResourceId = 6043;               // "No Circuit" - Zero based index
        //private const int TrackDesignBaseResourceId = 6525;         // "" - Zero based index

        public IdentityCollection LanguageStrings { get; set; }
        public TeamCollection Teams { get; set; }
        public DriverCollection Drivers { get; set; }
        public EngineCollection Engines { get; set; }
        public TyreCollection Tyres { get; set; }
        public FuelCollection Fuels { get; set; }
        public TrackCollection Tracks { get; set; }
        public RacePerformance RacePerformance { get; set; }
        public FiveRatingCollection StaffEfforts { get; set; }
        public FiveRatingCollection StaffSalaries { get; set; }
        public FiveValueCollection FactoryRunningCosts { get; set; }
        public FiveRatingCollection FactoryExpansionCosts { get; set; }
        public TenValueCollection TestingMiles { get; set; }
        public TenValueCollection EngineeringCosts { get; set; }
        public SingleValueCollection UnknownAEfforts { get; set; }
        public SingleValueCollection UnknownBEfforts { get; set; }

        public DriverNationalityCollection DriverNationalityLookups { get; set; }
        public FastestLapDriverIdAsStaffIdCollection FastestLapDriverIdAsStaffIdLookups { get; set; }
        public FirstGpTrackCollection FirstGpTrackLookups { get; set; }
        public TrackDesignCollection TrackDesignLookups { get; set; }
        public TyreSupplierAsSupplierIdCollection TyreSupplierAsSupplierIdLookups { get; set; }

        public void ImportDataFromFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            ImportLanguageStrings(languageFileFilePath);

            ImportTeams(gameExecutableFilePath);
            ImportFirstGpTrackLookups();
            ImportTyreSupplierAsSupplierIdLookups();

            ImportDrivers(gameExecutableFilePath);
            ImportDriverNationalityLookups();

            ImportEngines(gameExecutableFilePath);
            ImportTyres(gameExecutableFilePath);
            ImportFuels(gameExecutableFilePath);

            ImportTracks(gameExecutableFilePath);
            ImportTrackDesignLookups();
            ImportFastestLapDriverIdAsStaffIdLookups();

            ImportRacePerformance(gameExecutableFilePath);

            ImportStaffEfforts(gameExecutableFilePath);
            ImportStaffSalaries(gameExecutableFilePath);
            ImportFactoryRunningCosts(gameExecutableFilePath);
            ImportFactoryExpansionCosts(gameExecutableFilePath);
            ImportTestingMiles(gameExecutableFilePath);
            ImportEngineeringCosts(gameExecutableFilePath);
            ImportUnknownAEfforts(gameExecutableFilePath);
            ImportUnknownBEfforts(gameExecutableFilePath);
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

            ExportStaffEfforts(gameExecutableFilePath);
            ExportStaffSalaries(gameExecutableFilePath);
            ExportFactoryRunningCosts(gameExecutableFilePath);
            ExportFactoryExpansionCosts(gameExecutableFilePath);
            ExportTestingMiles(gameExecutableFilePath);
            ExportEngineeringCosts(gameExecutableFilePath);
            ExportUnknownAEfforts(gameExecutableFilePath);
            ExportUnknownBEfforts(gameExecutableFilePath);

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
            Teams = new TeamCollection
            {
                new TeamEntities.Team(new TeamMapping.Team(0), 0),
                new TeamEntities.Team(new TeamMapping.Team(1), 1),
                new TeamEntities.Team(new TeamMapping.Team(2), 2),
                new TeamEntities.Team(new TeamMapping.Team(3), 3),
                new TeamEntities.Team(new TeamMapping.Team(4), 4),
                new TeamEntities.Team(new TeamMapping.Team(5), 5),
                new TeamEntities.Team(new TeamMapping.Team(6), 6),
                new TeamEntities.Team(new TeamMapping.Team(7), 7),
                new TeamEntities.Team(new TeamMapping.Team(8), 8),
                new TeamEntities.Team(new TeamMapping.Team(9), 9),
                new TeamEntities.Team(new TeamMapping.Team(10), 10)
            };
            ImportData(gameExecutableFilePath, Teams);
        }

        private void ExportTeams(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, Teams);
        }

        private void ImportDrivers(string gameExecutableFilePath)
        {
            Drivers = new DriverCollection
            {
                new TeamEntities.Driver(new TeamMapping.Driver(0), 0),
                new TeamEntities.Driver(new TeamMapping.Driver(1), 1),
                new TeamEntities.Driver(new TeamMapping.Driver(2), 2),
                new TeamEntities.Driver(new TeamMapping.Driver(3), 3),
                new TeamEntities.Driver(new TeamMapping.Driver(4), 4),
                new TeamEntities.Driver(new TeamMapping.Driver(5), 5),
                new TeamEntities.Driver(new TeamMapping.Driver(6), 6),
                new TeamEntities.Driver(new TeamMapping.Driver(7), 7),
                new TeamEntities.Driver(new TeamMapping.Driver(8), 8),
                new TeamEntities.Driver(new TeamMapping.Driver(9), 9),
                new TeamEntities.Driver(new TeamMapping.Driver(10), 10),
                new TeamEntities.Driver(new TeamMapping.Driver(11), 11),
                new TeamEntities.Driver(new TeamMapping.Driver(12), 12),
                new TeamEntities.Driver(new TeamMapping.Driver(13), 13),
                new TeamEntities.Driver(new TeamMapping.Driver(14), 14),
                new TeamEntities.Driver(new TeamMapping.Driver(15), 15),
                new TeamEntities.Driver(new TeamMapping.Driver(16), 16),
                new TeamEntities.Driver(new TeamMapping.Driver(17), 17),
                new TeamEntities.Driver(new TeamMapping.Driver(18), 18),
                new TeamEntities.Driver(new TeamMapping.Driver(19), 19),
                new TeamEntities.Driver(new TeamMapping.Driver(20), 20),
                new TeamEntities.Driver(new TeamMapping.Driver(21), 21),
                new TeamEntities.Driver(new TeamMapping.Driver(22), 22),
                new TeamEntities.Driver(new TeamMapping.Driver(23), 23),
                new TeamEntities.Driver(new TeamMapping.Driver(24), 24),
                new TeamEntities.Driver(new TeamMapping.Driver(25), 25),
                new TeamEntities.Driver(new TeamMapping.Driver(26), 26),
                new TeamEntities.Driver(new TeamMapping.Driver(27), 27),
                new TeamEntities.Driver(new TeamMapping.Driver(28), 28),
                new TeamEntities.Driver(new TeamMapping.Driver(29), 29),
                new TeamEntities.Driver(new TeamMapping.Driver(30), 30),
                new TeamEntities.Driver(new TeamMapping.Driver(31), 31),
                new TeamEntities.Driver(new TeamMapping.Driver(32), 32)
            };
            ImportData(gameExecutableFilePath, Drivers);
        }

        private void ExportDrivers(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, Drivers);
        }

        // TODO Remove
        //private void ImportDriverIdentities()
        //{
        //    // Generate driver identity records
        //    DriverIdAsTeamIdLookups = new IdentityCollection();
        //    foreach (var driver in Drivers)
        //    {
        //        var driverIdentity = new Identity()
        //        {
        //            Id = driver.Id,
        //            LocalResourceId = driver.LocalResourceId,
        //            ResourceId = driver.ResourceId,
        //            ResourceText = driver.ResourceText
        //        };
        //        DriverIdAsTeamIdLookups.Add(driverIdentity);
        //    }
        //
        //    // Add additional driver identity records
        //    for (var id = DriverCount; id < DriverIdentityCount; id++)
        //    {
        //        var driverIdentity = new Identity()
        //        {
        //            Id = id,
        //            LocalResourceId = GetDriverResourceId(id),
        //            ResourceId = GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true),
        //            ResourceText = GetResourceText(GetResourceId(DriverBaseResourceId, GetDriverResourceId(id), true))
        //        };
        //        DriverIdAsTeamIdLookups.Add(driverIdentity);
        //    }
        //}

        // TODO Remove
        //private static int GetDriverResourceId(int id)
        //{
        //    var idToResourceIdMap = new[]
        //        {
        //            6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
        //            78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 200, 201, 202, 203
        //        };
        //
        //    return idToResourceIdMap[id];
        //}

        // TODO Remove
        //private void ImportDriverNationalityIdIdentities()
        //{
        //    // Import from file
        //    DriverNationalityLookups = new IdentityCollection();
        //    for (var id = 0; id < DriverNationalityIdCount; id++)
        //    {
        //        var driverNationalityIdIdentity = new Identity
        //        {
        //            Id = id,
        //            LocalResourceId = GetDriverNationalityIdResourceId(id),
        //            ResourceId = GetResourceId(DriverNationalityIdBaseResourceId, GetDriverNationalityIdResourceId(id)),
        //            ResourceText = GetResourceText(GetResourceId(DriverNationalityIdBaseResourceId, GetDriverNationalityIdResourceId(id)))
        //        };
        //        DriverNationalityLookups.Add(driverNationalityIdIdentity);
        //    }
        //}

        // TODO Remove
        //private static int GetDriverNationalityIdResourceId(int id)
        //{
        //    var idToResourceIdMap = new[]
        //        {
        //            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
        //        };
        //
        //    return idToResourceIdMap[id];
        //}

        private void ImportEngines(string gameExecutableFilePath)
        {
            Engines = new EngineCollection
            {
                new SupplierEntities.Engine(new SupplierMapping.Engine(0), 0),
                new SupplierEntities.Engine(new SupplierMapping.Engine(1), 1),
                new SupplierEntities.Engine(new SupplierMapping.Engine(2), 2),
                new SupplierEntities.Engine(new SupplierMapping.Engine(3), 3),
                new SupplierEntities.Engine(new SupplierMapping.Engine(4), 4),
                new SupplierEntities.Engine(new SupplierMapping.Engine(5), 5),
                new SupplierEntities.Engine(new SupplierMapping.Engine(6), 6),
                new SupplierEntities.Engine(new SupplierMapping.Engine(7), 7)
            };
            ImportData(gameExecutableFilePath, Engines);
        }

        private void ExportEngines(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, Engines);
        }

        private void ImportTyres(string gameExecutableFilePath)
        {
            Tyres = new TyreCollection
            {
                new SupplierEntities.Tyre(new SupplierMapping.Tyre(0), 0),
                new SupplierEntities.Tyre(new SupplierMapping.Tyre(1), 1),
                new SupplierEntities.Tyre(new SupplierMapping.Tyre(2), 2)
            };
            ImportData(gameExecutableFilePath, Tyres);
        }

        private void ExportTyres(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, Tyres);
        }

        private void ImportFuels(string gameExecutableFilePath)
        {
            Fuels = new FuelCollection
            {
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(0), 0),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(1), 1),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(2), 2),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(3), 3),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(4), 4),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(5), 5),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(6), 6),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(7), 7),
                new SupplierEntities.Fuel(new SupplierMapping.Fuel(8), 8)
            };
            ImportData(gameExecutableFilePath, Fuels);
        }

        private void ExportFuels(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, Fuels);
        }

        private void ImportTracks(string gameExecutableFilePath)
        {
            Tracks = new TrackCollection
            {
                new TrackEntities.Track(new TrackMapping.Track(0), 0),
                new TrackEntities.Track(new TrackMapping.Track(1), 1),
                new TrackEntities.Track(new TrackMapping.Track(2), 2),
                new TrackEntities.Track(new TrackMapping.Track(3), 3),
                new TrackEntities.Track(new TrackMapping.Track(4), 4),
                new TrackEntities.Track(new TrackMapping.Track(5), 5),
                new TrackEntities.Track(new TrackMapping.Track(6), 6),
                new TrackEntities.Track(new TrackMapping.Track(7), 7),
                new TrackEntities.Track(new TrackMapping.Track(8), 8),
                new TrackEntities.Track(new TrackMapping.Track(9), 9),
                new TrackEntities.Track(new TrackMapping.Track(10), 10),
                new TrackEntities.Track(new TrackMapping.Track(11), 11),
                new TrackEntities.Track(new TrackMapping.Track(12), 12),
                new TrackEntities.Track(new TrackMapping.Track(13), 13),
                new TrackEntities.Track(new TrackMapping.Track(14), 14),
                new TrackEntities.Track(new TrackMapping.Track(15), 15)
            };
            ImportData(gameExecutableFilePath, Tracks);
        }

        private void ExportTracks(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, Tracks);
        }

        // TODO Refactor
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

        // TODO Refactor
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

        private void ImportStaffEfforts(string gameExecutableFilePath)
        {
            StaffEfforts = new FiveRatingCollection
            {
                new EnvironmentEntities.StaffEfforts.DepartmentChief(new EnvironmentMapping.StaffEfforts.DepartmentChief()),
                new EnvironmentEntities.StaffEfforts.DepartmentStaff(new EnvironmentMapping.StaffEfforts.DepartmentStaff())
            };
            ImportData(gameExecutableFilePath, StaffEfforts);
        }

        private void ExportStaffEfforts(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, StaffEfforts);
        }

        private void ImportStaffSalaries(string gameExecutableFilePath)
        {
            StaffSalaries = new FiveRatingCollection
            {
                new EnvironmentEntities.StaffSalaries.Commercial(new EnvironmentMapping.StaffSalaries.Commercial()),
                new EnvironmentEntities.StaffSalaries.Design(new EnvironmentMapping.StaffSalaries.Design()),
                new EnvironmentEntities.StaffSalaries.Engineering(new EnvironmentMapping.StaffSalaries.Engineering()),
                new EnvironmentEntities.StaffSalaries.Mechanics(new EnvironmentMapping.StaffSalaries.Mechanics()),
            };
            ImportData(gameExecutableFilePath, StaffSalaries);
        }

        private void ExportStaffSalaries(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, StaffSalaries);
        }

        private void ImportFactoryRunningCosts(string gameExecutableFilePath)
        {
            FactoryRunningCosts = new FiveValueCollection
            {
                new EnvironmentEntities.RunningCosts.Factory(new EnvironmentMapping.RunningCosts.Factory()),
                new EnvironmentEntities.RunningCosts.WindTunnel(new EnvironmentMapping.RunningCosts.WindTunnel())
            };
            ImportData(gameExecutableFilePath, FactoryRunningCosts);
        }

        private void ExportFactoryRunningCosts(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, FactoryRunningCosts);
        }

        private void ImportFactoryExpansionCosts(string gameExecutableFilePath)
        {
            FactoryExpansionCosts = new FiveRatingCollection
            {
                new EnvironmentEntities.ExpansionCosts.Factory(new EnvironmentMapping.ExpansionCosts.Factory()),
                new EnvironmentEntities.ExpansionCosts.Cad(new EnvironmentMapping.ExpansionCosts.Cad()),
                new EnvironmentEntities.ExpansionCosts.Cam(new EnvironmentMapping.ExpansionCosts.Cam()),
                new EnvironmentEntities.ExpansionCosts.Supercomputer(new EnvironmentMapping.ExpansionCosts.Supercomputer()),
                new EnvironmentEntities.ExpansionCosts.TestRig(new EnvironmentMapping.ExpansionCosts.TestRig()),
                new EnvironmentEntities.ExpansionCosts.WindTunnel(new EnvironmentMapping.ExpansionCosts.WindTunnel()),
                new EnvironmentEntities.ExpansionCosts.Workshop(new EnvironmentMapping.ExpansionCosts.Workshop())
            };
            ImportData(gameExecutableFilePath, FactoryExpansionCosts);
        }

        private void ExportFactoryExpansionCosts(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, FactoryExpansionCosts);
        }

        private void ImportTestingMiles(string gameExecutableFilePath)
        {
            TestingMiles = new TenValueCollection
            {
                new EnvironmentEntities.TestingMiles.TestingMiles(new EnvironmentMapping.TestingMiles.TestingMiles())
            };
            ImportData(gameExecutableFilePath, TestingMiles);
        }

        private void ExportTestingMiles(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, TestingMiles);
        }

        private void ImportEngineeringCosts(string gameExecutableFilePath)
        {
            EngineeringCosts = new TenValueCollection
            {
                new EnvironmentEntities.EngineeringCosts.BuildThisYearCar(new EnvironmentMapping.EngineeringCosts.BuildThisYearCar()),
                new EnvironmentEntities.EngineeringCosts.BuildNextYearCar(new EnvironmentMapping.EngineeringCosts.BuildNextYearCar()),
                new EnvironmentEntities.EngineeringCosts.UpgradeChassis(new EnvironmentMapping.EngineeringCosts.UpgradeChassis()),
                new EnvironmentEntities.EngineeringCosts.UpgradeTechnology(new EnvironmentMapping.EngineeringCosts.UpgradeTechnology()),
                new EnvironmentEntities.EngineeringCosts.UpgradeDrivingAid(new EnvironmentMapping.EngineeringCosts.UpgradeDrivingAid()),
                new EnvironmentEntities.EngineeringCosts.BuildSpare(new EnvironmentMapping.EngineeringCosts.BuildSpare())
            };
            ImportData(gameExecutableFilePath, EngineeringCosts);
        }

        private void ExportEngineeringCosts(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, EngineeringCosts);
        }

        private void ImportUnknownAEfforts(string gameExecutableFilePath)
        {
            UnknownAEfforts = new SingleValueCollection
            {
                new EnvironmentEntities.UnknownAEfforts.Unknown1(new EnvironmentMapping.UnknownAEfforts.Unknown1()),
                new EnvironmentEntities.UnknownAEfforts.Unknown2(new EnvironmentMapping.UnknownAEfforts.Unknown2()),
                new EnvironmentEntities.UnknownAEfforts.Unknown3(new EnvironmentMapping.UnknownAEfforts.Unknown3()),
                new EnvironmentEntities.UnknownAEfforts.Unknown4(new EnvironmentMapping.UnknownAEfforts.Unknown4()),
                new EnvironmentEntities.UnknownAEfforts.Unknown5(new EnvironmentMapping.UnknownAEfforts.Unknown5()),
                new EnvironmentEntities.UnknownAEfforts.Unknown6(new EnvironmentMapping.UnknownAEfforts.Unknown6())
            };
            ImportData(gameExecutableFilePath, UnknownAEfforts);
        }

        private void ExportUnknownAEfforts(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, UnknownAEfforts);
        }

        private void ImportUnknownBEfforts(string gameExecutableFilePath)
        {
            UnknownBEfforts = new SingleValueCollection
            {
                new EnvironmentEntities.UnknownBEfforts.Unknown1(new EnvironmentMapping.UnknownBEfforts.Unknown1()),
                new EnvironmentEntities.UnknownBEfforts.Unknown2(new EnvironmentMapping.UnknownBEfforts.Unknown2()),
                new EnvironmentEntities.UnknownBEfforts.Unknown3(new EnvironmentMapping.UnknownBEfforts.Unknown3()),
                new EnvironmentEntities.UnknownBEfforts.Unknown4(new EnvironmentMapping.UnknownBEfforts.Unknown4()),
                new EnvironmentEntities.UnknownBEfforts.Unknown5(new EnvironmentMapping.UnknownBEfforts.Unknown5()),
                new EnvironmentEntities.UnknownBEfforts.Unknown6(new EnvironmentMapping.UnknownBEfforts.Unknown6())
            };
            ImportData(gameExecutableFilePath, UnknownBEfforts);
        }

        private void ExportUnknownBEfforts(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, UnknownBEfforts);
        }

        // TODO Remove
        private static string GetResourceId(int baseResourceId, int localResourceId, bool isDriver = false)
        {
            if (!isDriver)
            {
                return (baseResourceId + localResourceId).BuildResourceId();
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

            return (baseResourceId + recalculatedLocalResourceId).BuildResourceId();
        }

        // TODO Remove
        private string GetResourceText(string resourceId)
        {
            return ResourceHelper.GetResourceText(LanguageStrings, resourceId);

            //var resource = LanguageStrings.SingleOrDefault(x => x.ResourceId == resourceId);
            //
            //if (resource == null)
            //{
            //    throw new Exception($"Unable to find a resource string in the language file matching the resource id {resourceId}.");
            //}
            //
            //return resource.ResourceText;
        }

        // TODO Remove
        private void SetResourceText(string resourceId, string resourceText)
        {
            ResourceHelper.SetResourceText(LanguageStrings, resourceId, resourceText);

            //var resource = LanguageStrings.SingleOrDefault(x => x.ResourceId == resourceId);
            //
            //if (resource == null)
            //{
            //    throw new Exception($"Unable to find a resource string in the language file matching the resource id {resourceId}.");
            //}
            //
            //resource.ResourceText = resourceText;
        }

        /// <summary>
        /// Generic method that imports a collection of lookup entities.
        /// </summary>
        /// <typeparam name="T">The type of the collection of lookup entities.</typeparam>
        /// <typeparam name="TU">The type of the lookup entity.</typeparam>
        /// <typeparam name="TY">The tytpe of the lookup mapping.</typeparam>
        /// <param name="count">The number of lookup records to import.</param>
        /// <returns></returns>
        private IEnumerable<TU> ImportLookups<T, TU, TY>(int count)
            where T : Collection<TU>, new()
            where TU : class, IDataConnection
        {
            var lookups = new T();
            for (var id = 0; id < count; id++)
            {
                // Using Activator.CreateInstance to instantiate classes that have constructors with parameters
                // In effect, the three lines below are the same as: lookups.Add(new TU(new TY(id), id));
                var tyInstance = Activator.CreateInstance(typeof(TY), new object[] { id }) as LookupMapping.ILookup;
                var tuInstance = Activator.CreateInstance(typeof(TU), new object[] { tyInstance, id }) as TU;
                lookups.Add(tuInstance);
            }
            ImportData(lookups);
            return lookups;
        }

        private void ImportDriverNationalityLookups()
        {
            DriverNationalityLookups =
                (DriverNationalityCollection)
                    ImportLookups
                        <DriverNationalityCollection, LookupEntities.DriverNationality, LookupMapping.DriverNationality>(14);

            // TODO remove
            //const int count = 14;
            //DriverNationalityLookups = new DriverNationalityCollection();
            //for (var id = 0; id < count; id++)
            //{
            //    DriverNationalityLookups.Add(new LookupEntities.DriverNationality(new LookupMapping.DriverNationality(id), id));
            //}
            //ImportData(DriverNationalityLookups);
        }

        private void ImportFastestLapDriverIdAsStaffIdLookups()
        {
            FastestLapDriverIdAsStaffIdLookups =
                (FastestLapDriverIdAsStaffIdCollection)
                    ImportLookups
                        <FastestLapDriverIdAsStaffIdCollection, LookupEntities.FastestLapDriverIdAsStaffId, LookupMapping.FastestLapDriverIdAsStaffId>(48);

            // TODO remove
            //const int count = 48;
            //FastestLapDriverIdAsStaffIdLookups = new FastestLapDriverIdAsStaffIdCollection();
            //for (var id = 0; id < count; id++)
            //{
            //    FastestLapDriverIdAsStaffIdLookups.Add(new LookupEntities.FastestLapDriverIdAsStaffId(new LookupMapping.FastestLapDriverIdAsStaffId(id), id));
            //}
            //ImportData(FastestLapDriverIdAsStaffIdLookups);
        }

        private void ImportFirstGpTrackLookups()
        {
            FirstGpTrackLookups =
                (FirstGpTrackCollection)
                    ImportLookups
                        <FirstGpTrackCollection, LookupEntities.FirstGpTrack, LookupMapping.FirstGpTrack>(19);

            // TODO remove
            //const int count = 19;
            //FirstGpTrackLookups = new FirstGpTrackCollection();
            //for (var id = 0; id < count; id++)
            //{
            //    FirstGpTrackLookups.Add(new LookupEntities.FirstGpTrack(new LookupMapping.FirstGpTrack(id), id));
            //}
            //ImportData(FirstGpTrackLookups);
        }

        private void ImportTrackDesignLookups()
        {
            TrackDesignLookups =
                (TrackDesignCollection)
                    ImportLookups
                        <TrackDesignCollection, LookupEntities.TrackDesign, LookupMapping.TrackDesign>(3);

            // TODO remove
            //const int count = 3;
            //TrackDesignLookups = new TrackDesignCollection();
            //for (var id = 0; id < count; id++)
            //{
            //    TrackDesignLookups.Add(new LookupEntities.TrackDesign(new LookupMapping.TrackDesign(id), id));
            //}
            //ImportData(TrackDesignLookups);
        }

        private void ImportTyreSupplierAsSupplierIdLookups()
        {
            TyreSupplierAsSupplierIdLookups =
                (TyreSupplierAsSupplierIdCollection)
                    ImportLookups
                        <TyreSupplierAsSupplierIdCollection, LookupEntities.TyreSupplierAsSupplierId, LookupMapping.TyreSupplierAsSupplierId>(3);

            // TODO remove
            //const int count = 3;
            //TyreSupplierAsSupplierIdLookups = new TyreSupplierAsSupplierIdCollection();
            //for (var id = 0; id < count; id++)
            //{
            //    TyreSupplierAsSupplierIdLookups.Add(new LookupEntities.TyreSupplierAsSupplierId(new LookupMapping.TyreSupplierAsSupplierId(id), id));
            //}
            //ImportData(TyreSupplierAsSupplierIdLookups);
        }

        private void ImportData<T>(IEnumerable<T> collection) where T : IDataConnection
        {
            foreach (var item in collection)
            {
                item.ImportData(null, LanguageStrings);
            }
        }

        private void ImportData<T>(string gameExecutableFilePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                foreach (var item in collection)
                {
                    item.ImportData(executableConnection, LanguageStrings);
                }
            }
        }

        private void ExportData<T>(string gameExecutableFilePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                foreach (var item in collection)
                {
                    item.ExportData(executableConnection, LanguageStrings);
                }
            }
        }
    }
}
