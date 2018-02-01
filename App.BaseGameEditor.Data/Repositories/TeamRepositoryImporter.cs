using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class TeamRepositoryImporter : RepositoryImporterBase
    {
        public TeamRepositoryImporter(TeamDataEntityImporter dataEntityImporter) : base(dataEntityImporter)
        {
        }
    }
}