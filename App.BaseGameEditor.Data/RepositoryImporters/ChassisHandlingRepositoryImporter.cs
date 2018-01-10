using App.BaseGameEditor.Data.EntityImporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters
{
    public class ChassisHandlingRepositoryImporter : RepositoryImporterBase
    {
        public ChassisHandlingRepositoryImporter(ChassisHandlingEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}