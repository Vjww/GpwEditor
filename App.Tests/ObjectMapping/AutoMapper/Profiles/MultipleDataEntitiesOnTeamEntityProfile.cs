using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Maps;
using App.ObjectMapping.AutoMapper.Configurations;
using App.Services;
using NUnit.Framework;

namespace App.Tests.ObjectMapping.AutoMapper.Profiles
{
    [TestFixture]
    public class MultipleDataEntitiesOnTeamEntityProfile
    {
        private static TeamEntityFactory _teamDataEntityFactory;
        private static ChassisHandlingEntityFactory _chassisHandlingDataEntityFactory;
        //private CarNumberEntityFactory carNumberDataEntityFactory;
        private static CarNumbersObjectFactory _carNumbersObjectFactory;
        private static BaseGameEditor.Infrastructure.Factories.EntityFactory<BaseGameEditor.Domain.Entities.TeamEntity> _teamDomainEntityFactory;

        private PresentationConfiguration _presentationConfiguration;
        private InfrastructureConfiguration _infrastructureConfiguration;
        private AutoMapperObjectMapperService _mapper;

        private TeamEntity _teamDataEntity;
        private ChassisHandlingEntity _chassisHandlingDataEntity;
        private CarNumbersObject _carNumbersObject;

        //private CarNumberEntity carNumberEntity1;
        //private CarNumberEntity carNumberEntity2;
        //private List<CarNumberEntity> carNumberEntities;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _teamDataEntityFactory = new TeamEntityFactory();
            _chassisHandlingDataEntityFactory = new ChassisHandlingEntityFactory();
            //carNumberDataEntityFactory = new CarNumberEntityFactory();
            _carNumbersObjectFactory = new CarNumbersObjectFactory();
            _teamDomainEntityFactory = new BaseGameEditor.Infrastructure.Factories.EntityFactory<BaseGameEditor.Domain.Entities.TeamEntity>();
        }

        [SetUp]
        public void SetUp()
        {
            _presentationConfiguration = new PresentationConfiguration();
            _infrastructureConfiguration = new InfrastructureConfiguration();
            _mapper = new AutoMapperObjectMapperService(_presentationConfiguration, _infrastructureConfiguration);
            _mapper.Initialise();

            _teamDataEntity = _teamDataEntityFactory.Create(8);
            _teamDataEntity.Name.All = "UnitTest";
            _teamDataEntity.LastPosition = 5;
            _teamDataEntity.LastPoints = 50;
            _teamDataEntity.FirstGpTrack = 16;
            _teamDataEntity.FirstGpYear = 1950;
            _teamDataEntity.Wins = 10;
            _teamDataEntity.YearlyBudget = 50000000;
            _teamDataEntity.UnknownA = 42;
            _teamDataEntity.CountryMapId = 3;
            _teamDataEntity.LocationPointerX = 21;
            _teamDataEntity.LocationPointerY = 22;
            _teamDataEntity.TyreSupplierId = 2;

            _chassisHandlingDataEntity = _chassisHandlingDataEntityFactory.Create(0);
            _chassisHandlingDataEntity.TeamId = 0;
            _chassisHandlingDataEntity.Value = 75;

            //carNumberEntity1 = carNumberDataEntityFactory.Create(0);
            //carNumberEntity1.TeamId = 0;
            //carNumberEntity1.PositionId = 0;
            //carNumberEntity1.ValueA = 11;
            //carNumberEntity1.ValueB = 12;

            //carNumberEntity2 = carNumberDataEntityFactory.Create(1);
            //carNumberEntity1.TeamId = 0;
            //carNumberEntity1.PositionId = 1;
            //carNumberEntity1.ValueA = 13;
            //carNumberEntity1.ValueB = 14;

            //carNumberEntities = new List<CarNumberEntity> { carNumberEntity1, carNumberEntity2 };

            _carNumbersObject = _carNumbersObjectFactory.Create();
            _carNumbersObject.CarNumberDriver1 = 11;
            _carNumbersObject.CarNumberDriver2 = 12;
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamDataEntity_ExpectPopulatedTeamEntity()
        {
            var sut = _mapper.Map<TeamEntity, BaseGameEditor.Domain.Entities.TeamEntity>(_teamDataEntity);
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.Id == _teamDataEntity.Id);
            Assert.IsTrue(sut.Name == _teamDataEntity.Name.All);
            Assert.IsTrue(sut.LastPosition == _teamDataEntity.LastPosition);
            Assert.IsTrue(sut.LastPoints == _teamDataEntity.LastPoints);
            Assert.IsTrue(sut.FirstGpTrack == _teamDataEntity.FirstGpTrack);
            Assert.IsTrue(sut.FirstGpYear == _teamDataEntity.FirstGpYear);
            Assert.IsTrue(sut.Wins == _teamDataEntity.Wins);
            Assert.IsTrue(sut.YearlyBudget == _teamDataEntity.YearlyBudget);
            Assert.IsTrue(sut.CountryMapId == _teamDataEntity.CountryMapId);
            Assert.IsTrue(sut.LocationPointerX == _teamDataEntity.LocationPointerX);
            Assert.IsTrue(sut.LocationPointerY == _teamDataEntity.LocationPointerY);
            Assert.IsTrue(sut.TyreSupplierId == _teamDataEntity.TyreSupplierId);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedChassisHandlingDataEntity_ExpectPopulatedTeamEntity()
        {
            var sut = _mapper.Map<ChassisHandlingEntity, BaseGameEditor.Domain.Entities.TeamEntity>(_chassisHandlingDataEntity);
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.ChassisHandling == _chassisHandlingDataEntity.Value);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedCarNumbersObject_ExpectPopulatedTeamEntity()
        {
            var sut = _mapper.Map<CarNumbersObject, BaseGameEditor.Domain.Entities.TeamEntity>(_carNumbersObject);
            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.CarNumberDriver1 == _carNumbersObject.CarNumberDriver1);
            Assert.IsTrue(sut.CarNumberDriver2 == _carNumbersObject.CarNumberDriver2);
        }

        // TODO: And one full test of three into one and one into three
        // TODO: And reverse methods for each above test
    }
}