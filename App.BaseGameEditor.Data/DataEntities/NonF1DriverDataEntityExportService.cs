using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1DriverDataEntityExportService : IDataEntityExportService<NonF1DriverDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1DriverDataLocator> _dataLocatorFactory;

        public NonF1DriverDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1DriverDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(NonF1DriverDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is NonF1DriverDataEntity nonF1DriverDataEntity)) throw new ArgumentNullException(nameof(nonF1DriverDataEntity));

            var dataLocator = _dataLocatorFactory.Create(nonF1DriverDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = nonF1DriverDataEntity.Name.English;
            frenchCatalogueItem.Value = nonF1DriverDataEntity.Name.French;
            germanCatalogueItem.Value = nonF1DriverDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, nonF1DriverDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, nonF1DriverDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, nonF1DriverDataEntity.ChampionshipBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, nonF1DriverDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Nationality, nonF1DriverDataEntity.Nationality);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.UnknownA, nonF1DriverDataEntity.UnknownA);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Speed, nonF1DriverDataEntity.Speed);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Skill, nonF1DriverDataEntity.Skill);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Overtaking, nonF1DriverDataEntity.Overtaking);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.WetWeather, nonF1DriverDataEntity.WetWeather);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Concentration, nonF1DriverDataEntity.Concentration);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Experience, nonF1DriverDataEntity.Experience);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Stamina, nonF1DriverDataEntity.Stamina);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, nonF1DriverDataEntity.Morale);
        }
    }
}