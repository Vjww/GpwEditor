﻿namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to protect
    /// the player from receiving an ignored yellow flag penalty.
    /// </summary>
    public class YellowFlagFix : DataPatcherUnitBase
    {
        public YellowFlagFix(string executableFilePath) : base(executableFilePath)
        {
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x00444E12,
                Instructions = new byte[]
                {
                    0x0F, 0x85, 0x3D, 0x00, 0x00, 0x00  // jnz loc_444E55
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x00444E12,
                Instructions = new byte[]
                {
                    0x90,                           // nop
                    0xE9, 0x3D, 0x00, 0x00, 0x00    // jmp loc_444E55
                }
            });
        }
    }
}
