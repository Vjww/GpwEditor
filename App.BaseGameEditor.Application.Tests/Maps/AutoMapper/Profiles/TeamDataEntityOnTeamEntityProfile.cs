using App.BaseGameEditor.Application.Tests.Fixtures;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Objects;
using App.Shared.Data.Catalogues.Language;
using App.Shared.Infrastructure.Services;
using FluentAssertions;
using Xunit;

namespace App.BaseGameEditor.Application.Tests.Maps.AutoMapper.Profiles
{
    [Collection("Application Maps Collection")]
    public class TeamDataEntityOnTeamEntityProfile
    {
        private readonly AutoMapperMapperService _mapperService;

        public TeamDataEntityOnTeamEntityProfile(ApplicationMapsFixture applicationMapsFixture)
        {
            _mapperService = applicationMapsFixture.GetService<AutoMapperMapperService>();
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromPopulatedTeamDataEntity_ExpectPopulatedTeamEntity()
        {
            // Arrange
            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue()));
            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity());
            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            // Initialise data entities using unique non-default dummy values to verify mappings
            const int teamDataEntityId = 1;
            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
            teamDataEntity.Name.Shared = "UnitTest";
            teamDataEntity.LastPosition = 11;
            teamDataEntity.LastPoints = 12;
            teamDataEntity.DebutGrandPrix = 13;
            teamDataEntity.DebutYear = 14;
            teamDataEntity.Wins = 15;
            teamDataEntity.YearlyBudget = 16;
            teamDataEntity.UnknownA = 17;
            teamDataEntity.Location = 18;
            teamDataEntity.LocationX = 19;
            teamDataEntity.LocationY = 20;
            teamDataEntity.TyreSupplier = 21;

            const int chassisHandlingDataEntityId = 2;
            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
            chassisHandlingDataEntity.Value = 22;

            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
            carNumbersObject.CarNumberDriver1 = 23;
            carNumbersObject.CarNumberDriver2 = 24;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
            teamEntity.TeamId = teamDataEntity.Id + 1;
            teamEntity.Name = teamDataEntity.Name.Shared;
            teamEntity.LastPosition = teamDataEntity.LastPosition;
            teamEntity.LastPoints = teamDataEntity.LastPoints;
            teamEntity.DebutGrandPrix = teamDataEntity.DebutGrandPrix;
            teamEntity.DebutYear = teamDataEntity.DebutYear;
            teamEntity.Wins = teamDataEntity.Wins;
            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
            teamEntity.Location = teamDataEntity.Location;
            teamEntity.LocationX = teamDataEntity.LocationX;
            teamEntity.LocationY = teamDataEntity.LocationY;
            teamEntity.TyreSupplier = teamDataEntity.TyreSupplier;
            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

