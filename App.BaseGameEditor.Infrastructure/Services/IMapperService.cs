namespace App.BaseGameEditor.Infrastructure.Services
{
    public interface IMapperService
    {
        void Initialise();
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}