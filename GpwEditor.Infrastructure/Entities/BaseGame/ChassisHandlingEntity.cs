using Common.Editor.Data.Entities;

namespace GpwEditor.Infrastructure.Entities.BaseGame
{
    public class ChassisHandlingEntity : EntityBase
    {
        public int TeamId { get; set; }
        public int Value { get; set; }
    }
}