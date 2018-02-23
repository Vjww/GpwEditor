using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.EntityImporters.BaseGame;

namespace GpwEditor.Infrastructure.RepositoryImporters.BaseGame
{
    public class TeamRepositoryImporter : RepositoryImporterBase
    {
        public TeamRepositoryImporter(TeamEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}