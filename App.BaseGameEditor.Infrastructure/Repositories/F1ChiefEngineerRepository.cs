using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class F1ChiefEngineerRepository : RepositoryBase<F1ChiefEngineerEntity>, IF1ChiefEngineerRepository
    {
        public F1ChiefEngineerRepository(List<F1ChiefEngineerEntity> list) : base(list)
        {
        }
    }
}