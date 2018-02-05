using System;
using App.Core.Factories;
using App.Core.Identities;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class IntegerIdentityFactory<TIntegerIdentity> : IIntegerIdentityFactory<TIntegerIdentity>
        where TIntegerIdentity : class, IIntegerIdentity
    {
        private readonly Func<TIntegerIdentity> _instantiateType;

        public IntegerIdentityFactory(Func<TIntegerIdentity> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public TIntegerIdentity Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}