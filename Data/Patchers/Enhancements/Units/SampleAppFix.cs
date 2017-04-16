namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to ignore
    /// a failed graphics check on Windows XP or higher.
    /// </summary>
    public class SampleAppFix : DataPatcherUnitBase
    {
        public SampleAppFix(string executableFilePath) : base(executableFilePath)
        {
            var taskId = 0;

            // Task A
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                TaskId = taskId,
                Description = typeof(SampleAppFix).Name,
                VirtualPosition = 0x0043A10C,
                Instructions = new byte[]
                {
                    0x0F, 0x8D, 0x66, 0x00, 0x00, 0x00 // jnz loc_43A178
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                TaskId = taskId,
                Description = typeof(SampleAppFix).Name,
                VirtualPosition = 0x0043A10C,
                Instructions = new byte[]
                {
                    0x90,                              // nop
                    0xE9, 0x66, 0x00, 0x00, 0x00       // jmp loc_43A178
                }
            });
            // End
        }
    }
}
