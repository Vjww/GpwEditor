using GpwEditor.Domain.Objects;

namespace GpwEditor.Application.ObjectReaders
{
    public interface IObjectReader<TObject>
        where TObject : IObject
    {
        TObject Read(TObject @object);
    }
}