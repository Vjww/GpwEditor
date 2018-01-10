using System;
using System.Collections.Generic;
using Common.Editor.Domain.Models;

namespace Common.Editor.Domain.Repositories
{
    public interface IRepository<TModel>
        where TModel : class, IModel
    {
        IEnumerable<TModel> Get();
        IEnumerable<TModel> Get(Func<TModel, bool> predicate);
        TModel GetById(int id);
        void Set(IEnumerable<TModel> items);
        void SetById(TModel item);
    }
}