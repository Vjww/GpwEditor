using App.BaseGameEditor.Application.Tests.Fixtures;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Factories;
using App.Shared.Data.Catalogues.Language;
using App.Shared.Infrastructure.Services;
using FluentAssertions;
using Xunit;

namespace App.BaseGameEditor.Application.Tests.Maps.AutoMapper.Profiles
{
    [Collection("Application Maps Collection")]
    public class F1DriverDataEntityOnF1DriverEntityProfile
    {
        private readonly AutoMapperMapperService _mapperService;

        public F1DriverDataEntityOnF1DriverEntityProfile(ApplicationMapsFixture applicationMapsFixture)
        {
            _mapperService = applicationMapsFixture.GetService<AutoMapperMapperService>();
        }

        [Fact]
        public void F1DriverDataEntityOnF1DriverEntityProfile_WhenMappingFromPopulatedF1DriverDataEntity_ExpectPopulatedF1DriverEntity()
        {
            // Arrange
            var personDataEntityFactory = new IntegerIdentityFactory<F1DriverDataEntity>(() => new F1DriverDataEntity(new LanguageCatalogueValue()));
            var personEntityFactory = new IntegerIdentityFactory<F1DriverEntity>(() => new F1DriverEntity());

            // Initialise using unique non-default dummy values to verify mappings
            const int personDataEntityId = 42;
            var personDataEntity = personDataEntityFactory.Create(personDataEntityId);
            personDataEntity.Name.Shared = "UnitTest";
            personDataEntity.Salary = -7600000;
            personDataEntity.RaceBonus = 3;
            personDataEntity.ChampionshipBonus = 4;
            personDataEntity.PayRating = 4;
            personDataEntity.PositiveSalary = 7600000;
            personDataEntity.LastChampionshipPosition = 7;
            personDataEntity.Role = 8;
            personDataEntity.Age = 9;
            personDataEntity.Nationality = 10;
            personDataEntity.CareerChampionships = 11;
            personDataEntity.CareerRaces = 12;
            personDataEntity.CareerWins = 13;
            personDataEntity.CareerPoints = 14;
            personDataEntity.CareerFastestLaps = 15;
            personDataEntity.CareerPointsFinishes = 16;
            personDataEntity.CareerPolePositions = 17;
            personDataEntity.Speed = 18;
            personDataEntity.Skill = 19;
            personDataEntity.Overtaking = 20;
            personDataEntity.WetWeather = 21;
            personDataEntity.Concentration = 22;
            personDataEntity.Experience = 23;
            personDataEntity.Stamina = 24;
            personDataEntity.Morale = 40; // Consumed by a value resolver

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personEntity = personEntityFactory.Create(personDataEntity.Id);
            personEntity.TeamId = 15; // Calculated by a value resolver
            personEntity.Name = personDataEntity.Name.Shared;
            personEntity.Salary = personDataEntity.Salary;
            personEntity.RaceBonus = personDataEntity.RaceBonus;
            personEntity.ChampionshipBonus = personDataEntity.ChampionshipBonus;
            personEntity.PayRating = personDataEntity.PayRating;
            personEntity.PositiveSalary = personDataEntity.PositiveSalary;
            personEntity.LastChampionshipPosition = personDataEntity.LastChampionshipPosition;
            personEntity.Role = personDataEntity.Role;
            personEntity.Age = personDataEntity.Age;
            personEntity.Nationality = personDataEntity.Nationality;
            personEntity.CareerChampionships = personDataEntity.CareerChampionships;
            personEntity.CareerRaces = personDataEntity.CareerRaces;
            personEntity.CareerWins = personDataEntity.CareerWins;
            personEntity.CareerPoints = personDataEntity.CareerPoints;
            personEntity.CareerFastestLaps = personDataEntity.CareerFastestLaps;
            personEntity.CareerPointsFinishes = personDataEntity.CareerPointsFinishes;
            personEntity.CareerPolePositions = personDataEntity.CareerPolePositions;
            personEntity.Speed = personDataEntity.Speed;
            personEntity.Skill = personDataEntity.Skill;
            personEntity.Overtaking = personDataEntity.Overtaking;
            personEntity.WetWeather = personDataEntity.WetWeather;
            personEntity.Concentration = personDataEntity.Concentration;
            personEntity.Experience = personDataEntity.Experience;
            personEntity.Stamina = personDataEntity.Stamina;
            personEntity.Morale = 2; // Calculated by a value resolver

            // Act
            var sut = personEntityFactory.Create(personEntity.Id);
            _mapperService.Map(personDataEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(personEntity.Id);
            sut.TeamId.Should().Be(personEntity.TeamId);
            sut.Name.Should().Be(personEntity.Name);
            sut.Salary.Should().Be(personEntity.Salary);
            sut.RaceBonus.Should().Be(personEntity.RaceBonus);
            sut.ChampionshipBonus.Should().Be(personEntity.ChampionshipBonus);
            sut.PayRating.Should().Be(personEntity.PayRating);
            sut.PositiveSalary.Should().Be(personEntity.PositiveSalary);
            sut.LastChampionshipPosition.Should().Be(personEntity.LastChampionshipPosition);
            sut.Role.Should().Be(personEntity.Role);
            sut.Age.Should().Be(personEntity.Age);
            sut.Nationality.Should().Be(personEntity.Nationality);
            sut.CareerChampionships.Should().Be(personEntity.CareerChampionships);
            sut.CareerRaces.Should().Be(personEntity.CareerRaces);
            sut.CareerWins.Should().Be(personEntity.CareerWins);
            sut.CareerPoints.Should().Be(personEntity.CareerPoints);
            sut.CareerFastestLaps.Should().Be(personEntity.CareerFastestLaps);
            sut.CareerPointsFinishes.Should().Be(personEntity.CareerPointsFinishes);
            sut.CareerPolePositions.Should().Be(personEntity.CareerPolePositions);
            sut.Speed.Should().Be(personEntity.Speed);
            sut.Skill.Should().Be(personEntity.Skill);
            sut.Overtaking.Should().Be(personEntity.Overtaking);
            sut.WetWeather.Should().Be(personEntity.WetWeather);
            sut.Concentration.Should().Be(personEntity.Concentration);
            sut.Experience.Should().Be(personEntity.Experience);
            sut.Stamina.Should().Be(personEntity.Stamina);
            sut.Morale.Should().Be(personEntity.Morale);
        }

        [Fact]
        public void F1DriverDataEntityOnF1DriverEntityProfile_WhenMappingFromPopulatedF1DriverEntity_ExpectPopulatedF1DriverDataEntity()
        {
            // Arrange
            var personEntityFactory = new IntegerIdentityFactory<F1DriverEntity>(() => new F1DriverEntity());
            var personDataEntityFactory = new IntegerIdentityFactory<F1DriverDataEntity>(() => new F1DriverDataEntity(new LanguageCatalogueValue()));

            // Initialise using unique non-default dummy values to verify mappings
            const int personEntityId = 42;
            var personEntity = personEntityFactory.Create(personEntityId);
            personEntity.TeamId = 15;
            personEntity.Name = "UnitTest";
            personEntity.Salary = -7600000; // Consumed by a value resolver
            personEntity.RaceBonus = 3;
            personEntity.ChampionshipBonus = 4;
            personEntity.PayRating = 0; // Superseded by a value resolver
            personEntity.PositiveSalary = 0; // Superseded by a value resolver
            personEntity.LastChampionshipPosition = 7;
            personEntity.Role = 8;
            personEntity.Age = 9;
            personEntity.Nationality = 10;
            personEntity.CareerChampionships = 11;
            personEntity.CareerRaces = 12;
            personEntity.CareerWins = 13;
            personEntity.CareerPoints = 14;
            personEntity.CareerFastestLaps = 15;
            personEntity.CareerPointsFinishes = 16;
            personEntity.CareerPolePositions = 17;
            personEntity.Speed = 18;
            personEntity.Skill = 19;
            personEntity.Overtaking = 20;
            personEntity.WetWeather = 21;
            personEntity.Concentration = 22;
            personEntity.Experience = 23;
            personEntity.Stamina = 24;
            personEntity.Morale = 2; // Consumed by a value resolver

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personDataEntity = personDataEntityFactory.Create(personEntity.Id);
            personDataEntity.Name.Shared = personEntity.Name;
            personDataEntity.Salary = personEntity.Salary;
            personDataEntity.RaceBonus = personEntity.RaceBonus;
            personDataEntity.ChampionshipBonus = personEntity.ChampionshipBonus;
            personDataEntity.PayRating = 4; // Calculated by a value resolver
            personDataEntity.PositiveSalary = 7600000; // Calculated by a value resolver
            personDataEntity.LastChampionshipPosition = personEntity.LastChampionshipPosition;
            personDataEntity.Role = personEntity.Role;
            personDataEntity.Age = personEntity.Age;
            personDataEntity.Nationality = personEntity.Nationality;
            personDataEntity.CareerChampionships = personEntity.CareerChampionships;
            personDataEntity.CareerRaces = personEntity.CareerRaces;
            personDataEntity.CareerWins = personEntity.CareerWins;
            personDataEntity.CareerPoints = personEntity.CareerPoints;
            personDataEntity.CareerFastestLaps = personEntity.CareerFastestLaps;
            personDataEntity.CareerPointsFinishes = personEntity.CareerPointsFinishes;
            personDataEntity.CareerPolePositions = personEntity.CareerPolePositions;
            personDataEntity.Speed = personEntity.Speed;
            personDataEntity.Skill = personEntity.Skill;
            personDataEntity.Overtaking = personEntity.Overtaking;
            personDataEntity.WetWeather = personEntity.WetWeather;
            personDataEntity.Concentration = personEntity.Concentration;
            personDataEntity.Experience = personEntity.Experience;
            personDataEntity.Stamina = personEntity.Stamina;
            personDataEntity.Morale = 40; // Calculated by a value resolver

            // Act
            var sut = personDataEntityFactory.Create(personDataEntity.Id);
            _mapperService.Map(personEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(personDataEntity.Id);
            sut.Name.Shared.Should().Be(personDataEntity.Name.Shared);
            sut.Salary.Should().Be(personDataEntity.Salary);
            sut.RaceBonus.Should().Be(personDataEntity.RaceBonus);
            sut.ChampionshipBonus.Should().Be(personDataEntity.ChampionshipBonus);
            sut.PayRating.Should().Be(personDataEntity.PayRating);
            sut.PositiveSalary.Should().Be(personDataEntity.PositiveSalary);
            sut.LastChampionshipPosition.Should().Be(personDataEntity.LastChampionshipPosition);
            sut.Role.Should().Be(personDataEntity.Role);
            sut.Age.Should().Be(personDataEntity.Age);
            sut.Nationality.Should().Be(personDataEntity.Nationality);
            sut.CareerChampionships.Should().Be(personDataEntity.CareerChampionships);
            sut.CareerRaces.Should().Be(personDataEntity.CareerRaces);
            sut.CareerWins.Should().Be(personDataEntity.CareerWins);
            sut.CareerPoints.Should().Be(personDataEntity.CareerPoints);
            sut.CareerFastestLaps.Should().Be(personDataEntity.CareerFastestLaps);
            sut.CareerPointsFinishes.Should().Be(personDataEntity.CareerPointsFinishes);
            sut.CareerPolePositions.Should().Be(personDataEntity.CareerPolePositions);
            sut.Speed.Should().Be(personDataEntity.Speed);
            sut.Skill.Should().Be(personDataEntity.Skill);
            sut.Overtaking.Should().Be(personDataEntity.Overtaking);
            sut.WetWeather.Should().Be(personDataEntity.WetWeather);
            sut.Concentration.Should().Be(personDataEntity.Concentration);
            sut.Experience.Should().Be(personDataEntity.Experience);
            sut.Stamina.Should().Be(personDataEntity.Stamina);
            sut.Morale.Should().Be(personDataEntity.Morale);
        }
    }
}
