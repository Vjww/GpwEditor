
namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to perform an unconditional jump to circumvent
    /// the requirement for the display mode to be 16-bit or greater.
    /// </summary>
    public class DisplayModeFix : IDataPatcherUnit
    {
        public long UnmodifiedVirtualFilePosition { get; private set; }
        public long ModifiedVirtualFilePosition { get; private set; }

        public DisplayModeFix()
        {
            UnmodifiedVirtualFilePosition = 0x00439E0A;
            ModifiedVirtualFilePosition = 0x00439E0A;
        }

        public byte[] GetModifiedInstructions()
        {
            return new byte[]
            {
                0xE9, 0x41, 0x00, 0x00, 0x00,       // jmp loc_439E50
                0x90                                // nop
            };
        }

        public byte[] GetUnmodifiedInstructions()
        {
            return new byte[]
            {
                0x0F, 0x84, 0x40, 0x00, 0x00, 0x00  // jz loc_439E50
            };
        }
    }
}
