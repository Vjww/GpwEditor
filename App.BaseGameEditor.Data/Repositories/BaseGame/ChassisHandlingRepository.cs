using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.RepositoryExporters.BaseGame;
using App.BaseGameEditor.Data.RepositoryImporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.Repositories.BaseGame
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