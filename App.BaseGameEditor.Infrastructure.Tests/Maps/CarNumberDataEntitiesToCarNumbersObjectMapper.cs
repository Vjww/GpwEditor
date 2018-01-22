using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Infrastructure.Factories;
using NUnit.Framework;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    [TestFixture]
    public class CarNumberDataEntitiesToCarNumbersObjectMapper
    {
        private CarNumberDataEntity _carNumberDataEntity1;
        private CarNumberDataEntity _carNumberDataEntity2;
        private CarNumberDataEntity _carNumberDataEntity3;

        [SetUp]
        public void SetUp()
        {
            _carNumberDataEntity1 = new CarNumberDataEntity { Id = 0, TeamId = 0, ValueA = 1, ValueB = 2, PositionId = 0 };
            _carNumberDataEntity2 = new CarNumberDataEntity { Id = 1, TeamId = 0, ValueA = 3, ValueB = 4, PositionId = 1 };
            _carNumberDataEntity3 = new CarNumberDataEntity { Id = 2, TeamId = 0, ValueA = 5, ValueB = 6, PositionId = 2 };
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            void TestDelegate()
            {
                var _ = mapper.Map(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithEmptyList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            // ReSharper disable once CollectionNeverUpdated.Local
            var list = new List<CarNumberDataEntity>();

            void TestDelegate()
            {
                var _ = mapper.Map(list);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), TestDelegate);
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithUnderpopulatedList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberDataEntity> { _carNumberDataEntity1 };

            void TestDelegate()
            {
                var _ = mapper.Map(list);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), TestDelegate);
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithOverpopulatedList_ExpectException()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberDataEntity> { _carNumberDataEntity1, _carNumberDataEntity2, _carNumberDataEntity3 };

            void TestDelegate()
            {
                var _ = mapper.Map(list);
            }

            Assert.Throws(typeof(ArgumentOutOfRangeException), TestDelegate);
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithPopulatedList_ExpectPopulatedObject()
        {
            var factory = new CarNumbersObjectFactory();
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(factory);

            var list = new List<CarNumberDataEntity> { _carNumberDataEntity1, _carNumberDataEntity2 };

            var sut = mapper.Map(list);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.CarNumberDriver1 == _carNumberDataEntity1.ValueA);
            Assert.IsTrue(sut.CarNumberDriver2 == _carNumberDataEntity2.ValueA);
        }
    }
}