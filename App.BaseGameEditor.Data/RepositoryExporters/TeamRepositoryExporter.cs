using App.BaseGameEditor.Data.DataEntityExporters;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class TeamRepositoryExporter : RepositoryExporterBase
    {
        public TeamRepositoryExporter(TeamDataEntityExporter dataEntityExporter) : base(dataEntityExporter)
        {
        }
    }
}