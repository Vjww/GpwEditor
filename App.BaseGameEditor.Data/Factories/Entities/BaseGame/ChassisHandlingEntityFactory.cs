using App.BaseGameEditor.Data.Entities.BaseGame;
using Common.Editor.Data.Factories;

namespace App.BaseGameEditor.Data.Factories.Entities.BaseGame
{
    public class ChassisHandlingEntityFactory : IEntityFactory<ChassisHandlingEntity>
    {
        public ChassisHandlingEntity Create(int id)
        {
            return new ChassisHandlingEntity { Id = id };
        }
    }
}