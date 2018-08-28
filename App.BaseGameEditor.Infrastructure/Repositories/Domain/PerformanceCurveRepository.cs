using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class PerformanceCurveRepository : RepositoryBase<PerformanceCurveEntity>
    {
        public PerformanceCurveRepository(List<PerformanceCurveEntity> list) : base(list)
        {
        }
    }
}