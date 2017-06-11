using System.Collections.Generic;
using System.Linq;

namespace Data.Patchers.CodeShiftPatcher
{
    public static class RelocatedDataFunctionAt401000
    {
        public static byte[] GetInstructions()
        {
            var functionStartInstructions = new byte[]
            {
                0x55,
                0x8B, 0xEC,
                0x53,
                0x56,
                0x57,
            };

            var teamInstructions = TeamData.GetInstructions();
            var driverInstructions = DriverData.GetInstructions();
            var chiefInstructions = ChiefData.GetInstructions();

            var functionEndInstructions = new byte[]
            {
                0x5F,
                0x5E,
                0x5B,
                0xC9,
                0xC3
            };

            var instructionModules = new List<byte[]>
            {
                functionStartInstructions,
                teamInstructions,
                driverInstructions,
                chiefInstructions,
                functionEndInstructions
            };

            var result = JoinInstructionModules(instructionModules);
            return result;
        }

        private static byte[] JoinInstructionModules(List<byte[]> instructionModules)
        {
            var arrayLength = instructionModules.Sum(item => item.Length);
            var result = new byte[arrayLength];

            var index = 0;
            foreach (var instructionModule in instructionModules)
            {
                foreach (var @byte in instructionModule)
                {
                    result[index] = @byte;
                    index++;
                }
            }

            return result;
        }
    }
}