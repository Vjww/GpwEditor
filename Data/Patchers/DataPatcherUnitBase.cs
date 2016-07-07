using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Common.Enums;
using Core.Helpers;
using Data.FileConnection;

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
            ApplyCode(ModifiedInstructions);
        }

        public void ApplyUnmodifiedCode()
        {
            ApplyCode(UnmodifiedInstructions);
        }

        public bool IsCodeModified()
        {
            return IsInstructionTasksEqual(ModifiedInstructions);
        }

        public bool IsCodeUnmodified()
        {
            return IsInstructionTasksEqual(UnmodifiedInstructions);
        }

        private void ApplyCode(IEnumerable<DataPatcherUnitTask> instructionTasks)
        {
            ExecutableConnection executableConnection = null;

            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(_executableFilePath, StreamDirectionType.Write);

                foreach (var instructionTask in instructionTasks)
                {
                    var realPosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionTask.VirtualPosition);
                    executableConnection.WriteByteArray(realPosition, instructionTask.Instructions);
#if DEBUG
                    Debug.WriteLine($"Instruction index {instructionTask.Index}: {instructionTask.Description}. Offset: {realPosition}");
#endif
                }
            }
            finally
            {
                executableConnection?.Close();
            }
        }

        private bool IsInstructionTasksEqual(IEnumerable<DataPatcherUnitTask> instructionTasks)
        {
            ExecutableConnection executableConnection = null;

            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(_executableFilePath, StreamDirectionType.Read);

                foreach (var instructionTask in instructionTasks)
                {
                    var currentInstructions =
                        executableConnection.ReadByteArray(
                            InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionTask.VirtualPosition),
                            instructionTask.Instructions.Length);

                    // If current instructions do not equal unmodified instructions
                    if (!currentInstructions.SequenceEqual(instructionTask.Instructions))
                    {
                        return false;
                    }
                }

                return true;
            }
            finally
            {
                executableConnection?.Close();
            }
        }
    }
}
