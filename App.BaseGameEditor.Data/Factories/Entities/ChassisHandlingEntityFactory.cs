using App.BaseGameEditor.Data.Entities;
using Common.Editor.Data.Factories;

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