using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.Console.ViewModels;
using App.Console.Views;

namespace App.Console.Controllers
{
    public class TrackController
    {
        private readonly ApplicationService _service;
        private readonly TrackView _trackView;
        private readonly IMapperService _mapper;

        public TrackController(
            ApplicationService service,
            TrackView trackView,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _trackView = trackView ?? throw new ArgumentNullException(nameof(trackView));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayTracks()
        {
            var entities = _service.DomainModel.Tracks.GetTracks();
            var viewModel = _mapper.Map<IEnumerable<TrackEntity>, IEnumerable<TrackViewModel>>(entities);
            _trackView.Display(viewModel);
        }
    }
}