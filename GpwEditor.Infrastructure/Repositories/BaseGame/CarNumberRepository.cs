using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Enums;
using GpwEditor.Infrastructure.RepositoryExporters.BaseGame;
using GpwEditor.Infrastructure.RepositoryImporters.BaseGame;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class CarNumberRepository : RepositoryBase, IBaseGameRepository
    {
        public CarNumberRepository(
            CarNumberRepositoryExporter repositoryExporter,
            CarNumberRepositoryImporter repositoryImporter)
            : base(repositoryExporter, repositoryImporter)
        {
            RepositoryCapacity = 22;
        }

        public BaseGameRepositoryType Type { get; } = BaseGameRepositoryType.CarNumber;
    }
}