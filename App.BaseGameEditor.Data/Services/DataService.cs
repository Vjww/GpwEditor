using System;
using App.BaseGameEditor.Data.DataEntities;
using App.Core.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class DataService
    {
        private readonly IRepositoryExportService<CarNumberDataEntity> _carNumberRepositoryExportService;
        private readonly IRepositoryImportService<CarNumberDataEntity> _carNumberRepositoryImportService;
        private readonly IRepositoryExportService<ChassisHandlingDataEntity> _chassisHandlingRepositoryExportService;
        private readonly IRepositoryImportService<ChassisHandlingDataEntity> _chassisHandlingRepositoryImportService;
        private readonly IRepositoryExportService<F1ChiefCommercialDataEntity> _f1ChiefCommercialRepositoryExportService;
        private readonly IRepositoryImportService<F1ChiefCommercialDataEntity> _f1ChiefCommercialRepositoryImportService;
        private readonly IRepositoryExportService<F1ChiefDesignerDataEntity> _f1ChiefDesignerRepositoryExportService;
        private readonly IRepositoryImportService<F1ChiefDesignerDataEntity> _f1ChiefDesignerRepositoryImportService;
        private readonly IRepositoryExportService<F1ChiefEngineerDataEntity> _f1ChiefEngineerRepositoryExportService;
        private readonly IRepositoryImportService<F1ChiefEngineerDataEntity> _f1ChiefEngineerRepositoryImportService;
        private readonly IRepositoryExportService<F1ChiefMechanicDataEntity> _f1ChiefMechanicRepositoryExportService;
        private readonly IRepositoryImportService<F1ChiefMechanicDataEntity> _f1ChiefMechanicRepositoryImportService;
        private readonly IRepositoryExportService<F1DriverDataEntity> _f1DriverRepositoryExportService;
        private readonly IRepositoryImportService<F1DriverDataEntity> _f1DriverRepositoryImportService;
        private readonly IRepositoryExportService<TeamDataEntity> _teamRepositoryExportService;
        private readonly IRepositoryImportService<TeamDataEntity> _teamRepositoryImportService;

        public IRepository<CarNumberDataEntity> CarNumbers { get; }
        public IRepository<ChassisHandlingDataEntity> ChassisHandlings { get; }
        public IRepository<F1ChiefCommercialDataEntity> F1ChiefCommercials { get; }
        public IRepository<F1ChiefDesignerDataEntity> F1ChiefDesigners { get; }
        public IRepository<F1ChiefEngineerDataEntity> F1ChiefEngineers { get; }
        public IRepository<F1ChiefMechanicDataEntity> F1ChiefMechanics { get; }
        public IRepository<F1DriverDataEntity> F1Drivers { get; }
        public IRepository<TeamDataEntity> Teams { get; }

        public DataService(
            IRepositoryExportService<CarNumberDataEntity> carNumberRepositoryExportService,
            IRepositoryImportService<CarNumberDataEntity> carNumberRepositoryImportService,
            IRepositoryExportService<ChassisHandlingDataEntity> chassisHandlingRepositoryExportService,
            IRepositoryImportService<ChassisHandlingDataEntity> chassisHandlingRepositoryImportService,
            IRepositoryExportService<F1ChiefCommercialDataEntity> f1ChiefCommercialRepositoryExportService,
            IRepositoryImportService<F1ChiefCommercialDataEntity> f1ChiefCommercialRepositoryImportService,
            IRepositoryExportService<F1ChiefDesignerDataEntity> f1ChiefDesignerRepositoryExportService,
            IRepositoryImportService<F1ChiefDesignerDataEntity> f1ChiefDesignerRepositoryImportService,
            IRepositoryExportService<F1ChiefEngineerDataEntity> f1ChiefEngineerRepositoryExportService,
            IRepositoryImportService<F1ChiefEngineerDataEntity> f1ChiefEngineerRepositoryImportService,
            IRepositoryExportService<F1ChiefMechanicDataEntity> f1ChiefMechanicRepositoryExportService,
            IRepositoryImportService<F1ChiefMechanicDataEntity> f1ChiefMechanicRepositoryImportService,
            IRepositoryExportService<F1DriverDataEntity> f1DriverRepositoryExportService,
            IRepositoryImportService<F1DriverDataEntity> f1DriverRepositoryImportService,
            IRepositoryExportService<TeamDataEntity> teamRepositoryExportService,
            IRepositoryImportService<TeamDataEntity> teamRepositoryImportService,
            IRepository<CarNumberDataEntity> carNumberRepository,
            IRepository<ChassisHandlingDataEntity> chassisHandlingRepository,
            IRepository<F1ChiefCommercialDataEntity> f1ChiefCommercialRepository,
            IRepository<F1ChiefDesignerDataEntity> f1ChiefDesignerRepository,
            IRepository<F1ChiefEngineerDataEntity> f1ChiefEngineerRepository,
            IRepository<F1ChiefMechanicDataEntity> f1ChiefMechanicRepository,
            IRepository<F1DriverDataEntity> f1DriverRepository,
            IRepository<TeamDataEntity> teamRepository)
        {
            _carNumberRepositoryExportService = carNumberRepositoryExportService ?? throw new ArgumentNullException(nameof(carNumberRepositoryExportService));
            _carNumberRepositoryImportService = carNumberRepositoryImportService ?? throw new ArgumentNullException(nameof(carNumberRepositoryImportService));
            _chassisHandlingRepositoryExportService = chassisHandlingRepositoryExportService ?? throw new ArgumentNullException(nameof(chassisHandlingRepositoryExportService));
            _chassisHandlingRepositoryImportService = chassisHandlingRepositoryImportService ?? throw new ArgumentNullException(nameof(chassisHandlingRepositoryImportService));
            _f1ChiefCommercialRepositoryExportService = f1ChiefCommercialRepositoryExportService ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepositoryExportService));
            _f1ChiefCommercialRepositoryImportService = f1ChiefCommercialRepositoryImportService ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepositoryImportService));
            _f1ChiefDesignerRepositoryExportService = f1ChiefDesignerRepositoryExportService ?? throw new ArgumentNullException(nameof(f1ChiefDesignerRepositoryExportService));
            _f1ChiefDesignerRepositoryImportService = f1ChiefDesignerRepositoryImportService ?? throw new ArgumentNullException(nameof(f1ChiefDesignerRepositoryImportService));
            _f1ChiefEngineerRepositoryExportService = f1ChiefEngineerRepositoryExportService ?? throw new ArgumentNullException(nameof(f1ChiefEngineerRepositoryExportService));
            _f1ChiefEngineerRepositoryImportService = f1ChiefEngineerRepositoryImportService ?? throw new ArgumentNullException(nameof(f1ChiefEngineerRepositoryImportService));
            _f1ChiefMechanicRepositoryExportService = f1ChiefMechanicRepositoryExportService ?? throw new ArgumentNullException(nameof(f1ChiefMechanicRepositoryExportService));
            _f1ChiefMechanicRepositoryImportService = f1ChiefMechanicRepositoryImportService ?? throw new ArgumentNullException(nameof(f1ChiefMechanicRepositoryImportService));
            _f1DriverRepositoryExportService = f1DriverRepositoryExportService ?? throw new ArgumentNullException(nameof(f1DriverRepositoryExportService));
            _f1DriverRepositoryImportService = f1DriverRepositoryImportService ?? throw new ArgumentNullException(nameof(f1DriverRepositoryImportService));
            _teamRepositoryExportService = teamRepositoryExportService ?? throw new ArgumentNullException(nameof(teamRepositoryExportService));
            _teamRepositoryImportService = teamRepositoryImportService ?? throw new ArgumentNullException(nameof(teamRepositoryImportService));

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
            _carNumberRepositoryExportService.Export();
            _chassisHandlingRepositoryExportService.Export();
            _f1ChiefCommercialRepositoryExportService.Export();
            _f1ChiefDesignerRepositoryExportService.Export();
            _f1ChiefEngineerRepositoryExportService.Export();
            _f1ChiefMechanicRepositoryExportService.Export();
            _f1DriverRepositoryExportService.Export();
            _teamRepositoryExportService.Export();
        }

        public void Import()
        {
            _carNumberRepositoryImportService.Import(22);
            _chassisHandlingRepositoryImportService.Import(11);
            _f1ChiefCommercialRepositoryImportService.Import(11);
            _f1ChiefDesignerRepositoryImportService.Import(11);
            _f1ChiefEngineerRepositoryImportService.Import(11);
            _f1ChiefMechanicRepositoryImportService.Import(11);
            _f1DriverRepositoryImportService.Import(33);
            _teamRepositoryImportService.Import(11);
        }
    }
}