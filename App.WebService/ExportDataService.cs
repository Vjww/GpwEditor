using System;
using App.BaseGameEditor.Application.Services;

namespace App.WebService
{
    // TODO: Temporary solution
    public class ExportDataService
    {
        private readonly ApplicationService _service;

        public ExportDataService(ApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Export()
        {
            // TODO: Export to service
            //_service.Export();

            throw new NotImplementedException();
        }
    }
}