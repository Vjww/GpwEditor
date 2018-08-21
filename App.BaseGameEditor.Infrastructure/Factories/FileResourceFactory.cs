using System;
using App.Shared.Data.FileResources;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class FileResourceFactory
    {
        private readonly Func<FileResource> _instantiateType;

        public FileResourceFactory(Func<FileResource> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public FileResource Create()
        {
            return _instantiateType.Invoke();
        }
    }
}