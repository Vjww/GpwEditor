using System.Diagnostics;

namespace GpwEditor.Infrastructure.Entities
{
    public abstract class EntityBase : IEntity
    {
        private bool _isInitialised;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetId(value); }
        }

        private void SetId(int id)
        {
            Debug.Assert(!_isInitialised, $"The {nameof(Id)} property cannot be changed after it has been initialised.");

            _id = id;
            _isInitialised = true;
        }
    }
}