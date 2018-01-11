using System.IO;

namespace App.BaseGameEditor.Data.Factories
{
    public class MemoryStreamFactory : IStreamFactory
    {
        public Stream Create()
        {
            return new MemoryStream();
        }
    }
}