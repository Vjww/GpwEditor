using App.BaseGameEditor.Data.EntityImporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters
{
    public class CarNumberRepositoryImporter : RepositoryImporterBase
    {
        public CarNumberRepositoryImporter(CarNumberEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}