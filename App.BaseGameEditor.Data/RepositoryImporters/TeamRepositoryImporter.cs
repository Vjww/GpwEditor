using App.BaseGameEditor.Data.DataEntityImporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters
{
    public class TeamRepositoryImporter : RepositoryImporterBase
    {
        public TeamRepositoryImporter(TeamDataEntityImporter dataEntityImporter) : base(dataEntityImporter)
        {
        }
    }
}