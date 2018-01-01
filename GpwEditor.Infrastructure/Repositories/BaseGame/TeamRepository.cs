using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public class TeamRepository : RepositoryBase, IBaseGameRepository
    {
        public TeamRepository(
            IRepositoryExporter repositoryExporter,
            IRepositoryImporter repositoryImporter)
            : base(repositoryExporter, repositoryImporter)
        {
        }

        public BaseGameRepositoryType Type { get; } = BaseGameRepositoryType.Team;
    }
}