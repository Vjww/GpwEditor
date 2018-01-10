using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public TeamService Teams { get; }

        public DomainModelService(TeamService teamService)
        {
            Teams = teamService ?? throw new ArgumentNullException(nameof(teamService));
        }
    }
}