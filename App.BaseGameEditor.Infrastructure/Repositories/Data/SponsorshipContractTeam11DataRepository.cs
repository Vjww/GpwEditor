using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam11DataRepository : RepositoryBase<SponsorshipContractTeam11DataEntity>
    {
        public SponsorshipContractTeam11DataRepository(List<SponsorshipContractTeam11DataEntity> list) : base(list)
        {
        }
    }
}