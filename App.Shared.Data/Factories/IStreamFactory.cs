using System.IO;

namespace App.Shared.Data.Factories
{
    public interface IStreamFactory
    {
        Stream Create();
    }
}