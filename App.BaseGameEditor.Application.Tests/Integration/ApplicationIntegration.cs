using App.BaseGameEditor.Application.Services.Application;
using App.BaseGameEditor.Application.Tests.Fixtures;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace App.BaseGameEditor.Application.Tests.Integration
{
    [Collection("Application Maps Collection")]
    public class ApplicationIntegration
    {
        private readonly BaseGameEditorApplicationService _applicationService;
        private const string GameFolder = @"C:\gpw";

        public ApplicationIntegration(ApplicationMapsFixture applicationMapsFixture)
        {
            _applicationService = applicationMapsFixture.GetService<BaseGameEditorApplicationService>();
        }

        [Fact]
        //[Fact(Skip = "Used for integration testing only. Test can be enabled/disabled as required.")]
        public void ApplicationIntegration_WhenGettingTeamModels_ExpectSelectedModelIsPopulatedWithData()
        {
            _applicationService.Import(
                $@"{GameFolder}",
                $@"{GameFolder}\gpw.exe",
                $@"{GameFolder}\english.txt",
                $@"{GameFolder}\french.txt",
                $@"{GameFolder}\german.txt",
                $@"{GameFolder}\text\comme.txt",
                $@"{GameFolder}\textf\commf.txt",
                $@"{GameFolder}\textg\commg.txt");

            var models = _applicationService.DomainModel.Teams.GetTeams();
            var sut = models.Single(x => x.TeamId == 10);

            sut.Should().NotBeNull();
            sut.Id.Should().Be(9);
            sut.TeamId.Should().Be(10);
            sut.Name.Should().Be("Tyrrell");
            sut.LastPosition.Should().Be(10);
            sut.LastPoints.Should().Be(2);
            sut.DebutGrandPrix.Should().Be(7);
            sut.DebutYear.Should().Be(1970);
            sut.Wins.Should().Be(23);
            sut.YearlyBudget.Should().Be(25000000);
            sut.Location.Should().Be(1);
            sut.LocationX.Should().Be(128);
            sut.LocationY.Should().Be(120);
            sut.TyreSupplier.Should().Be(9);
            sut.ChassisHandling.Should().Be(25);
            sut.CarNumberDriver1.Should().Be(20);
            sut.CarNumberDriver2.Should().Be(21);
        }
    }
}
