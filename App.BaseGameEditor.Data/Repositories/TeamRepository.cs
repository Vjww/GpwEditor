using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.RepositoryExporters;
using App.BaseGameEditor.Data.RepositoryImporters;

namespace App.BaseGameEditor.Data.Repositories
{
    public class TeamRepository : RepositoryBase, IBaseGameRepository
    {
        public TeamRepository(
            TeamRepositoryExporter repositoryExporter,
            TeamRepositoryImporter repositoryImporter)
            : base(repositoryExporter, repositoryImporter)
        {
            RepositoryCapacity = 11;
        }

        public BaseGameRepositoryType Type { get; } = BaseGameRepositoryType.Team;
    }
}