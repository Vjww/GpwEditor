using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Application.Patchers.CodeShiftPatcher.Sponsor;

namespace App.BaseGameEditor.Application.Patchers.CodeShiftPatcher
{
    public class RelocatedFunctionAt401000
    {
        public static byte[] GetInstructions()
        {
            var functionStartInstructions = new byte[]
            {
                0x55,
                0x8B, 0xEC,
                0x53,
                0x56,
                0x57
            };

            var contractInstructions = ContractData.GetInstructions();
            var slotInstructions = SlotData.GetInstructions();
            var cashSponsorshipInstructions = CashSponsorshipData.GetInstructions();
            var fiaSponsorshipInstructions = FiaSponsorshipData.GetInstructions();

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
                contractInstructions,
                slotInstructions,
                cashSponsorshipInstructions,
                fiaSponsorshipInstructions,
                functionEndInstructions
            };

            return JoinInstructionModules(instructionModules);
        }

        private static byte[] JoinInstructionModules(IReadOnlyCollection<byte[]> instructionModules)
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