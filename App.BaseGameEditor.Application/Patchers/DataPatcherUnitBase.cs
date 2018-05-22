using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using App.BaseGameEditor.Application.Data.Helpers;

namespace App.BaseGameEditor.Application.Patchers
{
    public interface IDataPatcherUnitBase
    {
        void ApplyModifiedCode(string gameExecutableFilePath);
        void ApplyUnmodifiedCode(string gameExecutableFilePath);
        bool IsCodeUnmodified(string gameExecutableFilePath);
        bool IsCodeModified(string gameExecutableFilePath);
    }

    public class DataPatcherUnitBase : IDataPatcherUnitBase
    {
        protected readonly ICollection<DataPatcherUnitTask> ModifiedInstructions;
        protected readonly ICollection<DataPatcherUnitTask> UnmodifiedInstructions;

        protected DataPatcherUnitBase()
        {
            ModifiedInstructions = new Collection<DataPatcherUnitTask>();
            UnmodifiedInstructions = new Collection<DataPatcherUnitTask>();
        }

        public void ApplyModifiedCode(string gameExecutableFilePath)
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Starting {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            ApplyCode(ModifiedInstructions, gameExecutableFilePath);
            Debug.WriteLine($"Finishing {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public void ApplyUnmodifiedCode(string gameExecutableFilePath)
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Starting {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            ApplyCode(UnmodifiedInstructions, gameExecutableFilePath);
            Debug.WriteLine($"Finishing {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public bool IsCodeModified(string gameExecutableFilePath)
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Evaluating {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            return AreInstructionTasksEqual(ModifiedInstructions, gameExecutableFilePath);
        }

        public bool IsCodeUnmodified(string gameExecutableFilePath)
        {
            Debug.WriteLine("********************************************************************************");
            Debug.WriteLine($"Evaluating {GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
            return AreInstructionTasksEqual(UnmodifiedInstructions, gameExecutableFilePath);
        }

        private void ApplyCode(IEnumerable<DataPatcherUnitTask> instructionTasks, string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                foreach (var instructionTask in instructionTasks)
                {
                    var realPosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionTask.VirtualPosition);
                    Debug.WriteLine($"Executing task {instructionTask.TaskId:D2} at location {instructionTask.VirtualPosition:X8} ({realPosition:X8})");
                    executableConnection.WriteByteArray(realPosition, instructionTask.Instructions);
                }
            }
        }

        private bool AreInstructionTasksEqual(IEnumerable<DataPatcherUnitTask> instructionTasks, string gameExecutableFilePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
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
                    for (var i = 0; i < currentInstructions.Length; i++)
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