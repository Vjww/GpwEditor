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
    public class NonF1DriverDataEntityOnNonF1DriverEntityProfile
    {
        private readonly AutoMapperMapperService _mapperService;

        public NonF1DriverDataEntityOnNonF1DriverEntityProfile(ApplicationMapsFixture applicationMapsFixture)
        {
            _mapperService = applicationMapsFixture.GetService<AutoMapperMapperService>();
        }

        [Fact]
        public void NonF1DriverDataEntityOnNonF1DriverEntityProfile_WhenMappingFromPopulatedNonF1DriverDataEntity_ExpectPopulatedNonF1DriverEntity()
        {
            // Arrange
            var personDataEntityFactory = new IntegerIdentityFactory<NonF1DriverDataEntity>(() => new NonF1DriverDataEntity(new LanguageCatalogueValue()));
            var personEntityFactory = new IntegerIdentityFactory<NonF1DriverEntity>(() => new NonF1DriverEntity());

            // Initialise using unique non-default dummy values to verify mappings
            const int personDataEntityId = 42;
            var personDataEntity = personDataEntityFactory.Create(personDataEntityId);
            personDataEntity.Name.Shared = "UnitTest";
            personDataEntity.Salary = 2;
            personDataEntity.RaceBonus = 3;
            personDataEntity.ChampionshipBonus = 4;
            personDataEntity.Age = 5;
            personDataEntity.Nationality = 6;
            personDataEntity.UnknownA = 7;
            personDataEntity.Speed = 8;
            personDataEntity.Skill = 9;
            personDataEntity.Overtaking = 10;
            personDataEntity.WetWeather = 11;
            personDataEntity.Concentration = 12;
            personDataEntity.Experience = 13;
            personDataEntity.Stamina = 14;
            personDataEntity.Morale = 15;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personEntity = personEntityFactory.Create(personDataEntity.Id);
            personEntity.Name = personDataEntity.Name.Shared;
            personEntity.Salary = personDataEntity.Salary;
            personEntity.RaceBonus = personDataEntity.RaceBonus;
            personEntity.ChampionshipBonus = personDataEntity.ChampionshipBonus;
            personEntity.Age = personDataEntity.Age;
            personEntity.Nationality = personDataEntity.Nationality;
            personEntity.UnknownA = personDataEntity.UnknownA;
            personEntity.Speed = personDataEntity.Speed;
            personEntity.Skill = personDataEntity.Skill;
            personEntity.Overtaking = personDataEntity.Overtaking;
            personEntity.WetWeather = personDataEntity.WetWeather;
            personEntity.Concentration = personDataEntity.Concentration;
            personEntity.Experience = personDataEntity.Experience;
            personEntity.Stamina = personDataEntity.Stamina;
            personEntity.Morale = personDataEntity.Morale;

            // Act
            var sut = personEntityFactory.Create(personEntity.Id);
            _mapperService.Map(personDataEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(personEntity.Id);
            sut.Name.Should().Be(personEntity.Name);
            sut.Salary.Should().Be(personEntity.Salary);
            sut.RaceBonus.Should().Be(personEntity.RaceBonus);
            sut.ChampionshipBonus.Should().Be(personEntity.ChampionshipBonus);
            sut.Age.Should().Be(personEntity.Age);
            sut.Nationality.Should().Be(personEntity.Nationality);
            sut.UnknownA.Should().Be(personEntity.UnknownA);
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
        public void NonF1DriverDataEntityOnNonF1DriverEntityProfile_WhenMappingFromPopulatedNonF1DriverEntity_ExpectPopulatedNonF1DriverDataEntity()
        {
            // Arrange
            var personEntityFactory = new IntegerIdentityFactory<NonF1DriverEntity>(() => new NonF1DriverEntity());
            var personDataEntityFactory = new IntegerIdentityFactory<NonF1DriverDataEntity>(() => new NonF1DriverDataEntity(new LanguageCatalogueValue()));

            // Initialise using unique non-default dummy values to verify mappings
            const int personEntityId = 42;
            var personEntity = personEntityFactory.Create(personEntityId);
            personEntity.Name = "UnitTest";
            personEntity.Salary = 2;
            personEntity.RaceBonus = 3;
            personEntity.ChampionshipBonus = 4;
            personEntity.Age = 5;
            personEntity.Nationality = 6;
            personEntity.UnknownA = 7;
            personEntity.Speed = 8;
            personEntity.Skill = 9;
            personEntity.Overtaking = 10;
            personEntity.WetWeather = 11;
            personEntity.Concentration = 12;
            personEntity.Experience = 13;
            personEntity.Stamina = 14;
            personEntity.Morale = 15;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personDataEntity = personDataEntityFactory.Create(personEntity.Id);
            personDataEntity.Name.Shared = personEntity.Name;
            personDataEntity.Salary = personEntity.Salary;
            personDataEntity.RaceBonus = personEntity.RaceBonus;
            personDataEntity.ChampionshipBonus = personEntity.ChampionshipBonus;
            personDataEntity.Age = personEntity.Age;
            personDataEntity.Nationality = personEntity.Nationality;
            personDataEntity.UnknownA = personEntity.UnknownA;
            personDataEntity.Speed = personEntity.Speed;
            personDataEntity.Skill = personEntity.Skill;
            personDataEntity.Overtaking = personEntity.Overtaking;
            personDataEntity.WetWeather = personEntity.WetWeather;
            personDataEntity.Concentration = personEntity.Concentration;
            personDataEntity.Experience = personEntity.Experience;
            personDataEntity.Stamina = personEntity.Stamina;
            personDataEntity.Morale = personEntity.Morale;

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
            sut.Age.Should().Be(personDataEntity.Age);
            sut.Nationality.Should().Be(personDataEntity.Nationality);
            sut.UnknownA.Should().Be(personDataEntity.UnknownA);
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
