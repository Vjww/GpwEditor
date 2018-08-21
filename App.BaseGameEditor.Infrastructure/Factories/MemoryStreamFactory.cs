using System.IO;
using App.Shared.Data.Factories;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class MemoryStreamFactory : IStreamFactory
    {
        public Stream Create()
        {
            return new MemoryStream();
        }
    }
}