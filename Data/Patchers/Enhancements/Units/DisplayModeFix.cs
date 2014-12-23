﻿
namespace Data.Patchers.Enhancements.Units
{
    public class DisplayModeFix : IDataPatcherUnit
    {
        public long UnmodifiedVirtualFilePosition { get; private set; }
        public long ModifiedVirtualFilePosition { get; private set; }

        public DisplayModeFix()
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
        }
    }
}