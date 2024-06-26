﻿using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntityImportService : IDataEntityImportService<ChassisHandlingDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<ChassisHandlingDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<ChassisHandlingDataLocator> _dataLocatorFactory;

        public ChassisHandlingDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<ChassisHandlingDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<ChassisHandlingDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public ChassisHandlingDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Value = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Value);

            return result;
        }
    }
}