using App.BaseGameEditor.Data.EntityImporters;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters
{
    public class TeamRepositoryImporter : RepositoryImporterBase
    {
        public TeamRepositoryImporter(TeamEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}