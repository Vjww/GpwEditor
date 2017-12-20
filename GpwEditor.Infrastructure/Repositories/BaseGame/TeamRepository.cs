using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class TeamRepository : Repository<TeamEntity>, IBaseGameRepository<TeamEntity>
    {
        public BaseGameRepositoryEnum RepositoryType { get; set; } = BaseGameRepositoryEnum.Team;
    }
}