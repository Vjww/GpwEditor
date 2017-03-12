using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Generic;
using Data.Collections.Language;
using Data.Entities.Executable.Race;
using Data.Entities.Language;
using Data.FileConnection;
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

        public IEnumerable<LookupEntities.DriverNationality> DriverNationalityLookups { get; set; }
        public IEnumerable<LookupEntities.FastestLapDriverIdAsStaffId> FastestLapDriverIdAsStaffIdLookups { get; set; }
        public IEnumerable<LookupEntities.FirstGpTrack> FirstGpTrackLookups { get; set; }
        public IEnumerable<LookupEntities.TrackDesign> TrackDesignLookups { get; set; }
        public IEnumerable<LookupEntities.TyreSupplierIdAsSupplierId> TyreSupplierIdAsSupplierIdLookups { get; set; }

        public void ImportDataFromFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            ImportLanguageStrings(languageFileFilePath);

            ImportTeams(gameExecutableFilePath);
            ImportFirstGpTrackLookups();
            ImportTyreSupplierIdAsSupplierIdLookups();

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

        private void ImportRacePerformance(string gameExecutableFilePath)
        {
            RacePerformance = new RacePerformance();
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                RacePerformance.ImportData(executableConnection, LanguageStrings);
            }
        }

        private void ExportRacePerformance(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                RacePerformance.ExportData(executableConnection, LanguageStrings);
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

        private void ImportDriverNationalityLookups()
        {
            DriverNationalityLookups = ImportLookups<LookupEntities.DriverNationality, LookupMapping.DriverNationality>(14);
        }

        private void ImportFastestLapDriverIdAsStaffIdLookups()
        {
            FastestLapDriverIdAsStaffIdLookups = ImportLookups<LookupEntities.FastestLapDriverIdAsStaffId, LookupMapping.FastestLapDriverIdAsStaffId>(48);
        }

        private void ImportFirstGpTrackLookups()
        {
            FirstGpTrackLookups = ImportLookups<LookupEntities.FirstGpTrack, LookupMapping.FirstGpTrack>(19);
        }

        private void ImportTrackDesignLookups()
        {
            TrackDesignLookups = ImportLookups<LookupEntities.TrackDesign, LookupMapping.TrackDesign>(3);
        }

        private void ImportTyreSupplierIdAsSupplierIdLookups()
        {
            TyreSupplierIdAsSupplierIdLookups = ImportLookups<LookupEntities.TyreSupplierIdAsSupplierId, LookupMapping.TyreSupplierIdAsSupplierId>(3);
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

        /// <summary>
        /// Generic method that imports a collection of lookup entities.
        /// </summary>
        /// <typeparam name="T">The type of the lookup entity.</typeparam>
        /// <typeparam name="TU">The tytpe of the lookup mapping.</typeparam>
        /// <param name="count">The number of lookup records to import.</param>
        /// <returns></returns>
        private IEnumerable<T> ImportLookups<T, TU>(int count)
            where T : class, IIdentity, IDataConnection
            where TU : class, LookupMapping.ILookup
        {
            var lookups = new Collection<T>();
            for (var id = 0; id < count; id++)
            {
                // Using Activator.CreateInstance to instantiate classes that have constructors with parameters
                // In effect, the three lines below are the same as: lookups.Add(new T(new TU(id), id));
                var tyInstance = Activator.CreateInstance(typeof(TU), new object[] { id }) as LookupMapping.ILookup;
                var tuInstance = Activator.CreateInstance(typeof(T), new object[] { tyInstance, id }) as T;
                lookups.Add(tuInstance);
            }
            ImportData(lookups);
            return lookups;
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
