using App.BaseGameEditor.Data.DataEntityImporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters
{
    public class ChassisHandlingRepositoryImporter : RepositoryImporterBase
    {
        public ChassisHandlingRepositoryImporter(ChassisHandlingDataEntityImporter dataEntityImporter) : base(dataEntityImporter)
        {
        }
    }
}