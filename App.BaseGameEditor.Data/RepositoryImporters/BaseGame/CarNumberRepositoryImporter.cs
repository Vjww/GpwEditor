using App.BaseGameEditor.Data.EntityImporters.BaseGame;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.RepositoryImporters.BaseGame
{
    public class CarNumberRepositoryImporter : RepositoryImporterBase
    {
        public CarNumberRepositoryImporter(CarNumberEntityImporter entityImporter) : base(entityImporter)
        {
        }
    }
}