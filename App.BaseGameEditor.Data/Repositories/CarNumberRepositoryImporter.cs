using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class CarNumberRepositoryImporter : RepositoryImporterBase
    {
        public CarNumberRepositoryImporter(CarNumberDataEntityImporter dataEntityImporter) : base(dataEntityImporter)
        {
        }
    }
}