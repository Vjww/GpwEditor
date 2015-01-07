using System;

namespace Data.Patchers.Enhancements.Units
{
    public class PointsScoringSystemUpdate : DataPatcherUnitBase
    {
        public PointsScoringSystemUpdate()
        {
            // Points251815121086421
            // Points108654321
            // Points1064321
            // Points964321

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
