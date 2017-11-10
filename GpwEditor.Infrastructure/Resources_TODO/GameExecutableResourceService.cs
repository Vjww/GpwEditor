using System.IO;
using Common.Editor.Infrastructure.New;

namespace GpwEditor.Infrastructure.Resources
{
    public class GameExecutableResourceService : BinaryFileResourceBase<MemoryStream>
    {
        public GameExecutableResourceService(MemoryStream stream) : base(stream)
        {
        }
    }
}