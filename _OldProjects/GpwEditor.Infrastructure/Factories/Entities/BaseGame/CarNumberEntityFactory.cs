using Common.Editor.Data.Factories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Factories.Entities.BaseGame
{
    public class CarNumberEntityFactory : IEntityFactory<CarNumberEntity>
    {
        public CarNumberEntity Create(int id)
        {
            return new CarNumberEntity { Id = id };
        }
    }
}