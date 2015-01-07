using System.Collections;
using System.Collections.Generic;

namespace Data.Patchers
{
    public class DataPatcherUnitBase
    {
        protected readonly List<DataPatcherUnitTask> UnmodifiedInstructions;
        protected readonly List<DataPatcherUnitTask> ModifiedInstructions;

        public DataPatcherUnitBase()
        {
            UnmodifiedInstructions = new List<DataPatcherUnitTask>();
            ModifiedInstructions = new List<DataPatcherUnitTask>();
        }

        public IEnumerable GetUnmodifiedInstructions()
        {
            return UnmodifiedInstructions;
        }

        public IEnumerable GetModifiedInstructions()
        {
            return ModifiedInstructions;
        }
    }
}
