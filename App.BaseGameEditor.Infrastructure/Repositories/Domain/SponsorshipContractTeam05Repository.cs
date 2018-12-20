using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipContractTeam05Repository : RepositoryBase<SponsorshipContractTeam05Entity>
    {
        public SponsorshipContractTeam05Repository(List<SponsorshipContractTeam05Entity> list) : base(list)
        {
        }
    }
}