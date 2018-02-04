using System.IO;
using App.BaseGameEditor.Data.Factories;

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