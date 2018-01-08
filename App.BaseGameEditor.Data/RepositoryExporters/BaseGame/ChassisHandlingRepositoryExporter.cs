using App.BaseGameEditor.Data.EntityExporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters.BaseGame
{
    public class ChassisHandlingRepositoryExporter : RepositoryExporterBase
    {
        public ChassisHandlingRepositoryExporter(ChassisHandlingEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}