using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorRepository : RepositoryBase<SponsorEntity>
    {
        public SponsorRepository(List<SponsorEntity> list) : base(list)
        {
        }
    }
}