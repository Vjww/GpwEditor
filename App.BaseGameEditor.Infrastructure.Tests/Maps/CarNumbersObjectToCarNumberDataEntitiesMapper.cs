using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Maps;
using NUnit.Framework;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    [TestFixture]
    public class CarNumbersObjectToCarNumberDataEntitiesMapper
    {
        private static CarNumbersObjectFactory _carNumbersObjectFactory;
        private static CarNumberDataEntityFactory _carNumberDataEntityFactory;

        private CarNumbersObject _carNumbersObject;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _carNumbersObjectFactory = new CarNumbersObjectFactory();
            _carNumberDataEntityFactory = new CarNumberDataEntityFactory();
        }

        [SetUp]
        public void SetUp()
        {
            const int carNumbersObjectId = 1;
            _carNumbersObject = _carNumbersObjectFactory.Create(carNumbersObjectId);
            _carNumbersObject.CarNumberDriver1 = 3;
            _carNumbersObject.CarNumberDriver2 = 4;
        }

        [Test]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingConstructorWithNullParameter_ExpectException()
        {
            void TestDelegate()
            {
                var _ = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(_carNumberDataEntityFactory);

            void TestDelegate()
            {
                var _ = mapper.Map(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingMapMethodWithPopulatedEntity_ExpectPopulatedList()
        {
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(_carNumberDataEntityFactory);

            var sut = mapper.Map(_carNumbersObject);

            Assert.IsNotNull(sut);
            var sutAsList = sut as IList<CarNumberDataEntity> ?? sut.ToList();
            Assert.IsTrue(sutAsList.Count == 2);

            var carNumberDataEntity1 = sutAsList.Single(x => x.PositionId == 0);
            Assert.IsNotNull(carNumberDataEntity1);
            Assert.IsTrue(carNumberDataEntity1.Id == 2);
            Assert.IsTrue(carNumberDataEntity1.TeamId == _carNumbersObject.Id);
            Assert.IsTrue(carNumberDataEntity1.ValueA == _carNumbersObject.CarNumberDriver1);
            Assert.IsTrue(carNumberDataEntity1.ValueB == _carNumbersObject.CarNumberDriver1);

            var carNumberDataEntity2 = sutAsList.Single(x => x.PositionId == 1);
            Assert.IsNotNull(carNumberDataEntity2);
            Assert.IsTrue(carNumberDataEntity2.Id == 3);
            Assert.IsTrue(carNumberDataEntity2.TeamId == _carNumbersObject.Id);
            Assert.IsTrue(carNumberDataEntity2.ValueA == _carNumbersObject.CarNumberDriver2);
            Assert.IsTrue(carNumberDataEntity2.ValueB == _carNumbersObject.CarNumberDriver2);
        }
    }
}