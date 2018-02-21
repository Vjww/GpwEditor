using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class EngineRepository : RepositoryBase<EngineEntity>
    {
        public EngineRepository(List<EngineEntity> list) : base(list)
        {
        }
    }
}