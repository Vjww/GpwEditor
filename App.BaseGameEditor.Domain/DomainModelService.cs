using System;
using App.BaseGameEditor.Domain.Services;

namespace App.BaseGameEditor.Domain
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