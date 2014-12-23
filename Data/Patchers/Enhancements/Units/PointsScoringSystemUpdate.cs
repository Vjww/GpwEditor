using System;
using Core.Enums;

namespace Data.Patchers.Enhancements.Units
{
    public class PointsScoringSystemUpdate : IDataPatcherUnit
    {
        public long UnmodifiedVirtualFilePosition { get; private set; }
        public long ModifiedVirtualFilePosition { get; private set; }

        public PointsScoringSystemUpdate()
        {
            UnmodifiedVirtualFilePosition = 0x0;
            ModifiedVirtualFilePosition = 0x0;
        }

        public byte[] GetModifiedInstructions()
        {
            throw new NotImplementedException("Please use the alternative declaration to specify which points scoring system to return.");
        }

        public byte[] GetModifiedInstructions(PointsScoringSystemType pointsScoringSystemType)
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
