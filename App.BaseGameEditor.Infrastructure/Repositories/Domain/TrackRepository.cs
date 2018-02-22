using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class TrackRepository : RepositoryBase<TrackEntity>
    {
        public TrackRepository(List<TrackEntity> list) : base(list)
        {
        }
    }
}