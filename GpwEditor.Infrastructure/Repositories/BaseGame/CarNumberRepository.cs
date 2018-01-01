using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class CarNumberRepository : RepositoryBase, IBaseGameRepository
    {
        public CarNumberRepository(
            IRepositoryExporter repositoryExporter,
            IRepositoryImporter repositoryImporter)
            : base(repositoryExporter, repositoryImporter)
        {
        }

        public BaseGameRepositoryType Type { get; } = BaseGameRepositoryType.CarNumber;
    }
}