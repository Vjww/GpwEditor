using System;
using System.Collections.Generic;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.WebService.Controllers
{
    [Route("api/[controller]")]
    public class BaseGameController : Controller
    {
        private readonly ApplicationService _applicationService;
        private readonly ImportDataService _importDataService;
        private readonly ExportDataService _exportDataService;

        public BaseGameController(
            ApplicationService applicationService,
            ImportDataService importDataService,
            ExportDataService exportDataService)
        {
            _applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
            _importDataService = importDataService ?? throw new ArgumentNullException(nameof(importDataService));
            _exportDataService = exportDataService ?? throw new ArgumentNullException(nameof(exportDataService));
        }

        [HttpPost("[action]")]
        public void Import([FromBody]Test test)
        {
            var _ = test;
            _importDataService.Import();
        }

        [HttpPost("[action]")]
        public void Export(Test test)
        {
            var _ = test;
            _exportDataService.Export();
        }

        [HttpGet("[action]")]
        public IEnumerable<TeamEntity> GetTeams()
        {
            return _applicationService.DomainModel.Teams.GetTeams();
        }
    }

    public class Test
    {
        public string FilePath { get; set; }
    }
}