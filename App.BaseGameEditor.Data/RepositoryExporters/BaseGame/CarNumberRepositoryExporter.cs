using App.BaseGameEditor.Data.EntityExporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters.BaseGame
{
    public class CarNumberRepositoryExporter : RepositoryExporterBase
    {
        public CarNumberRepositoryExporter(CarNumberEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}