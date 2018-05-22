using System;
using System.Windows.Forms;
using App.BaseGameEditor.Infrastructure.Services;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public abstract class ControllerBase
    {
        protected readonly IMapperService MapperService;

        protected ControllerBase(IMapperService mapperService)
        {
            MapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        protected void ShowView(Form parentView, EditorForm childView)
        {
            childView.FormClosing += delegate { parentView.Show(); };
            childView.Show(parentView);
            parentView.Hide();
        }

        protected TU UpdateModelFromService<T, TU>(Func<T> service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            var entities = service.Invoke();
            return MapperService.Map<T, TU>(entities);
        }

        protected void UpdateServiceFromModel<T, TU>(Action<TU> service, T model)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entities = MapperService.Map<T, TU>(model);
            service.Invoke(entities);
        }
    }
}