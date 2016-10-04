using Common.Enums;
using Data.FileConnection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
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
                    Debug.WriteLine($"Applied code for {instructionTask.Description} Virtual: {instructionTask.VirtualPosition:X8}; Real: {realPosition:X8};");
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
                    var virtualPosition = instructionTask.VirtualPosition;
                    var realPosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionTask.VirtualPosition);
                    var currentInstructions = executableConnection.ReadByteArray(realPosition, instructionTask.Instructions.Length);

                    // If current instructions do not equal unmodified instructions
#if DEBUG
                    var debugStringCollection = new StringCollection();
                    for (var i = 0; i < currentInstructions.Count(); i++)
                    {
                        if (currentInstructions[i].Equals(instructionTask.Instructions[i]))
                        {
                            continue;
                        }

                        var debugVirtualPosition = virtualPosition + i;
                        var debugRealPosition = realPosition + i;

                        debugStringCollection.Add($"Byte mismatch; - File: {currentInstructions[i]:X2}; Code: {instructionTask.Instructions[i]:X2}; Index: {i:X8}; Virtual: {debugVirtualPosition:X8}; Real: {debugRealPosition:X8};");
                    }
                    if (debugStringCollection.Count > 0)
                    {
                        //Debug.WriteLine($"{instructionTask.Description} - Instructions in code are not equal to instructions in file.");
                        //foreach (var line in debugStringCollection)
                        //{
                        //    Debug.WriteLine(line);
                        //}
                        return false;
                    }
#else
                    if (!currentInstructions.SequenceEqual(instructionTask.Instructions))
                    {
                        return false;
                    }
#endif
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
