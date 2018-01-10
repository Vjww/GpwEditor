using App.BaseGameEditor.Data.EntityExporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class CarNumberRepositoryExporter : RepositoryExporterBase
    {
        public CarNumberRepositoryExporter(CarNumberEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}