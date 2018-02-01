using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class F1DriverRepository : RepositoryBase<F1DriverEntity>, IF1DriverRepository
    {
        public F1DriverRepository(List<F1DriverEntity> list) : base(list)
        {
        }
    }
}