            // Act
            var sut = teamEntityFactory.Create(teamEntity.Id);
            _mapperService.Map(teamDataEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(teamEntity.Id);
            sut.Name.Should().Be(teamDataEntity.Name.Shared);
            sut.LastPosition.Should().Be(teamDataEntity.LastPosition);
            sut.LastPoints.Should().Be(teamDataEntity.LastPoints);
            sut.DebutGrandPrix.Should().Be(teamDataEntity.DebutGrandPrix);
            sut.DebutYear.Should().Be(teamDataEntity.DebutYear);
            sut.Wins.Should().Be(teamDataEntity.Wins);
            sut.YearlyBudget.Should().Be(teamDataEntity.YearlyBudget);
            sut.Location.Should().Be(teamDataEntity.Location);
            sut.LocationX.Should().Be(teamDataEntity.LocationX);
            sut.LocationY.Should().Be(teamDataEntity.LocationY);
            sut.TyreSupplier.Should().Be(teamDataEntity.TyreSupplier);
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromPopulatedChassisHandlingDataEntity_ExpectPopulatedTeamEntity()
        {
            // Arrange
            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            const int chassisHandlingDataEntityId = 2;
            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
            chassisHandlingDataEntity.Value = 22;

            // Act
            const int teamEntityId = 1;
            var sut = teamEntityFactory.Create(teamEntityId);
            _mapperService.Map(chassisHandlingDataEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.ChassisHandling.Should().Be(chassisHandlingDataEntity.Value);
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromPopulatedCarNumbersObject_ExpectPopulatedTeamEntity()
        {
            // Arrange
            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            const int teamDataEntityId = 1;
            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
            carNumbersObject.CarNumberDriver1 = 23;
            carNumbersObject.CarNumberDriver2 = 24;

            // Act
            const int teamEntityId = 1;
            var sut = teamEntityFactory.Create(teamEntityId);
            _mapperService.Map(carNumbersObject, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.CarNumberDriver1.Should().Be(carNumbersObject.CarNumberDriver1);
            sut.CarNumberDriver2.Should().Be(carNumbersObject.CarNumberDriver2);
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromThreeSourcesToOne_ExpectPopulatedTeamEntity()
        {
            // Arrange
            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue()));
            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity());
            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            // Initialise data entities using unique non-default dummy values to verify mappings
            const int teamDataEntityId = 1;
            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
            teamDataEntity.Name.Shared = "UnitTest";
            teamDataEntity.LastPosition = 11;
            teamDataEntity.LastPoints = 12;
            teamDataEntity.DebutGrandPrix = 13;
            teamDataEntity.DebutYear = 14;
            teamDataEntity.Wins = 15;
            teamDataEntity.YearlyBudget = 16;
            teamDataEntity.UnknownA = 17;
            teamDataEntity.Location = 18;
            teamDataEntity.LocationX = 19;
            teamDataEntity.LocationY = 20;
            teamDataEntity.TyreSupplier = 21;

            const int chassisHandlingDataEntityId = 2;
            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
            chassisHandlingDataEntity.Value = 22;

            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
            carNumbersObject.CarNumberDriver1 = 23;
            carNumbersObject.CarNumberDriver2 = 24;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
            teamEntity.TeamId = teamDataEntity.Id + 1;
            teamEntity.Name = teamDataEntity.Name.Shared;
            teamEntity.LastPosition = teamDataEntity.LastPosition;
            teamEntity.LastPoints = teamDataEntity.LastPoints;
            teamEntity.DebutGrandPrix = teamDataEntity.DebutGrandPrix;
            teamEntity.DebutYear = teamDataEntity.DebutYear;
            teamEntity.Wins = teamDataEntity.Wins;
            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
            teamEntity.Location = teamDataEntity.Location;
            teamEntity.LocationX = teamDataEntity.LocationX;
            teamEntity.LocationY = teamDataEntity.LocationY;
            teamEntity.TyreSupplier = teamDataEntity.TyreSupplier;
            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

            // Act
            var sut = teamEntityFactory.Create(teamEntity.Id);
            _mapperService.Map(teamDataEntity, sut);
            _mapperService.Map(chassisHandlingDataEntity, sut);
            _mapperService.Map(carNumbersObject, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(teamEntity.Id);
            sut.Name.Should().Be(teamDataEntity.Name.Shared);
            sut.LastPosition.Should().Be(teamDataEntity.LastPosition);
            sut.LastPoints.Should().Be(teamDataEntity.LastPoints);
            sut.DebutGrandPrix.Should().Be(teamDataEntity.DebutGrandPrix);
            sut.DebutYear.Should().Be(teamDataEntity.DebutYear);
            sut.Wins.Should().Be(teamDataEntity.Wins);
            sut.YearlyBudget.Should().Be(teamDataEntity.YearlyBudget);
            sut.Location.Should().Be(teamDataEntity.Location);
            sut.LocationX.Should().Be(teamDataEntity.LocationX);
            sut.LocationY.Should().Be(teamDataEntity.LocationY);
            sut.TyreSupplier.Should().Be(teamDataEntity.TyreSupplier);
            sut.ChassisHandling.Should().Be(chassisHandlingDataEntity.Value);
            sut.CarNumberDriver1.Should().Be(carNumbersObject.CarNumberDriver1);
            sut.CarNumberDriver2.Should().Be(carNumbersObject.CarNumberDriver2);
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedTeamDataEntity()
        {
            // Arrange
            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue()));
            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity());
            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            // Initialise data entities using unique non-default dummy values to verify mappings
            const int teamDataEntityId = 1;
            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
            teamDataEntity.Name.Shared = "UnitTest";
            teamDataEntity.LastPosition = 11;
            teamDataEntity.LastPoints = 12;
            teamDataEntity.DebutGrandPrix = 13;
            teamDataEntity.DebutYear = 14;
            teamDataEntity.Wins = 15;
            teamDataEntity.YearlyBudget = 16;
            teamDataEntity.UnknownA = 17;
            teamDataEntity.Location = 18;
            teamDataEntity.LocationX = 19;
            teamDataEntity.LocationY = 20;
            teamDataEntity.TyreSupplier = 21;

            const int chassisHandlingDataEntityId = 2;
            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
            chassisHandlingDataEntity.Value = 22;

            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
            carNumbersObject.CarNumberDriver1 = 23;
            carNumbersObject.CarNumberDriver2 = 24;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
            teamEntity.TeamId = teamDataEntity.Id + 1;
            teamEntity.Name = teamDataEntity.Name.Shared;
            teamEntity.LastPosition = teamDataEntity.LastPosition;
            teamEntity.LastPoints = teamDataEntity.LastPoints;
            teamEntity.DebutGrandPrix = teamDataEntity.DebutGrandPrix;
            teamEntity.DebutYear = teamDataEntity.DebutYear;
            teamEntity.Wins = teamDataEntity.Wins;
            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
            teamEntity.Location = teamDataEntity.Location;
            teamEntity.LocationX = teamDataEntity.LocationX;
            teamEntity.LocationY = teamDataEntity.LocationY;
            teamEntity.TyreSupplier = teamDataEntity.TyreSupplier;
            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

            // Act
            var newTeamDataEntity = teamDataEntityFactory.Create(teamDataEntity.Id);
            var sut = _mapperService.Map(teamEntity, newTeamDataEntity);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(teamDataEntity.Id);
            sut.Name.Shared.Should().Be(teamEntity.Name);
            sut.LastPosition.Should().Be(teamEntity.LastPosition);
            sut.LastPoints.Should().Be(teamEntity.LastPoints);
            sut.DebutGrandPrix.Should().Be(teamEntity.DebutGrandPrix);
            sut.DebutYear.Should().Be(teamEntity.DebutYear);
            sut.Wins.Should().Be(teamEntity.Wins);
            sut.YearlyBudget.Should().Be(teamEntity.YearlyBudget);
            sut.Location.Should().Be(teamEntity.Location);
            sut.LocationX.Should().Be(teamEntity.LocationX);
            sut.LocationY.Should().Be(teamEntity.LocationY);
            sut.TyreSupplier.Should().Be(teamEntity.TyreSupplier);
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedChassisHandlingDataEntity()
        {
            // Arrange
            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue()));
            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity());
            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            // Initialise data entities using unique non-default dummy values to verify mappings
            const int teamDataEntityId = 1;
            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
            teamDataEntity.Name.Shared = "UnitTest";
            teamDataEntity.LastPosition = 11;
            teamDataEntity.LastPoints = 12;
            teamDataEntity.DebutGrandPrix = 13;
            teamDataEntity.DebutYear = 14;
            teamDataEntity.Wins = 15;
            teamDataEntity.YearlyBudget = 16;
            teamDataEntity.UnknownA = 17;
            teamDataEntity.Location = 18;
            teamDataEntity.LocationX = 19;
            teamDataEntity.LocationY = 20;
            teamDataEntity.TyreSupplier = 21;

