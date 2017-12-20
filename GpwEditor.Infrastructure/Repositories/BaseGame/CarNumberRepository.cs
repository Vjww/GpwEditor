using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class CarNumberRepository : Repository<CarNumberEntity>, IBaseGameRepository<CarNumberEntity>
    {
        public BaseGameRepositoryEnum RepositoryType { get; set; } = BaseGameRepositoryEnum.CarNumber;
    }
}