using App.BaseGameEditor.Data.EntityImporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters.BaseGame
{
    public class TeamRepositoryImporter : RepositoryImporterBase
    {
        public TeamRepositoryImporter(TeamEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}