            const int chassisHandlingDataEntityId = 2;
            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
            chassisHandlingDataEntity.Value = 22;

            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
            carNumbersObject.CarNumberDriver1 = 23;
            carNumbersObject.CarNumberDriver2 = 24;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
            teamEntity.TeamId = teamDataEntity.Id + 1;
            teamEntity.Name = teamDataEntity.Name.Shared;
            teamEntity.LastPosition = teamDataEntity.LastPosition;
            teamEntity.LastPoints = teamDataEntity.LastPoints;
            teamEntity.DebutGrandPrix = teamDataEntity.DebutGrandPrix;
            teamEntity.DebutYear = teamDataEntity.DebutYear;
            teamEntity.Wins = teamDataEntity.Wins;
            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
            teamEntity.Location = teamDataEntity.Location;
            teamEntity.LocationX = teamDataEntity.LocationX;
            teamEntity.LocationY = teamDataEntity.LocationY;
            teamEntity.TyreSupplier = teamDataEntity.TyreSupplier;
            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

            // Act
            var newChassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntity.Id);
            var sut = _mapperService.Map(teamEntity, newChassisHandlingDataEntity);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(chassisHandlingDataEntity.Id);
            sut.Value.Should().Be(teamEntity.ChassisHandling);
        }

        [Fact]
        public void TeamDataEntityOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedCarNumbersObject()
        {
            // Arrange
            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue()));
            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity());
            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject());
            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity());

            // Initialise data entities using unique non-default dummy values to verify mappings
            const int teamDataEntityId = 1;
            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
            teamDataEntity.Name.Shared = "UnitTest";
            teamDataEntity.LastPosition = 11;
            teamDataEntity.LastPoints = 12;
            teamDataEntity.DebutGrandPrix = 13;
            teamDataEntity.DebutYear = 14;
            teamDataEntity.Wins = 15;
            teamDataEntity.YearlyBudget = 16;
            teamDataEntity.UnknownA = 17;
            teamDataEntity.Location = 18;
            teamDataEntity.LocationX = 19;
            teamDataEntity.LocationY = 20;
            teamDataEntity.TyreSupplier = 21;

            const int chassisHandlingDataEntityId = 2;
            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
            chassisHandlingDataEntity.Value = 22;

            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
            carNumbersObject.CarNumberDriver1 = 23;
            carNumbersObject.CarNumberDriver2 = 24;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
            teamEntity.TeamId = teamDataEntity.Id + 1;
            teamEntity.Name = teamDataEntity.Name.Shared;
            teamEntity.LastPosition = teamDataEntity.LastPosition;
            teamEntity.LastPoints = teamDataEntity.LastPoints;
            teamEntity.DebutGrandPrix = teamDataEntity.DebutGrandPrix;
            teamEntity.DebutYear = teamDataEntity.DebutYear;
            teamEntity.Wins = teamDataEntity.Wins;
            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
            teamEntity.Location = teamDataEntity.Location;
            teamEntity.LocationX = teamDataEntity.LocationX;
            teamEntity.LocationY = teamDataEntity.LocationY;
            teamEntity.TyreSupplier = teamDataEntity.TyreSupplier;
            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

            // Act
            var newCarNumbersObject = carNumbersObjectFactory.Create(teamEntity.Id);
            var sut = _mapperService.Map(teamEntity, newCarNumbersObject);

            // Assert
            sut.Should().NotBeNull();
            sut.CarNumberDriver1.Should().Be(teamEntity.CarNumberDriver1);
            sut.CarNumberDriver2.Should().Be(teamEntity.CarNumberDriver2);
        }
    }
}
