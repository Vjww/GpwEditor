using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class PerformanceCurveRepository : RepositoryBase<PerformanceCurveEntity>
    {
        public PerformanceCurveRepository(List<PerformanceCurveEntity> list) : base(list)
        {
        }
    }
}