using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam10DataRepository : RepositoryBase<SponsorshipContractTeam10DataEntity>
    {
        public SponsorshipContractTeam10DataRepository(List<SponsorshipContractTeam10DataEntity> list) : base(list)
        {
        }
    }
}