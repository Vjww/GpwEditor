using App.BaseGameEditor.Data.EntityExporters;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class CarNumberRepositoryExporter : RepositoryExporterBase
    {
        public CarNumberRepositoryExporter(CarNumberEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}