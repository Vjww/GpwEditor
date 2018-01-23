using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Infrastructure.Factories;
using NUnit.Framework;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    [TestFixture]
    public class CarNumberDataEntitiesToCarNumbersObjectMapper
    {
        private static CarNumbersObjectFactory _carNumbersObjectFactory;
        private static CarNumberDataEntityFactory _carNumberDataEntityFactory;

        private CarNumberDataEntity _carNumberDataEntity1;
        private CarNumberDataEntity _carNumberDataEntity2;
        private CarNumberDataEntity _carNumberDataEntity3;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _carNumbersObjectFactory = new CarNumbersObjectFactory();
            _carNumberDataEntityFactory = new CarNumberDataEntityFactory();
        }

        [SetUp]
        public void SetUp()
        {
            _carNumberDataEntity1 = _carNumberDataEntityFactory.Create(0);
            _carNumberDataEntity1.TeamId = 7;
            _carNumberDataEntity1.ValueA = 1;
            _carNumberDataEntity1.ValueB = 2;
            _carNumberDataEntity1.PositionId = 0;

            _carNumberDataEntity2 = _carNumberDataEntityFactory.Create(1);
            _carNumberDataEntity2.TeamId = 8;
            _carNumberDataEntity2.ValueA = 3;
            _carNumberDataEntity2.ValueB = 4;
            _carNumberDataEntity2.PositionId = 1;

            _carNumberDataEntity3 = _carNumberDataEntityFactory.Create(2);
            _carNumberDataEntity3.TeamId = 9;
            _carNumberDataEntity3.ValueA = 5;
            _carNumberDataEntity3.ValueB = 6;
            _carNumberDataEntity3.PositionId = 2;
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingConstructorWithNullParameter_ExpectException()
        {
            void TestDelegate()
            {
                var _ = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(_carNumbersObjectFactory);

            void TestDelegate()
            {
                var _ = mapper.Map(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumberDataEntitiesToCarNumbersObjectMapper_WhenInvokingMapMethodWithEmptyList_ExpectException()
        {
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(_carNumbersObjectFactory);

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
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(_carNumbersObjectFactory);

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
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(_carNumbersObjectFactory);

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
            var mapper = new Infrastructure.Maps.CarNumberDataEntitiesToCarNumbersObjectMapper(_carNumbersObjectFactory);

            var list = new List<CarNumberDataEntity> { _carNumberDataEntity1, _carNumberDataEntity2 };

            var sut = mapper.Map(list);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.Id == 7);
            Assert.IsTrue(sut.CarNumberDriver1 == _carNumberDataEntity1.ValueA);
            Assert.IsTrue(sut.CarNumberDriver2 == _carNumberDataEntity2.ValueA);
        }
    }
}