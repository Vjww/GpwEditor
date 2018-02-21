using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TyreDataEntityExportService : IDataEntityExportService<TyreDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TyreDataLocator> _dataLocatorFactory;

        public TyreDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TyreDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(TyreDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is TyreDataEntity tyreDataEntity)) throw new ArgumentNullException(nameof(tyreDataEntity));

            var dataLocator = _dataLocatorFactory.Create(tyreDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, tyreDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, tyreDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, tyreDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardGripSupplier, tyreDataEntity.DryHardGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardResilienceSupplier, tyreDataEntity.DryHardResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardStiffnessSupplier, tyreDataEntity.DryHardStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardTemperatureSupplier, tyreDataEntity.DryHardTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftGripSupplier, tyreDataEntity.DrySoftGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftResilienceSupplier, tyreDataEntity.DrySoftResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftStiffnessSupplier, tyreDataEntity.DrySoftStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftTemperatureSupplier, tyreDataEntity.DrySoftTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateGripSupplier, tyreDataEntity.IntermediateGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateResilienceSupplier, tyreDataEntity.IntermediateResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateStiffnessSupplier, tyreDataEntity.IntermediateStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateTemperatureSupplier, tyreDataEntity.IntermediateTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherGripSupplier, tyreDataEntity.WetWeatherGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherResilienceSupplier, tyreDataEntity.WetWeatherResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherStiffnessSupplier, tyreDataEntity.WetWeatherStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherTemperatureSupplier, tyreDataEntity.WetWeatherTemperature);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardGripTeam, tyreDataEntity.DryHardGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardResilienceTeam, tyreDataEntity.DryHardResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardStiffnessTeam, tyreDataEntity.DryHardStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DryHardTemperatureTeam, tyreDataEntity.DryHardTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftGripTeam, tyreDataEntity.DrySoftGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftResilienceTeam, tyreDataEntity.DrySoftResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftStiffnessTeam, tyreDataEntity.DrySoftStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DrySoftTemperatureTeam, tyreDataEntity.DrySoftTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateGripTeam, tyreDataEntity.IntermediateGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateResilienceTeam, tyreDataEntity.IntermediateResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateStiffnessTeam, tyreDataEntity.IntermediateStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.IntermediateTemperatureTeam, tyreDataEntity.IntermediateTemperature);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherGripTeam, tyreDataEntity.WetWeatherGrip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherResilienceTeam, tyreDataEntity.WetWeatherResilience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherStiffnessTeam, tyreDataEntity.WetWeatherStiffness);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeatherTemperatureTeam, tyreDataEntity.WetWeatherTemperature);
        }
    }
}