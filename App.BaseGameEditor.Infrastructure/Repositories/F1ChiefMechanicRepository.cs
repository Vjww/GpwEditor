using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class F1ChiefMechanicRepository : RepositoryBase<F1ChiefMechanicEntity>, IF1ChiefMechanicRepository
    {
        public F1ChiefMechanicRepository(List<F1ChiefMechanicEntity> list) : base(list)
        {
        }
    }
}