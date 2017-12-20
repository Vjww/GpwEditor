using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class ChassisHandlingRepository : Repository<ChassisHandlingEntity>, IBaseGameRepository<ChassisHandlingEntity>
    {
        public BaseGameRepositoryEnum RepositoryType { get; set; } = BaseGameRepositoryEnum.ChassisHandling;
    }
}