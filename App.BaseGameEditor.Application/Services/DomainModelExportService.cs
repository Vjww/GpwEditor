using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelExportService
    {
        private readonly TeamDomainModelExportService _service;

        public DomainModelExportService(TeamDomainModelExportService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Export()
        {
            _service.Export();
        }
    }
}