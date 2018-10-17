using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipTeamRepository : RepositoryBase<SponsorshipTeamEntity>
    {
        public SponsorshipTeamRepository(List<SponsorshipTeamEntity> list) : base(list)
        {
        }
    }
}