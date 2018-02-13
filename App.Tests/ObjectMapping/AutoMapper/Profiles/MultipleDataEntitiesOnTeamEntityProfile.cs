// TODO: Resolve?
//using System.Collections.Generic;
//using App.BaseGameEditor.Data.Catalogues.Language;
//using App.BaseGameEditor.Data.DataEntities;
//using App.BaseGameEditor.Domain.Entities;
//using App.BaseGameEditor.Infrastructure.Factories;
//using App.BaseGameEditor.Infrastructure.Maps.AutoMapper;
//using App.BaseGameEditor.Infrastructure.Maps.Manual;
//using App.ObjectMapping.AutoMapper;
//using App.Services;
//using FluentAssertions;
//using Xunit;

//namespace App.Tests.ObjectMapping.AutoMapper.Profiles
//{
//    // TODO: Review if these unit tests are against the right class
//    public class MultipleDataEntitiesOnTeamEntityProfile
//    {
//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamDataEntity_ExpectPopulatedTeamEntity()
//        {
//            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue())); // TODO: Mock it
//            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity()); // TODO: Mock it
//            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            // Initialise data entities using unique non-default dummy values to verify mappings
//            const int teamDataEntityId = 1;
//            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
//            teamDataEntity.Name.Shared = "UnitTest";
//            teamDataEntity.LastPosition = 11;
//            teamDataEntity.LastPoints = 12;
//            teamDataEntity.FirstGpTrack = 13;
//            teamDataEntity.FirstGpYear = 14;
//            teamDataEntity.Wins = 15;
//            teamDataEntity.YearlyBudget = 16;
//            teamDataEntity.UnknownA = 17;
//            teamDataEntity.CountryMapId = 18;
//            teamDataEntity.LocationPointerX = 19;
//            teamDataEntity.LocationPointerY = 20;
//            teamDataEntity.TyreSupplierId = 21;

//            const int chassisHandlingDataEntityId = 2;
//            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
//            chassisHandlingDataEntity.TeamId = 22;
//            chassisHandlingDataEntity.Value = 23;

//            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
//            carNumbersObject.CarNumberDriver1 = 24;
//            carNumbersObject.CarNumberDriver2 = 25;

//            // Initialise using values used in earlier initialisation to verify reverse mappings
//            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
//            teamEntity.TeamId = teamDataEntity.Id + 1;
//            teamEntity.Name = teamDataEntity.Name.Shared;
//            teamEntity.LastPosition = teamDataEntity.LastPosition;
//            teamEntity.LastPoints = teamDataEntity.LastPoints;
//            teamEntity.FirstGpTrack = teamDataEntity.FirstGpTrack;
//            teamEntity.FirstGpYear = teamDataEntity.FirstGpYear;
//            teamEntity.Wins = teamDataEntity.Wins;
//            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
//            teamEntity.CountryMapId = teamDataEntity.CountryMapId;
//            teamEntity.LocationPointerX = teamDataEntity.LocationPointerX;
//            teamEntity.LocationPointerY = teamDataEntity.LocationPointerY;
//            teamEntity.TyreSupplierId = teamDataEntity.TyreSupplierId;
//            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
//            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
//            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

//            var sut = teamEntityFactory.Create(teamEntity.Id);
//            mapper.Map(teamDataEntity, sut);

//            sut.Should().NotBeNull();
//            sut.Id.Should().Be(teamEntity.Id);
//            sut.Name.Should().Be(teamDataEntity.Name.Shared);
//            sut.LastPosition.Should().Be(teamDataEntity.LastPosition);
//            sut.LastPoints.Should().Be(teamDataEntity.LastPoints);
//            sut.FirstGpTrack.Should().Be(teamDataEntity.FirstGpTrack);
//            sut.FirstGpYear.Should().Be(teamDataEntity.FirstGpYear);
//            sut.Wins.Should().Be(teamDataEntity.Wins);
//            sut.YearlyBudget.Should().Be(teamDataEntity.YearlyBudget);
//            sut.CountryMapId.Should().Be(teamDataEntity.CountryMapId);
//            sut.LocationPointerX.Should().Be(teamDataEntity.LocationPointerX);
//            sut.LocationPointerY.Should().Be(teamDataEntity.LocationPointerY);
//            sut.TyreSupplierId.Should().Be(teamDataEntity.TyreSupplierId);
//        }

