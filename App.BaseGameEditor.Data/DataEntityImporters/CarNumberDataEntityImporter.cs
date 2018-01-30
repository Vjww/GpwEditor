using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntityImporters
{
    public class CarNumberDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly CarNumberDataLocator _dataLocator;
        private readonly CarNumberDataEntityFactory _factory;

        public CarNumberDataEntityImporter(
            DataEndpoint dataEndpoint,
            CarNumberDataLocator dataLocator,
            CarNumberDataEntityFactory factory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _dataLocator.Initialise(id);

            var result = _factory.Create(id);
            result.TeamId = result.Id / 2;
            result.PositionId = result.Id % 2;
            result.ValueA = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.ValueA);
            result.ValueB = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.ValueB);

            return result;
        }
    }
}