namespace Core.Helpers
{
    public static class InstructionHelper
    {
        /// <summary>
        /// Calculates the relative offset to an absolute position from an opcode position.
        /// </summary>
        /// <param name="opcodePosition">The position where the start of the opcode is located.</param>
        /// <param name="opcodeLength">The entire length of the opcode including parameters.</param>
        /// <param name="absolutePosition">The absolute position to calculate the relative position to.</param>
        /// <returns>Returns calculated relative offset.</returns>
        public static long CalculateRelativeOffsetFromAbsolutePosition(long opcodePosition, int opcodeLength, long absolutePosition)
        {
            return absolutePosition - (opcodePosition + opcodeLength);
        }

        /// <summary>
        /// Calculates the real position from a virtual position in a GPW v1.01b executable.
        /// </summary>
        /// <param name="virtualPosition">The virtual position in a file.</param>
        /// <returns>Returns calculated real position.</returns>
        public static long CalculateRealPositionFromVirtualPosition(long virtualPosition)
        {
            const long dataOffset = 0x00000800;
            const long rdataOffset = 0x00F63200;
            const long textOffset = 0x00400C00;

            // If position is in .data section
            if (virtualPosition > 0x015EF7CF)
            {
                // Subtract section offset and preceeding section offsets
                return virtualPosition - textOffset - rdataOffset - dataOffset;
            }

            // If position is in .rdata section
            if (virtualPosition > 0x00689FFF)
            {
                // Subtract section offset and preceeding section offsets
                return virtualPosition - textOffset - rdataOffset;
            }

            // If position is in .text section, subtract section offset
            return virtualPosition - textOffset;
        }

        public static long CalculatePositionWithLeaIndex(int index)
        {
            // mov ecx, eax
            // lea eax, [eax+eax*8]
            // lea eax, [ecx+eax*4]
            // lea eax, [ecx+eax*4]
            // lea eax, [eax+eax*2]
            // mov ds:dword_01234567[eax*8], 42

            var result = index;
            result = result + result * 8;
            result = index + result * 4;
            result = index + result * 4;
            result = result + result * 2;
            return result * 8;
        }
    }
}
