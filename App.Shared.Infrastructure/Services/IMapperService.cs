namespace App.Shared.Infrastructure.Services
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}