using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class NonF1ChiefMechanicRepository : RepositoryBase<NonF1ChiefMechanicEntity>
    {
        public NonF1ChiefMechanicRepository(List<NonF1ChiefMechanicEntity> list) : base(list)
        {
        }
    }
}