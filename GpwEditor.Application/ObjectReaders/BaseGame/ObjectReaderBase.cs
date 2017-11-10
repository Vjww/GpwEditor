using GpwEditor.Domain.Objects;
using GpwEditor.Infrastructure.Databases;

namespace GpwEditor.Application.ObjectReaders.BaseGame
{
    public abstract class ObjectReaderBase<TObject> : IObjectReader<TObject>
        where TObject : class, IObject
    {
        protected BaseGameDatabase Database;

        protected ObjectReaderBase(BaseGameDatabase database)
        {
            Database = database;
        }

        public abstract TObject Read(TObject @object);
    }
}