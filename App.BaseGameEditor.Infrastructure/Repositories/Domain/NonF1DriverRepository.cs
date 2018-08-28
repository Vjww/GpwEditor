using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class NonF1DriverRepository : RepositoryBase<NonF1DriverEntity>
    {
        public NonF1DriverRepository(List<NonF1DriverEntity> list) : base(list)
        {
        }
    }
}