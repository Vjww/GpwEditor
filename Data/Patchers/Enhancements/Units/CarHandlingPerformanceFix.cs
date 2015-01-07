using System;

namespace Data.Patchers.Enhancements.Units
{
    public class CarHandlingPerformanceFix : DataPatcherUnitBase
    {
        public CarHandlingPerformanceFix()
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
                Location = 0x0,
                InstructionSet = new byte[]
                {
                    0x90    // nop
                }
            });
        }
    }
}