//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedChassisHandlingDataEntity_ExpectPopulatedTeamEntity()
//        {
//            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            const int chassisHandlingDataEntityId = 2;
//            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
//            chassisHandlingDataEntity.TeamId = 22;
//            chassisHandlingDataEntity.Value = 23;

//            const int teamEntityId = 1;
//            var sut = teamEntityFactory.Create(teamEntityId);
//            mapper.Map(chassisHandlingDataEntity, sut);

//            sut.Should().NotBeNull();
//            sut.ChassisHandling.Should().Be(chassisHandlingDataEntity.Value);
//        }

//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedCarNumbersObject_ExpectPopulatedTeamEntity()
//        {
//            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            const int teamDataEntityId = 1;
//            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
//            carNumbersObject.CarNumberDriver1 = 24;
//            carNumbersObject.CarNumberDriver2 = 25;

//            const int teamEntityId = 1;
//            var sut = teamEntityFactory.Create(teamEntityId);
//            mapper.Map(carNumbersObject, sut);

//            sut.Should().NotBeNull();
//            sut.CarNumberDriver1.Should().Be(carNumbersObject.CarNumberDriver1);
//            sut.CarNumberDriver2.Should().Be(carNumbersObject.CarNumberDriver2);
//        }

//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromThreeSourcesToOne_ExpectPopulatedTeamEntity()
//        {
//            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue())); // TODO: Mock it
//            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity()); // TODO: Mock it
//            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            // Initialise data entities using unique non-default dummy values to verify mappings
//            const int teamDataEntityId = 1;
//            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
//            teamDataEntity.Name.Shared = "UnitTest";
//            teamDataEntity.LastPosition = 11;
//            teamDataEntity.LastPoints = 12;
//            teamDataEntity.FirstGpTrack = 13;
//            teamDataEntity.FirstGpYear = 14;
//            teamDataEntity.Wins = 15;
//            teamDataEntity.YearlyBudget = 16;
//            teamDataEntity.UnknownA = 17;
//            teamDataEntity.CountryMapId = 18;
//            teamDataEntity.LocationPointerX = 19;
//            teamDataEntity.LocationPointerY = 20;
//            teamDataEntity.TyreSupplierId = 21;

//            const int chassisHandlingDataEntityId = 2;
//            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
//            chassisHandlingDataEntity.TeamId = 22;
//            chassisHandlingDataEntity.Value = 23;

//            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
//            carNumbersObject.CarNumberDriver1 = 24;
//            carNumbersObject.CarNumberDriver2 = 25;

//            // Initialise using values used in earlier initialisation to verify reverse mappings
//            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
//            teamEntity.TeamId = teamDataEntity.Id + 1;
//            teamEntity.Name = teamDataEntity.Name.Shared;
//            teamEntity.LastPosition = teamDataEntity.LastPosition;
//            teamEntity.LastPoints = teamDataEntity.LastPoints;
//            teamEntity.FirstGpTrack = teamDataEntity.FirstGpTrack;
//            teamEntity.FirstGpYear = teamDataEntity.FirstGpYear;
//            teamEntity.Wins = teamDataEntity.Wins;
//            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
//            teamEntity.CountryMapId = teamDataEntity.CountryMapId;
//            teamEntity.LocationPointerX = teamDataEntity.LocationPointerX;
//            teamEntity.LocationPointerY = teamDataEntity.LocationPointerY;
//            teamEntity.TyreSupplierId = teamDataEntity.TyreSupplierId;
//            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
//            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
//            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

