using System.IO;
using Common.Editor.Infrastructure.New;

namespace GpwEditor.Infrastructure.Resources
{
    public class SaveGameResourceService : BinaryFileResourceBase<MemoryStream>
    {
        public SaveGameResourceService(MemoryStream stream) : base(stream)
        {
        }
    }
}