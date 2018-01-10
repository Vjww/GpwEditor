using App.BaseGameEditor.Data.EntityExporters;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters
{
    public class TeamRepositoryExporter : RepositoryExporterBase
    {
        public TeamRepositoryExporter(TeamEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}