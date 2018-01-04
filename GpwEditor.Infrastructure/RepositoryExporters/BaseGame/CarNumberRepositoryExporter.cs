using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.EntityExporters.BaseGame;

namespace GpwEditor.Infrastructure.RepositoryExporters.BaseGame
{
    public class CarNumberRepositoryExporter : RepositoryExporterBase
    {
        public CarNumberRepositoryExporter(CarNumberEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}