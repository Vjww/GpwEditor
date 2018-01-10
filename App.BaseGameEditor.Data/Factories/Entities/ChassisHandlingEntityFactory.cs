using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Factories.Entities
{
    public class ChassisHandlingEntityFactory : IEntityFactory<ChassisHandlingEntity>
    {
        public ChassisHandlingEntity Create(int id)
        {
            return new ChassisHandlingEntity { Id = id };
        }
    }
}