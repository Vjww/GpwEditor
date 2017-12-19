using System;
using GpwEditor.Application.DataServices;
using GpwEditor.Presentation.Console.Models;
using GpwEditor.Presentation.Console.Views.BaseGame;

namespace GpwEditor.Presentation.Console.Controllers
{
    public class BaseGameController : IController
    {
        private readonly BaseGameDataService _service;
        private readonly BaseGameModel _model;
        private readonly TeamView _teamView;

        public BaseGameController(
            BaseGameDataService service,
            BaseGameModel model,
            TeamView teamView)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _teamView = teamView ?? throw new ArgumentNullException(nameof(teamView));
        }

        public void Home()
        {
            _model.Teams = _service.GetTeams();

            _teamView.Display();
        }
    }
}