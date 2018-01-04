using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.EntityExporters.BaseGame;

namespace GpwEditor.Infrastructure.RepositoryExporters.BaseGame
{
    public class ChassisHandlingRepositoryExporter : RepositoryExporterBase
    {
        public ChassisHandlingRepositoryExporter(ChassisHandlingEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}