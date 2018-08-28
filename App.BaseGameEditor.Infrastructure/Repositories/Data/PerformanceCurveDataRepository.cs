using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class PerformanceCurveDataRepository : RepositoryBase<PerformanceCurveDataEntity>
    {
        public PerformanceCurveDataRepository(List<PerformanceCurveDataEntity> list) : base(list)
        {
        }
    }
}