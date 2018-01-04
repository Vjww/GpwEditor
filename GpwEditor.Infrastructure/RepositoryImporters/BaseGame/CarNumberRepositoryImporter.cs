using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.EntityImporters.BaseGame;

namespace GpwEditor.Infrastructure.RepositoryImporters.BaseGame
{
    public class CarNumberRepositoryImporter : RepositoryImporterBase
    {
        public CarNumberRepositoryImporter(CarNumberEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}