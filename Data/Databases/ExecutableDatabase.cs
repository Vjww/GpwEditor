using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Collections.Generic;
using Data.Collections.Language;
using Data.FileConnection;
using Data.Patchers.Enhancements.Units;
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

        public void ImportDataFromFile(string gameExecutablePath, string languageFilePath)
        {
            ValidateLanguageFile(languageFilePath);
            ValidateGameExecutable(gameExecutablePath);

            ImportLanguageStrings(languageFilePath);

            ImportTeams(gameExecutablePath);
            ImportFirstGpTrackLookups();
            ImportTyreSupplierIdAsSupplierIdLookups();

            ImportF1Chiefs(gameExecutablePath);
            ImportNonF1Chiefs(gameExecutablePath);

            ImportF1Drivers(gameExecutablePath);
            ImportNonF1Drivers(gameExecutablePath);
            ImportDriverNationalityLookups();
            ImportDriverLoyaltyDriverIdAsStaffIdLookups();

            ImportEngines(gameExecutablePath);
            ImportTyres(gameExecutablePath);
            ImportFuels(gameExecutablePath);

            ImportTracks(gameExecutablePath);
            ImportTrackDesignLookups();
            ImportFastestLapDriverIdAsStaffIdLookups();

            ImportChassisHandlings(gameExecutablePath);

            // TODO ImportStaffEfforts(gameExecutablePath);
            // TODO ImportStaffSalaries(gameExecutablePath);
            // TODO ImportFactoryRunningCosts(gameExecutablePath);
            // TODO ImportFactoryExpansionCosts(gameExecutablePath);
            // TODO ImportTestingMiles(gameExecutablePath);
            // TODO ImportEngineeringCosts(gameExecutablePath);
            // TODO ImportUnknownAEfforts(gameExecutablePath);
            // TODO ImportUnknownBEfforts(gameExecutablePath);
        }

        public void ExportDataToFile(string gameExecutablePath, string languageFilePath)
        {
            ValidateLanguageFile(languageFilePath);
            ValidateGameExecutable(gameExecutablePath);

            ExportTeams(gameExecutablePath);

            ExportF1Chiefs(gameExecutablePath);
            ExportNonF1Chiefs(gameExecutablePath);

            ExportF1Drivers(gameExecutablePath);
            ExportNonF1Drivers(gameExecutablePath);

            ExportEngines(gameExecutablePath);
            ExportTyres(gameExecutablePath);
            ExportFuels(gameExecutablePath);

            ExportTracks(gameExecutablePath);

            ExportChassisHandlings(gameExecutablePath);

            // TODO ExportStaffEfforts(gameExecutablePath);
            // TODO ExportStaffSalaries(gameExecutablePath);
            // TODO ExportFactoryRunningCosts(gameExecutablePath);
            // TODO ExportFactoryExpansionCosts(gameExecutablePath);
            // TODO ExportTestingMiles(gameExecutablePath);
            // TODO ExportEngineeringCosts(gameExecutablePath);
            // TODO ExportUnknownAEfforts(gameExecutablePath);
            // TODO ExportUnknownBEfforts(gameExecutablePath);

            ExportLanguageStrings(languageFilePath);
        }

        private void ImportLanguageStrings(string languageFilePath)
        {
            using (var languageConnection = new LanguageResourceConnection(languageFilePath))
            {
                LanguageStrings = languageConnection.Load();
            }
        }

        private void ExportLanguageStrings(string languageFilePath)
        {
            using (var languageConnection = new LanguageResourceConnection(languageFilePath))
            {
                languageConnection.Save(LanguageStrings);
            }
        }

        private void ImportTeams(string gameExecutablePath)
        {
            Teams = new Collection<TeamEntities.Team>
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
            ImportData(gameExecutablePath, Teams);
        }

        private void ExportTeams(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, Teams);
        }

        private void ImportF1Chiefs(string gameExecutablePath)
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
            ImportData(gameExecutablePath, F1ChiefCommercials);

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
            ImportData(gameExecutablePath, F1ChiefDesigners);

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
            ImportData(gameExecutablePath, F1ChiefEngineers);

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
            ImportData(gameExecutablePath, F1ChiefMechanics);
        }

        private void ExportF1Chiefs(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, F1ChiefCommercials);
            ExportData(gameExecutablePath, F1ChiefDesigners);
            ExportData(gameExecutablePath, F1ChiefEngineers);
            ExportData(gameExecutablePath, F1ChiefMechanics);
        }

        private void ImportNonF1Chiefs(string gameExecutablePath)
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
            ImportData(gameExecutablePath, NonF1ChiefCommercials);

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
            ImportData(gameExecutablePath, NonF1ChiefDesigners);

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
            ImportData(gameExecutablePath, NonF1ChiefEngineers);

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
            ImportData(gameExecutablePath, NonF1ChiefMechanics);
        }

        private void ExportNonF1Chiefs(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, NonF1ChiefCommercials);
            ExportData(gameExecutablePath, NonF1ChiefDesigners);
            ExportData(gameExecutablePath, NonF1ChiefEngineers);
            ExportData(gameExecutablePath, NonF1ChiefMechanics);
        }

        private void ImportF1Drivers(string gameExecutablePath)
        {
            F1Drivers = new Collection<TeamEntities.F1Driver>
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
            ImportData(gameExecutablePath, F1Drivers);
        }

        private void ExportF1Drivers(string gameExecutablePath)
        {
            UpdateF1DriversPayDrivers();
            ExportData(gameExecutablePath, F1Drivers);
        }

        private void UpdateF1DriversPayDrivers()
        {
            foreach (var item in F1Drivers)
            {
                if (item.Salary < 0)
                {
                    item.RaceBonus = 0;
                    item.ChampionshipBonus = 0;
                }
                item.PositiveSalary = item.Salary < 0 ? Math.Abs(item.Salary) : 0;
                item.PayRating = item.Salary < 0 ? GetPayRating(item.PositiveSalary) : 0;
            }
        }

        private static int GetPayRating(int salary)
        {
                                              // Pay driver salaries ($million):
            if (salary <= 3500000) return 1;  // Level 1: 2.6-3.5
            if (salary <= 4500000) return 2;  // Level 2: 3.6-4.5
            if (salary <= 6500000) return 3;  // Level 3: 5.6-6.5
            if (salary <= 8500000) return 4;  // Level 4: 7.6-8.5
            return 5;                         // Level 5: 9.6-10.5
        }

        private void ImportNonF1Drivers(string gameExecutablePath)
        {
            NonF1Drivers = new Collection<TeamEntities.NonF1Driver>
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
            ImportData(gameExecutablePath, NonF1Drivers);
        }

        private void ExportNonF1Drivers(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, NonF1Drivers);
        }

        private void ImportEngines(string gameExecutablePath)
        {
            Engines = new Collection<SupplierEntities.Engine>
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
            ImportData(gameExecutablePath, Engines);
        }

        private void ExportEngines(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, Engines);
        }

        private void ImportTyres(string gameExecutablePath)
        {
            Tyres = new Collection<SupplierEntities.Tyre>
            {
                new SupplierEntities.Tyre(new SupplierMapping.Tyre(0), 0),
                new SupplierEntities.Tyre(new SupplierMapping.Tyre(1), 1),
                new SupplierEntities.Tyre(new SupplierMapping.Tyre(2), 2)
            };
            ImportData(gameExecutablePath, Tyres);
        }

        private void ExportTyres(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, Tyres);
        }

        private void ImportFuels(string gameExecutablePath)
        {
            Fuels = new Collection<SupplierEntities.Fuel>
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
            ImportData(gameExecutablePath, Fuels);
        }

        private void ExportFuels(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, Fuels);
        }

        private void ImportTracks(string gameExecutablePath)
        {
            Tracks = new Collection<TrackEntities.Track>
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
            ImportData(gameExecutablePath, Tracks);
        }

        private void ExportTracks(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, Tracks);
        }

        private void ImportChassisHandlings(string gameExecutablePath)
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
            ImportData(gameExecutablePath, ChassisHandlings);
        }

        private void ExportChassisHandlings(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, ChassisHandlings);
        }

        //private void ImportStaffEfforts(string gameExecutablePath)
        //{
        //    StaffEfforts = new FiveRatingCollection
        //    {
        //        new EnvironmentEntities.StaffEfforts.DepartmentChief(new EnvironmentMapping.StaffEfforts.DepartmentChief()),
        //        new EnvironmentEntities.StaffEfforts.DepartmentStaff(new EnvironmentMapping.StaffEfforts.DepartmentStaff())
        //    };
        //    ImportData(gameExecutablePath, StaffEfforts);
        //}

        //private void ExportStaffEfforts(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, StaffEfforts);
        //}

        //private void ImportStaffSalaries(string gameExecutablePath)
        //{
        //    StaffSalaries = new FiveRatingCollection
        //    {
        //        new EnvironmentEntities.StaffSalaries.Commercial(new EnvironmentMapping.StaffSalaries.Commercial()),
        //        new EnvironmentEntities.StaffSalaries.Design(new EnvironmentMapping.StaffSalaries.Design()),
        //        new EnvironmentEntities.StaffSalaries.Engineering(new EnvironmentMapping.StaffSalaries.Engineering()),
        //        new EnvironmentEntities.StaffSalaries.Mechanics(new EnvironmentMapping.StaffSalaries.Mechanics()),
        //    };
        //    ImportData(gameExecutablePath, StaffSalaries);
        //}

        //private void ExportStaffSalaries(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, StaffSalaries);
        //}

        //private void ImportFactoryRunningCosts(string gameExecutablePath)
        //{
        //    FactoryRunningCosts = new FiveValueCollection
        //    {
        //        new EnvironmentEntities.RunningCosts.Factory(new EnvironmentMapping.RunningCosts.Factory()),
        //        new EnvironmentEntities.RunningCosts.WindTunnel(new EnvironmentMapping.RunningCosts.WindTunnel())
        //    };
        //    ImportData(gameExecutablePath, FactoryRunningCosts);
        //}

        //private void ExportFactoryRunningCosts(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, FactoryRunningCosts);
        //}

        //private void ImportFactoryExpansionCosts(string gameExecutablePath)
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
        //    ImportData(gameExecutablePath, FactoryExpansionCosts);
        //}

        //private void ExportFactoryExpansionCosts(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, FactoryExpansionCosts);
        //}

        //private void ImportTestingMiles(string gameExecutablePath)
        //{
        //    TestingMiles = new TenValueCollection
        //    {
        //        new EnvironmentEntities.TestingMiles.TestingMiles(new EnvironmentMapping.TestingMiles.TestingMiles())
        //    };
        //    ImportData(gameExecutablePath, TestingMiles);
        //}

        //private void ExportTestingMiles(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, TestingMiles);
        //}

        //private void ImportEngineeringCosts(string gameExecutablePath)
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
        //    ImportData(gameExecutablePath, EngineeringCosts);
        //}

        //private void ExportEngineeringCosts(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, EngineeringCosts);
        //}

        //private void ImportUnknownAEfforts(string gameExecutablePath)
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
        //    ImportData(gameExecutablePath, UnknownAEfforts);
        //}

        //private void ExportUnknownAEfforts(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, UnknownAEfforts);
        //}

        //private void ImportUnknownBEfforts(string gameExecutablePath)
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
        //    ImportData(gameExecutablePath, UnknownBEfforts);
        //}

        //private void ExportUnknownBEfforts(string gameExecutablePath)
        //{
        //    ExportData(gameExecutablePath, UnknownBEfforts);
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

        private void ImportData<T>(string gameExecutablePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
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

        private void ExportData<T>(string gameExecutablePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                foreach (var item in collection)
                {
                    item.ExportData(executableConnection, LanguageStrings);
                }
            }
        }

        private static void ValidateGameExecutable(string gameExecutablePath)
        {
            string verificationMessage;
            var isValid = new GameExecutableVerification().IsFileSupported(gameExecutablePath, out verificationMessage);

            if (isValid) return;
            const string resolutionMessage = "Please ensure the official v1.01b patch has been applied to the game and select a compatible v1.01b game executable to modify successfully.";
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        private static void ValidateLanguageFile(string languageFilePath)
        {
            // TODO: Implement
        }
    }
}