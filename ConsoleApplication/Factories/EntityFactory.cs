using ConsoleApplication.Entities;

namespace ConsoleApplication.Factories
{
    public static class EntityFactory<T>
        where T : class, IEntity, new()
    {
        public static T New(int id)
        {
            return new T { Id = id };
        }
    }
}