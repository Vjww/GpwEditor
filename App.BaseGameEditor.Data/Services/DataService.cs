using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.Core.Repositories;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.Services
{
    public class DataService
    {
        private readonly IRepositoryExportService<CarNumberDataEntity> _carNumberRepositoryExportService;
        private readonly IRepositoryImportService<CarNumberDataEntity> _carNumberRepositoryImportService;
        private readonly IRepositoryExportService<CommentaryIndexDriverDataEntity> _commentaryIndexDriverRepositoryExportService;
        private readonly IRepositoryImportService<CommentaryIndexDriverDataEntity> _commentaryIndexDriverRepositoryImportService;
        private readonly IRepositoryExportService<CommentaryIndexTeamDataEntity> _commentaryIndexTeamRepositoryExportService;
        private readonly IRepositoryImportService<CommentaryIndexTeamDataEntity> _commentaryIndexTeamRepositoryImportService;
        private readonly IRepositoryExportService<CommentaryPrefixDriverDataEntity> _commentaryPrefixDriverRepositoryExportService;
        private readonly IRepositoryImportService<CommentaryPrefixDriverDataEntity> _commentaryPrefixDriverRepositoryImportService;
        private readonly IRepositoryExportService<CommentaryPrefixTeamDataEntity> _commentaryPrefixTeamRepositoryExportService;
        private readonly IRepositoryImportService<CommentaryPrefixTeamDataEntity> _commentaryPrefixTeamRepositoryImportService;
        private readonly IRepositoryExportService<CommentaryDriverDataEntity> _commentaryDriverRepositoryExportService;
        private readonly IRepositoryImportService<CommentaryDriverDataEntity> _commentaryDriverRepositoryImportService;
        private readonly IRepositoryExportService<CommentaryTeamDataEntity> _commentaryTeamRepositoryExportService;
        private readonly IRepositoryImportService<CommentaryTeamDataEntity> _commentaryTeamRepositoryImportService;
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
        private readonly IRepositoryExportService<SponsorshipTeamDataEntity> _sponsorshipTeamRepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipTeamDataEntity> _sponsorshipTeamRepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipEngineDataEntity> _sponsorshipEngineRepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipEngineDataEntity> _sponsorshipEngineRepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipTyreDataEntity> _sponsorshipTyreRepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipTyreDataEntity> _sponsorshipTyreRepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipFuelDataEntity> _sponsorshipFuelRepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipFuelDataEntity> _sponsorshipFuelRepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipCashDataEntity> _sponsorshipCashRepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipCashDataEntity> _sponsorshipCashRepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam01DataEntity> _sponsorshipContractTeam01RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam01DataEntity> _sponsorshipContractTeam01RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam02DataEntity> _sponsorshipContractTeam02RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam02DataEntity> _sponsorshipContractTeam02RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam03DataEntity> _sponsorshipContractTeam03RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam03DataEntity> _sponsorshipContractTeam03RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam04DataEntity> _sponsorshipContractTeam04RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam04DataEntity> _sponsorshipContractTeam04RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam05DataEntity> _sponsorshipContractTeam05RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam05DataEntity> _sponsorshipContractTeam05RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam06DataEntity> _sponsorshipContractTeam06RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam06DataEntity> _sponsorshipContractTeam06RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam07DataEntity> _sponsorshipContractTeam07RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam07DataEntity> _sponsorshipContractTeam07RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam08DataEntity> _sponsorshipContractTeam08RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam08DataEntity> _sponsorshipContractTeam08RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam09DataEntity> _sponsorshipContractTeam09RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam09DataEntity> _sponsorshipContractTeam09RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam10DataEntity> _sponsorshipContractTeam10RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam10DataEntity> _sponsorshipContractTeam10RepositoryImportService;
        private readonly IRepositoryExportService<SponsorshipContractTeam11DataEntity> _sponsorshipContractTeam11RepositoryExportService;
        private readonly IRepositoryImportService<SponsorshipContractTeam11DataEntity> _sponsorshipContractTeam11RepositoryImportService;
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

        public IRepository<CommentaryIndexDriverDataEntity> CommentaryIndexDrivers { get; }
        public IRepository<CommentaryIndexTeamDataEntity> CommentaryIndexTeams { get; }
        public IRepository<CommentaryPrefixDriverDataEntity> CommentaryPrefixDrivers { get; }
        public IRepository<CommentaryPrefixTeamDataEntity> CommentaryPrefixTeams { get; }
        public IRepository<CommentaryDriverDataEntity> CommentaryDrivers { get; }
        public IRepository<CommentaryTeamDataEntity> CommentaryTeams { get; }
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
        public IRepository<SponsorshipTeamDataEntity> SponsorshipTeams { get; }
        public IRepository<SponsorshipEngineDataEntity> SponsorshipEngines { get; }
        public IRepository<SponsorshipTyreDataEntity> SponsorshipTyres { get; }
        public IRepository<SponsorshipFuelDataEntity> SponsorshipFuels { get; }
        public IRepository<SponsorshipCashDataEntity> SponsorshipCashs { get; }
        public IRepository<SponsorshipContractTeam01DataEntity> SponsorshipContractsTeam01 { get; }
        public IRepository<SponsorshipContractTeam02DataEntity> SponsorshipContractsTeam02 { get; }
        public IRepository<SponsorshipContractTeam03DataEntity> SponsorshipContractsTeam03 { get; }
        public IRepository<SponsorshipContractTeam04DataEntity> SponsorshipContractsTeam04 { get; }
        public IRepository<SponsorshipContractTeam05DataEntity> SponsorshipContractsTeam05 { get; }
        public IRepository<SponsorshipContractTeam06DataEntity> SponsorshipContractsTeam06 { get; }
        public IRepository<SponsorshipContractTeam07DataEntity> SponsorshipContractsTeam07 { get; }
        public IRepository<SponsorshipContractTeam08DataEntity> SponsorshipContractsTeam08 { get; }
        public IRepository<SponsorshipContractTeam09DataEntity> SponsorshipContractsTeam09 { get; }
        public IRepository<SponsorshipContractTeam10DataEntity> SponsorshipContractsTeam10 { get; }
        public IRepository<SponsorshipContractTeam11DataEntity> SponsorshipContractsTeam11 { get; }
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
            IRepositoryExportService<CommentaryIndexDriverDataEntity> commentaryIndexDriverRepositoryExportService,
            IRepositoryImportService<CommentaryIndexDriverDataEntity> commentaryIndexDriverRepositoryImportService,
            IRepositoryExportService<CommentaryIndexTeamDataEntity> commentaryIndexTeamRepositoryExportService,
            IRepositoryImportService<CommentaryIndexTeamDataEntity> commentaryIndexTeamRepositoryImportService,
            IRepositoryExportService<CommentaryPrefixDriverDataEntity> commentaryPrefixDriverRepositoryExportService,
            IRepositoryImportService<CommentaryPrefixDriverDataEntity> commentaryPrefixDriverRepositoryImportService,
            IRepositoryExportService<CommentaryPrefixTeamDataEntity> commentaryPrefixTeamRepositoryExportService,
            IRepositoryImportService<CommentaryPrefixTeamDataEntity> commentaryPrefixTeamRepositoryImportService,
            IRepositoryExportService<CommentaryDriverDataEntity> commentaryDriverRepositoryExportService,
            IRepositoryImportService<CommentaryDriverDataEntity> commentaryDriverRepositoryImportService,
            IRepositoryExportService<CommentaryTeamDataEntity> commentaryTeamRepositoryExportService,
            IRepositoryImportService<CommentaryTeamDataEntity> commentaryTeamRepositoryImportService,
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
            IRepositoryExportService<SponsorshipTeamDataEntity> sponsorshipTeamRepositoryExportService,
            IRepositoryImportService<SponsorshipTeamDataEntity> sponsorshipTeamRepositoryImportService,
            IRepositoryExportService<SponsorshipEngineDataEntity> sponsorshipEngineRepositoryExportService,
            IRepositoryImportService<SponsorshipEngineDataEntity> sponsorshipEngineRepositoryImportService,
            IRepositoryExportService<SponsorshipTyreDataEntity> sponsorshipTyreRepositoryExportService,
            IRepositoryImportService<SponsorshipTyreDataEntity> sponsorshipTyreRepositoryImportService,
            IRepositoryExportService<SponsorshipFuelDataEntity> sponsorshipFuelRepositoryExportService,
            IRepositoryImportService<SponsorshipFuelDataEntity> sponsorshipFuelRepositoryImportService,
            IRepositoryExportService<SponsorshipCashDataEntity> sponsorshipCashRepositoryExportService,
            IRepositoryImportService<SponsorshipCashDataEntity> sponsorshipCashRepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam01DataEntity> sponsorshipContractTeam01RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam01DataEntity> sponsorshipContractTeam01RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam02DataEntity> sponsorshipContractTeam02RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam02DataEntity> sponsorshipContractTeam02RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam03DataEntity> sponsorshipContractTeam03RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam03DataEntity> sponsorshipContractTeam03RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam04DataEntity> sponsorshipContractTeam04RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam04DataEntity> sponsorshipContractTeam04RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam05DataEntity> sponsorshipContractTeam05RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam05DataEntity> sponsorshipContractTeam05RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam06DataEntity> sponsorshipContractTeam06RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam06DataEntity> sponsorshipContractTeam06RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam07DataEntity> sponsorshipContractTeam07RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam07DataEntity> sponsorshipContractTeam07RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam08DataEntity> sponsorshipContractTeam08RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam08DataEntity> sponsorshipContractTeam08RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam09DataEntity> sponsorshipContractTeam09RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam09DataEntity> sponsorshipContractTeam09RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam10DataEntity> sponsorshipContractTeam10RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam10DataEntity> sponsorshipContractTeam10RepositoryImportService,
            IRepositoryExportService<SponsorshipContractTeam11DataEntity> sponsorshipContractTeam11RepositoryExportService,
            IRepositoryImportService<SponsorshipContractTeam11DataEntity> sponsorshipContractTeam11RepositoryImportService,
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
            IRepository<CommentaryIndexDriverDataEntity> commentaryIndexDriverRepository,
            IRepository<CommentaryIndexTeamDataEntity> commentaryIndexTeamRepository,
            IRepository<CommentaryPrefixDriverDataEntity> commentaryPrefixDriverRepository,
            IRepository<CommentaryPrefixTeamDataEntity> commentaryPrefixTeamRepository,
            IRepository<CommentaryDriverDataEntity> commentaryDriverRepository,
            IRepository<CommentaryTeamDataEntity> commentaryTeamRepository,
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
            IRepository<SponsorshipTeamDataEntity> sponsorshipTeamRepository,
            IRepository<SponsorshipEngineDataEntity> sponsorshipEngineRepository,
            IRepository<SponsorshipTyreDataEntity> sponsorshipTyreRepository,
            IRepository<SponsorshipFuelDataEntity> sponsorshipFuelRepository,
            IRepository<SponsorshipCashDataEntity> sponsorshipCashRepository,
            IRepository<SponsorshipContractTeam01DataEntity> sponsorshipContractTeam01Repository,
            IRepository<SponsorshipContractTeam02DataEntity> sponsorshipContractTeam02Repository,
            IRepository<SponsorshipContractTeam03DataEntity> sponsorshipContractTeam03Repository,
            IRepository<SponsorshipContractTeam04DataEntity> sponsorshipContractTeam04Repository,
            IRepository<SponsorshipContractTeam05DataEntity> sponsorshipContractTeam05Repository,
            IRepository<SponsorshipContractTeam06DataEntity> sponsorshipContractTeam06Repository,
            IRepository<SponsorshipContractTeam07DataEntity> sponsorshipContractTeam07Repository,
            IRepository<SponsorshipContractTeam08DataEntity> sponsorshipContractTeam08Repository,
            IRepository<SponsorshipContractTeam09DataEntity> sponsorshipContractTeam09Repository,
            IRepository<SponsorshipContractTeam10DataEntity> sponsorshipContractTeam10Repository,
            IRepository<SponsorshipContractTeam11DataEntity> sponsorshipContractTeam11Repository,
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
            _commentaryIndexDriverRepositoryExportService = commentaryIndexDriverRepositoryExportService ?? throw new ArgumentNullException(nameof(commentaryIndexDriverRepositoryExportService));
            _commentaryIndexDriverRepositoryImportService = commentaryIndexDriverRepositoryImportService ?? throw new ArgumentNullException(nameof(commentaryIndexDriverRepositoryImportService));
            _commentaryIndexTeamRepositoryExportService = commentaryIndexTeamRepositoryExportService ?? throw new ArgumentNullException(nameof(commentaryIndexTeamRepositoryExportService));
            _commentaryIndexTeamRepositoryImportService = commentaryIndexTeamRepositoryImportService ?? throw new ArgumentNullException(nameof(commentaryIndexTeamRepositoryImportService));
            _commentaryPrefixDriverRepositoryExportService = commentaryPrefixDriverRepositoryExportService ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverRepositoryExportService));
            _commentaryPrefixDriverRepositoryImportService = commentaryPrefixDriverRepositoryImportService ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverRepositoryImportService));
            _commentaryPrefixTeamRepositoryExportService = commentaryPrefixTeamRepositoryExportService ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamRepositoryExportService));
            _commentaryPrefixTeamRepositoryImportService = commentaryPrefixTeamRepositoryImportService ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamRepositoryImportService));
            _commentaryDriverRepositoryExportService = commentaryDriverRepositoryExportService ?? throw new ArgumentNullException(nameof(commentaryDriverRepositoryExportService));
            _commentaryDriverRepositoryImportService = commentaryDriverRepositoryImportService ?? throw new ArgumentNullException(nameof(commentaryDriverRepositoryImportService));
            _commentaryTeamRepositoryExportService = commentaryTeamRepositoryExportService ?? throw new ArgumentNullException(nameof(commentaryTeamRepositoryExportService));
            _commentaryTeamRepositoryImportService = commentaryTeamRepositoryImportService ?? throw new ArgumentNullException(nameof(commentaryTeamRepositoryImportService));
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
            _sponsorshipTeamRepositoryExportService = sponsorshipTeamRepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipTeamRepositoryExportService));
            _sponsorshipTeamRepositoryImportService = sponsorshipTeamRepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipTeamRepositoryImportService));
            _sponsorshipEngineRepositoryExportService = sponsorshipEngineRepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipEngineRepositoryExportService));
            _sponsorshipEngineRepositoryImportService = sponsorshipEngineRepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipEngineRepositoryImportService));
            _sponsorshipTyreRepositoryExportService = sponsorshipTyreRepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipTyreRepositoryExportService));
            _sponsorshipTyreRepositoryImportService = sponsorshipTyreRepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipTyreRepositoryImportService));
            _sponsorshipFuelRepositoryExportService = sponsorshipFuelRepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipFuelRepositoryExportService));
            _sponsorshipFuelRepositoryImportService = sponsorshipFuelRepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipFuelRepositoryImportService));
            _sponsorshipCashRepositoryExportService = sponsorshipCashRepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipCashRepositoryExportService));
            _sponsorshipCashRepositoryImportService = sponsorshipCashRepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipCashRepositoryImportService));
            _sponsorshipContractTeam01RepositoryExportService = sponsorshipContractTeam01RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01RepositoryExportService));
            _sponsorshipContractTeam01RepositoryImportService = sponsorshipContractTeam01RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01RepositoryImportService));
            _sponsorshipContractTeam02RepositoryExportService = sponsorshipContractTeam02RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02RepositoryExportService));
            _sponsorshipContractTeam02RepositoryImportService = sponsorshipContractTeam02RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02RepositoryImportService));
            _sponsorshipContractTeam03RepositoryExportService = sponsorshipContractTeam03RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03RepositoryExportService));
            _sponsorshipContractTeam03RepositoryImportService = sponsorshipContractTeam03RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03RepositoryImportService));
            _sponsorshipContractTeam04RepositoryExportService = sponsorshipContractTeam04RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04RepositoryExportService));
            _sponsorshipContractTeam04RepositoryImportService = sponsorshipContractTeam04RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04RepositoryImportService));
            _sponsorshipContractTeam05RepositoryExportService = sponsorshipContractTeam05RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05RepositoryExportService));
            _sponsorshipContractTeam05RepositoryImportService = sponsorshipContractTeam05RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05RepositoryImportService));
            _sponsorshipContractTeam06RepositoryExportService = sponsorshipContractTeam06RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06RepositoryExportService));
            _sponsorshipContractTeam06RepositoryImportService = sponsorshipContractTeam06RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06RepositoryImportService));
            _sponsorshipContractTeam07RepositoryExportService = sponsorshipContractTeam07RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07RepositoryExportService));
            _sponsorshipContractTeam07RepositoryImportService = sponsorshipContractTeam07RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07RepositoryImportService));
            _sponsorshipContractTeam08RepositoryExportService = sponsorshipContractTeam08RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08RepositoryExportService));
            _sponsorshipContractTeam08RepositoryImportService = sponsorshipContractTeam08RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08RepositoryImportService));
            _sponsorshipContractTeam09RepositoryExportService = sponsorshipContractTeam09RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09RepositoryExportService));
            _sponsorshipContractTeam09RepositoryImportService = sponsorshipContractTeam09RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09RepositoryImportService));
            _sponsorshipContractTeam10RepositoryExportService = sponsorshipContractTeam10RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10RepositoryExportService));
            _sponsorshipContractTeam10RepositoryImportService = sponsorshipContractTeam10RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10RepositoryImportService));
            _sponsorshipContractTeam11RepositoryExportService = sponsorshipContractTeam11RepositoryExportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11RepositoryExportService));
            _sponsorshipContractTeam11RepositoryImportService = sponsorshipContractTeam11RepositoryImportService ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11RepositoryImportService));
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

            CommentaryIndexDrivers = commentaryIndexDriverRepository ?? throw new ArgumentNullException(nameof(commentaryIndexDriverRepository));
            CommentaryIndexTeams = commentaryIndexTeamRepository ?? throw new ArgumentNullException(nameof(commentaryIndexTeamRepository));
            CommentaryPrefixDrivers = commentaryPrefixDriverRepository ?? throw new ArgumentNullException(nameof(commentaryPrefixDriverRepository));
            CommentaryPrefixTeams = commentaryPrefixTeamRepository ?? throw new ArgumentNullException(nameof(commentaryPrefixTeamRepository));
            CommentaryDrivers = commentaryDriverRepository ?? throw new ArgumentNullException(nameof(commentaryDriverRepository));
            CommentaryTeams = commentaryTeamRepository ?? throw new ArgumentNullException(nameof(commentaryTeamRepository));
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
            SponsorshipTeams = sponsorshipTeamRepository ?? throw new ArgumentNullException(nameof(sponsorshipTeamRepository));
            SponsorshipEngines = sponsorshipEngineRepository ?? throw new ArgumentNullException(nameof(sponsorshipEngineRepository));
            SponsorshipTyres = sponsorshipTyreRepository ?? throw new ArgumentNullException(nameof(sponsorshipTyreRepository));
            SponsorshipFuels = sponsorshipFuelRepository ?? throw new ArgumentNullException(nameof(sponsorshipFuelRepository));
            SponsorshipCashs = sponsorshipCashRepository ?? throw new ArgumentNullException(nameof(sponsorshipCashRepository));
            SponsorshipContractsTeam01 = sponsorshipContractTeam01Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01Repository));
            SponsorshipContractsTeam02 = sponsorshipContractTeam02Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02Repository));
            SponsorshipContractsTeam03 = sponsorshipContractTeam03Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03Repository));
            SponsorshipContractsTeam04 = sponsorshipContractTeam04Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04Repository));
            SponsorshipContractsTeam05 = sponsorshipContractTeam05Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05Repository));
            SponsorshipContractsTeam06 = sponsorshipContractTeam06Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06Repository));
            SponsorshipContractsTeam07 = sponsorshipContractTeam07Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07Repository));
            SponsorshipContractsTeam08 = sponsorshipContractTeam08Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08Repository));
            SponsorshipContractsTeam09 = sponsorshipContractTeam09Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09Repository));
            SponsorshipContractsTeam10 = sponsorshipContractTeam10Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10Repository));
            SponsorshipContractsTeam11 = sponsorshipContractTeam11Repository ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11Repository));
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
            _commentaryIndexDriverRepositoryExportService.Export();
            _commentaryIndexTeamRepositoryExportService.Export();
            _commentaryPrefixDriverRepositoryExportService.Export();
            _commentaryPrefixTeamRepositoryExportService.Export();
            _commentaryDriverRepositoryExportService.Export();
            _commentaryTeamRepositoryExportService.Export();
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
            _sponsorshipTeamRepositoryExportService.Export();
            _sponsorshipEngineRepositoryExportService.Export();
            _sponsorshipTyreRepositoryExportService.Export();
            _sponsorshipFuelRepositoryExportService.Export();
            _sponsorshipCashRepositoryExportService.Export();
            _sponsorshipContractTeam01RepositoryExportService.Export();
            _sponsorshipContractTeam02RepositoryExportService.Export();
            _sponsorshipContractTeam03RepositoryExportService.Export();
            _sponsorshipContractTeam04RepositoryExportService.Export();
            _sponsorshipContractTeam05RepositoryExportService.Export();
            _sponsorshipContractTeam06RepositoryExportService.Export();
            _sponsorshipContractTeam07RepositoryExportService.Export();
            _sponsorshipContractTeam08RepositoryExportService.Export();
            _sponsorshipContractTeam09RepositoryExportService.Export();
            _sponsorshipContractTeam10RepositoryExportService.Export();
            _sponsorshipContractTeam11RepositoryExportService.Export();
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

            _commentaryIndexDriverRepositoryImportService.Import(44);
            _commentaryIndexTeamRepositoryImportService.Import(11);
            _commentaryPrefixDriverRepositoryImportService.Import(41);
            _commentaryPrefixTeamRepositoryImportService.Import(11);
            _commentaryDriverRepositoryImportService.Import(205);
            _commentaryTeamRepositoryImportService.Import(11);
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
            _sponsorshipTeamRepositoryImportService.Import(7);
            _sponsorshipEngineRepositoryImportService.Import(8);
            _sponsorshipTyreRepositoryImportService.Import(3);
            _sponsorshipFuelRepositoryImportService.Import(9);
            _sponsorshipCashRepositoryImportService.Import(71);
            _sponsorshipContractTeam01RepositoryImportService.Import(10);
            _sponsorshipContractTeam02RepositoryImportService.Import(10);
            _sponsorshipContractTeam03RepositoryImportService.Import(10);
            _sponsorshipContractTeam04RepositoryImportService.Import(10);
            _sponsorshipContractTeam05RepositoryImportService.Import(10);
            _sponsorshipContractTeam06RepositoryImportService.Import(10);
            _sponsorshipContractTeam07RepositoryImportService.Import(10);
            _sponsorshipContractTeam08RepositoryImportService.Import(10);
            _sponsorshipContractTeam09RepositoryImportService.Import(10);
            _sponsorshipContractTeam10RepositoryImportService.Import(10);
            _sponsorshipContractTeam11RepositoryImportService.Import(10);
            _trackRepositoryImportService.Import(16);
            _performanceCurveRepositoryImportService.Import(120);
        }
    }
}