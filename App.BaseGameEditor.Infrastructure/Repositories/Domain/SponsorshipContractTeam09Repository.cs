using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipContractTeam09Repository : RepositoryBase<SponsorshipContractTeam09Entity>
    {
        public SponsorshipContractTeam09Repository(List<SponsorshipContractTeam09Entity> list) : base(list)
        {
        }
    }
}