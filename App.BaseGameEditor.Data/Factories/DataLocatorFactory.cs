using System;
using App.BaseGameEditor.Data.DataLocators;

namespace App.BaseGameEditor.Data.Factories
{
    public class DataLocatorFactory<TDataLocator>
        where TDataLocator : class, IDataLocator
    {
        private readonly Func<TDataLocator> _instantiateType;

        public DataLocatorFactory(Func<TDataLocator> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public TDataLocator Create()
        {
            return _instantiateType.Invoke();
        }
    }
}