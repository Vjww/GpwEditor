using App.BaseGameEditor.Application.Data.Helpers;

namespace App.BaseGameEditor.Application.Patchers.CodeShiftPatcher
{
    public class CodeShiftPatcher
    {
        public void Apply(string gameExecutableFilePath)
        {
            // Team, driver and chief data
            ApplyReconstructedFunctionAt4706D7(gameExecutableFilePath);
            ApplyRelocatedFunctionAt4718EA(gameExecutableFilePath);

            // Track data
            ApplyReorderedModuleAt5031C6(gameExecutableFilePath);
        }

        private void ApplyReconstructedFunctionAt4706D7(string gameExecutableFilePath)
        {
            const int firstByteAddress = 0x004706D7;
            const int lastByteAddress = 0x004793DE;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                ClearExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, ReconstructedFunctionAt4706D7.GetInstructions());
            }
        }

        // ReSharper disable once InconsistentNaming
        private void ApplyRelocatedFunctionAt4718EA(string gameExecutableFilePath)
        {
            const int relocationAddress = 0x004718EA;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                WriteNewBytes(executableConnection, relocationAddress, RelocatedFunctionAt4718EA.GetInstructions());
            }
        }

        private void ApplyReorderedModuleAt5031C6(string gameExecutableFilePath)
        {
            const int firstByteAddress = 0x005031C6;
            const int lastByteAddress = 0x00503EE5;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
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