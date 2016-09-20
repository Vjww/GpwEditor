namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to protect
    /// the player from receiving an ignored yellow flag penalty.
    /// </summary>
    public class YellowFlagFix : DataPatcherUnitBase
    {
        public YellowFlagFix(string executableFilePath) : base(executableFilePath)
        {
            var taskId = 0;

            // Task A
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                TaskId = taskId,
                Description = $"{typeof(YellowFlagFix).Name} Unmodified; TaskId {taskId:D2};",
                VirtualPosition = 0x00444E12,
                Instructions = new byte[]
                {
                    0x0F, 0x85, 0x3D, 0x00, 0x00, 0x00  // jnz loc_444E55
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                TaskId = taskId,
                Description = $"{typeof(YellowFlagFix).Name} Modified; TaskId {taskId:D2};",
                VirtualPosition = 0x00444E12,
                Instructions = new byte[]
                {
                    0x90,                           // nop
                    0xE9, 0x3D, 0x00, 0x00, 0x00    // jmp loc_444E55
                }
            });
            // End
        }
    }
}
