using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.EntityImporters.BaseGame;

namespace GpwEditor.Infrastructure.RepositoryImporters.BaseGame
{
    public class ChassisHandlingRepositoryImporter : RepositoryImporterBase
    {
        public ChassisHandlingRepositoryImporter(ChassisHandlingEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}