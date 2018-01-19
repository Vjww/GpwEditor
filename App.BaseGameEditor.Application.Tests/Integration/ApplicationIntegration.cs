using System.Linq;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.DependencyInjection.Unity;
using App.Output;
using NUnit.Framework;

namespace App.BaseGameEditor.Application.Tests.Integration
{
    [TestFixture]
    public class ApplicationIntegration
    {
        private const string GameFolder = @"C:\gpw";

        [Test]
        public void ApplicationIntegration_WhenGettingTeamModels_ExpectSelectedModelIsPopulatedWithData()
        {
            var output = new ConsoleOutput();

            using (var container = new UnityDependencyInjectionContainer(output))
            {
                container.PerformRegistrations();

                var mapperService = container.GetInstance<IMapperService>();
                mapperService.Initialise();

                var applicationService = container.GetInstance<ApplicationService>();

                applicationService.Import(
                    $@"{GameFolder}",
                    $@"{GameFolder}\gpw.exe",
                    $@"{GameFolder}\english.txt",
                    $@"{GameFolder}\french.txt",
                    $@"{GameFolder}\german.txt",
                    $@"{GameFolder}\text\comme.txt",
                    $@"{GameFolder}\textf\commf.txt",
                    $@"{GameFolder}\textg\commg.txt");

                var models = applicationService.DomainModel.Teams.GetTeams();
                var sut = models.Single(x => x.TeamId == 10);

                Assert.IsTrue(sut.TeamId == 10);
                Assert.IsTrue(sut.Name == "Tyrrell");
                Assert.IsTrue(sut.LastPosition == 10);
                Assert.IsTrue(sut.LastPoints == 2);
                Assert.IsTrue(sut.FirstGpTrack == 7);
                Assert.IsTrue(sut.FirstGpYear == 1970);
                Assert.IsTrue(sut.Wins == 23);
                Assert.IsTrue(sut.YearlyBudget == 25000000);
                Assert.IsTrue(sut.CountryMapId == 1);
                Assert.IsTrue(sut.LocationPointerX == 128);
                Assert.IsTrue(sut.LocationPointerY == 120);
                Assert.IsTrue(sut.TyreSupplierId == 9);
                Assert.IsTrue(sut.ChassisHandling == 25);
                Assert.IsTrue(sut.CarNumberDriver1 == 20);
                Assert.IsTrue(sut.CarNumberDriver2 == 21);
            }
        }
    }
}