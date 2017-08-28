using System.Collections.Generic;
using ConsoleApplication.Entities;

namespace ConsoleApplication.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetById(int id);
        IEnumerable<T> Get();
        #region Disabled Get Method
        //IEnumerable<T> Get(Func<T, bool> predicate);
        #endregion
        void SetById(T item);
        #region Disabled Set Method
        //void Set(IEnumerable<T> collection);
        #endregion
    }
}