using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Generic;
using Data.Collections.Language;
using Data.FileConnection;
using LanguageEntities = Data.Entities.Language;
using LookupEntities = Data.Entities.Executable.Lookup;
using LookupMapping = Data.ValueMapping.Executable.Lookup;
using TeamEntities = Data.Entities.Executable.Team;
using TeamMapping = Data.ValueMapping.Executable.Team;
using SupplierEntities = Data.Entities.Executable.Supplier;
using SupplierMapping = Data.ValueMapping.Executable.Supplier;
using TrackEntities = Data.Entities.Executable.Track;
using TrackMapping = Data.ValueMapping.Executable.Track;
using RaceEntities = Data.Entities.Executable.Race;
using RaceMapping = Data.ValueMapping.Executable.Race;
using EnvironmentEntities = Data.Entities.Executable.Environment;
using EnvironmentMapping = Data.ValueMapping.Executable.Environment;

namespace Data.Databases
{
    public class ExecutableDatabase
    {
        public IdentityCollection LanguageStrings { get; set; }
        public Collection<TeamEntities.Team> Teams { get; set; }
        public Collection<TeamEntities.F1ChiefCommercial> F1ChiefCommercials { get; set; }
        public Collection<TeamEntities.F1ChiefDesigner> F1ChiefDesigners { get; set; }
        public Collection<TeamEntities.F1ChiefEngineer> F1ChiefEngineers { get; set; }
        public Collection<TeamEntities.F1ChiefMechanic> F1ChiefMechanics { get; set; }
        public Collection<TeamEntities.NonF1ChiefCommercial> NonF1ChiefCommercials { get; set; }
        public Collection<TeamEntities.NonF1ChiefDesigner> NonF1ChiefDesigners { get; set; }
        public Collection<TeamEntities.NonF1ChiefEngineer> NonF1ChiefEngineers { get; set; }
        public Collection<TeamEntities.NonF1ChiefMechanic> NonF1ChiefMechanics { get; set; }
        public Collection<TeamEntities.F1Driver> F1Drivers { get; set; }
        public Collection<TeamEntities.NonF1Driver> NonF1Drivers { get; set; }
        public Collection<SupplierEntities.Engine> Engines { get; set; }
        public Collection<SupplierEntities.Tyre> Tyres { get; set; }
        public Collection<SupplierEntities.Fuel> Fuels { get; set; }
        public Collection<TrackEntities.Track> Tracks { get; set; }

        public RaceEntities.PerformanceCurve PerformanceCurve { get; set; }
        public Collection<RaceEntities.ChassisHandling> ChassisHandlings { get; set; }

        //TODO public FiveRatingCollection StaffEfforts { get; set; }
        //TODO public FiveRatingCollection StaffSalaries { get; set; }
        //TODO public FiveValueCollection FactoryRunningCosts { get; set; }
        //TODO public FiveRatingCollection FactoryExpansionCosts { get; set; }
        //TODO public TenValueCollection TestingMiles { get; set; }
        //TODO public TenValueCollection EngineeringCosts { get; set; }
        //TODO public SingleValueCollection UnknownAEfforts { get; set; }
        //TODO public SingleValueCollection UnknownBEfforts { get; set; }

        public IEnumerable<LookupEntities.DriverNationality> DriverNationalityLookups { get; set; }
        public IEnumerable<LookupEntities.DriverLoyaltyDriverIdAsStaffId> DriverLoyaltyDriverIdAsStaffIdLookups { get; set; }
        public IEnumerable<LookupEntities.FastestLapDriverIdAsStaffId> FastestLapDriverIdAsStaffIdLookups { get; set; }
        public IEnumerable<LookupEntities.FirstGpTrack> FirstGpTrackLookups { get; set; }
        public IEnumerable<LookupEntities.TrackDesign> TrackDesignLookups { get; set; }
        public IEnumerable<LookupEntities.TyreSupplierIdAsSupplierId> TyreSupplierIdAsSupplierIdLookups { get; set; }

        public void ImportDataFromFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            ValidateLanguageFile(languageFileFilePath);
            ValidateGameExecutable(gameExecutableFilePath);

            ImportLanguageStrings(languageFileFilePath);

            ImportTeams(gameExecutableFilePath);
            ImportFirstGpTrackLookups();
            ImportTyreSupplierIdAsSupplierIdLookups();

            ImportF1Chiefs(gameExecutableFilePath);
            ImportNonF1Chiefs(gameExecutableFilePath);

            ImportF1Drivers(gameExecutableFilePath);
            ImportNonF1Drivers(gameExecutableFilePath);
            ImportDriverNationalityLookups();
            ImportDriverLoyaltyDriverIdAsStaffIdLookups();

