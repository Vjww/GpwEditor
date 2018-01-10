using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.DataServices;
using App.BaseGameEditor.Domain.Models;
using App.BaseGameEditor.Presentation.ViewModels;
using App.BaseGameEditor.Presentation.Views;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class TeamController : IController
    {
        private readonly DataService _dataService;
        private readonly TeamView _view;

        public TeamController(
            DataService dataService,
            TeamView view)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void DisplayTeams()
        {
            var teams = _dataService.Teams.Get();
            var teamViewModels = Mapper.Map<IEnumerable<TeamModel>, IEnumerable<TeamViewModel>>(teams);
            _view.Display(teamViewModels);
        }
    }
}