using GpwEditor.Infrastructure.ValueMappers;

namespace GpwEditor.Infrastructure.Factories
{
    public static class ValueMapperFactory<T>
        where T : class, IValueMapper, new()
    {
        public static T New(int id)
        {
            return new T { Id = id };
        }
    }
}