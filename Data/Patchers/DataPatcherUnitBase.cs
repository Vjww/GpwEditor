using System.Collections.Generic;

namespace Data.Patchers
{
    public interface IDataPatcherUnitBase
    {
        IEnumerable<DataPatcherUnitTask> GetUnmodifiedInstructions();
        IEnumerable<DataPatcherUnitTask> GetModifiedInstructions();
    }

    public class DataPatcherUnitBase : IDataPatcherUnitBase
    {
        protected readonly List<DataPatcherUnitTask> UnmodifiedInstructions;
        protected readonly List<DataPatcherUnitTask> ModifiedInstructions;

        public DataPatcherUnitBase()
        {
            UnmodifiedInstructions = new List<DataPatcherUnitTask>();
            ModifiedInstructions = new List<DataPatcherUnitTask>();
        }

        public IEnumerable<DataPatcherUnitTask> GetUnmodifiedInstructions()
        {
            return UnmodifiedInstructions;
        }

        public IEnumerable<DataPatcherUnitTask> GetModifiedInstructions()
        {
            return ModifiedInstructions;
        }
    }
}
