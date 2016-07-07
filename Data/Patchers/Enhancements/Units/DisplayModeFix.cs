namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to circumvent
    /// the requirement for the display mode to be 16-bit or greater.
    /// </summary>
    public class DisplayModeFix : DataPatcherUnitBase
    {
        public DisplayModeFix(string executableFilePath) : base(executableFilePath)
        {
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x00439E0A,
                Instructions = new byte[]
                {
                    0x0F, 0x84, 0x40, 0x00, 0x00, 0x00  // jz loc_439E50
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x00439E0A,
                Instructions = new byte[]
                {
                    0x90,                           // nop
                    0xE9, 0x40, 0x00, 0x00, 0x00    // jmp loc_439E50
                }
            });
        }
    }
}