            ImportEngines(gameExecutableFilePath);
            ImportTyres(gameExecutableFilePath);
            ImportFuels(gameExecutableFilePath);

            ImportTracks(gameExecutableFilePath);
            ImportTrackDesignLookups();
            ImportFastestLapDriverIdAsStaffIdLookups();

            ImportPerformanceCurve(gameExecutableFilePath);
            ImportChassisHandlings(gameExecutableFilePath);

            // TODO ImportStaffEfforts(gameExecutableFilePath);
            // TODO ImportStaffSalaries(gameExecutableFilePath);
            // TODO ImportFactoryRunningCosts(gameExecutableFilePath);
            // TODO ImportFactoryExpansionCosts(gameExecutableFilePath);
            // TODO ImportTestingMiles(gameExecutableFilePath);
            // TODO ImportEngineeringCosts(gameExecutableFilePath);
            // TODO ImportUnknownAEfforts(gameExecutableFilePath);
            // TODO ImportUnknownBEfforts(gameExecutableFilePath);
        }

        public void ExportDataToFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            ValidateLanguageFile(languageFileFilePath);
            ValidateGameExecutable(gameExecutableFilePath);

            ExportTeams(gameExecutableFilePath);

            ExportF1Chiefs(gameExecutableFilePath);
            ExportNonF1Chiefs(gameExecutableFilePath);

            ExportF1Drivers(gameExecutableFilePath);
            ExportNonF1Drivers(gameExecutableFilePath);

            ExportEngines(gameExecutableFilePath);
            ExportTyres(gameExecutableFilePath);
            ExportFuels(gameExecutableFilePath);

            ExportTracks(gameExecutableFilePath);

            ExportPerformanceCurve(gameExecutableFilePath);
            ExportChassisHandlings(gameExecutableFilePath);

            // TODO ExportStaffEfforts(gameExecutableFilePath);
            // TODO ExportStaffSalaries(gameExecutableFilePath);
            // TODO ExportFactoryRunningCosts(gameExecutableFilePath);
            // TODO ExportFactoryExpansionCosts(gameExecutableFilePath);
            // TODO ExportTestingMiles(gameExecutableFilePath);
            // TODO ExportEngineeringCosts(gameExecutableFilePath);
            // TODO ExportUnknownAEfforts(gameExecutableFilePath);
            // TODO ExportUnknownBEfforts(gameExecutableFilePath);

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

