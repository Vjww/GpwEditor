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
        private static CarNumbersObjectFactory _carNumbersObjectFactory;
        private static BaseGameEditor.Infrastructure.Factories.EntityFactory<BaseGameEditor.Domain.Entities.TeamEntity> _teamEntityFactory;

        private TeamEntity _teamDataEntity;
        private ChassisHandlingEntity _chassisHandlingDataEntity;
        private CarNumbersObject _carNumbersObject;
        private BaseGameEditor.Domain.Entities.TeamEntity _teamEntity;
        private PresentationConfiguration _presentationConfiguration;
        private InfrastructureConfiguration _infrastructureConfiguration;
        private AutoMapperObjectMapperService _mapper;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            _teamDataEntityFactory = new TeamEntityFactory();
            _chassisHandlingDataEntityFactory = new ChassisHandlingEntityFactory();
            _carNumbersObjectFactory = new CarNumbersObjectFactory();
            _teamEntityFactory = new BaseGameEditor.Infrastructure.Factories.EntityFactory<BaseGameEditor.Domain.Entities.TeamEntity>();
        }

        [SetUp]
        public void SetUp()
        {
            _presentationConfiguration = new PresentationConfiguration();
            _infrastructureConfiguration = new InfrastructureConfiguration();
            _mapper = new AutoMapperObjectMapperService(_presentationConfiguration, _infrastructureConfiguration);
            _mapper.Initialise();

            // Initialise data entities using unique non-default dummy values to verify mappings
            _teamDataEntity = _teamDataEntityFactory.Create(1);
            _teamDataEntity.Name.All = "UnitTest";
            _teamDataEntity.LastPosition = 11;
            _teamDataEntity.LastPoints = 12;
            _teamDataEntity.FirstGpTrack = 13;
            _teamDataEntity.FirstGpYear = 14;
            _teamDataEntity.Wins = 15;
            _teamDataEntity.YearlyBudget = 16;
            _teamDataEntity.UnknownA = 17;
            _teamDataEntity.CountryMapId = 18;
            _teamDataEntity.LocationPointerX = 19;
            _teamDataEntity.LocationPointerY = 20;
            _teamDataEntity.TyreSupplierId = 21;

            _chassisHandlingDataEntity = _chassisHandlingDataEntityFactory.Create(2);
            _chassisHandlingDataEntity.TeamId = 22;
            _chassisHandlingDataEntity.Value = 23;

            _carNumbersObject = _carNumbersObjectFactory.Create();
            _carNumbersObject.CarNumberDriver1 = 24;
            _carNumbersObject.CarNumberDriver2 = 25;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            _teamEntity = _teamEntityFactory.Create(_teamDataEntity.Id);
            _teamEntity.TeamId = _teamDataEntity.Id + 1;
            _teamEntity.Name = _teamDataEntity.Name.All;
            _teamEntity.LastPosition = _teamDataEntity.LastPosition;
            _teamEntity.LastPoints = _teamDataEntity.LastPoints;
            _teamEntity.FirstGpTrack = _teamDataEntity.FirstGpTrack;
            _teamEntity.FirstGpYear = _teamDataEntity.FirstGpYear;
            _teamEntity.Wins = _teamDataEntity.Wins;
            _teamEntity.YearlyBudget = _teamDataEntity.YearlyBudget;
            _teamEntity.CountryMapId = _teamDataEntity.CountryMapId;
            _teamEntity.LocationPointerX = _teamDataEntity.LocationPointerX;
            _teamEntity.LocationPointerY = _teamDataEntity.LocationPointerY;
            _teamEntity.TyreSupplierId = _teamDataEntity.TyreSupplierId;
            _teamEntity.ChassisHandling = _chassisHandlingDataEntity.Value;
            _teamEntity.CarNumberDriver1 = _carNumbersObject.CarNumberDriver1;
            _teamEntity.CarNumberDriver2 = _carNumbersObject.CarNumberDriver2;
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamDataEntity_ExpectPopulatedTeamEntity()
        {
            var sut = _teamEntityFactory.Create(_teamEntity.Id);
            _mapper.Map(_teamDataEntity, sut);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.Id == _teamEntity.Id);
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
            var sut = _teamEntityFactory.Create(_teamEntity.Id);
            _mapper.Map(_chassisHandlingDataEntity, sut);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.ChassisHandling == _chassisHandlingDataEntity.Value);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedCarNumbersObject_ExpectPopulatedTeamEntity()
        {
            var sut = _teamEntityFactory.Create(_teamEntity.Id);
            _mapper.Map(_carNumbersObject, sut);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.CarNumberDriver1 == _carNumbersObject.CarNumberDriver1);
            Assert.IsTrue(sut.CarNumberDriver2 == _carNumbersObject.CarNumberDriver2);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromThreeSourcesToOne_ExpectPopulatedTeamEntity()
        {
            var sut = _teamEntityFactory.Create(_teamEntity.Id);
            _mapper.Map(_teamDataEntity, sut);
            _mapper.Map(_chassisHandlingDataEntity, sut);
            _mapper.Map(_carNumbersObject, sut);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.Id == _teamEntity.Id);
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
            Assert.IsTrue(sut.ChassisHandling == _chassisHandlingDataEntity.Value);
            Assert.IsTrue(sut.CarNumberDriver1 == _carNumbersObject.CarNumberDriver1);
            Assert.IsTrue(sut.CarNumberDriver2 == _carNumbersObject.CarNumberDriver2);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedTeamDataEntity()
        {
            var teamDataEntity = _teamDataEntityFactory.Create(_teamDataEntity.Id);
            var sut = _mapper.Map(_teamEntity, teamDataEntity);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.Id == _teamDataEntity.Id);
            Assert.IsTrue(sut.Name.All == _teamEntity.Name);
            Assert.IsTrue(sut.LastPosition == _teamEntity.LastPosition);
            Assert.IsTrue(sut.LastPoints == _teamEntity.LastPoints);
            Assert.IsTrue(sut.FirstGpTrack == _teamEntity.FirstGpTrack);
            Assert.IsTrue(sut.FirstGpYear == _teamEntity.FirstGpYear);
            Assert.IsTrue(sut.Wins == _teamEntity.Wins);
            Assert.IsTrue(sut.YearlyBudget == _teamEntity.YearlyBudget);
            Assert.IsTrue(sut.CountryMapId == _teamEntity.CountryMapId);
            Assert.IsTrue(sut.LocationPointerX == _teamEntity.LocationPointerX);
            Assert.IsTrue(sut.LocationPointerY == _teamEntity.LocationPointerY);
            Assert.IsTrue(sut.TyreSupplierId == _teamEntity.TyreSupplierId);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedChassisHandlingDataEntity()
        {
            var chassisHandlingDataEntity = _chassisHandlingDataEntityFactory.Create(_chassisHandlingDataEntity.Id);
            var sut = _mapper.Map(_teamEntity, chassisHandlingDataEntity);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.Id == _chassisHandlingDataEntity.Id);
            Assert.IsTrue(sut.TeamId == _teamEntity.Id);
            Assert.IsTrue(sut.Value == _teamEntity.ChassisHandling);
        }

        [Test]
        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedCarNumbersObject()
        {
            var sut = _mapper.Map<BaseGameEditor.Domain.Entities.TeamEntity, CarNumbersObject>(_teamEntity);

            Assert.IsNotNull(sut);
            Assert.IsTrue(sut.CarNumberDriver1 == _teamEntity.CarNumberDriver1);
            Assert.IsTrue(sut.CarNumberDriver2 == _teamEntity.CarNumberDriver2);
        }
    }
}