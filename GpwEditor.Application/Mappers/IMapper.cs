namespace GpwEditor.Application.Mappers
{
    public interface IMapper<in TFrom, out TTo>
        where TFrom : class
        where TTo : class
    {
        TTo Map(TFrom from);
    }
}