﻿using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.BaseGameEditor.Presentation.ViewModels;
using App.BaseGameEditor.Presentation.Views;

namespace App.BaseGameEditor.Presentation.Controllers
{
    public class TeamController
    {
        private readonly ApplicationService _service;
        private readonly TeamView _view;
        private readonly IMapperService _mapper;

        public TeamController(
            ApplicationService service,
            TeamView view,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayTeams()
        {
            var entities = _service.DomainModel.Teams.GetTeams();
            var viewModel = _mapper.Map<IEnumerable<TeamEntity>, IEnumerable<TeamViewModel>>(entities);
            _view.Display(viewModel);
        }
    }
}