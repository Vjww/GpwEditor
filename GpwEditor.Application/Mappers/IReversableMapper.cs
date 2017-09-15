namespace GpwEditor.Application.Mappers
{
    public interface IReversableMapper<TFromTo, TToFrom> : IMapper<TFromTo, TToFrom>
        where TFromTo : class
        where TToFrom : class
    {
        TFromTo Map(TToFrom from);
    }
}