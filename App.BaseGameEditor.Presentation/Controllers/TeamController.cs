using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Models;
using App.BaseGameEditor.Presentation.ViewModels;
using App.BaseGameEditor.Presentation.Views;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class TeamController : IController
    {
        private readonly TeamService _service;
        private readonly TeamView _view;

        public TeamController(
            TeamService service,
            TeamView view)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void DisplayTeams()
        {
            var models = _service.Get();
            var viewModels = Mapper.Map<IEnumerable<TeamModel>, IEnumerable<TeamViewModel>>(models);
            _view.Display(viewModels);
        }
    }
}