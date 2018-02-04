using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefEngineerDataEntityExportService : IDataEntityExportService<F1ChiefEngineerDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataLocatorFactory<F1ChiefEngineerDataLocator> _dataLocatorFactory;

        public F1ChiefEngineerDataEntityExportService(
            DataEndpoint dataEndpoint,
            IDataLocatorFactory<F1ChiefEngineerDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(F1ChiefEngineerDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1ChiefEngineerDataEntity f1ChiefEngineerDataEntity)) throw new ArgumentNullException(nameof(f1ChiefEngineerDataEntity));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(f1ChiefEngineerDataEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, f1ChiefEngineerDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, f1ChiefEngineerDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, f1ChiefEngineerDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, f1ChiefEngineerDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, f1ChiefEngineerDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, f1ChiefEngineerDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, f1ChiefEngineerDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, f1ChiefEngineerDataEntity.ChampionshipBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.DriverLoyalty, f1ChiefEngineerDataEntity.DriverLoyalty);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, f1ChiefEngineerDataEntity.Morale);
        }
    }
}