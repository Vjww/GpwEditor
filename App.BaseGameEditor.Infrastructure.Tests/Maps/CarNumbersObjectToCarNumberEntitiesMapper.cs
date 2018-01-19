using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Factories;
using NUnit.Framework;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.Tests.Maps
{
    [TestFixture]
    public class CarNumbersObjectToCarNumberEntitiesMapper
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
        public void CarNumbersObjectToCarNumberEntitiesMapper_WhenInvokingConstructorWithNullParameter_ExpectException()
        {
            void TestDelegate()
            {
                var _ = new Infrastructure.Maps.CarNumbersObjectToCarNumberEntitiesMapper(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumbersObjectToCarNumberEntitiesMapper_WhenInvokingMapMethodWithNullParameter_ExpectException()
        {
            var factory = new CarNumberEntityFactory();
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberEntitiesMapper(factory);

            void TestDelegate()
            {
                var _ = mapper.Map(null);
            }

            Assert.Throws(typeof(ArgumentNullException), TestDelegate);
        }

        [Test]
        public void CarNumbersObjectToCarNumberEntitiesMapper_WhenInvokingMapMethodWithPopulatedEntity_ExpectPopulatedList()
        {
            var factory = new CarNumberEntityFactory();
            var mapper = new Infrastructure.Maps.CarNumbersObjectToCarNumberEntitiesMapper(factory);

            var sut = mapper.Map(_teamEntity);

            Assert.IsNotNull(sut);
            var sutAsList = sut as IList<CarNumberEntity> ?? sut.ToList();
            Assert.IsTrue(sutAsList.Count == 2);

            var carNumberEntity1 = sutAsList.Single(x => x.PositionId == 0);
            Assert.IsNotNull(carNumberEntity1);
            Assert.IsTrue(carNumberEntity1.Id == 2);
            Assert.IsTrue(carNumberEntity1.TeamId == _teamEntity.TeamId);
            Assert.IsTrue(carNumberEntity1.ValueA == _teamEntity.CarNumberDriver1);
            Assert.IsTrue(carNumberEntity1.ValueB == _teamEntity.CarNumberDriver1);

            var carNumberEntity2 = sutAsList.Single(x => x.PositionId == 1);
            Assert.IsNotNull(carNumberEntity2);
            Assert.IsTrue(carNumberEntity2.Id == 3);
            Assert.IsTrue(carNumberEntity2.TeamId == _teamEntity.TeamId);
            Assert.IsTrue(carNumberEntity2.ValueA == _teamEntity.CarNumberDriver2);
            Assert.IsTrue(carNumberEntity2.ValueB == _teamEntity.CarNumberDriver2);
        }
    }
}