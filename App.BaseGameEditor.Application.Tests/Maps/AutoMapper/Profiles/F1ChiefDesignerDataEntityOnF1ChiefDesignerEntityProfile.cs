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
    public class F1ChiefDesignerDataEntityOnF1ChiefDesignerEntityProfile
    {
        private readonly AutoMapperMapperService _mapperService;

        public F1ChiefDesignerDataEntityOnF1ChiefDesignerEntityProfile(ApplicationMapsFixture applicationMapsFixture)
        {
            _mapperService = applicationMapsFixture.GetService<AutoMapperMapperService>();
        }

        [Fact]
        public void F1ChiefDesignerDataEntityOnF1ChiefDesignerEntityProfile_WhenMappingFromPopulatedF1ChiefDesignerDataEntity_ExpectPopulatedF1ChiefDesignerEntity()
        {
            // Arrange
            var personDataEntityFactory = new IntegerIdentityFactory<F1ChiefDesignerDataEntity>(() => new F1ChiefDesignerDataEntity(new LanguageCatalogueValue()));
            var personEntityFactory = new IntegerIdentityFactory<F1ChiefDesignerEntity>(() => new F1ChiefDesignerEntity());

            // Initialise using unique non-default dummy values to verify mappings
            const int personDataEntityId = 42;
            var personDataEntity = personDataEntityFactory.Create(personDataEntityId);
            personDataEntity.Name.Shared = "UnitTest";
            personDataEntity.Ability = 2;
            personDataEntity.Age = 3;
            personDataEntity.Salary = 4;
            personDataEntity.RaceBonus = 5;
            personDataEntity.ChampionshipBonus = 6;
            personDataEntity.DriverLoyalty = 7;
            personDataEntity.Morale = 40; // Consumed by a value resolver

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personEntity = personEntityFactory.Create(personDataEntity.Id);
            personEntity.TeamId = 43; // Calculated by a value resolver
            personEntity.Name = personDataEntity.Name.Shared;
            personEntity.Ability = personDataEntity.Ability;
            personEntity.Age = personDataEntity.Age;
            personEntity.Salary = personDataEntity.Salary;
            personEntity.RaceBonus = personDataEntity.RaceBonus;
            personEntity.ChampionshipBonus = personDataEntity.ChampionshipBonus;
            personEntity.DriverLoyalty = personDataEntity.DriverLoyalty;
            personEntity.Morale = 2; // Calculated by a value resolver

            // Act
            var sut = personEntityFactory.Create(personEntity.Id);
            _mapperService.Map(personDataEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(personEntity.Id);
            sut.TeamId.Should().Be(personEntity.TeamId);
            sut.Name.Should().Be(personEntity.Name);
            sut.Ability.Should().Be(personEntity.Ability);
            sut.Age.Should().Be(personEntity.Age);
            sut.Salary.Should().Be(personEntity.Salary);
            sut.RaceBonus.Should().Be(personEntity.RaceBonus);
            sut.ChampionshipBonus.Should().Be(personEntity.ChampionshipBonus);
            sut.DriverLoyalty.Should().Be(personEntity.DriverLoyalty);
            sut.Morale.Should().Be(personEntity.Morale);
        }

        [Fact]
        public void F1ChiefDesignerDataEntityOnF1ChiefDesignerEntityProfile_WhenMappingFromPopulatedF1ChiefDesignerEntity_ExpectPopulatedF1ChiefDesignerDataEntity()
        {
            // Arrange
            var personEntityFactory = new IntegerIdentityFactory<F1ChiefDesignerEntity>(() => new F1ChiefDesignerEntity());
            var personDataEntityFactory = new IntegerIdentityFactory<F1ChiefDesignerDataEntity>(() => new F1ChiefDesignerDataEntity(new LanguageCatalogueValue()));

            // Initialise using unique non-default dummy values to verify mappings
            const int personEntityId = 42;
            var personEntity = personEntityFactory.Create(personEntityId);
            personEntity.TeamId = 43;
            personEntity.Name = "UnitTest";
            personEntity.Ability = 2;
            personEntity.Age = 3;
            personEntity.Salary = 4;
            personEntity.RaceBonus = 5;
            personEntity.ChampionshipBonus = 6;
            personEntity.DriverLoyalty = 7;
            personEntity.Morale = 2; // Consumed by a value resolver

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personDataEntity = personDataEntityFactory.Create(personEntity.Id);
            personDataEntity.Name.Shared = personEntity.Name;
            personDataEntity.Ability = personEntity.Ability;
            personDataEntity.Age = personEntity.Age;
            personDataEntity.Salary = personEntity.Salary;
            personDataEntity.RaceBonus = personEntity.RaceBonus;
            personDataEntity.ChampionshipBonus = personEntity.ChampionshipBonus;
            personDataEntity.DriverLoyalty = personEntity.DriverLoyalty;
            personDataEntity.Morale = 40; // Calculated by a value resolver

            // Act
            var sut = personDataEntityFactory.Create(personDataEntity.Id);
            _mapperService.Map(personEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(personDataEntity.Id);
            sut.Name.Shared.Should().Be(personDataEntity.Name.Shared);
            sut.Ability.Should().Be(personDataEntity.Ability);
            sut.Age.Should().Be(personDataEntity.Age);
            sut.Salary.Should().Be(personDataEntity.Salary);
            sut.RaceBonus.Should().Be(personDataEntity.RaceBonus);
            sut.ChampionshipBonus.Should().Be(personDataEntity.ChampionshipBonus);
            sut.DriverLoyalty.Should().Be(personDataEntity.DriverLoyalty);
            sut.Morale.Should().Be(personDataEntity.Morale);
        }
    }
}
