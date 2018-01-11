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
        private readonly TeamDataExportService _teamDataExportService;
        private readonly TeamDataImportService _teamDataImportService;

        public CarNumberRepository CarNumbers { get; }
        public ChassisHandlingRepository ChassisHandlings { get; }
        public TeamRepository Teams { get; }

        public DataService(
            CarNumberDataExportService carNumberDataExportService,
            CarNumberDataImportService carNumberDataImportService,
            ChassisHandlingDataExportService chassisHandlingDataExportService,
            ChassisHandlingDataImportService chassisHandlingDataImportService,
            TeamDataExportService teamDataExportService,
            TeamDataImportService teamDataImportService,
            CarNumberRepository carNumberRepository,
            ChassisHandlingRepository chassisHandlingRepository,
            TeamRepository teamRepository)
        {
            _carNumberDataExportService = carNumberDataExportService ?? throw new ArgumentNullException(nameof(carNumberDataExportService));
            _carNumberDataImportService = carNumberDataImportService ?? throw new ArgumentNullException(nameof(carNumberDataImportService));
            _chassisHandlingDataExportService = chassisHandlingDataExportService ?? throw new ArgumentNullException(nameof(chassisHandlingDataExportService));
            _chassisHandlingDataImportService = chassisHandlingDataImportService ?? throw new ArgumentNullException(nameof(chassisHandlingDataImportService));
            _teamDataExportService = teamDataExportService ?? throw new ArgumentNullException(nameof(teamDataExportService));
            _teamDataImportService = teamDataImportService ?? throw new ArgumentNullException(nameof(teamDataImportService));

            CarNumbers = carNumberRepository ?? throw new ArgumentNullException(nameof(carNumberRepository));
            ChassisHandlings = chassisHandlingRepository ?? throw new ArgumentNullException(nameof(chassisHandlingRepository));
            Teams = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public void Export()
        {
            _carNumberDataExportService.Export();
            _chassisHandlingDataExportService.Export();
            _teamDataExportService.Export();
        }

        public void Import()
        {
            _carNumberDataImportService.Import();
            _chassisHandlingDataImportService.Import();
            _teamDataImportService.Import();
        }
    }
}