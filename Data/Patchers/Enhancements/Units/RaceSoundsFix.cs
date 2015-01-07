using System;

namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to eliminate calls made to memset()
    /// to prevent the game from crashing on Win XP/Vista/7
    /// when preparing memory areas for loading race sounds.
    /// </summary>
    public class RaceSoundsFix : DataPatcherUnitBase
    {
        public RaceSoundsFix()
        {
            throw new NotImplementedException();

            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                Location = 0x0,
                InstructionSet = new byte[]
                {
                    0x90    // nop
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                // 0x00099E5F
                // 0x00049AA5F

                Location = 0x0,
                InstructionSet = new byte[]
                {
                    0x90    // nop
                }
            });
        }
    }
}
