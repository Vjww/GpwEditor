using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam07DataRepository : RepositoryBase<SponsorshipContractTeam07DataEntity>
    {
        public SponsorshipContractTeam07DataRepository(List<SponsorshipContractTeam07DataEntity> list) : base(list)
        {
        }
    }
}