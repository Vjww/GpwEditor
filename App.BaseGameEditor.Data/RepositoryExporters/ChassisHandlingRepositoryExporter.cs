using App.BaseGameEditor.Data.EntityExporters;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class ChassisHandlingRepositoryExporter : RepositoryExporterBase
    {
        public ChassisHandlingRepositoryExporter(ChassisHandlingEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}