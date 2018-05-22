﻿using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1ChiefMechanicDataEntityExportService : IDataEntityExportService<NonF1ChiefMechanicDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1ChiefMechanicDataLocator> _dataLocatorFactory;

        public NonF1ChiefMechanicDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1ChiefMechanicDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(NonF1ChiefMechanicDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is NonF1ChiefMechanicDataEntity nonF1ChiefMechanicDataEntity)) throw new ArgumentNullException(nameof(nonF1ChiefMechanicDataEntity));

            var dataLocator = _dataLocatorFactory.Create(nonF1ChiefMechanicDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = nonF1ChiefMechanicDataEntity.Name.English;
            frenchCatalogueItem.Value = nonF1ChiefMechanicDataEntity.Name.French;
            germanCatalogueItem.Value = nonF1ChiefMechanicDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, nonF1ChiefMechanicDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, nonF1ChiefMechanicDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, nonF1ChiefMechanicDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.RaceBonus, nonF1ChiefMechanicDataEntity.RaceBonus);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ChampionshipBonus, nonF1ChiefMechanicDataEntity.ChampionshipBonus);
        }
    }
}