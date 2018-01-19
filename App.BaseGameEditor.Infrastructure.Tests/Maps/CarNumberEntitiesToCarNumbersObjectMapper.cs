using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Infrastructure.Factories;
using NUnit.Framework;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    [TestFixture]
    public class CarNumberEntitiesToCarNumbersObjectMapper
    {
        private CarNumberEntity _carNumberEntity1;
        private CarNumberEntity _carNumberEntity2;
        private CarNumberEntity _carNumberEntity3;

        [SetUp]
        public void SetUp()
        {
            _carNumberEntity1 = new CarNumberEntity { Id = 0, TeamId = 0, ValueA = 1, ValueB = 2, PositionId = 0 };
            _carNumberEntity2 = new CarNumberEntity { Id = 1, TeamId = 0, ValueA = 3, ValueB = 4, PositionId = 1 };
            _carNumberEntity3 = new CarNumberEntity { Id = 2, TeamId = 0, ValueA = 5, ValueB = 6, PositionId = 2 };
        }

        [Test]
        public void CarNumberEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberEntitiesToCarNumbersObjectMapper(factory);

            void TestDelegate()
            {
                var _ = mapper.Map(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumberEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithEmptyList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberEntitiesToCarNumbersObjectMapper(factory);

            // ReSharper disable once CollectionNeverUpdated.Local
            var list = new List<CarNumberEntity>();

            void TestDelegate()
            {
                var _ = mapper.Map(list);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), TestDelegate);
        }

        [Test]
        public void CarNumberEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithUnderpopulatedList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberEntity> { _carNumberEntity1 };

            void TestDelegate()
            {
                var _ = mapper.Map(list);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), TestDelegate);
        }

        [Test]
        public void CarNumberEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithOverpopulatedList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberEntity> { _carNumberEntity1, _carNumberEntity2, _carNumberEntity3 };

            void TestDelegate()
            {
                var _ = mapper.Map(list);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), TestDelegate);
        }

        [Test]
        public void CarNumberEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithPopulatedList_ExpectPopulatedObject()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberEntity> { _carNumberEntity1, _carNumberEntity2 };

            var sut = mapper.Map(list);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.CarNumberDriver1 == _carNumberEntity1.ValueA);
            Assert.IsTrue(sut.CarNumberDriver2 == _carNumberEntity2.ValueA);
        }
    }
}