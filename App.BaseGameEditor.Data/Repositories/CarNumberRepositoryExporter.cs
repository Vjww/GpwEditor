using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class CarNumberRepositoryExporter : RepositoryExporterBase
    {
        public CarNumberRepositoryExporter(CarNumberDataEntityExporter dataEntityExporter) : base(dataEntityExporter)
        {
        }
    }
}