using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.EntityExporters.BaseGame;

namespace GpwEditor.Infrastructure.RepositoryExporters.BaseGame
{
    public class TeamRepositoryExporter : RepositoryExporterBase
    {
        public TeamRepositoryExporter(TeamEntityExporter entityExporter) : base(entityExporter)
        {
        }
    }
}