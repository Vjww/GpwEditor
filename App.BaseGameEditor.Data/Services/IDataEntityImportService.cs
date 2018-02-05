﻿using App.Core.Entities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IDataEntityImportService<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Import(int id);
    }
}