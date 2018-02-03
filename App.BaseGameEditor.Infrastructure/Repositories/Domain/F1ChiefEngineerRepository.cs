using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class F1ChiefEngineerRepository : RepositoryBase<F1ChiefEngineerEntity>
    {
        public F1ChiefEngineerRepository(List<F1ChiefEngineerEntity> list) : base(list)
        {
        }
    }
}