using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class TeamRepository : RepositoryBase<TeamEntity>, ITeamRepository
    {
    }
}