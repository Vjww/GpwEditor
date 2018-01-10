using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelImportService
    {
        private readonly TeamDomainModelImportService _service;

        public DomainModelImportService(TeamDomainModelImportService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            _service.Import();
        }
    }
}