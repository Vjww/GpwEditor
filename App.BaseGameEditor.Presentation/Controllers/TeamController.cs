using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Presentation.ViewModels;
using App.BaseGameEditor.Presentation.Views;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class TeamController : IController
    {
        private readonly ApplicationService _service;
        private readonly TeamView _view;
        private readonly IMapper _mapper;

        public TeamController(
            ApplicationService service,
            TeamView view,
            IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayTeams()
        {
            var teams = _service.DomainModel.Teams.GetTeams();
            var teamViewModels = _mapper.Map<IEnumerable<TeamViewModel>>(teams);
            _view.Display(teamViewModels);
        }
    }
}