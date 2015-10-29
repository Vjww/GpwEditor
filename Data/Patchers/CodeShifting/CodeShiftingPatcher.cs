// How to write call to new function
// var functionInstructions = new byte[5] { 0xE8, 0x00, 0x00, 0x00, 0x00 };
// Array.Copy(BitConverter.GetBytes(positionOfNewFunction - (nopPositions[0] + 5)), 0, functionInstructions, 1, 4);
// executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(nopPositions[0]), functionInstructions);

using Common.Enums;
using Core.Helpers;
using Data.FileConnection;
using Data.Patchers.CodeShifting.Units;

namespace Data.Patchers.CodeShifting
{
    public class CodeShiftingPatcher
    {
        public void Apply(string filePath)
        {
            // File connection
            ExecutableConnection executableConnection = null;

            var firstByte = 0x0047141F;
            var lastByte = 0x00478F18;

            // Open file and write
            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(filePath, StreamDirectionType.Write);

                // Create byte array of NOPs
                var nopInstructions = new byte[lastByte + 1 - firstByte];
                for (var i = 0; i < nopInstructions.Length; i++)
                {
                    nopInstructions[i] = 0x90;
                }

                // Write byte array of NOPs
                executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(firstByte), nopInstructions);

                // Get the data-laden instructions
                var teamInstructions = TeamData.GetInstructions();
                var personnelInstructions = PersonnelData.GetInstructions();
                var driverInstructions = DriverData.GetInstructions();

                // Write instructions
                var writePosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(firstByte);
                executableConnection.WriteByteArray(writePosition, teamInstructions);
                writePosition += teamInstructions.Length;
                executableConnection.WriteByteArray(writePosition, personnelInstructions);
                writePosition += personnelInstructions.Length;
                executableConnection.WriteByteArray(writePosition, driverInstructions);

                // Apply track changes
                firstByte = 0x005031C6;
                lastByte = 0x00503EE5;

                // Create byte array of NOPs
                var nopTrackInstructions = new byte[lastByte + 1 - firstByte];
                for (var i = 0; i < nopTrackInstructions.Length; i++)
                {
                    nopTrackInstructions[i] = 0x90;
                }

                // Write byte array of NOPs
                executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(firstByte), nopTrackInstructions);

                // Get the data-laden instructions
                var trackInstructions = TrackData.GetInstructions();
                writePosition = InstructionHelper.CalculateRealPositionFromVirtualPosition(firstByte);
                executableConnection.WriteByteArray(writePosition, trackInstructions);
            }
            finally
            {
                if (executableConnection != null)
                {
                    executableConnection.Close();
                }
            }
        }
    }
}
