﻿using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefCommercialDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataEntityFactory<F1ChiefCommercialDataEntity> _dataEntityFactory;
        private readonly IDataLocatorFactory<F1ChiefCommercialDataLocator> _dataLocatorFactory;

        public F1ChiefCommercialDataEntityImporter(
            DataEndpoint dataEndpoint,
            IDataEntityFactory<F1ChiefCommercialDataEntity> dataEntityFactory,
            IDataLocatorFactory<F1ChiefCommercialDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(id);

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);
            result.Ability = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Ability);
            result.Age = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Age);
            result.Salary = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Salary);
            result.Royalty = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Royalty);
            result.Morale = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Morale);

            return result;
        }
    }
}