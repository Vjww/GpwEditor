namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to circumvent the game's copyright protection check.
    /// The modified code changes conditional jumps into unconditional jumps
    /// when verifying whether the game CD is present on game launch.
    /// </summary>
    public class GameCdFix : DataPatcherUnitBase
    {
        public GameCdFix(string executableFilePath) : base(executableFilePath)
        {
            // Task A
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                VirtualPosition = 0x0043989D,
                Instructions = new byte[]
                {
                    0x0F, 0x85  // jnz
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                VirtualPosition = 0x0043989D,
                Instructions = new byte[]
                {
                    0x90,       // nop
                    0xE9        // jmp
                }
            });
            // End

            // Task B
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                VirtualPosition = 0x004398E3,
                Instructions = new byte[]
                {
                    0x0F, 0x85  // jnz
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                VirtualPosition = 0x004398E3,
                Instructions = new byte[]
                {
                    0x90,       // nop
                    0xE9        // jmp
                }
            });
            // End

            // Task C
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                VirtualPosition = 0x0043997A,
                Instructions = new byte[]
                {
                    0x0F, 0x84  // jz
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                VirtualPosition = 0x0043997A,
                Instructions = new byte[]
                {
                    0x90,       // nop
                    0xE9        // jmp
                }
            });
            // End
        }
    }
}
