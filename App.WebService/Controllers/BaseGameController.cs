using System;
using Microsoft.AspNetCore.Mvc;

namespace App.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/BaseGame")]
    public class BaseGameController : Controller
    {
        private readonly ImportDataService _importDataService;
        private readonly ExportDataService _exportDataService;

        public BaseGameController(
            ImportDataService importDataService,
            ExportDataService exportDataService)
        {
            _importDataService = importDataService ?? throw new ArgumentNullException(nameof(importDataService));
            _exportDataService = exportDataService ?? throw new ArgumentNullException(nameof(exportDataService));
        }

        // TODO: Should be Post method once UI is in place
        //// POST: api/BaseGame/Import
        //[HttpPost("Import")]

        // GET: api/BaseGame/Import
        [HttpGet("Import")]
        public void Import()
        {
            _importDataService.Import();
        }

        // TODO: Should be Post method once UI is in place
        //// POST: api/BaseGame/Export
        //[HttpPost("Export")]

        // GET: api/BaseGame/Export
        [HttpGet("Export")]
        public void Export()
        {
            _exportDataService.Export();
        }
    }
}