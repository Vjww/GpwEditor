using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.DomainServices;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Presentation.ViewModels;
using App.BaseGameEditor.Presentation.Views;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class TeamController : IController
    {
        private readonly DomainService _dataService;
        private readonly TeamView _view;

        public TeamController(
            DomainService dataService,
            TeamView view)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void DisplayTeams()
        {
            var teams = _dataService.DomainModelService.Teams.GetTeams();
            var teamViewModels = Mapper.Map<IEnumerable<TeamEntity>, IEnumerable<TeamViewModel>>(teams);
            _view.Display(teamViewModels);
        }
    }
}