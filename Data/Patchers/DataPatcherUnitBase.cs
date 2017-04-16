using Data.FileConnection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Data.Helpers;

namespace Data.Patchers
{
    public interface IDataPatcherUnitBase
    {
        void ApplyModifiedCode();
        void ApplyUnmodifiedCode();
        bool IsCodeUnmodified();
        bool IsCodeModified();
    }

    public class DataPatcherUnitBase : IDataPatcherUnitBase
    {
        private readonly string _executableFilePath;
        protected readonly ICollection<DataPatcherUnitTask> ModifiedInstructions;
        protected readonly ICollection<DataPatcherUnitTask> UnmodifiedInstructions;

        protected DataPatcherUnitBase(string executableFilePath)
        {
            _executableFilePath = executableFilePath;
            ModifiedInstructions = new Collection<DataPatcherUnitTask>();
            UnmodifiedInstructions = new Collection<DataPatcherUnitTask>();
        }

        public void ApplyModifiedCode()
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Starting {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            ApplyCode(ModifiedInstructions);
            Debug.WriteLine($"Finishing {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public void ApplyUnmodifiedCode()
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Starting {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            ApplyCode(UnmodifiedInstructions);
            Debug.WriteLine($"Finishing {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public bool IsCodeModified()
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Evaluating {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            return AreInstructionTasksEqual(ModifiedInstructions);
        }

        public bool IsCodeUnmodified()
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Evaluating {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            return AreInstructionTasksEqual(UnmodifiedInstructions);
        }

        private void ApplyCode(IEnumerable<DataPatcherUnitTask> instructionTasks)
        {
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                foreach (var instructionTask in instructionTasks)
                {
                    var realPosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionTask.VirtualPosition);
                    Debug.WriteLine($"Executing task {instructionTask.TaskId:D2} at location {instructionTask.VirtualPosition:X8} ({realPosition:X8})");
                    executableConnection.WriteByteArray(realPosition, instructionTask.Instructions);
                }
            }
        }

        private bool AreInstructionTasksEqual(IEnumerable<DataPatcherUnitTask> instructionTasks)
        {
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                foreach (var instructionTask in instructionTasks)
                {
                    var realPosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionTask.VirtualPosition);
                    var currentInstructions = executableConnection.ReadByteArray(realPosition, instructionTask.Instructions.Length);

#if DEBUG
                    var virtualPosition = instructionTask.VirtualPosition;
                    Debug.WriteLine($"Evaluating task {instructionTask.TaskId:D2} at location {virtualPosition:X8} ({realPosition:X8})");

                    // If current instructions (file) do not equal task instructions (code)
                    var debugStringCollection = new StringCollection();
                    for (var i = 0; i < currentInstructions.Count(); i++)
                    {
                        if (currentInstructions[i].Equals(instructionTask.Instructions[i]))
                        {
                            continue;
                        }

                        var debugVirtualPosition = virtualPosition + i;
                        var debugRealPosition = realPosition + i;

                        debugStringCollection.Add($"Mismatch at location {debugVirtualPosition:X8} ({debugRealPosition:X8}) at byte index {i:X8}. Value {currentInstructions[i]:X2} vs. {instructionTask.Instructions[i]:X2} (File vs. Code).");
                    }
                    if (debugStringCollection.Count > 0)
                    {
                        Debug.WriteLine("WARNING - Instructions in code are not equal to instructions in file.");
                        foreach (var line in debugStringCollection)
                        {
                            Debug.WriteLine(line);
                        }
                        return false;
                    }
#else
                    // If current instructions (file) do not equal task instructions (code)
                    if (!currentInstructions.SequenceEqual(instructionTask.Instructions))
                    {
                        return false;
                    }
#endif
                }

                return true;
            }
        }
    }
}
