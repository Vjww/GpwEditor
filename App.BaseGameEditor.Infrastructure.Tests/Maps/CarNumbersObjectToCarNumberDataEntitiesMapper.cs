using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Maps;
using FluentAssertions;
using Xunit;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    public class CarNumbersObjectToCarNumberDataEntitiesMapper
    {
        [Fact]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingConstructorWithNullParameter_ExpectException()
        {
            var action = new Action(() =>
            {
                var _ = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(null);
            });

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var factory = new CarNumberDataEntityFactory(() => new CarNumberDataEntity()); // TODO: Mock it
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(factory);

            var action = new Action(() =>
            {
                var _ = mapper.Map(null);
            });

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingMapMethodWithPopulatedEntity_ExpectPopulatedList()
        {
            var factory = new CarNumberDataEntityFactory(() => new CarNumberDataEntity()); // TODO: Mock it
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(factory);

            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it

            const int carNumbersObjectId = 1;
            var carNumbersObject = carNumbersObjectFactory.Create(carNumbersObjectId);
            carNumbersObject.CarNumberDriver1 = 3;
            carNumbersObject.CarNumberDriver2 = 4;

            var sut = mapper.Map(carNumbersObject).ToList();
            sut.Should().NotBeNull();
            sut.Count.Should().Be(2);

            var carNumberDataEntity1 = sut.Single(x => x.PositionId == 0);
            carNumberDataEntity1.Should().NotBeNull();
            carNumberDataEntity1.Id.Should().Be(2);
            carNumberDataEntity1.TeamId.Should().Be(carNumbersObject.Id);
            carNumberDataEntity1.ValueA.Should().Be(carNumbersObject.CarNumberDriver1);
            carNumberDataEntity1.ValueB.Should().Be(carNumbersObject.CarNumberDriver1);

            var carNumberDataEntity2 = sut.Single(x => x.PositionId == 1);
            carNumberDataEntity2.Should().NotBeNull();
            carNumberDataEntity2.Id.Should().Be(3);
            carNumberDataEntity2.TeamId.Should().Be(carNumbersObject.Id);
            carNumberDataEntity2.ValueA.Should().Be(carNumbersObject.CarNumberDriver2);
            carNumberDataEntity2.ValueB.Should().Be(carNumbersObject.CarNumberDriver2);
        }
    }
}