using System;
using App.Shared.Data.Factories;
using App.Shared.Data.Objects;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class SponsorContractObjectFactory : ISponsorContractObjectFactory
    {
        private readonly Func<SponsorContractObject> _instantiateType;

        public SponsorContractObjectFactory(Func<SponsorContractObject> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public SponsorContractObject Create()
        {
            return _instantiateType.Invoke();
        }
    }
}