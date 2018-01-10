using System.IO;

namespace App.BaseGameEditor.Data.Factories
{
    public interface IStreamFactory
    {
        Stream Create();
    }
}