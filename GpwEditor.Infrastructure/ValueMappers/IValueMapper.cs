namespace GpwEditor.Infrastructure.ValueMappers
{
    public interface IValueMapper
    {
        int Id { get; set; }

        void Map();
    }
}