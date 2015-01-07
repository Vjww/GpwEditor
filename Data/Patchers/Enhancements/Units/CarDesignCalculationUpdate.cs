using System;

namespace Data.Patchers.Enhancements.Units
{
    public class CarDesignCalculationUpdate : DataPatcherUnitBase
    {
        public CarDesignCalculationUpdate()
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
