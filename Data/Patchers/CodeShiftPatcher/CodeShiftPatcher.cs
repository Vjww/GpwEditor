﻿using Data.FileConnection;
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
            ApplyReconstructedDataFunctionAt4706D7();
            ApplyRelocatedDataFunctionAt401000();

            ApplyReorderedInstructionsAt5031C6();
        }

        private void ApplyReconstructedDataFunctionAt4706D7()
        {
            const int firstByteAddress = 0x004706D7;
            const int lastByteAddress = 0x004793DE;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                NopExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, ReconstructedDataFunctionAt4706D7.GetInstructions());
            }
        }

        private void ApplyRelocatedDataFunctionAt401000()
        {
            const int relocationAddress = 0x00401000;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                WriteNewBytes(executableConnection, relocationAddress, RelocatedDataFunctionAt401000.GetInstructions());
            }
        }

        private void ApplyReorderedInstructionsAt5031C6()
        {
            // Apply reordered track data
            const int firstByteAddress = 0x005031C6;
            const int lastByteAddress = 0x00503EE5;

            const int address = firstByteAddress;
            const int length = lastByteAddress + 1 - firstByteAddress;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                NopExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, TrackData.GetInstructions());
            }
        }

        private static void NopExistingBytes(ExecutableConnection executableConnection, int address, int length)
        {
            // Create byte array of NOPs
            var nopInstructions = new byte[length];
            for (var i = 0; i < nopInstructions.Length; i++)
            {
                nopInstructions[i] = 0x90;
            }

            // Write byte array of NOPs
            executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(address), nopInstructions);
        }

        private static void WriteNewBytes(ExecutableConnection executableConnection, int address, byte[] instructions)
        {
            var realAddress = InstructionHelper.CalculateRealPositionFromVirtualPosition(address);
            executableConnection.WriteByteArray(realAddress, instructions);
        }
    }
}