using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipEngineRepository : RepositoryBase<SponsorshipEngineEntity>
    {
        public SponsorshipEngineRepository(List<SponsorshipEngineEntity> list) : base(list)
        {
        }
    }
}