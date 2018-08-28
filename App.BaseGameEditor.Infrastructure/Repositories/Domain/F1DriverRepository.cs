using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class F1DriverRepository : RepositoryBase<F1DriverEntity>
    {
        public F1DriverRepository(List<F1DriverEntity> list) : base(list)
        {
        }
    }
}