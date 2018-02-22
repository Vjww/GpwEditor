using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class PerformanceCurveDataRepository : RepositoryBase<PerformanceCurveDataEntity>
    {
        public PerformanceCurveDataRepository(List<PerformanceCurveDataEntity> list) : base(list)
        {
        }
    }
}