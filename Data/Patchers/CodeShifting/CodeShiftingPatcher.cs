using Data.FileConnection;
using Data.Helpers;
using Data.Patchers.CodeShifting.Units;

namespace Data.Patchers.CodeShifting
{
    public class CodeShiftingPatcher
    {
        private readonly string _executableFilePath;

        public CodeShiftingPatcher(string executableFilePath)
        {
            _executableFilePath = executableFilePath;
        }

        public void Apply()
        {
            var firstByte = 0x0047141F;
            var lastByte = 0x00478F18;

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
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
        }
    }
}
