using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipTyreDataEntityExportService : IDataEntityExportService<SponsorshipTyreDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipTyreDataLocator> _dataLocatorFactory;

        public SponsorshipTyreDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipTyreDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorshipTyreDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is SponsorshipTyreDataEntity sponsorshipTyreDataEntity)) throw new ArgumentNullException(nameof(sponsorshipTyreDataEntity));

            var dataLocator = _dataLocatorFactory.Create(sponsorshipTyreDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = sponsorshipTyreDataEntity.Name.English;
            frenchCatalogueItem.Value = sponsorshipTyreDataEntity.Name.French;
            germanCatalogueItem.Value = sponsorshipTyreDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardGripSupplier, sponsorshipTyreDataEntity.DryHardGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardResilienceSupplier, sponsorshipTyreDataEntity.DryHardResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardStiffnessSupplier, sponsorshipTyreDataEntity.DryHardStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardTemperatureSupplier, sponsorshipTyreDataEntity.DryHardTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftGripSupplier, sponsorshipTyreDataEntity.DrySoftGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftResilienceSupplier, sponsorshipTyreDataEntity.DrySoftResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftStiffnessSupplier, sponsorshipTyreDataEntity.DrySoftStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftTemperatureSupplier, sponsorshipTyreDataEntity.DrySoftTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateGripSupplier, sponsorshipTyreDataEntity.IntermediateGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateResilienceSupplier, sponsorshipTyreDataEntity.IntermediateResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateStiffnessSupplier, sponsorshipTyreDataEntity.IntermediateStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateTemperatureSupplier, sponsorshipTyreDataEntity.IntermediateTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherGripSupplier, sponsorshipTyreDataEntity.WetWeatherGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherResilienceSupplier, sponsorshipTyreDataEntity.WetWeatherResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherStiffnessSupplier, sponsorshipTyreDataEntity.WetWeatherStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherTemperatureSupplier, sponsorshipTyreDataEntity.WetWeatherTemperature);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardGripTeam, sponsorshipTyreDataEntity.DryHardGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardResilienceTeam, sponsorshipTyreDataEntity.DryHardResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardStiffnessTeam, sponsorshipTyreDataEntity.DryHardStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardTemperatureTeam, sponsorshipTyreDataEntity.DryHardTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftGripTeam, sponsorshipTyreDataEntity.DrySoftGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftResilienceTeam, sponsorshipTyreDataEntity.DrySoftResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftStiffnessTeam, sponsorshipTyreDataEntity.DrySoftStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftTemperatureTeam, sponsorshipTyreDataEntity.DrySoftTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateGripTeam, sponsorshipTyreDataEntity.IntermediateGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateResilienceTeam, sponsorshipTyreDataEntity.IntermediateResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateStiffnessTeam, sponsorshipTyreDataEntity.IntermediateStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateTemperatureTeam, sponsorshipTyreDataEntity.IntermediateTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherGripTeam, sponsorshipTyreDataEntity.WetWeatherGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherResilienceTeam, sponsorshipTyreDataEntity.WetWeatherResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherStiffnessTeam, sponsorshipTyreDataEntity.WetWeatherStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherTemperatureTeam, sponsorshipTyreDataEntity.WetWeatherTemperature);
        }
    }
}