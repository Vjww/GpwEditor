using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Factories;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class PerformanceCurveValuesController : ControllerBase
    {
        private PerformanceCurveValuesForm _view;
        private ConfigureGameController _parentController;

        private readonly FormFactory _formFactory;

        public PerformanceCurveValuesController(
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void Run(Form parentView, ConfigureGameController parentController)
        {
            _parentController = parentController;

            _view = _formFactory.Create<PerformanceCurveValuesForm>();
            _view.SetController(this);

            ShowView(parentView, _view);
        }

        public IEnumerable<int> GetProposedSeriesValuesFromPerformanceCurveChart()
        {
            if (_parentController == null)
            {
                throw new NullReferenceException($"The member field '{nameof(_parentController)}' is null. Please ensure the '{nameof(Run)}' method is invoked prior to invoking the '{nameof(GetProposedSeriesValuesFromPerformanceCurveChart)}' method.");
            }

            return _parentController.GetProposedSeriesValuesFromPerformanceCurveChart();
        }

        public void UpdatePerformanceCurveChartWithHiddenSeriesValues(int[] values)
        {
            if (_parentController == null)
            {
                throw new NullReferenceException($"The member field '{nameof(_parentController)}' is null. Please ensure the '{nameof(Run)}' method is invoked prior to invoking the '{nameof(UpdatePerformanceCurveChartWithHiddenSeriesValues)}' method.");
            }

            _parentController.UpdatePerformanceCurveChartWithHiddenSeriesValues(values);
        }
    }
}