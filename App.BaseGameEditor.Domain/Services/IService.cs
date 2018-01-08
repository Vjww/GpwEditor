﻿using System;
using System.Collections.Generic;
using App.BaseGameEditor.Domain.Models;

namespace App.BaseGameEditor.Domain.Services
{
    public interface IService<TModel>
        where TModel : class, IModel
    {
        IEnumerable<TModel> Get();
        IEnumerable<TModel> Get(Func<TModel, bool> predicate);
        TModel GetById(int id);
        void Set(IEnumerable<TModel> models);
        void SetById(TModel model);
    }
}