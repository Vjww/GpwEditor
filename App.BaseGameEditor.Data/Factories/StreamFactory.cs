using System.IO;

namespace App.BaseGameEditor.Data.Factories
{
    public class StreamFactory : IStreamFactory
    {
        public Stream Create()
        {
            return new MemoryStream();
        }
    }
}