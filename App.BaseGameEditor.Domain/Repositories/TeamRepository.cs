using App.BaseGameEditor.Domain.Models;
using Common.Editor.Domain.Repositories;

namespace App.BaseGameEditor.Domain.Repositories
{
    public class TeamRepository : RepositoryBase<TeamModel>, IRepositorySize
    {
        public int Size { get; } = 11;
    }
}