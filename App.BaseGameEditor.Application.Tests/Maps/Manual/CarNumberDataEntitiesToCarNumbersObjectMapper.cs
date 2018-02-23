using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Objects;
using FluentAssertions;
using Xunit;

namespace App.BaseGameEditor.Application.Tests.Maps.Manual
{
    public class CarNumberDataEntitiesToCarNumbersObjectMapper
    {
        [Fact]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingConstructorWithNullParameter_ExpectException()
        {
            var action = new Action(() =>
            {
                var _ = new Application.Maps.Manual.CarNumberDataEntitiesToCarNumbersObjectMapper(null);
            });

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var factory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
            var mapper = new Application.Maps.Manual.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var action = new Action(() =>
            {
                var _ = mapper.Map(null);
            });

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithEmptyList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
            var mapper = new Application.Maps.Manual.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            // ReSharper disable once CollectionNeverUpdated.Local
            var list = new List<CarNumberDataEntity>();

            var action = new Action(() =>
            {
                var _ = mapper.Map(list);
            });

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithUnderpopulatedList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
            var mapper = new Application.Maps.Manual.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberDataEntity> { new CarNumberDataEntity() };

            var action = new Action(() =>
            {
                var _ = mapper.Map(list);
            });

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithOverpopulatedList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
            var mapper = new Application.Maps.Manual.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberDataEntity> { new CarNumberDataEntity(), new CarNumberDataEntity(), new CarNumberDataEntity() };

            var action = new Action(() =>
            {
                var _ = mapper.Map(list);
            });

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithPopulatedList_ExpectPopulatedObject()
        {
            var factory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
            var mapper = new Application.Maps.Manual.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var carNumberDataEntityFactory = new IntegerIdentityFactory<CarNumberDataEntity>(() => new CarNumberDataEntity()); // TODO: Mock it

            var carNumberDataEntity1 = carNumberDataEntityFactory.Create(8);
            carNumberDataEntity1.ValueA = 1;
            carNumberDataEntity1.ValueB = 2;
            carNumberDataEntity1.PositionId = 0;

            var carNumberDataEntity2 = carNumberDataEntityFactory.Create(9);
            carNumberDataEntity2.ValueA = 3;
            carNumberDataEntity2.ValueB = 4;
            carNumberDataEntity2.PositionId = 1;

            var list = new List<CarNumberDataEntity> { carNumberDataEntity1, carNumberDataEntity2 };

            var sut = mapper.Map(list);

            sut.Should().NotBeNull();
            sut.Id.Should().Be(4);
            sut.CarNumberDriver1.Should().Be(carNumberDataEntity1.ValueA);
            sut.CarNumberDriver2.Should().Be(carNumberDataEntity2.ValueA);
        }
    }
}