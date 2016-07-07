namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to ignore a failed
    /// test and prevent continuous calls to GlobalUnlock on Windows XP or higher.
    /// </summary>
    public class GlobalUnlockFix : DataPatcherUnitBase
    {
        public GlobalUnlockFix(string executableFilePath) : base(executableFilePath)
        {
            var jumpPositions = new long[]
            {
                0x0041332A,
                0x00413632,
                0x004138A9,
                0x00413ABB,
                0x00413FBB,
                0x00414039,
                0x00414221,
                0x00414253,
                0x004142D4,
                0x004144B8,
                0x004145A7,
                0x00414636,
                0x004146A8,
                0x00414883,
                0x00414A66,
                0x00414AA2,
                0x00414AEA,
                0x0043B9AD,
                0x005C552D
            };

            var index = 0;
            foreach (var position in jumpPositions)
            {
                UnmodifiedInstructions.Add(new DataPatcherUnitTask()
                {
                    Index = index,
                    Description = $"Unmodified instructions at 0x{position:X8}.",
                    VirtualPosition = position,
                    Instructions = new byte[]
                    {
                        0x0F, 0x84, 0x05, 0x00, 0x00, 0x00 // jz loc_XXXXXX
                    }
                });

                ModifiedInstructions.Add(new DataPatcherUnitTask()
                {
                    Index = index,
                    Description = $"Modified instructions at 0x{position:X8}.",
                    VirtualPosition = position,
                    Instructions = new byte[]
                    {
                        0x90,                              // nop
                        0xE9, 0x05, 0x00, 0x00, 0x00       // jmp loc_XXXXXX
                    }
                });
                index++;
            }
        }
    }
}
