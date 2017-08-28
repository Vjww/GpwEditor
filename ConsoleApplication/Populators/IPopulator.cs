﻿namespace ConsoleApplication.Populators
{
    public interface IPopulator<in T, in TU, in TV>
    {
        void ImportEntityFromDataSource(T dataSource, TU entity, TV mapper);
        void ExportEntityToDataSource(T dataSource, TU entity, TV mapper);
    }
}