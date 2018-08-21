using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1ChiefEngineerDataEntityExportService : IDataEntityExportService<NonF1ChiefEngineerDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1ChiefEngineerDataLocator> _dataLocatorFactory;

        public NonF1ChiefEngineerDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1ChiefEngineerDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(NonF1ChiefEngineerDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is NonF1ChiefEngineerDataEntity nonF1ChiefEngineerDataEntity)) throw new ArgumentNullException(nameof(nonF1ChiefEngineerDataEntity));

            var dataLocator = _dataLocatorFactory.Create(nonF1ChiefEngineerDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = nonF1ChiefEngineerDataEntity.Name.English;
            frenchCatalogueItem.Value = nonF1ChiefEngineerDataEntity.Name.French;
            germanCatalogueItem.Value = nonF1ChiefEngineerDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, nonF1ChiefEngineerDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, nonF1ChiefEngineerDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, nonF1ChiefEngineerDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, nonF1ChiefEngineerDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, nonF1ChiefEngineerDataEntity.ChampionshipBonus);
        }
    }
}