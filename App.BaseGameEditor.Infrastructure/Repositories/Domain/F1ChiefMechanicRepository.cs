using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class F1ChiefMechanicRepository : RepositoryBase<F1ChiefMechanicEntity>
    {
        public F1ChiefMechanicRepository(List<F1ChiefMechanicEntity> list) : base(list)
        {
        }
    }
}