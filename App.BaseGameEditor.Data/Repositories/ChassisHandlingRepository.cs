using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.RepositoryExporters;
using App.BaseGameEditor.Data.RepositoryImporters;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.Repositories
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