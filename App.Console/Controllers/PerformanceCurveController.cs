using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Services;
using App.Console.ViewModels;
using App.Console.Views;

namespace App.Console.Controllers
{
    public class PerformanceCurveController
    {
        private readonly ApplicationService _service;
        private readonly PerformanceCurveView _performanceCurveView;
        private readonly IMapperService _mapper;

        public PerformanceCurveController(
            ApplicationService service,
            PerformanceCurveView performanceCurveView,
            IMapperService mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _performanceCurveView = performanceCurveView ?? throw new ArgumentNullException(nameof(performanceCurveView));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void DisplayPerformanceCurves()
        {
            var entities = _service.DomainModel.PerformanceCurveValues.GetPerformanceCurves();
            var viewModel = _mapper.Map<IEnumerable<PerformanceCurveEntity>, IEnumerable<PerformanceCurveViewModel>>(entities);
            _performanceCurveView.Display(viewModel);
        }
    }
}