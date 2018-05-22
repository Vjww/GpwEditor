using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TyreDataEntityImportService : IDataEntityImportService<TyreDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TyreDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<TyreDataLocator> _dataLocatorFactory;

        public TyreDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TyreDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<TyreDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public TyreDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;
            result.DryHardGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardGripSupplier);
            result.DryHardResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardResilienceSupplier);
            result.DryHardStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardStiffnessSupplier);
            result.DryHardTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DryHardTemperatureSupplier);
            result.DrySoftGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftGripSupplier);
            result.DrySoftResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftResilienceSupplier);
            result.DrySoftStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftStiffnessSupplier);
            result.DrySoftTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.DrySoftTemperatureSupplier);
            result.IntermediateGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateGripSupplier);
            result.IntermediateResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateResilienceSupplier);
            result.IntermediateStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateStiffnessSupplier);
            result.IntermediateTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.IntermediateTemperatureSupplier);
            result.WetWeatherGrip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherGripSupplier);
            result.WetWeatherResilience = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherResilienceSupplier);
            result.WetWeatherStiffness = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherStiffnessSupplier);
            result.WetWeatherTemperature = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.WetWeatherTemperatureSupplier);

            return result;
        }
    }
}