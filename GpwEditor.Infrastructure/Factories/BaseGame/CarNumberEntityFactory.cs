using Common.Editor.Data.Factories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Factories.BaseGame
{
    // TODO: Is this required?
    public class CarNumberEntityFactory : IEntityFactory<CarNumberEntity>
    {
        public CarNumberEntity Create(int id)
        {
            return new CarNumberEntity { Id = id };
        }
    }
}