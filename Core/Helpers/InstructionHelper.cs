
namespace Core.Helpers
{
    public static class InstructionHelper
    {
        /// <summary>
        /// Calculates the relative offset to an absolute position from an opcode position.
        /// </summary>
        /// <param name="opcodeHexPosition">The position where the start of the opcode is located.</param>
        /// <param name="opcodeLength">The entire length of the opcode including parameters.</param>
        /// <param name="absoluteHexPosition">The absolute position to calculate the relative position to.</param>
        /// <returns>Returns calculated relative offset.</returns>
        public static int CalculateRelativeOffsetFromAbsolutePosition(int opcodeHexPosition, int opcodeLength, int absoluteHexPosition)
        {
            return absoluteHexPosition - (opcodeHexPosition + opcodeLength);
        }

        /// <summary>
        /// Calculates the real position from a virtual position in a GPW v1.01b executable.
        /// </summary>
        /// <param name="virtualHexPosition">The </param>
        /// <returns>Returns calculated real position.</returns>
        public static int CalculateRealPositionFromVirtualPosition(int virtualHexPosition)
        {
            const int dataOffset = 0x00000800;
            const int rdataOffset = 0x00F63200;
            const int textOffset = 0x00400C00;

            // If position is in .data section
            if (virtualHexPosition > 0x015EF7CF)
            {
                // Subtract section offset and preceeding section offsets
                return virtualHexPosition - textOffset - rdataOffset - dataOffset;
            }

            // If position is in .rdata section
            if (virtualHexPosition > 0x00689FFF)
            {
                // Subtract section offset and preceeding section offsets
                return virtualHexPosition - textOffset - rdataOffset;
            }

            // If position is in .text section, subtract section offset
            return virtualHexPosition - textOffset;
        }

        public static int CalculatePositionWithLeaIndex(int index)
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
