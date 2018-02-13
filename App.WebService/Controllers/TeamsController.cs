using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly ApplicationService _service;

        public TeamsController(ApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/teams
        [HttpGet]
        public IEnumerable<TeamEntity> Get()
        {
            return _service.DomainModel.Teams.GetTeams();
        }

        // GET api/teams/5
        [HttpGet("{id}")]
        public TeamEntity Get(int id)
        {
            return _service.DomainModel.Teams.GetTeams().Single(x => x.TeamId == id);
        }

        // POST api/teams
        [HttpPost]
        public void Post([FromBody]IEnumerable<TeamEntity> values)
        {
            // TODO: Validate and then Set? Return validation failures?
            _service.DomainModel.Teams.SetTeams(values);
        }

        // PUT api/teams/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TeamEntity value)
        {
            // TODO: Validate and then Set? Return validation failures?
            _service.DomainModel.Teams.SetTeam(value);
        }

        // DELETE api/teams/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}