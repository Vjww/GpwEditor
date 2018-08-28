using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class TrackRepository : RepositoryBase<TrackEntity>
    {
        public TrackRepository(List<TrackEntity> list) : base(list)
        {
        }
    }
}