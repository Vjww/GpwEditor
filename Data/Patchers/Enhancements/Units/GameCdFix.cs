using System;

namespace Data.Patchers.Enhancements.Units
{
    public class GameCdFix : DataPatcherUnitBase
    {
        public GameCdFix()
        {
            throw new NotImplementedException();

            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                Position = 0x0,
                InstructionSet = new byte[]
                {
                    0x90    // nop
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                Position = 0x0,
                InstructionSet = new byte[]
                {
                    0x90    // nop
                }
            });
        }
    }
}
