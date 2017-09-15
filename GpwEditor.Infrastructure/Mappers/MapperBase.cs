using System.Diagnostics;

namespace GpwEditor.Infrastructure.Mappers
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

        protected static int GetMultiplier0To31From0To21(int id)
        {
            // Generate a multiplier of 0,1,3,4..30,31 from id of 0,1,2,3..20,21 
            return id / 2 * 3 + id % 2; // 0..10 * 3 + 0..1
        }

        protected static int GetTeamAlphabeticalId(int id)
        {
            var idToAlphabeticalIdMap = new[]
            {
                10, 2, 1, 4, 3, 6, 7, 0, 8, 9, 5
            };

            return idToAlphabeticalIdMap[id];
        }

        //protected static int GetTeamLocalResourceId(int id)
        //{
        //    var idToResourceIdMap = new[]
        //        {
        //            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
        //        };

        //    return idToResourceIdMap[id];
        //}

        private void SetId(int id)
        {
            Debug.Assert(!_isInitialised, $"The {nameof(Id)} property cannot be changed after it has been initialised.");

            _id = id;
            _isInitialised = true;
        }
    }
}