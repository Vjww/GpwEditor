using System.Collections.Generic;

namespace Data.Patchers
{
    public interface IDataPatcherUnitBase
    {
        List<DataPatcherUnitTask> GetUnmodifiedInstructions();
        List<DataPatcherUnitTask> GetModifiedInstructions();
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

        public List<DataPatcherUnitTask> GetUnmodifiedInstructions()
        {
            return UnmodifiedInstructions;
        }

        public List<DataPatcherUnitTask> GetModifiedInstructions()
        {
            return ModifiedInstructions;
        }
    }
}
