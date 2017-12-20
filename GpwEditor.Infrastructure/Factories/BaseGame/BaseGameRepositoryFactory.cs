using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.Repositories.BaseGame;

namespace GpwEditor.Infrastructure.Factories.BaseGame
{
    public class BaseGameRepositoryFactory : IBaseGameRepositoryFactory
    {
        private readonly IEnumerable<IBaseGameRepository<IEntity>> _repositories;

        public BaseGameRepositoryFactory(IEnumerable<IBaseGameRepository<IEntity>> repositories)
        {
            _repositories = repositories ?? throw new ArgumentNullException(nameof(repositories));
        }

        public IBaseGameRepository<IEntity> Create(BaseGameRepositoryEnum repositoryType)
        {
            if (!Enum.IsDefined(typeof(BaseGameRepositoryEnum), repositoryType))
                throw new InvalidEnumArgumentException(nameof(repositoryType), (int)repositoryType, typeof(BaseGameRepositoryEnum));

            var typeName = $"IRepository<{repositoryType}>";
            var result = _repositories.SingleOrDefault(x => x.RepositoryType == repositoryType);

            if (result == null)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve '{typeName}'. Make sure the type is registered with the dependency injection container.");
            }

            return result;
        }
    }
}