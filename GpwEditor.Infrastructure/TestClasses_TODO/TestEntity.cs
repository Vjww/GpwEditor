using Common.Editor.Infrastructure.Entities;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestEntity : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }
    }
}