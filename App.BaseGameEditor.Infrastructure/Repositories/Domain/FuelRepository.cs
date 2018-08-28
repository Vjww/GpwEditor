using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class FuelRepository : RepositoryBase<FuelEntity>
    {
        public FuelRepository(List<FuelEntity> list) : base(list)
        {
        }
    }
}