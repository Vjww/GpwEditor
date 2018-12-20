using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam04DataRepository : RepositoryBase<SponsorshipContractTeam04DataEntity>
    {
        public SponsorshipContractTeam04DataRepository(List<SponsorshipContractTeam04DataEntity> list) : base(list)
        {
        }
    }
}