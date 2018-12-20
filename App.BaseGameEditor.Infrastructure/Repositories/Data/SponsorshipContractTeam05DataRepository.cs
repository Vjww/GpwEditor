using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam05DataRepository : RepositoryBase<SponsorshipContractTeam05DataEntity>
    {
        public SponsorshipContractTeam05DataRepository(List<SponsorshipContractTeam05DataEntity> list) : base(list)
        {
        }
    }
}