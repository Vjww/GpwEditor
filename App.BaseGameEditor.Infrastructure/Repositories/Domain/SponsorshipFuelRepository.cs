using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipFuelRepository : RepositoryBase<SponsorshipFuelEntity>
    {
        public SponsorshipFuelRepository(List<SponsorshipFuelEntity> list) : base(list)
        {
        }
    }
}