//            var sut = teamEntityFactory.Create(teamEntity.Id);
//            mapper.Map(teamDataEntity, sut);
//            mapper.Map(chassisHandlingDataEntity, sut);
//            mapper.Map(carNumbersObject, sut);

//            sut.Should().NotBeNull();
//            sut.Id.Should().Be(teamEntity.Id);
//            sut.Name.Should().Be(teamDataEntity.Name.Shared);
//            sut.LastPosition.Should().Be(teamDataEntity.LastPosition);
//            sut.LastPoints.Should().Be(teamDataEntity.LastPoints);
//            sut.FirstGpTrack.Should().Be(teamDataEntity.FirstGpTrack);
//            sut.FirstGpYear.Should().Be(teamDataEntity.FirstGpYear);
//            sut.Wins.Should().Be(teamDataEntity.Wins);
//            sut.YearlyBudget.Should().Be(teamDataEntity.YearlyBudget);
//            sut.CountryMapId.Should().Be(teamDataEntity.CountryMapId);
//            sut.LocationPointerX.Should().Be(teamDataEntity.LocationPointerX);
//            sut.LocationPointerY.Should().Be(teamDataEntity.LocationPointerY);
//            sut.TyreSupplierId.Should().Be(teamDataEntity.TyreSupplierId);
//            sut.ChassisHandling.Should().Be(chassisHandlingDataEntity.Value);
//            sut.CarNumberDriver1.Should().Be(carNumbersObject.CarNumberDriver1);
//            sut.CarNumberDriver2.Should().Be(carNumbersObject.CarNumberDriver2);
//        }

//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedTeamDataEntity()
//        {
//            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue())); // TODO: Mock it
//            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity()); // TODO: Mock it
//            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            // Initialise data entities using unique non-default dummy values to verify mappings
//            const int teamDataEntityId = 1;
//            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
//            teamDataEntity.Name.Shared = "UnitTest";
//            teamDataEntity.LastPosition = 11;
//            teamDataEntity.LastPoints = 12;
//            teamDataEntity.FirstGpTrack = 13;
//            teamDataEntity.FirstGpYear = 14;
//            teamDataEntity.Wins = 15;
//            teamDataEntity.YearlyBudget = 16;
//            teamDataEntity.UnknownA = 17;
//            teamDataEntity.CountryMapId = 18;
//            teamDataEntity.LocationPointerX = 19;
//            teamDataEntity.LocationPointerY = 20;
//            teamDataEntity.TyreSupplierId = 21;

//            const int chassisHandlingDataEntityId = 2;
//            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
//            chassisHandlingDataEntity.TeamId = 22;
//            chassisHandlingDataEntity.Value = 23;

//            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
//            carNumbersObject.CarNumberDriver1 = 24;
//            carNumbersObject.CarNumberDriver2 = 25;

//            // Initialise using values used in earlier initialisation to verify reverse mappings
//            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
//            teamEntity.TeamId = teamDataEntity.Id + 1;
//            teamEntity.Name = teamDataEntity.Name.Shared;
//            teamEntity.LastPosition = teamDataEntity.LastPosition;
//            teamEntity.LastPoints = teamDataEntity.LastPoints;
//            teamEntity.FirstGpTrack = teamDataEntity.FirstGpTrack;
//            teamEntity.FirstGpYear = teamDataEntity.FirstGpYear;
//            teamEntity.Wins = teamDataEntity.Wins;
//            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
//            teamEntity.CountryMapId = teamDataEntity.CountryMapId;
//            teamEntity.LocationPointerX = teamDataEntity.LocationPointerX;
//            teamEntity.LocationPointerY = teamDataEntity.LocationPointerY;
//            teamEntity.TyreSupplierId = teamDataEntity.TyreSupplierId;
//            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
//            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
//            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

//            var newTeamDataEntity = teamDataEntityFactory.Create(teamDataEntity.Id);
//            var sut = mapper.Map(teamEntity, newTeamDataEntity);

