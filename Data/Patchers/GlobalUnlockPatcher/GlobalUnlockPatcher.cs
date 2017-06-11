using System;
using Data.FileConnection;
using Data.Helpers;

namespace Data.Patchers.GlobalUnlockPatcher
{
    /// <summary>
    /// The Global Unlock Patcher class makes changes to the instruction set/pattern
    /// in the gpw.exe v1.01b executable file to manage the return value from the
    /// Kernel32.dll function GlobalUnlock. The return value appears to be causing
    /// an incompatibility issue when running the game on Windows XP or higher.
    /// When the game is launched on OSes other than Windows 95/98/Me and without
    /// using any compatibility mode options, the game will lock up at the gold
    /// FIA logo launch screen. This appears to be caused by an infinite loop when
    /// the return value of GlobalUnlock is checked to confirm whether the memory
    /// was successfully unlocked. Under newer OSes, the return value appears to
    /// be different to older OSes, causing defensive code to continuously call
    /// GlobalUnlock when the the return value is equal to 1.
    /// 
    /// Changes are made to the instruction set where any calls to GlobalUnlock
    /// are now redirected to a newly created function. This new function will call
    /// GlobalUnlock on behalf of the original code and handle the return value
    /// and perform validation that will ensure the memory is successfully unlocked.
    /// 
    /// Code logic
    /// - Identifies all calls made to GlobalUnlock where the return value is tested.
    /// - Replaces calls to GlobalUnlock with calls to location of newly created function.
    /// - Inserts newly created function that will perform calls to GlobalUnlock and
    ///   return an appropriate value to prevent an infinate loop.
    /// 
    /// Notes
    /// - OpCode E8 uses a relative offset to locate the function, rather than a absolute value
    /// - The relative offset formula is: referenced_function_position - (opcode_position + 5 bytes) = relative_offset
    /// - This formula applies for both forward and backward referencing (using dword and overflow)
    /// 
    /// Examples
    /// --------
    /// OpCode FF 15 -> E8
    /// old	.text:0041487B	FF 15 AC D5 60 01           		call ds:GlobalUnlock
    /// new	.text:0041487B	90                                  nop
    ///                 	E8 6A D0 05 00						call sub_4718EA (newly created function)
    /// </summary>
    public class GlobalUnlockPatcher
    {
        private readonly string _executableFilePath;

        public GlobalUnlockPatcher(string executableFilePath)
        {
            _executableFilePath = executableFilePath;
        }

        /// <summary>
        /// Applys the redirect on all calls to GlobalUnlock where the return value is tested.
        /// This method is only intended for use with gpw.exe v1.01b.
        /// This method requires the Jump Bypass Patcher to be applied beforehand.
        /// Do not invoke this method more than once on the same file.
        /// </summary>
        public void Apply()
        {
            // New function to call GlobalUnlock on behalf of original calls
            var newGlobalUnlockInstructions = new byte[] {
                0x55,                               // push    ebp
                0x8B, 0xEC,                         // mov     ebp, esp
                0x53,                               // push    ebx
                0x56,                               // push    esi
                0x57,                               // push    edi

                // loc_call
                0x8B, 0x45, 0x08,                   // mov     eax, [ebp + arg_0]
                0x50,                               // push    eax
                0xFF, 0x15, 0xAC, 0xD5, 0x60, 0x01, // call    GlobalUnlock

                // if result greater than 1, go to loc_call
                0x83, 0xF8, 0x01,                   // cmp     eax, 1
                0x0F, 0x8F, 0xED, 0xFF, 0xFF, 0xFF, // jg      loc_call

                // if result is 0, jump to loc_continue
                0x85, 0xC0,                         // test    eax, eax
                0x0F, 0x84, 0x0C, 0x00, 0x00, 0x00, // jz      loc_continue

                // therefore result must be 1
                // call once more for safety (and ignore if still returns 1)
                0x8B, 0x45, 0x08,                   // mov     eax, [ebp + arg_0]
                0x50,                               // push    eax
                0xFF, 0x15, 0xAC, 0xD5, 0x60, 0x01, // call    GlobalUnlock

                // ensure eax is set to 0
                0x33, 0xC0,                         // xor     eax, eax

                // loc_contine
                0x5F,                               // pop     edi
                0x5E,                               // pop     esi
                0x5B,                               // pop     ebx
                0xC9,                               // leave
                0xC3                                // retn
            };

            // File location to insert new function
            var newGlobalUnlockLocation = 0x00474C17;

            // New redirect instruction template, 0x00 will be overwritten by relative function location
            var newRedirectInstructions = new byte[] {
                0x90, 0xE8, 0x00, 0x00, 0x00, 0x00
            };

            // File location of each global unlock call to modify
            var globalUnlockLocation = new long[]
            {
                0x00413322, 0x0041362A, 0x004138A1, 0x00413AB3, 0x00413FB3, 0x00414031, 0x00414219, 0x0041424B,
                0x004142CC, 0x004144B0, 0x0041459F, 0x0041462E, 0x004146A0, 0x0041487B, 0x00414A5E, 0x00414A9A,
                0x00414AE2, 0x0043B9A5, 0x005C5525
            };

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                // Apply new function to call GlobalUnlock on behalf of original calls
                executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(newGlobalUnlockLocation), newGlobalUnlockInstructions);

                // Apply redirects
                foreach (var item in globalUnlockLocation)
                {
                    var redirectInstructions = new byte[6];
                    var relativeFunctionLocation = BitConverter.GetBytes(newGlobalUnlockLocation - (item + 6));

                    // Create copy of new instructions by overwriting current instructions
                    Array.Copy(newRedirectInstructions, redirectInstructions, redirectInstructions.Length);

                    // Modify with new instructions
                    for (var i = 2; i < 6; i++)
                    {
                        // Write first four bytes of eight into the last four bytes of six
                        redirectInstructions[i] = relativeFunctionLocation[i - 2];
                    }

                    // Write six bytes
                    executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(item), redirectInstructions);
                }
            }
        }
    }
}