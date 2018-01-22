using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Domain.Entities;
using NUnit.Framework;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    [TestFixture]
    public class CarNumbersObjectToCarNumberDataEntitiesMapper
    {
        private TeamEntity _teamEntity;

        [SetUp]
        public void SetUp()
        {
            _teamEntity = new TeamEntity
            {
                Id = 1,
                CarNumberDriver1 = 3,
                CarNumberDriver2 = 4
            };
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
            var factory = new CarNumberDataEntityFactory();
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(factory);

            void TestDelegate()
            {
                var _ = mapper.Map(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumbersObjectToCarNumberDataEntitiesMapper_WhenInvokingMapMethodWithPopulatedEntity_ExpectPopulatedList()
        {
            var factory = new CarNumberDataEntityFactory();
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberDataEntitiesMapper(factory);

            var sut = mapper.Map(_teamEntity);

            Assert.IsNotNull(sut);
            var sutAsList = sut as IList<CarNumberDataEntity> ?? sut.ToList();
            Assert.IsTrue(sutAsList.Count == 2);

            var carNumberDataEntity1 = sutAsList.Single(x => x.PositionId == 0);
            Assert.IsNotNull(carNumberDataEntity1);
            Assert.IsTrue(carNumberDataEntity1.Id == 2);
            Assert.IsTrue(carNumberDataEntity1.TeamId == _teamEntity.TeamId);
            Assert.IsTrue(carNumberDataEntity1.ValueA == _teamEntity.CarNumberDriver1);
            Assert.IsTrue(carNumberDataEntity1.ValueB == _teamEntity.CarNumberDriver1);

            var carNumberDataEntity2 = sutAsList.Single(x => x.PositionId == 1);
            Assert.IsNotNull(carNumberDataEntity2);
            Assert.IsTrue(carNumberDataEntity2.Id == 3);
            Assert.IsTrue(carNumberDataEntity2.TeamId == _teamEntity.TeamId);
            Assert.IsTrue(carNumberDataEntity2.ValueA == _teamEntity.CarNumberDriver2);
            Assert.IsTrue(carNumberDataEntity2.ValueB == _teamEntity.CarNumberDriver2);
        }
    }
}