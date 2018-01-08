using App.BaseGameEditor.Data.Entities.BaseGame;
using Common.Editor.Data.Factories;

namespace App.BaseGameEditor.Data.Factories.Entities.BaseGame
{
    public class CarNumberEntityFactory : IEntityFactory<CarNumberEntity>
    {
        public CarNumberEntity Create(int id)
        {
            return new CarNumberEntity { Id = id };
        }
    }
}