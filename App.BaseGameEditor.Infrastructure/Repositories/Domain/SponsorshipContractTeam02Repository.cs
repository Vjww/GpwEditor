using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipContractTeam02Repository : RepositoryBase<SponsorshipContractTeam02Entity>
    {
        public SponsorshipContractTeam02Repository(List<SponsorshipContractTeam02Entity> list) : base(list)
        {
        }
    }
}