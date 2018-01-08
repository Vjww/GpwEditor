using App.BaseGameEditor.Data.EntityExporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryExporters.BaseGame
{
    public class TeamRepositoryExporter : RepositoryExporterBase
    {
        public TeamRepositoryExporter(TeamEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}