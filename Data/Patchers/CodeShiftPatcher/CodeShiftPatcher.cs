using Data.FileConnection;
using Data.Helpers;

namespace Data.Patchers.CodeShiftPatcher
{
    public class CodeShiftPatcher
    {
        private readonly string _executableFilePath;

        public CodeShiftPatcher(string executableFilePath)
        {
            _executableFilePath = executableFilePath;
        }

        public void Apply()
        {
            // Team, driver and chief data
            ApplyReconstructedFunctionAt4706D7();
            ApplyRelocatedFunctionAt4718EA();

            // Track data
            ApplyReorderedModuleAt5031C6();
        }

        private void ApplyReconstructedFunctionAt4706D7()
        {
            const int firstByteAddress = 0x004706D7;
            const int lastByteAddress = 0x004793DE;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                ClearExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, ReconstructedFunctionAt4706D7.GetInstructions());
            }
        }

        // ReSharper disable once InconsistentNaming
        private void ApplyRelocatedFunctionAt4718EA()
        {
            const int relocationAddress = 0x004718EA;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                WriteNewBytes(executableConnection, relocationAddress, RelocatedFunctionAt4718EA.GetInstructions());
            }
        }

        private void ApplyReorderedModuleAt5031C6()
        {
            const int firstByteAddress = 0x005031C6;
            const int lastByteAddress = 0x00503EE5;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                ClearExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, ReorderedModuleAt5031C6.GetInstructions());
            }
        }

        private static void ClearExistingBytes(ExecutableConnection executableConnection, int address, int length)
        {
            // Create byte array
            var clearByteArray = new byte[length];
            for (var i = 0; i < clearByteArray.Length; i++)
            {
                clearByteArray[i] = 0xCC; // Fill array with int3 opcode
            }

            // Write byte array
            executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(address), clearByteArray);
        }

        private static void WriteNewBytes(ExecutableConnection executableConnection, int address, byte[] instructions)
        {
            var realAddress = InstructionHelper.CalculateRealPositionFromVirtualPosition(address);
            executableConnection.WriteByteArray(realAddress, instructions);
        }
    }
}