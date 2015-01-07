
namespace Data.Patchers.Enhancements.Units
{
    public class RaceSoundsFix : IDataPatcherUnit
    {
        public long UnmodifiedVirtualFilePosition { get; private set; }
        public long ModifiedVirtualFilePosition { get; private set; }

        public RaceSoundsFix()
        {
            UnmodifiedVirtualFilePosition = 0x0;
            ModifiedVirtualFilePosition = 0x0;
        }

        public byte[] GetModifiedInstructions()
        {
            return new byte[]
            {
                0x90
            };
        }

        public byte[] GetUnmodifiedInstructions()
        {
            return new byte[]
            {
                0x90
            };

            // 0x00099E5F
            // 0x00049AA5F
        }
    }
}
