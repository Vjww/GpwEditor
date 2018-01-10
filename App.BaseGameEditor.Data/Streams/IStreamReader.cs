using System.Collections;
using System.IO;

namespace App.BaseGameEditor.Data.Streams
{
    public interface IStreamReader
    {
        byte[] Read(Stream stream, long offset, int count, SeekOrigin seekOrigin);
        IEnumerable ReadStringList(Stream stream);
    }
}