using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipContractTeam08Repository : RepositoryBase<SponsorshipContractTeam08Entity>
    {
        public SponsorshipContractTeam08Repository(List<SponsorshipContractTeam08Entity> list) : base(list)
        {
        }
    }
}