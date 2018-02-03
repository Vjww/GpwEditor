using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class TeamRepository : RepositoryBase<TeamEntity>
    {
        public TeamRepository(List<TeamEntity> list) : base(list)
        {
        }
    }
}