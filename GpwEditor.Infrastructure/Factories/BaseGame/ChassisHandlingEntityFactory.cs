using Common.Editor.Data.Factories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Factories.BaseGame
{
    public class ChassisHandlingEntityFactory : IEntityFactory<ChassisHandlingEntity>
    {
        // TODO: Is this required?
        public ChassisHandlingEntity Create(int id)
        {
            return new ChassisHandlingEntity { Id = id };
        }
    }
}