//            sut.Should().NotBeNull();
//            sut.Id.Should().Be(teamDataEntity.Id);
//            sut.Name.Shared.Should().Be(teamEntity.Name);
//            sut.LastPosition.Should().Be(teamEntity.LastPosition);
//            sut.LastPoints.Should().Be(teamEntity.LastPoints);
//            sut.FirstGpTrack.Should().Be(teamEntity.FirstGpTrack);
//            sut.FirstGpYear.Should().Be(teamEntity.FirstGpYear);
//            sut.Wins.Should().Be(teamEntity.Wins);
//            sut.YearlyBudget.Should().Be(teamEntity.YearlyBudget);
//            sut.CountryMapId.Should().Be(teamEntity.CountryMapId);
//            sut.LocationPointerX.Should().Be(teamEntity.LocationPointerX);
//            sut.LocationPointerY.Should().Be(teamEntity.LocationPointerY);
//            sut.TyreSupplierId.Should().Be(teamEntity.TyreSupplierId);
//        }

//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedChassisHandlingDataEntity()
//        {
//            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue())); // TODO: Mock it
//            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity()); // TODO: Mock it
//            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            // Initialise data entities using unique non-default dummy values to verify mappings
//            const int teamDataEntityId = 1;
//            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
//            teamDataEntity.Name.Shared = "UnitTest";
//            teamDataEntity.LastPosition = 11;
//            teamDataEntity.LastPoints = 12;
//            teamDataEntity.FirstGpTrack = 13;
//            teamDataEntity.FirstGpYear = 14;
//            teamDataEntity.Wins = 15;
//            teamDataEntity.YearlyBudget = 16;
//            teamDataEntity.UnknownA = 17;
//            teamDataEntity.CountryMapId = 18;
//            teamDataEntity.LocationPointerX = 19;
//            teamDataEntity.LocationPointerY = 20;
//            teamDataEntity.TyreSupplierId = 21;

//            const int chassisHandlingDataEntityId = 2;
//            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
//            chassisHandlingDataEntity.TeamId = 22;
//            chassisHandlingDataEntity.Value = 23;

//            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
//            carNumbersObject.CarNumberDriver1 = 24;
//            carNumbersObject.CarNumberDriver2 = 25;

//            // Initialise using values used in earlier initialisation to verify reverse mappings
//            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
//            teamEntity.TeamId = teamDataEntity.Id + 1;
//            teamEntity.Name = teamDataEntity.Name.Shared;
//            teamEntity.LastPosition = teamDataEntity.LastPosition;
//            teamEntity.LastPoints = teamDataEntity.LastPoints;
//            teamEntity.FirstGpTrack = teamDataEntity.FirstGpTrack;
//            teamEntity.FirstGpYear = teamDataEntity.FirstGpYear;
//            teamEntity.Wins = teamDataEntity.Wins;
//            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
//            teamEntity.CountryMapId = teamDataEntity.CountryMapId;
//            teamEntity.LocationPointerX = teamDataEntity.LocationPointerX;
//            teamEntity.LocationPointerY = teamDataEntity.LocationPointerY;
//            teamEntity.TyreSupplierId = teamDataEntity.TyreSupplierId;
//            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
//            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
//            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

//            var newChassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntity.Id);
//            var sut = mapper.Map(teamEntity, newChassisHandlingDataEntity);

//            sut.Should().NotBeNull();
//            sut.Id.Should().Be(chassisHandlingDataEntity.Id);
//            sut.TeamId.Should().Be(teamEntity.Id);
//            sut.Value.Should().Be(teamEntity.ChassisHandling);
//        }

//        [Fact]
//        public void MultipleDataEntitiesOnTeamEntityProfile_WhenMappingFromPopulatedTeamEntity_ExpectPopulatedCarNumbersObject()
//        {
//            var teamDataEntityFactory = new IntegerIdentityFactory<TeamDataEntity>(() => new TeamDataEntity(new LanguageCatalogueValue())); // TODO: Mock it
//            var chassisHandlingDataEntityFactory = new IntegerIdentityFactory<ChassisHandlingDataEntity>(() => new ChassisHandlingDataEntity()); // TODO: Mock it
//            var carNumbersObjectFactory = new CarNumbersObjectFactory(() => new CarNumbersObject()); // TODO: Mock it
//            var teamEntityFactory = new IntegerIdentityFactory<TeamEntity>(() => new TeamEntity()); // TODO: Mock it

