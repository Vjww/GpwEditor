using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class TeamRepository : RepositoryBase<TeamEntity>, ITeamRepository
    {
        public TeamRepository(List<TeamEntity> list) : base(list)
        {
        }
    }
}