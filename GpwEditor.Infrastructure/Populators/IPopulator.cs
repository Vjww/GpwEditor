namespace GpwEditor.Infrastructure.Populators
{
    public interface IPopulator<in T, in TU, in TV>
    {
        void ImportEntityFromDataSource(T dataSource, TU entity, TV valueMapper);
        void ExportEntityToDataSource(T dataSource, TU entity, TV valueMapper);
    }
}