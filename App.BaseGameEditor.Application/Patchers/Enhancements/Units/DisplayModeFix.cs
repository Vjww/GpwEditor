namespace App.BaseGameEditor.Application.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to circumvent
    /// the requirement for the display mode to be 16-bit or greater.
    /// </summary>
    public class DisplayModeFix : DataPatcherUnitBase
    {
        public DisplayModeFix()
        {
            var taskId = 0;

            // Task A
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                TaskId = taskId,
                Description = typeof(DisplayModeFix).Name,
                VirtualPosition = 0x00439E0A,
                Instructions = new byte[]
                {
                    0x0F, 0x84, 0x40, 0x00, 0x00, 0x00 // jz loc_439E50
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                TaskId = taskId,
                Description = typeof(DisplayModeFix).Name,
                VirtualPosition = 0x00439E0A,
                Instructions = new byte[]
                {
                    0x90,                              // nop
                    0xE9, 0x40, 0x00, 0x00, 0x00       // jmp loc_439E50
                }
            });
            // End
        }
    }
}