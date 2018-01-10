using System.Linq;
using App.BaseGameEditor.Application.DomainServices;
using App.DependencyInjection.Unity;
using App.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.BaseGameEditor.Application.Tests
{
    [TestClass]
    public class QuickIntegrationTest
    {
        private const string GameFolder = @"C:\gpw";

        [TestMethod]
        public void QuickIntegrationTest_WhenGettingTeamModels_ExpectSelectedModelIsPopulatedWithData()
        {
            var outputDevice = new ConsoleOutput();
            using (var container = new UnityDependencyInjectionContainer(outputDevice))
            {
                container.PerformRegistrations();

                var dataService = container.GetInstance<DomainService>();

                dataService.Import(
                    $@"{GameFolder}",
                    $@"{GameFolder}\gpw.exe",
                    $@"{GameFolder}\english.txt",
                    $@"{GameFolder}\french.txt",
                    $@"{GameFolder}\german.txt",
                    $@"{GameFolder}\text\comme.txt",
                    $@"{GameFolder}\textf\commf.txt",
                    $@"{GameFolder}\textg\commg.txt");

                var models = dataService.DomainModelService.Teams.GetTeams();
                var model = models.Single(x => x.TeamId == 10);

                Assert.IsTrue(model.TeamId == 10);
                Assert.IsTrue(model.Name == "Tyrrell");
                Assert.IsTrue(model.LastPosition == 10);
                Assert.IsTrue(model.LastPoints == 2);
                Assert.IsTrue(model.FirstGpTrack == 7);
                Assert.IsTrue(model.FirstGpYear == 1970);
                Assert.IsTrue(model.Wins == 23);
                Assert.IsTrue(model.YearlyBudget == 25000000);
                Assert.IsTrue(model.CountryMapId == 1);
                Assert.IsTrue(model.LocationPointerX == 128);
                Assert.IsTrue(model.LocationPointerY == 120);
                Assert.IsTrue(model.TyreSupplierId == 9);
                Assert.IsTrue(model.ChassisHandling == 25);
                Assert.IsTrue(model.CarNumberDriver1 == 20);
                Assert.IsTrue(model.CarNumberDriver2 == 21);
            }
        }
    }
}