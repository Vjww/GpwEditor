using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataEntities.Lookups;
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
        private readonly IRepositoryExportService<NonF1ChiefCommercialDataEntity> _nonF1ChiefCommercialRepositoryExportService;
        private readonly IRepositoryImportService<NonF1ChiefCommercialDataEntity> _nonF1ChiefCommercialRepositoryImportService;
        private readonly IRepositoryExportService<NonF1ChiefDesignerDataEntity> _nonF1ChiefDesignerRepositoryExportService;
        private readonly IRepositoryImportService<NonF1ChiefDesignerDataEntity> _nonF1ChiefDesignerRepositoryImportService;
        private readonly IRepositoryExportService<NonF1ChiefEngineerDataEntity> _nonF1ChiefEngineerRepositoryExportService;
        private readonly IRepositoryImportService<NonF1ChiefEngineerDataEntity> _nonF1ChiefEngineerRepositoryImportService;
        private readonly IRepositoryExportService<NonF1ChiefMechanicDataEntity> _nonF1ChiefMechanicRepositoryExportService;
        private readonly IRepositoryImportService<NonF1ChiefMechanicDataEntity> _nonF1ChiefMechanicRepositoryImportService;
        private readonly IRepositoryExportService<NonF1DriverDataEntity> _nonF1DriverRepositoryExportService;
        private readonly IRepositoryImportService<NonF1DriverDataEntity> _nonF1DriverRepositoryImportService;
        private readonly IRepositoryExportService<TeamDataEntity> _teamRepositoryExportService;
        private readonly IRepositoryImportService<TeamDataEntity> _teamRepositoryImportService;
        private readonly IRepositoryExportService<EngineDataEntity> _engineRepositoryExportService;
        private readonly IRepositoryImportService<EngineDataEntity> _engineRepositoryImportService;
        private readonly IRepositoryExportService<TyreDataEntity> _tyreRepositoryExportService;
        private readonly IRepositoryImportService<TyreDataEntity> _tyreRepositoryImportService;
        private readonly IRepositoryExportService<FuelDataEntity> _fuelRepositoryExportService;
        private readonly IRepositoryImportService<FuelDataEntity> _fuelRepositoryImportService;
        private readonly IRepositoryExportService<TrackDataEntity> _trackRepositoryExportService;
        private readonly IRepositoryImportService<TrackDataEntity> _trackRepositoryImportService;
        private readonly IRepositoryExportService<PerformanceCurveDataEntity> _performanceCurveRepositoryExportService;
        private readonly IRepositoryImportService<PerformanceCurveDataEntity> _performanceCurveRepositoryImportService;
        private readonly IRepositoryImportService<ChiefDriverLoyaltyLookupDataEntity> _chiefDriverLoyaltyLookupRepositoryImportService;
        private readonly IRepositoryImportService<DriverNationalityLookupDataEntity> _driverNationalityLookupRepositoryImportService;
        private readonly IRepositoryImportService<DriverRoleLookupDataEntity> _driverRoleLookupRepositoryImportService;
        private readonly IRepositoryImportService<TeamDebutGrandPrixLookupDataEntity> _teamDebutGrandPrixLookupRepositoryImportService;
        private readonly IRepositoryImportService<TrackDriverLookupDataEntity> _trackDriverLookupRepositoryImportService;
        private readonly IRepositoryImportService<TrackLayoutLookupDataEntity> _trackLayoutLookupRepositoryImportService;
        private readonly IRepositoryImportService<TrackTeamLookupDataEntity> _trackTeamLookupRepositoryImportService;
        private readonly IRepositoryImportService<TyreSupplierLookupDataEntity> _tyreSupplierLookupRepositoryImportService;

        public IRepository<CarNumberDataEntity> CarNumbers { get; }
        public IRepository<ChassisHandlingDataEntity> ChassisHandlings { get; }
        public IRepository<F1ChiefCommercialDataEntity> F1ChiefCommercials { get; }
        public IRepository<F1ChiefDesignerDataEntity> F1ChiefDesigners { get; }
        public IRepository<F1ChiefEngineerDataEntity> F1ChiefEngineers { get; }
        public IRepository<F1ChiefMechanicDataEntity> F1ChiefMechanics { get; }
        public IRepository<F1DriverDataEntity> F1Drivers { get; }
        public IRepository<NonF1ChiefCommercialDataEntity> NonF1ChiefCommercials { get; }
        public IRepository<NonF1ChiefDesignerDataEntity> NonF1ChiefDesigners { get; }
        public IRepository<NonF1ChiefEngineerDataEntity> NonF1ChiefEngineers { get; }
        public IRepository<NonF1ChiefMechanicDataEntity> NonF1ChiefMechanics { get; }
        public IRepository<NonF1DriverDataEntity> NonF1Drivers { get; }
        public IRepository<TeamDataEntity> Teams { get; }
        public IRepository<EngineDataEntity> Engines { get; }
        public IRepository<TyreDataEntity> Tyres { get; }
        public IRepository<FuelDataEntity> Fuels { get; }
        public IRepository<TrackDataEntity> Tracks { get; }
        public IRepository<PerformanceCurveDataEntity> PerformanceCurveValues { get; }
        public IRepository<ChiefDriverLoyaltyLookupDataEntity> ChiefDriverLoyaltyLookups { get; }
        public IRepository<DriverNationalityLookupDataEntity> DriverNationalityLookups { get; }
        public IRepository<DriverRoleLookupDataEntity> DriverRoleLookups { get; }
        public IRepository<TeamDebutGrandPrixLookupDataEntity> TeamDebutGrandPrixLookups { get; }
        public IRepository<TrackDriverLookupDataEntity> TrackDriverLookups { get; }
        public IRepository<TrackLayoutLookupDataEntity> TrackLayoutLookups { get; }
        public IRepository<TrackTeamLookupDataEntity> TrackTeamLookups { get; }
        public IRepository<TyreSupplierLookupDataEntity> TyreSupplierLookups { get; }

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
            IRepositoryExportService<NonF1ChiefCommercialDataEntity> nonF1ChiefCommercialRepositoryExportService,
            IRepositoryImportService<NonF1ChiefCommercialDataEntity> nonF1ChiefCommercialRepositoryImportService,
            IRepositoryExportService<NonF1ChiefDesignerDataEntity> nonF1ChiefDesignerRepositoryExportService,
            IRepositoryImportService<NonF1ChiefDesignerDataEntity> nonF1ChiefDesignerRepositoryImportService,
            IRepositoryExportService<NonF1ChiefEngineerDataEntity> nonF1ChiefEngineerRepositoryExportService,
            IRepositoryImportService<NonF1ChiefEngineerDataEntity> nonF1ChiefEngineerRepositoryImportService,
            IRepositoryExportService<NonF1ChiefMechanicDataEntity> nonF1ChiefMechanicRepositoryExportService,
            IRepositoryImportService<NonF1ChiefMechanicDataEntity> nonF1ChiefMechanicRepositoryImportService,
            IRepositoryExportService<NonF1DriverDataEntity> nonF1DriverRepositoryExportService,
            IRepositoryImportService<NonF1DriverDataEntity> nonF1DriverRepositoryImportService,
            IRepositoryExportService<TeamDataEntity> teamRepositoryExportService,
            IRepositoryImportService<TeamDataEntity> teamRepositoryImportService,
            IRepositoryExportService<EngineDataEntity> engineRepositoryExportService,
            IRepositoryImportService<EngineDataEntity> engineRepositoryImportService,
            IRepositoryExportService<TyreDataEntity> tyreRepositoryExportService,
            IRepositoryImportService<TyreDataEntity> tyreRepositoryImportService,
            IRepositoryExportService<FuelDataEntity> fuelRepositoryExportService,
            IRepositoryImportService<FuelDataEntity> fuelRepositoryImportService,
            IRepositoryExportService<TrackDataEntity> trackRepositoryExportService,
            IRepositoryImportService<TrackDataEntity> trackRepositoryImportService,
            IRepositoryExportService<PerformanceCurveDataEntity> performanceCurveRepositoryExportService,
            IRepositoryImportService<PerformanceCurveDataEntity> performanceCurveRepositoryImportService,
            IRepositoryImportService<ChiefDriverLoyaltyLookupDataEntity> chiefDriverLoyaltyLookupRepositoryImportService,
            IRepositoryImportService<DriverNationalityLookupDataEntity> driverNationalityLookupRepositoryImportService,
            IRepositoryImportService<DriverRoleLookupDataEntity> driverRoleLookupRepositoryImportService,
            IRepositoryImportService<TeamDebutGrandPrixLookupDataEntity> teamDebutGrandPrixLookupRepositoryImportService,
            IRepositoryImportService<TrackDriverLookupDataEntity> trackDriverLookupRepositoryImportService,
            IRepositoryImportService<TrackLayoutLookupDataEntity> trackLayoutLookupRepositoryImportService,
            IRepositoryImportService<TrackTeamLookupDataEntity> trackTeamLookupRepositoryImportService,
            IRepositoryImportService<TyreSupplierLookupDataEntity> tyreSupplierLookupRepositoryImportService,
            IRepository<CarNumberDataEntity> carNumberRepository,
            IRepository<ChassisHandlingDataEntity> chassisHandlingRepository,
            IRepository<F1ChiefCommercialDataEntity> f1ChiefCommercialRepository,
            IRepository<F1ChiefDesignerDataEntity> f1ChiefDesignerRepository,
            IRepository<F1ChiefEngineerDataEntity> f1ChiefEngineerRepository,
            IRepository<F1ChiefMechanicDataEntity> f1ChiefMechanicRepository,
            IRepository<F1DriverDataEntity> f1DriverRepository,
            IRepository<NonF1ChiefCommercialDataEntity> nonF1ChiefCommercialRepository,
            IRepository<NonF1ChiefDesignerDataEntity> nonF1ChiefDesignerRepository,
            IRepository<NonF1ChiefEngineerDataEntity> nonF1ChiefEngineerRepository,
            IRepository<NonF1ChiefMechanicDataEntity> nonF1ChiefMechanicRepository,
            IRepository<NonF1DriverDataEntity> nonF1DriverRepository,
            IRepository<TeamDataEntity> teamRepository,
            IRepository<EngineDataEntity> engineRepository,
            IRepository<TyreDataEntity> tyreRepository,
            IRepository<FuelDataEntity> fuelRepository,
            IRepository<TrackDataEntity> trackRepository,
            IRepository<PerformanceCurveDataEntity> performanceCurveRepository,
            IRepository<ChiefDriverLoyaltyLookupDataEntity> chiefDriverLoyaltyLookupRepository,
            IRepository<DriverNationalityLookupDataEntity> driverNationalityLookupRepository,
            IRepository<DriverRoleLookupDataEntity> driverRoleLookupRepository,
            IRepository<TeamDebutGrandPrixLookupDataEntity> teamDebutGrandPrixLookupRepository,
            IRepository<TrackDriverLookupDataEntity> trackDriverLookupRepository,
            IRepository<TrackLayoutLookupDataEntity> trackLayoutLookupRepository,
            IRepository<TrackTeamLookupDataEntity> trackTeamLookupRepository,
            IRepository<TyreSupplierLookupDataEntity> tyreSupplierLookupRepository)
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
            _nonF1ChiefCommercialRepositoryExportService = nonF1ChiefCommercialRepositoryExportService ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialRepositoryExportService));
            _nonF1ChiefCommercialRepositoryImportService = nonF1ChiefCommercialRepositoryImportService ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialRepositoryImportService));
            _nonF1ChiefDesignerRepositoryExportService = nonF1ChiefDesignerRepositoryExportService ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerRepositoryExportService));
            _nonF1ChiefDesignerRepositoryImportService = nonF1ChiefDesignerRepositoryImportService ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerRepositoryImportService));
            _nonF1ChiefEngineerRepositoryExportService = nonF1ChiefEngineerRepositoryExportService ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerRepositoryExportService));
            _nonF1ChiefEngineerRepositoryImportService = nonF1ChiefEngineerRepositoryImportService ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerRepositoryImportService));
            _nonF1ChiefMechanicRepositoryExportService = nonF1ChiefMechanicRepositoryExportService ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicRepositoryExportService));
            _nonF1ChiefMechanicRepositoryImportService = nonF1ChiefMechanicRepositoryImportService ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicRepositoryImportService));
            _nonF1DriverRepositoryExportService = nonF1DriverRepositoryExportService ?? throw new ArgumentNullException(nameof(nonF1DriverRepositoryExportService));
            _nonF1DriverRepositoryImportService = nonF1DriverRepositoryImportService ?? throw new ArgumentNullException(nameof(nonF1DriverRepositoryImportService));
            _teamRepositoryExportService = teamRepositoryExportService ?? throw new ArgumentNullException(nameof(teamRepositoryExportService));
            _teamRepositoryImportService = teamRepositoryImportService ?? throw new ArgumentNullException(nameof(teamRepositoryImportService));
            _engineRepositoryExportService = engineRepositoryExportService ?? throw new ArgumentNullException(nameof(engineRepositoryExportService));
            _engineRepositoryImportService = engineRepositoryImportService ?? throw new ArgumentNullException(nameof(engineRepositoryImportService));
            _tyreRepositoryExportService = tyreRepositoryExportService ?? throw new ArgumentNullException(nameof(tyreRepositoryExportService));
            _tyreRepositoryImportService = tyreRepositoryImportService ?? throw new ArgumentNullException(nameof(tyreRepositoryImportService));
            _fuelRepositoryExportService = fuelRepositoryExportService ?? throw new ArgumentNullException(nameof(fuelRepositoryExportService));
            _fuelRepositoryImportService = fuelRepositoryImportService ?? throw new ArgumentNullException(nameof(fuelRepositoryImportService));
            _trackRepositoryExportService = trackRepositoryExportService ?? throw new ArgumentNullException(nameof(trackRepositoryExportService));
            _trackRepositoryImportService = trackRepositoryImportService ?? throw new ArgumentNullException(nameof(trackRepositoryImportService));
            _performanceCurveRepositoryExportService = performanceCurveRepositoryExportService ?? throw new ArgumentNullException(nameof(performanceCurveRepositoryExportService));
            _performanceCurveRepositoryImportService = performanceCurveRepositoryImportService ?? throw new ArgumentNullException(nameof(performanceCurveRepositoryImportService));
            _chiefDriverLoyaltyLookupRepositoryImportService = chiefDriverLoyaltyLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupRepositoryImportService));
            _driverNationalityLookupRepositoryImportService = driverNationalityLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(driverNationalityLookupRepositoryImportService));
            _driverRoleLookupRepositoryImportService = driverRoleLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(driverRoleLookupRepositoryImportService));
            _teamDebutGrandPrixLookupRepositoryImportService = teamDebutGrandPrixLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupRepositoryImportService));
            _trackDriverLookupRepositoryImportService = trackDriverLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(trackDriverLookupRepositoryImportService));
            _trackLayoutLookupRepositoryImportService = trackLayoutLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(trackLayoutLookupRepositoryImportService));
            _trackTeamLookupRepositoryImportService = trackTeamLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(trackTeamLookupRepositoryImportService));
            _tyreSupplierLookupRepositoryImportService = tyreSupplierLookupRepositoryImportService ?? throw new ArgumentNullException(nameof(tyreSupplierLookupRepositoryImportService));

            CarNumbers = carNumberRepository ?? throw new ArgumentNullException(nameof(carNumberRepository));
            ChassisHandlings = chassisHandlingRepository ?? throw new ArgumentNullException(nameof(chassisHandlingRepository));
            F1ChiefCommercials = f1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(f1ChiefCommercialRepository));
            F1ChiefDesigners = f1ChiefDesignerRepository ?? throw new ArgumentNullException(nameof(f1ChiefDesignerRepository));
            F1ChiefEngineers = f1ChiefEngineerRepository ?? throw new ArgumentNullException(nameof(f1ChiefEngineerRepository));
            F1ChiefMechanics = f1ChiefMechanicRepository ?? throw new ArgumentNullException(nameof(f1ChiefMechanicRepository));
            F1Drivers = f1DriverRepository ?? throw new ArgumentNullException(nameof(f1DriverRepository));
            NonF1ChiefCommercials = nonF1ChiefCommercialRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialRepository));
            NonF1ChiefDesigners = nonF1ChiefDesignerRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerRepository));
            NonF1ChiefEngineers = nonF1ChiefEngineerRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerRepository));
            NonF1ChiefMechanics = nonF1ChiefMechanicRepository ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicRepository));
            NonF1Drivers = nonF1DriverRepository ?? throw new ArgumentNullException(nameof(nonF1DriverRepository));
            Teams = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            Engines = engineRepository ?? throw new ArgumentNullException(nameof(engineRepository));
            Tyres = tyreRepository ?? throw new ArgumentNullException(nameof(tyreRepository));
            Fuels = fuelRepository ?? throw new ArgumentNullException(nameof(fuelRepository));
            Tracks = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
            PerformanceCurveValues = performanceCurveRepository ?? throw new ArgumentNullException(nameof(performanceCurveRepository));
            ChiefDriverLoyaltyLookups = chiefDriverLoyaltyLookupRepository ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupRepository));
            DriverNationalityLookups = driverNationalityLookupRepository ?? throw new ArgumentNullException(nameof(driverNationalityLookupRepository));
            DriverRoleLookups = driverRoleLookupRepository ?? throw new ArgumentNullException(nameof(driverRoleLookupRepository));
            TeamDebutGrandPrixLookups = teamDebutGrandPrixLookupRepository ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupRepository));
            TrackDriverLookups = trackDriverLookupRepository ?? throw new ArgumentNullException(nameof(trackDriverLookupRepository));
            TrackLayoutLookups = trackLayoutLookupRepository ?? throw new ArgumentNullException(nameof(trackLayoutLookupRepository));
            TrackTeamLookups = trackTeamLookupRepository ?? throw new ArgumentNullException(nameof(trackTeamLookupRepository));
            TyreSupplierLookups = tyreSupplierLookupRepository ?? throw new ArgumentNullException(nameof(tyreSupplierLookupRepository));
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
            _nonF1ChiefCommercialRepositoryExportService.Export();
            _nonF1ChiefDesignerRepositoryExportService.Export();
            _nonF1ChiefEngineerRepositoryExportService.Export();
            _nonF1ChiefMechanicRepositoryExportService.Export();
            _nonF1DriverRepositoryExportService.Export();
            _teamRepositoryExportService.Export();
            _engineRepositoryExportService.Export();
            _tyreRepositoryExportService.Export();
            _fuelRepositoryExportService.Export();
            _trackRepositoryExportService.Export();
            _performanceCurveRepositoryExportService.Export();
        }

        public void Import()
        {
            _chiefDriverLoyaltyLookupRepositoryImportService.Import(45);
            _driverNationalityLookupRepositoryImportService.Import(14);
            _driverRoleLookupRepositoryImportService.Import(4);
            _teamDebutGrandPrixLookupRepositoryImportService.Import(19);
            _trackDriverLookupRepositoryImportService.Import(48);
            _trackLayoutLookupRepositoryImportService.Import(3);
            _trackTeamLookupRepositoryImportService.Import(11);
            _tyreSupplierLookupRepositoryImportService.Import(3);

            _carNumberRepositoryImportService.Import(22);
            _chassisHandlingRepositoryImportService.Import(11);
            _f1ChiefCommercialRepositoryImportService.Import(11);
            _f1ChiefDesignerRepositoryImportService.Import(11);
            _f1ChiefEngineerRepositoryImportService.Import(11);
            _f1ChiefMechanicRepositoryImportService.Import(11);
            _f1DriverRepositoryImportService.Import(33);
            _nonF1ChiefCommercialRepositoryImportService.Import(10);
            _nonF1ChiefDesignerRepositoryImportService.Import(10);
            _nonF1ChiefEngineerRepositoryImportService.Import(10);
            _nonF1ChiefMechanicRepositoryImportService.Import(10);
            _nonF1DriverRepositoryImportService.Import(11);
            _teamRepositoryImportService.Import(11);
            _engineRepositoryImportService.Import(8);
            _tyreRepositoryImportService.Import(3);
            _fuelRepositoryImportService.Import(9);
            _trackRepositoryImportService.Import(16);
            _performanceCurveRepositoryImportService.Import(120);
        }
    }
}