//            var mapper = new AutoMapperObjectMapperService(
//                new List<IAutoMapperConfiguration>
//                {
//                    new InfrastructureConfiguration(new List<IAutoMapperInfrastructureProfile>
//                    {
//                        new BaseGameEditor.Infrastructure.Maps.AutoMapper.MultipleDataEntitiesOnTeamEntityProfile()
//                    })
//                }); // TODO: Mock it
//            mapper.Initialise();

//            // Initialise data entities using unique non-default dummy values to verify mappings
//            const int teamDataEntityId = 1;
//            var teamDataEntity = teamDataEntityFactory.Create(teamDataEntityId);
//            teamDataEntity.Name.Shared = "UnitTest";
//            teamDataEntity.LastPosition = 11;
//            teamDataEntity.LastPoints = 12;
//            teamDataEntity.FirstGpTrack = 13;
//            teamDataEntity.FirstGpYear = 14;
//            teamDataEntity.Wins = 15;
//            teamDataEntity.YearlyBudget = 16;
//            teamDataEntity.UnknownA = 17;
//            teamDataEntity.CountryMapId = 18;
//            teamDataEntity.LocationPointerX = 19;
//            teamDataEntity.LocationPointerY = 20;
//            teamDataEntity.TyreSupplierId = 21;

//            const int chassisHandlingDataEntityId = 2;
//            var chassisHandlingDataEntity = chassisHandlingDataEntityFactory.Create(chassisHandlingDataEntityId);
//            chassisHandlingDataEntity.TeamId = 22;
//            chassisHandlingDataEntity.Value = 23;

//            var carNumbersObject = carNumbersObjectFactory.Create(teamDataEntityId);
//            carNumbersObject.CarNumberDriver1 = 24;
//            carNumbersObject.CarNumberDriver2 = 25;

//            // Initialise using values used in earlier initialisation to verify reverse mappings
//            var teamEntity = teamEntityFactory.Create(teamDataEntity.Id);
//            teamEntity.TeamId = teamDataEntity.Id + 1;
//            teamEntity.Name = teamDataEntity.Name.Shared;
//            teamEntity.LastPosition = teamDataEntity.LastPosition;
//            teamEntity.LastPoints = teamDataEntity.LastPoints;
//            teamEntity.FirstGpTrack = teamDataEntity.FirstGpTrack;
//            teamEntity.FirstGpYear = teamDataEntity.FirstGpYear;
//            teamEntity.Wins = teamDataEntity.Wins;
//            teamEntity.YearlyBudget = teamDataEntity.YearlyBudget;
//            teamEntity.CountryMapId = teamDataEntity.CountryMapId;
//            teamEntity.LocationPointerX = teamDataEntity.LocationPointerX;
//            teamEntity.LocationPointerY = teamDataEntity.LocationPointerY;
//            teamEntity.TyreSupplierId = teamDataEntity.TyreSupplierId;
//            teamEntity.ChassisHandling = chassisHandlingDataEntity.Value;
//            teamEntity.CarNumberDriver1 = carNumbersObject.CarNumberDriver1;
//            teamEntity.CarNumberDriver2 = carNumbersObject.CarNumberDriver2;

//            var newCarNumbersObject = carNumbersObjectFactory.Create(teamEntity.Id);
//            var sut = mapper.Map(teamEntity, newCarNumbersObject);

//            sut.Should().NotBeNull();
//            sut.CarNumberDriver1.Should().Be(teamEntity.CarNumberDriver1);
//            sut.CarNumberDriver2.Should().Be(teamEntity.CarNumberDriver2);
//        }
//    }
//}