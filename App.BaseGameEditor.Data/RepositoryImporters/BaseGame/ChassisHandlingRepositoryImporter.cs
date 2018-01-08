using App.BaseGameEditor.Data.EntityImporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters.BaseGame
{
    public class ChassisHandlingRepositoryImporter : RepositoryImporterBase
    {
        public ChassisHandlingRepositoryImporter(ChassisHandlingEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}