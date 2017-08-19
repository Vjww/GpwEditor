using System.Diagnostics;

namespace ConsoleApplication.Mappers
{
    public abstract class MapperBase : IMapper
    {
        private bool _isInitialised;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetId(value); }
        }

        public virtual void Map()
        {
            Debug.Assert(_isInitialised, $"The {nameof(Id)} property must be set before the {nameof(Map)} method can be called.");
        }

        private void SetId(int id)
        {
            Debug.Assert(!_isInitialised, $"The {nameof(Id)} property cannot be changed once it has been initialised.");

            _id = id;
            _isInitialised = true;
        }
    }
}