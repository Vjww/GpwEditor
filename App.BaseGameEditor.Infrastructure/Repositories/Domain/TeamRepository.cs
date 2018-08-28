using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class TeamRepository : RepositoryBase<TeamEntity>
    {
        public TeamRepository(List<TeamEntity> list) : base(list)
        {
        }
    }
}