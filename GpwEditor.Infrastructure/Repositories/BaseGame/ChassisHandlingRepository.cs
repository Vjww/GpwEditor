using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class ChassisHandlingRepository : RepositoryBase, IBaseGameRepository
    {
        public ChassisHandlingRepository(
            IRepositoryExporter repositoryExporter,
            IRepositoryImporter repositoryImporter)
            : base(repositoryExporter, repositoryImporter)
        {
        }

        public BaseGameRepositoryType Type { get; } = BaseGameRepositoryType.ChassisHandling;
    }
}