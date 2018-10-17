using System;
using App.BaseGameEditor.Application.Data.Helpers;

namespace App.BaseGameEditor.Application.Patchers.CodeShiftPatcher
{
    public class CodeShiftPatcher
    {
        private readonly ReconstructedFunctionAt4E7A25 _reconstructedFunctionAt4E7A25;

        public CodeShiftPatcher(ReconstructedFunctionAt4E7A25 reconstructedFunctionAt4E7A25)
        {
            _reconstructedFunctionAt4E7A25 = reconstructedFunctionAt4E7A25 ?? throw new ArgumentNullException(nameof(reconstructedFunctionAt4E7A25));
        }

        public void Apply(string gameExecutableFilePath)
        {
            // Team, driver and chief data
            ApplyReconstructedFunctionAt4706D7(gameExecutableFilePath);
            ApplyRelocatedFunctionAt4718EA(gameExecutableFilePath);

            // Track data
            ApplyReorderedModuleAt5031C6(gameExecutableFilePath);

            // Sponsor data
            ApplyReconstructedFunctionAt4E7A25(gameExecutableFilePath);
            ApplyRelocatedFunctionAt401000(gameExecutableFilePath);
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

        private void ApplyReconstructedFunctionAt4E7A25(string gameExecutableFilePath)
        {
            const int firstByteAddress = 0x004E7A25;
            const int lastByteAddress = 0x004EA3EF;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                ClearExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, _reconstructedFunctionAt4E7A25.GetInstructions());
            }
        }

        private void ApplyRelocatedFunctionAt401000(string gameExecutableFilePath)
        {
            const int relocationAddress = 0x00401000;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(gameExecutableFilePath))
            {
                WriteNewBytes(executableConnection, relocationAddress, RelocatedFunctionAt401000.GetInstructions());
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