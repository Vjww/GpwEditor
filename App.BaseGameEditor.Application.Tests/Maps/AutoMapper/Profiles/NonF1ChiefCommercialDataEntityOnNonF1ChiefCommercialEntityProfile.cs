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
    public class NonF1ChiefCommercialDataEntityOnNonF1ChiefCommercialEntityProfile
    {
        private readonly AutoMapperMapperService _mapperService;

        public NonF1ChiefCommercialDataEntityOnNonF1ChiefCommercialEntityProfile(ApplicationMapsFixture applicationMapsFixture)
        {
            _mapperService = applicationMapsFixture.GetService<AutoMapperMapperService>();
        }

        [Fact]
        public void NonF1ChiefCommercialDataEntityOnNonF1ChiefCommercialEntityProfile_WhenMappingFromPopulatedNonF1ChiefCommercialDataEntity_ExpectPopulatedNonF1ChiefCommercialEntity()
        {
            // Arrange
            var personDataEntityFactory = new IntegerIdentityFactory<NonF1ChiefCommercialDataEntity>(() => new NonF1ChiefCommercialDataEntity(new LanguageCatalogueValue()));
            var personEntityFactory = new IntegerIdentityFactory<NonF1ChiefCommercialEntity>(() => new NonF1ChiefCommercialEntity());

            // Initialise using unique non-default dummy values to verify mappings
            const int personDataEntityId = 42;
            var personDataEntity = personDataEntityFactory.Create(personDataEntityId);
            personDataEntity.Name.Shared = "UnitTest";
            personDataEntity.Ability = 2;
            personDataEntity.Age = 3;
            personDataEntity.Salary = 4;
            personDataEntity.Royalty = 5;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personEntity = personEntityFactory.Create(personDataEntity.Id);
            personEntity.Name = personDataEntity.Name.Shared;
            personEntity.Ability = personDataEntity.Ability;
            personEntity.Age = personDataEntity.Age;
            personEntity.Salary = personDataEntity.Salary;
            personEntity.Royalty = personDataEntity.Royalty;

            // Act
            var sut = personEntityFactory.Create(personEntity.Id);
            _mapperService.Map(personDataEntity, sut);

            // Assert
            sut.Should().NotBeNull();
            sut.Id.Should().Be(personEntity.Id);
            sut.Name.Should().Be(personEntity.Name);
            sut.Ability.Should().Be(personEntity.Ability);
            sut.Age.Should().Be(personEntity.Age);
            sut.Salary.Should().Be(personEntity.Salary);
            sut.Royalty.Should().Be(personEntity.Royalty);
        }

        [Fact]
        public void NonF1ChiefCommercialDataEntityOnNonF1ChiefCommercialEntityProfile_WhenMappingFromPopulatedNonF1ChiefCommercialEntity_ExpectPopulatedNonF1ChiefCommercialDataEntity()
        {
            // Arrange
            var personEntityFactory = new IntegerIdentityFactory<NonF1ChiefCommercialEntity>(() => new NonF1ChiefCommercialEntity());
            var personDataEntityFactory = new IntegerIdentityFactory<NonF1ChiefCommercialDataEntity>(() => new NonF1ChiefCommercialDataEntity(new LanguageCatalogueValue()));

            // Initialise using unique non-default dummy values to verify mappings
            const int personEntityId = 42;
            var personEntity = personEntityFactory.Create(personEntityId);
            personEntity.Name = "UnitTest";
            personEntity.Ability = 2;
            personEntity.Age = 3;
            personEntity.Salary = 4;
            personEntity.Royalty = 5;

            // Initialise using values used in earlier initialisation to verify reverse mappings
            var personDataEntity = personDataEntityFactory.Create(personEntity.Id);
            personDataEntity.Name.Shared = personEntity.Name;
            personDataEntity.Ability = personEntity.Ability;
            personDataEntity.Age = personEntity.Age;
            personDataEntity.Salary = personEntity.Salary;
            personDataEntity.Royalty = personEntity.Royalty;

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
            sut.Royalty.Should().Be(personDataEntity.Royalty);
        }
    }
}
