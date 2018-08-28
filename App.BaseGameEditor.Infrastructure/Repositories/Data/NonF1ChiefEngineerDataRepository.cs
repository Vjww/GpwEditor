using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class NonF1ChiefEngineerDataRepository : RepositoryBase<NonF1ChiefEngineerDataEntity>
    {
        public NonF1ChiefEngineerDataRepository(List<NonF1ChiefEngineerDataEntity> list) : base(list)
        {
        }
    }
}