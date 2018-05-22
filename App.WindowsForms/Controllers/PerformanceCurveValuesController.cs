using System;
using System.Windows.Forms;
using App.BaseGameEditor.Infrastructure.Services;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class PerformanceCurveValuesController : ControllerBase
    {
        private PerformanceCurveValuesForm _view;

        private readonly FormFactory _formFactory;

        public PerformanceCurveValuesController(
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<PerformanceCurveValuesForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }
    }
}