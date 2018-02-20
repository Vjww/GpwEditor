using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("api/[controller]")]
    public class BaseGameDataController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Team> Teams()
        {
            return new List<Team>
            {
                new Team { Id = 1 },
                new Team { Id = 2 },
                new Team { Id = 3 }
            };
        }

        public class Team
        {
            public int Id { get; set; }
        }
    }
}