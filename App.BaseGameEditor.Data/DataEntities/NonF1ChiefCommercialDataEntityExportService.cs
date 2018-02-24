﻿using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class NonF1ChiefCommercialDataEntityExportService : IDataEntityExportService<NonF1ChiefCommercialDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<NonF1ChiefCommercialDataLocator> _dataLocatorFactory;

        public NonF1ChiefCommercialDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<NonF1ChiefCommercialDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(NonF1ChiefCommercialDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is NonF1ChiefCommercialDataEntity nonF1ChiefCommercialDataEntity)) throw new ArgumentNullException(nameof(nonF1ChiefCommercialDataEntity));

            var dataLocator = _dataLocatorFactory.Create(nonF1ChiefCommercialDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, nonF1ChiefCommercialDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, nonF1ChiefCommercialDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, nonF1ChiefCommercialDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, nonF1ChiefCommercialDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, nonF1ChiefCommercialDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, nonF1ChiefCommercialDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Royalty, nonF1ChiefCommercialDataEntity.Royalty);
        }
    }
}