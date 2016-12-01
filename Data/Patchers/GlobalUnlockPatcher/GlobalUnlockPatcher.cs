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
    /// - Identifies all calls made to GlobalUnlock
    /// - Replaces calls to GlobalUnlock with calls to location of newly created function
    /// - Inserts newly created function that will perform calls to GlobalUnlock
    /// 
    /// Notes
    /// - OpCode E8 uses a relative offset to locate the function, rather than a absolute value
    /// - The relative offset formula is: referenced_function_position - (opcode_position + 5 bytes) = relative_offset
    /// - This formula applies for both forward and backward referencing (using overflow)
    /// 
    /// Examples
    /// --------
    /// OpCode FF 15 -> E8
    /// old	.text:0041487B	FF 15 AC D5 60 01           		call ds:GlobalUnlock
    /// new	.text:0041487B	90                                  nop
    ///                 	E8 80 C7 FE FF						call sub_401000
    /// // TODO verify the above line is a correct relative reference example
    /// </summary>
    public class GlobalUnlockPatcher
    {
        // TODO THIS CLASS IS NOW REDUNDANT

        private readonly string _executableFilePath;

        public GlobalUnlockPatcher(string executableFilePath)
        {
            _executableFilePath = executableFilePath;
        }

        /// <summary>
        /// Applys the redirect on all calls to GlobalUnlock.
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
                0x8B, 0x45, 0x08,                   // mov     eax, [ebp + arg_0]
                0x50,                               // push    eax
                0xFF, 0x15, 0xAC, 0xD5, 0x60, 0x01, // call    GlobalUnlock
                0x83, 0xC4, 0x04,                   // add     esp, 4
                0xE9, 0x00, 0x00, 0x00, 0x00,       // jmp     $+5
                0x5F,                               // pop     edi
                0x5E,                               // pop     esi
                0x5B,                               // pop     ebx
                0xC9,                               // leave
                0xC3                                // retn

                //////0x55,                               // push    ebp
                //////0x8B, 0xEC,                         // mov     ebp, esp
                //////0x53,                               // push    ebx
                //////0x56,                               // push    esi
                //////0x57,                               // push    edi
                //////
                //////   //8B 45 08 // mov     eax, [ebp + arg_0]
                //////   //50       // push eax
                //////
                //////0xFF, 0x74, 0x24, 0x04,             // push    [esp+arg_0]
                //////
                //////0xFF, 0x15, 0xAC, 0xD5, 0x60, 0x01, // call    GlobalUnlock
                //////0x83, 0xC4, 0x04,                   // add     esp, 4
                //////   //0xB8, 0x00, 0x00, 0x00, 0x00,
                //////0x5F,                               // pop     edi
                //////0x5E,                               // pop     esi
                //////0x5B,                               // pop     ebx
                //////0xC9,                               // leave
                //////0xC3                                // retn
            };

            // File location to insert new function
            var newGlobalUnlockLocation = 0x00401000;

            // New redirect instruction template, 0x00 will be overwritten by relative function location
            var newRedirectInstructions = new byte[] {
                0x90, 0xE8, 0x00, 0x00, 0x00, 0x00
            };

            // File location of each global unlock call to modify
            var globalUnlockLocation = new long[] {
                // TODO verify 0x0043B987 is correct
                0x0040C807, 0x0040CA85, 0x00412B20, 0x00413322, 0x0041362A, 0x004138A1,
                0x00413AB3, 0x00413FB3, 0x00414031, 0x00414219, 0x0041424B, 0x004142CC,
                0x004144B0, 0x0041459F, 0x0041462E, 0x004146A0, 0x0041487B, 0x00414A5E,
                0x00414A9A, 0x00414AE2, 0x0043B987, 0x00457920, 0x0047A0D9, 0x0047A207,
                0x0047A32E, 0x0047A461, 0x0047A592, 0x0047B592, 0x0049DC03, 0x00506413,
                0x00506ADC, 0x00506F46, 0x005070DD, 0x00507157, 0x00507204, 0x00507251,
                0x0053A2A2, 0x0053BD1E, 0x005C5525, 0x005D2BEA, 0x005D2C02, 0x005D2DBB,
                0x005D2DD3, 0x005D2E0E, 0x005D2E26, 0x0062AC9E, 0x0062B0B4, 0x0062B204
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
