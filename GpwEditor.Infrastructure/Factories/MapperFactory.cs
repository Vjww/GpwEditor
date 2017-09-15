using GpwEditor.Infrastructure.Mappers;

namespace GpwEditor.Infrastructure.Factories
{
    public static class MapperFactory<T>
        where T : class, IMapper, new()
    {
        public static T New(int id)
        {
            return new T { Id = id };
        }
    }
}