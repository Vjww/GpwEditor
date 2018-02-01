using System;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class DataService
    {
        private readonly CarNumberDataExportService _carNumberDataExportService;
        private readonly CarNumberDataImportService _carNumberDataImportService;
        private readonly ChassisHandlingDataExportService _chassisHandlingDataExportService;
        private readonly ChassisHandlingDataImportService _chassisHandlingDataImportService;
        private readonly F1ChiefCommercialDataExportService _f1ChiefCommercialDataExportService;
        private readonly F1ChiefCommercialDataImportService _f1ChiefCommercialDataImportService;
        private readonly F1ChiefDesignerDataExportService _f1ChiefDesignerDataExportService;
        private readonly F1ChiefDesignerDataImportService _f1ChiefDesignerDataImportService;
        private readonly F1ChiefEngineerDataExportService _f1ChiefEngineerDataExportService;
        private readonly F1ChiefEngineerDataImportService _f1ChiefEngineerDataImportService;
        private readonly F1ChiefMechanicDataExportService _f1ChiefMechanicDataExportService;
        private readonly F1ChiefMechanicDataImportService _f1ChiefMechanicDataImportService;
        private readonly F1DriverDataExportService _f1DriverDataExportService;
        private readonly F1DriverDataImportService _f1DriverDataImportService;
        private readonly TeamDataExportService _teamDataExportService;
        private readonly TeamDataImportService _teamDataImportService;

        public CarNumberRepository CarNumbers { get; }
        public ChassisHandlingRepository ChassisHandlings { get; }
        public F1ChiefCommercialRepository F1ChiefCommercials { get; }
        public F1ChiefDesignerRepository F1ChiefDesigners { get; }
        public F1ChiefEngineerRepository F1ChiefEngineers { get; }
        public F1ChiefMechanicRepository F1ChiefMechanics { get; }
        public F1DriverRepository F1Drivers { get; }
        public TeamRepository Teams { get; }

        public DataService(
            CarNumberDataExportService carNumberDataExportService,
            CarNumberDataImportService carNumberDataImportService,
            ChassisHandlingDataExportService chassisHandlingDataExportService,
            ChassisHandlingDataImportService chassisHandlingDataImportService,
            F1ChiefCommercialDataExportService f1ChiefCommercialDataExportService,
            F1ChiefCommercialDataImportService f1ChiefCommercialDataImportService,
            F1ChiefDesignerDataExportService f1ChiefDesignerDataExportService,
            F1ChiefDesignerDataImportService f1ChiefDesignerDataImportService,
            F1ChiefEngineerDataExportService f1ChiefEngineerDataExportService,
            F1ChiefEngineerDataImportService f1ChiefEngineerDataImportService,
            F1ChiefMechanicDataExportService f1ChiefMechanicDataExportService,
            F1ChiefMechanicDataImportService f1ChiefMechanicDataImportService,
            F1DriverDataExportService f1DriverDataExportService,
            F1DriverDataImportService f1DriverDataImportService,
            TeamDataExportService teamDataExportService,
            TeamDataImportService teamDataImportService,
            CarNumberRepository carNumberRepository,
            ChassisHandlingRepository chassisHandlingRepository,
            F1ChiefCommercialRepository f1ChiefCommercialRepository,
            F1ChiefDesignerRepository f1ChiefDesignerRepository,
            F1ChiefEngineerRepository f1ChiefEngineerRepository,
            F1ChiefMechanicRepository f1ChiefMechanicRepository,
            F1DriverRepository f1DriverRepository,
            TeamRepository teamRepository)
        {
            _carNumberDataExportService = carNumberDataExportService ?? throw new ArgumentNullException(nameof(carNumberDataExportService));
            _carNumberDataImportService = carNumberDataImportService ?? throw new ArgumentNullException(nameof(carNumberDataImportService));
            _chassisHandlingDataExportService = chassisHandlingDataExportService ?? throw new ArgumentNullException(nameof(chassisHandlingDataExportService));
            _chassisHandlingDataImportService = chassisHandlingDataImportService ?? throw new ArgumentNullException(nameof(chassisHandlingDataImportService));
            _f1ChiefCommercialDataExportService = f1ChiefCommercialDataExportService ?? throw new ArgumentNullException(nameof(f1ChiefCommercialDataExportService));
            _f1ChiefCommercialDataImportService = f1ChiefCommercialDataImportService ?? throw new ArgumentNullException(nameof(f1ChiefCommercialDataImportService));
            _f1ChiefDesignerDataExportService = f1ChiefDesignerDataExportService ?? throw new ArgumentNullException(nameof(f1ChiefDesignerDataExportService));
            _f1ChiefDesignerDataImportService = f1ChiefDesignerDataImportService ?? throw new ArgumentNullException(nameof(f1ChiefDesignerDataImportService));
            _f1ChiefEngineerDataExportService = f1ChiefEngineerDataExportService ?? throw new ArgumentNullException(nameof(f1ChiefEngineerDataExportService));
            _f1ChiefEngineerDataImportService = f1ChiefEngineerDataImportService ?? throw new ArgumentNullException(nameof(f1ChiefEngineerDataImportService));
            _f1ChiefMechanicDataExportService = f1ChiefMechanicDataExportService ?? throw new ArgumentNullException(nameof(f1ChiefMechanicDataExportService));
            _f1ChiefMechanicDataImportService = f1ChiefMechanicDataImportService ?? throw new ArgumentNullException(nameof(f1ChiefMechanicDataImportService));
            _f1DriverDataExportService = f1DriverDataExportService ?? throw new ArgumentNullException(nameof(f1DriverDataExportService));
            _f1DriverDataImportService = f1DriverDataImportService ?? throw new ArgumentNullException(nameof(f1DriverDataImportService));
            _teamDataExportService = teamDataExportService ?? throw new ArgumentNullException(nameof(teamDataExportService));
            _teamDataImportService = teamDataImportService ?? throw new ArgumentNullException(nameof(teamDataImportService));

            CarNumbers = carNumberRepository ?? throw new ArgumentNullException(nameof(carNumberRepository));
            ChassisHandlings = chassisHandlingRepository ?? throw new ArgumentNullException(nameof(chassisHandlingRepository));
            F1ChiefCommercials = f1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepository));
            F1ChiefDesigners = f1ChiefDesignerRepository ?? throw new ArgumentNullException(nameof(f1ChiefDesignerRepository));
            F1ChiefEngineers = f1ChiefEngineerRepository ?? throw new ArgumentNullException(nameof(f1ChiefEngineerRepository));
            F1ChiefMechanics = f1ChiefMechanicRepository ?? throw new ArgumentNullException(nameof(f1ChiefMechanicRepository));
            F1Drivers = f1DriverRepository ?? throw new ArgumentNullException(nameof(f1DriverRepository));
            Teams = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public void Export()
        {
            _carNumberDataExportService.Export();
            _chassisHandlingDataExportService.Export();
            _f1ChiefCommercialDataExportService.Export();
            _f1ChiefDesignerDataExportService.Export();
            _f1ChiefEngineerDataExportService.Export();
            _f1ChiefMechanicDataExportService.Export();
            _f1DriverDataExportService.Export();
            _teamDataExportService.Export();
        }

        public void Import()
        {
            _carNumberDataImportService.Import();
            _chassisHandlingDataImportService.Import();
            _f1ChiefCommercialDataImportService.Import();
            _f1ChiefDesignerDataImportService.Import();
            _f1ChiefEngineerDataImportService.Import();
            _f1ChiefMechanicDataImportService.Import();
            _f1DriverDataImportService.Import();
            _teamDataImportService.Import();
        }
    }
}