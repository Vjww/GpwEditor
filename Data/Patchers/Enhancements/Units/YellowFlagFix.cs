
namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to protect
    /// the player from receiving an ignored yellow flag penalty.
    /// </summary>
    public class YellowFlagFix : DataPatcherUnitBase
    {
        public YellowFlagFix()
        {
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                Location = 0x00444E12,
                InstructionSet = new byte[]
                {
                    0x0F, 0x85, 0x3D, 0x00, 0x00, 0x00  // jnz loc_444E55
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                Location = 0x00444E12,
                InstructionSet = new byte[]
                {
                    0xE9, 0x3E, 0x00, 0x00, 0x00,   // jmp loc_444E55
                    0x90                            // nop
                }
            });
        }
    }
}
