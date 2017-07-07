using Data.Collections.Language;
using Data.FileConnection;
using Data.Helpers;

namespace Data.Patchers.CodeShiftPatcher
{
    public class CodeShiftPatcher
    {
        private readonly string _executableFilePath;
        private readonly IdentityCollection _languageStrings;

        public CodeShiftPatcher(string executableFilePath, IdentityCollection languageStrings)
        {
            _executableFilePath = executableFilePath;
            _languageStrings = languageStrings;
        }

        public void Apply()
        {
            // Team, driver and chief data
            ApplyReconstructedFunctionAt4706D7();
            ApplyRelocatedFunctionAt4718EA();

            // Track data
            ApplyReorderedModuleAt5031C6();

            // Driver names
            ApplyMissingTestDriverNames();
        }

        private void ApplyMissingTestDriverNames()
        {
            const string driver1ResourceId = "SID005819";
            const string driver2ResourceId = "SID005835";
            const string driver3ResourceId = "SID005867";
            const string driver1NameText = "Jason Watt";
            const string driver2NameText = "Juichi Wakisaka";
            const string driver3NameText = "Luciano Burti";
            const string driverUnknownNameText = "Driver Unknown";
            
            // Update test driver names if they have not been altered from the original value
            if (ResourceHelper.GetResourceText(_languageStrings, driver1ResourceId) == driverUnknownNameText)
            {
                ResourceHelper.SetResourceText(_languageStrings, driver1ResourceId, driver1NameText);
            }
            if (ResourceHelper.GetResourceText(_languageStrings, driver2ResourceId) == driverUnknownNameText)
            {
                ResourceHelper.SetResourceText(_languageStrings, driver2ResourceId, driver2NameText);
            }
            if (ResourceHelper.GetResourceText(_languageStrings, driver3ResourceId) == driverUnknownNameText)
            {
                ResourceHelper.SetResourceText(_languageStrings, driver3ResourceId, driver3NameText);
            }
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
                NopExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, ReconstructedFunctionAt4706D7.GetInstructions());
            }
        }

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
                NopExistingBytes(executableConnection, address, length);
                WriteNewBytes(executableConnection, address, ReorderedModuleAt5031C6.GetInstructions());
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