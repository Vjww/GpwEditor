using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Factories.Repositories
{
    public class BaseGameRepositoryFactory : IBaseGameRepositoryFactory
    {
        private readonly IEnumerable<IBaseGameRepository> _baseGameRepositories;

        public BaseGameRepositoryFactory(IEnumerable<IBaseGameRepository> baseGameRepositories)
        {
            _baseGameRepositories = baseGameRepositories ?? throw new ArgumentNullException(nameof(baseGameRepositories));
        }

        public IBaseGameRepository Create(BaseGameRepositoryType repository)
        {
            if (!Enum.IsDefined(typeof(BaseGameRepositoryType), repository))
                throw new InvalidEnumArgumentException(nameof(repository), (int)repository, typeof(BaseGameRepositoryType));

            var name = $"{repository}Repository";
            var result = _baseGameRepositories.SingleOrDefault(x => x.Type == repository);

            if (result == null)
            {
                throw new InvalidOperationException($"Unable to resolve '{name}'. Make sure the type is registered with the dependency injection container.");
            }

            return result;
        }
    }
}