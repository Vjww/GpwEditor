using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace App.WebService.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("[action]")]
        public IEnumerable<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team { Id = 1 },
                new Team { Id = 2 },
                new Team { Id = 3 },
                new Team { Id = 4 },
                new Team { Id = 5 }
            };
        }

        public class Team
        {
            public int Id { get; set; }
        }
    }

//    [Produces("application/json")]
//    [Route("api/BaseGame")]
//    public class BaseGameController : Controller
//    {
//        private readonly ImportDataService _importDataService;
//        private readonly ExportDataService _exportDataService;

//        public BaseGameController(
//            ImportDataService importDataService,
//            ExportDataService exportDataService)
//        {
//            _importDataService = importDataService ?? throw new ArgumentNullException(nameof(importDataService));
//            _exportDataService = exportDataService ?? throw new ArgumentNullException(nameof(exportDataService));
//        }

//        // TODO: Should be Post method once UI is in place
//        //// POST: api/BaseGame/Import
//        //[HttpPost("Import")]

//        // GET: api/BaseGame/Import
//        [HttpGet("Import")]
//        public void Import()
//        {
//            _importDataService.Import();
//        }

//        // TODO: Should be Post method once UI is in place
//        //// POST: api/BaseGame/Export
//        //[HttpPost("Export")]

//        // GET: api/BaseGame/Export
//        [HttpGet("Export")]
//        public void Export()
//        {
//            _exportDataService.Export();
//        }
//    }
}