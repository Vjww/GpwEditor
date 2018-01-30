using App.BaseGameEditor.Data.DataEntityImporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters
{
    public class CarNumberRepositoryImporter : RepositoryImporterBase
    {
        public CarNumberRepositoryImporter(CarNumberDataEntityImporter dataEntityImporter) : base(dataEntityImporter)
        {
        }
    }
}