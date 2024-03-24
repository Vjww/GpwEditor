using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorFiaRepository : RepositoryBase<SponsorFiaEntity>
    {
        public SponsorFiaRepository(List<SponsorFiaEntity> list) : base(list)
        {
        }
    }
}