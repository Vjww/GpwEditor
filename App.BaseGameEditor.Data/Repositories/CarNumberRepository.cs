using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.RepositoryExporters;
using App.BaseGameEditor.Data.RepositoryImporters;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.Repositories
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