using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Enums;
using GpwEditor.Infrastructure.RepositoryExporters.BaseGame;
using GpwEditor.Infrastructure.RepositoryImporters.BaseGame;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class ChassisHandlingRepository : RepositoryBase, IBaseGameRepository
    {
        public ChassisHandlingRepository(
            ChassisHandlingRepositoryExporter repositoryExporter,
            ChassisHandlingRepositoryImporter repositoryImporter)
            : base(repositoryExporter, repositoryImporter)
        {
            RepositoryCapacity = 11;
        }

        public BaseGameRepositoryType Type { get; } = BaseGameRepositoryType.ChassisHandling;
    }
}