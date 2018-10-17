using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipTyreRepository : RepositoryBase<SponsorshipTyreEntity>
    {
        public SponsorshipTyreRepository(List<SponsorshipTyreEntity> list) : base(list)
        {
        }
    }
}