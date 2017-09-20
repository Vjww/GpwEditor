namespace GpwEditor.Application.Mappers
{
    public interface IThingy<out T>
    {
        T Map();
    }
}