        private void ImportF1Chiefs(string gameExecutableFilePath)
        {
            F1ChiefCommercials = new Collection<TeamEntities.F1ChiefCommercial>
            {
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(0), 0),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(1), 1),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(2), 2),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(3), 3),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(4), 4),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(5), 5),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(6), 6),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(7), 7),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(8), 8),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(9), 9),
                new TeamEntities.F1ChiefCommercial(new TeamMapping.F1ChiefCommercial(10), 10)
            };
            ImportData(gameExecutableFilePath, F1ChiefCommercials);

            F1ChiefDesigners = new Collection<TeamEntities.F1ChiefDesigner>
            {
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(0), 0),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(1), 1),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(2), 2),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(3), 3),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(4), 4),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(5), 5),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(6), 6),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(7), 7),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(8), 8),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(9), 9),
                new TeamEntities.F1ChiefDesigner(new TeamMapping.F1ChiefDesigner(10), 10)
            };
            ImportData(gameExecutableFilePath, F1ChiefDesigners);

            F1ChiefEngineers = new Collection<TeamEntities.F1ChiefEngineer>
            {
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(0), 0),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(1), 1),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(2), 2),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(3), 3),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(4), 4),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(5), 5),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(6), 6),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(7), 7),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(8), 8),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(9), 9),
                new TeamEntities.F1ChiefEngineer(new TeamMapping.F1ChiefEngineer(10), 10)
            };
            ImportData(gameExecutableFilePath, F1ChiefEngineers);

            F1ChiefMechanics = new Collection<TeamEntities.F1ChiefMechanic>
            {
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(0), 0),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(1), 1),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(2), 2),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(3), 3),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(4), 4),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(5), 5),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(6), 6),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(7), 7),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(8), 8),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(9), 9),
                new TeamEntities.F1ChiefMechanic(new TeamMapping.F1ChiefMechanic(10), 10)
            };
            ImportData(gameExecutableFilePath, F1ChiefMechanics);
        }

        private void ExportF1Chiefs(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, F1ChiefCommercials);
            ExportData(gameExecutableFilePath, F1ChiefDesigners);
            ExportData(gameExecutableFilePath, F1ChiefEngineers);
            ExportData(gameExecutableFilePath, F1ChiefMechanics);
        }

        private void ImportNonF1Chiefs(string gameExecutableFilePath)
        {
            NonF1ChiefCommercials = new Collection<TeamEntities.NonF1ChiefCommercial>
            {
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(0), 0),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(1), 1),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(2), 2),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(3), 3),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(4), 4),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(5), 5),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(6), 6),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(7), 7),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(8), 8),
                new TeamEntities.NonF1ChiefCommercial(new TeamMapping.NonF1ChiefCommercial(9), 9)
            };
            ImportData(gameExecutableFilePath, NonF1ChiefCommercials);

            NonF1ChiefDesigners = new Collection<TeamEntities.NonF1ChiefDesigner>
            {
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(0), 0),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(1), 1),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(2), 2),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(3), 3),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(4), 4),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(5), 5),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(6), 6),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(7), 7),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(8), 8),
                new TeamEntities.NonF1ChiefDesigner(new TeamMapping.NonF1ChiefDesigner(9), 9)
            };
            ImportData(gameExecutableFilePath, NonF1ChiefDesigners);

            NonF1ChiefEngineers = new Collection<TeamEntities.NonF1ChiefEngineer>
            {
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(0), 0),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(1), 1),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(2), 2),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(3), 3),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(4), 4),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(5), 5),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(6), 6),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(7), 7),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(8), 8),
                new TeamEntities.NonF1ChiefEngineer(new TeamMapping.NonF1ChiefEngineer(9), 9)
            };
            ImportData(gameExecutableFilePath, NonF1ChiefEngineers);

            NonF1ChiefMechanics = new Collection<TeamEntities.NonF1ChiefMechanic>
            {
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(0), 0),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(1), 1),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(2), 2),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(3), 3),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(4), 4),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(5), 5),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(6), 6),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(7), 7),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(8), 8),
                new TeamEntities.NonF1ChiefMechanic(new TeamMapping.NonF1ChiefMechanic(9), 9)
            };
            ImportData(gameExecutableFilePath, NonF1ChiefMechanics);
        }

        private void ExportNonF1Chiefs(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, NonF1ChiefCommercials);
            ExportData(gameExecutableFilePath, NonF1ChiefDesigners);
            ExportData(gameExecutableFilePath, NonF1ChiefEngineers);
            ExportData(gameExecutableFilePath, NonF1ChiefMechanics);
        }

        private void ImportF1Drivers(string gameExecutableFilePath)
        {
            F1Drivers = new DriverCollection
            {
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(0), 0),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(1), 1),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(2), 2),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(3), 3),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(4), 4),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(5), 5),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(6), 6),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(7), 7),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(8), 8),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(9), 9),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(10), 10),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(11), 11),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(12), 12),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(13), 13),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(14), 14),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(15), 15),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(16), 16),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(17), 17),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(18), 18),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(19), 19),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(20), 20),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(21), 21),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(22), 22),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(23), 23),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(24), 24),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(25), 25),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(26), 26),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(27), 27),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(28), 28),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(29), 29),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(30), 30),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(31), 31),
                new TeamEntities.F1Driver(new TeamMapping.F1Driver(32), 32)
            };
            ImportData(gameExecutableFilePath, F1Drivers);
        }

        private void ExportF1Drivers(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, F1Drivers);
        }

        private void ImportNonF1Drivers(string gameExecutableFilePath)
        {
            NonF1Drivers = new NonF1DriverCollection
            {
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(0), 0),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(1), 1),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(2), 2),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(3), 3),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(4), 4),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(5), 5),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(6), 6),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(7), 7),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(8), 8),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(9), 9),
                new TeamEntities.NonF1Driver(new TeamMapping.NonF1Driver(10), 10)
            };
            ImportData(gameExecutableFilePath, NonF1Drivers);
        }

        private void ExportNonF1Drivers(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, NonF1Drivers);
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

        private void ImportPerformanceCurve(string gameExecutableFilePath)
        {
            PerformanceCurve = new RaceEntities.PerformanceCurve();
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                PerformanceCurve.ImportData(executableConnection, LanguageStrings);
            }
        }

        private void ExportPerformanceCurve(string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                PerformanceCurve.ExportData(executableConnection, LanguageStrings);
            }
        }

        private void ImportChassisHandlings(string gameExecutableFilePath)
        {
            ChassisHandlings = new Collection<RaceEntities.ChassisHandling>
            {
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(0), 0),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(1), 1),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(2), 2),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(3), 3),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(4), 4),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(5), 5),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(6), 6),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(7), 7),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(8), 8),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(9), 9),
                new RaceEntities.ChassisHandling(new RaceMapping.ChassisHandling(10), 10)
            };
            ImportData(gameExecutableFilePath, ChassisHandlings);
        }

        private void ExportChassisHandlings(string gameExecutableFilePath)
        {
            ExportData(gameExecutableFilePath, ChassisHandlings);
        }

        //private void ImportStaffEfforts(string gameExecutableFilePath)
        //{
        //    StaffEfforts = new FiveRatingCollection
        //    {
        //        new EnvironmentEntities.StaffEfforts.DepartmentChief(new EnvironmentMapping.StaffEfforts.DepartmentChief()),
        //        new EnvironmentEntities.StaffEfforts.DepartmentStaff(new EnvironmentMapping.StaffEfforts.DepartmentStaff())
        //    };
        //    ImportData(gameExecutableFilePath, StaffEfforts);
        //}

        //private void ExportStaffEfforts(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, StaffEfforts);
        //}

        //private void ImportStaffSalaries(string gameExecutableFilePath)
        //{
        //    StaffSalaries = new FiveRatingCollection
        //    {
        //        new EnvironmentEntities.StaffSalaries.Commercial(new EnvironmentMapping.StaffSalaries.Commercial()),
        //        new EnvironmentEntities.StaffSalaries.Design(new EnvironmentMapping.StaffSalaries.Design()),
        //        new EnvironmentEntities.StaffSalaries.Engineering(new EnvironmentMapping.StaffSalaries.Engineering()),
        //        new EnvironmentEntities.StaffSalaries.Mechanics(new EnvironmentMapping.StaffSalaries.Mechanics()),
        //    };
        //    ImportData(gameExecutableFilePath, StaffSalaries);
        //}

        //private void ExportStaffSalaries(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, StaffSalaries);
        //}

        //private void ImportFactoryRunningCosts(string gameExecutableFilePath)
        //{
        //    FactoryRunningCosts = new FiveValueCollection
        //    {
        //        new EnvironmentEntities.RunningCosts.Factory(new EnvironmentMapping.RunningCosts.Factory()),
        //        new EnvironmentEntities.RunningCosts.WindTunnel(new EnvironmentMapping.RunningCosts.WindTunnel())
        //    };
        //    ImportData(gameExecutableFilePath, FactoryRunningCosts);
        //}

        //private void ExportFactoryRunningCosts(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, FactoryRunningCosts);
        //}

        //private void ImportFactoryExpansionCosts(string gameExecutableFilePath)
        //{
        //    FactoryExpansionCosts = new FiveRatingCollection
        //    {
        //        new EnvironmentEntities.ExpansionCosts.Factory(new EnvironmentMapping.ExpansionCosts.Factory()),
        //        new EnvironmentEntities.ExpansionCosts.Cad(new EnvironmentMapping.ExpansionCosts.Cad()),
        //        new EnvironmentEntities.ExpansionCosts.Cam(new EnvironmentMapping.ExpansionCosts.Cam()),
        //        new EnvironmentEntities.ExpansionCosts.Supercomputer(new EnvironmentMapping.ExpansionCosts.Supercomputer()),
        //        new EnvironmentEntities.ExpansionCosts.TestRig(new EnvironmentMapping.ExpansionCosts.TestRig()),
        //        new EnvironmentEntities.ExpansionCosts.WindTunnel(new EnvironmentMapping.ExpansionCosts.WindTunnel()),
        //        new EnvironmentEntities.ExpansionCosts.Workshop(new EnvironmentMapping.ExpansionCosts.Workshop())
        //    };
        //    ImportData(gameExecutableFilePath, FactoryExpansionCosts);
        //}

        //private void ExportFactoryExpansionCosts(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, FactoryExpansionCosts);
        //}

        //private void ImportTestingMiles(string gameExecutableFilePath)
        //{
        //    TestingMiles = new TenValueCollection
        //    {
        //        new EnvironmentEntities.TestingMiles.TestingMiles(new EnvironmentMapping.TestingMiles.TestingMiles())
        //    };
        //    ImportData(gameExecutableFilePath, TestingMiles);
        //}

        //private void ExportTestingMiles(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, TestingMiles);
        //}

        //private void ImportEngineeringCosts(string gameExecutableFilePath)
        //{
        //    EngineeringCosts = new TenValueCollection
        //    {
        //        new EnvironmentEntities.EngineeringCosts.BuildThisYearCar(new EnvironmentMapping.EngineeringCosts.BuildThisYearCar()),
        //        new EnvironmentEntities.EngineeringCosts.BuildNextYearCar(new EnvironmentMapping.EngineeringCosts.BuildNextYearCar()),
        //        new EnvironmentEntities.EngineeringCosts.UpgradeChassis(new EnvironmentMapping.EngineeringCosts.UpgradeChassis()),
        //        new EnvironmentEntities.EngineeringCosts.UpgradeTechnology(new EnvironmentMapping.EngineeringCosts.UpgradeTechnology()),
        //        new EnvironmentEntities.EngineeringCosts.UpgradeDrivingAid(new EnvironmentMapping.EngineeringCosts.UpgradeDrivingAid()),
        //        new EnvironmentEntities.EngineeringCosts.BuildSpare(new EnvironmentMapping.EngineeringCosts.BuildSpare())
        //    };
        //    ImportData(gameExecutableFilePath, EngineeringCosts);
        //}

        //private void ExportEngineeringCosts(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, EngineeringCosts);
        //}

        //private void ImportUnknownAEfforts(string gameExecutableFilePath)
        //{
        //    UnknownAEfforts = new SingleValueCollection
        //    {
        //        new EnvironmentEntities.UnknownAEfforts.Unknown1(new EnvironmentMapping.UnknownAEfforts.Unknown1()),
        //        new EnvironmentEntities.UnknownAEfforts.Unknown2(new EnvironmentMapping.UnknownAEfforts.Unknown2()),
        //        new EnvironmentEntities.UnknownAEfforts.Unknown3(new EnvironmentMapping.UnknownAEfforts.Unknown3()),
        //        new EnvironmentEntities.UnknownAEfforts.Unknown4(new EnvironmentMapping.UnknownAEfforts.Unknown4()),
        //        new EnvironmentEntities.UnknownAEfforts.Unknown5(new EnvironmentMapping.UnknownAEfforts.Unknown5()),
        //        new EnvironmentEntities.UnknownAEfforts.Unknown6(new EnvironmentMapping.UnknownAEfforts.Unknown6())
        //    };
        //    ImportData(gameExecutableFilePath, UnknownAEfforts);
        //}

        //private void ExportUnknownAEfforts(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, UnknownAEfforts);
        //}

        //private void ImportUnknownBEfforts(string gameExecutableFilePath)
        //{
        //    UnknownBEfforts = new SingleValueCollection
        //    {
        //        new EnvironmentEntities.UnknownBEfforts.Unknown1(new EnvironmentMapping.UnknownBEfforts.Unknown1()),
        //        new EnvironmentEntities.UnknownBEfforts.Unknown2(new EnvironmentMapping.UnknownBEfforts.Unknown2()),
        //        new EnvironmentEntities.UnknownBEfforts.Unknown3(new EnvironmentMapping.UnknownBEfforts.Unknown3()),
        //        new EnvironmentEntities.UnknownBEfforts.Unknown4(new EnvironmentMapping.UnknownBEfforts.Unknown4()),
        //        new EnvironmentEntities.UnknownBEfforts.Unknown5(new EnvironmentMapping.UnknownBEfforts.Unknown5()),
        //        new EnvironmentEntities.UnknownBEfforts.Unknown6(new EnvironmentMapping.UnknownBEfforts.Unknown6())
        //    };
        //    ImportData(gameExecutableFilePath, UnknownBEfforts);
        //}

        //private void ExportUnknownBEfforts(string gameExecutableFilePath)
        //{
        //    ExportData(gameExecutableFilePath, UnknownBEfforts);
        //}

        private void ImportDriverNationalityLookups()
        {
            DriverNationalityLookups = ImportLookups<LookupEntities.DriverNationality, LookupMapping.DriverNationality>(14);
        }

        private void ImportDriverLoyaltyDriverIdAsStaffIdLookups()
        {
            DriverLoyaltyDriverIdAsStaffIdLookups = ImportLookups<LookupEntities.DriverLoyaltyDriverIdAsStaffId, LookupMapping.DriverLoyaltyDriverIdAsStaffId>(45);
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
            where T : class, LanguageEntities.IIdentity, IDataConnection
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

        private static void ValidateGameExecutable(string gameExecutableFilePath)
        {
            string verificationMessage;
            var isValid = new ExecutableVerification().IsGameExecutableSupported(gameExecutableFilePath, out verificationMessage);

            if (isValid) return;
            const string resolutionMessage = "Please ensure the official v1.01b patch has been applied to the game and select a compatible v1.01b game executable to modify successfully.";
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        private static void ValidateLanguageFile(string languageFileFilePath)
        {
            // TODO Implement
        }
    }
}