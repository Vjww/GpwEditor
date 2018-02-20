using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class NonF1ChiefEngineerRepository : RepositoryBase<NonF1ChiefEngineerEntity>
    {
        public NonF1ChiefEngineerRepository(List<NonF1ChiefEngineerEntity> list) : base(list)
        {
        }
    }
}