// TODO: Resolve?
//using System.Linq;
//using App.BaseGameEditor.Application.Services;
//using App.DependencyInjection.Autofac;
//using App.ObjectMapping.Services;
//using App.Outputs;
//using Autofac;
//using FluentAssertions;
//using Xunit;

//namespace App.BaseGameEditor.Application.Tests.Integration
//{
//    public class ApplicationIntegration
//    {
//        private const string GameFolder = @"C:\gpw";

//        [Fact]
//        //[Fact(Skip = "Used for integration testing only. Test can be enabled/disabled as required.")]
//        public void ApplicationIntegration_WhenGettingTeamModels_ExpectSelectedModelIsPopulatedWithData()
//        {
//            using (var container = new AutofacDependencyInjectionContainer(
//                new AutofacContainerBootstrapper(new ContainerBuilder()),
//                new ConsoleOutput()))
//            {
//                container.BuildContainer();

//                container.ListRegistrations();

//                var mapperService = container.Resolve<IMapperService>();

//                var applicationService = container.Resolve<ApplicationService>();

//                applicationService.Import(
//                    $@"{GameFolder}",
//                    $@"{GameFolder}\gpw.exe",
//                    $@"{GameFolder}\english.txt",
//                    $@"{GameFolder}\french.txt",
//                    $@"{GameFolder}\german.txt",
//                    $@"{GameFolder}\text\comme.txt",
//                    $@"{GameFolder}\textf\commf.txt",
//                    $@"{GameFolder}\textg\commg.txt");

//                var models = applicationService.DomainModel.Teams.GetTeams();
//                var sut = models.Single(x => x.TeamId == 10);

//                sut.Should().NotBeNull();
//                sut.Id.Should().Be(9);
//                sut.TeamId.Should().Be(10);
//                sut.Name.Should().Be("Tyrrell");
//                sut.LastPosition.Should().Be(10);
//                sut.LastPoints.Should().Be(2);
//                sut.FirstGpTrack.Should().Be(7);
//                sut.FirstGpYear.Should().Be(1970);
//                sut.Wins.Should().Be(23);
//                sut.YearlyBudget.Should().Be(25000000);
//                sut.CountryMapId.Should().Be(1);
//                sut.LocationPointerX.Should().Be(128);
//                sut.LocationPointerY.Should().Be(120);
//                sut.TyreSupplierId.Should().Be(9);
//                sut.ChassisHandling.Should().Be(25);
//                sut.CarNumberDriver1.Should().Be(20);
//                sut.CarNumberDriver2.Should().Be(21);
//            }
//        }
//    }
//}