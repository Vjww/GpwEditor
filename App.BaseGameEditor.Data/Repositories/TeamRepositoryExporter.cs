using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class TeamRepositoryExporter : RepositoryExporterBase
    {
        public TeamRepositoryExporter(TeamDataEntityExporter dataEntityExporter) : base(dataEntityExporter)
        {
        }
    }
}