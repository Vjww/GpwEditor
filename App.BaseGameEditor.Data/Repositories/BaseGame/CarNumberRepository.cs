using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.RepositoryExporters.BaseGame;
using App.BaseGameEditor.Data.RepositoryImporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.Repositories.BaseGame
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