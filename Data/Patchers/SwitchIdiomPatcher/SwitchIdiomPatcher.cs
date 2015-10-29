using System;
using Common.Enums;
using Data.FileConnection;

namespace Data.Patchers.SwitchIdiomPatcher
{
    /// <summary>
    /// The Switch Idiom Patcher class makes changes to the instruction set/pattern
    /// in the gpw.exe v1.01b executable file to improve disassembly of the file by
    /// IDA Pro v6.1. The executable appears to be compiled by Visual C++ 4.x and
    /// a number of switch statements are unable to be disassembled by IDA Pro.
    /// 
    /// Changes are made to the instruction set for each affected switch statement,
    /// to imitate the instruction set used for the same switch statements in
    /// gpwxp.exe (compiled by Visual C++ 5.x) that are disassembled without issue.
    /// 
    /// Original code detects 256 cases (instead of 40 (28h) cases)
    /// 
    /// .text:0042FBD5   cmp     dword ptr [ebp-0Ch], 28h             83 7D F4 28
    /// .text:0042FBD9   ja      near ptr unk_42FC31                  0F 87 52 00 00 00
    /// .text:0042FBDF   mov     eax, [ebp-0Ch]                       8B 45 F4
    /// .text:0042FBE2   mov     al, byte ptr ds:unk_42FC08[eax]      8A 80 08 FC 42 00
    /// .text:0042FBE8   and     eax, 0FFh       ; switch 256 cases   25 FF 00 00 00
    /// .text:0042FBED   jmp     ds:off_42FBF4[eax*4] ; switch jump   FF 24 85 F4 FB 42 00
    /// 
    /// Modified code rearranges switch idiom to detect 40 cases
    /// Note: removal of code "and eax, 0FFh" from above and added NOPs (90h)
    /// 
    /// .text:0042FBD5   cmp     [ebp+var_C], 28h ; switch 41 cases   83 7D F4 28
    /// .text:0042FBD9   ja      loc_42FC31      ; default case       0F 87 52 00 00 00
    /// .text:0042FBDF   mov     eax, [ebp+var_C]                     8B 45 F4
    /// .text:0042FBE2   xor     edx, edx                             33 D2
    /// .text:0042FBE4   mov     dl, ds:byte_42FC08[eax]              8A 90 08 FC 42 00
    /// .text:0042FBEA   jmp     ds:off_42FBF4[edx*4] ; switch jump   FF 24 95 F4 FB 42 00
    /// .text:0042FBF1           db 3 dup(90h)                        90 90 90
    /// </summary>
    public class SwitchIdiomPatcher
    {
        /// <summary>
        /// Applys the new switch idiom to all predefined target addresses within.
        /// This method is only intended for use with gpw.exe v1.01b.
        /// Do not invoke this method more than once on the same file.
        /// </summary>
        public void Apply(string filePath)
        {
            // New instruction template, 0x00 will be overwritten by jump/indirect table locations
            var newInstructions = new byte[] {
                0x33, 0xD2, 0x8A, 0x90, 0x00, 0x00, 0x00, 0x00, 0xFF,
                0x24, 0x95, 0x00, 0x00, 0x00, 0x00, 0x90, 0x90, 0x90
            };

            // File location of each switch idiom to modify
            var switchIdiomLocation = new long[] {
                0x00021A9C, 0x0002EFE2, 0x00034FC5, 0x000387AE, 0x0003AD71, 0x00044C99, 
                0x0004EFD4, 0x0004FEDF, 0x0005F0EB, 0x00078996, 0x0008E2F7, 0x0008E850, 
                0x0008EE9E, 0x00093B02, 0x0009507E, 0x0009ED62, 0x000A5F9E, 0x001130A4, 
                0x001131B2, 0x00116871, 0x001170FA, 0x00117198, 0x001180EF, 0x0011C88A, 
                0x00120DB0, 0x00120E1E, 0x0012DE99, 0x00130D87, 0x00138A8E, 0x00139B64, 
                0x0013F6D1, 0x0013FE4B, 0x0013FF79, 0x001499BF, 0x00149A59, 0x0014A727, 
                0x0014A7F6, 0x0014B09F, 0x0014B5EF, 0x0014BC5D, 0x0014BCEE, 0x00154C42, 
                0x00154F47, 0x00155176, 0x0015533B, 0x001556C7, 0x0015BC0B, 0x0015DC59, 
                0x0015DE57, 0x0015DF24, 0x0015DFA2, 0x0015E1C0, 0x001675AA, 0x0017344E, 
                0x0018BF05, 0x0019012B, 0x001A1AEE, 0x001A1D23, 0x001A1DCC, 0x001A2F62, 
                0x001AE631, 0x001B4CAE, 0x001B50EC, 0x001D4F47, 0x001DCC1B, 0x001DE2A5, 
                0x001E30E6, 0x001F4FE5, 0x001F51EF, 0x001F74D8, 0x00203BFE, 0x0021862C, 
                0x00218788, 0x00218977, 0x0021BFB7, 0x0021C26A, 0x0025FF17, 0x0026028F, 
                0x0026082B, 0x002622D7, 0x002638F9, 0x002739E7, 0x00276F01, 0x00276FE8, 
                0x00278CB2, 0x00278D53, 0x00278FDD, 0x002790F0
            };

            // File connection
            ExecutableConnection executableConnection = null;

            // For every switch idiom (represented by the target address)
            for (var i = 0; i < switchIdiomLocation.Length; i++)
            {
                var instructions = new byte[18];

                // Get current instructions at target address
                try
                {
                    executableConnection = new ExecutableConnection();
                    executableConnection.Open(filePath, StreamDirectionType.Read);

                    instructions = executableConnection.ReadByteArray(switchIdiomLocation[i], instructions.Length);
                }
                finally
                {
                    if (executableConnection != null)
                    {
                        executableConnection.Close();
                    }
                }

                // Extract table location values
                var indirectTableLocation = new byte[4];
                var jumpTableLocation = new byte[4];

                // Indirect table location is represented in little endian byte order
                for (var j = 0; j < indirectTableLocation.Length; j++)
                {
                    // Read four bytes
                    indirectTableLocation[j] = instructions[j + 2];
                }

                // Jump table location is represented in little endian byte order
                for (var j = 0; j < jumpTableLocation.Length; j++)
                {
                    // Read four bytes
                    jumpTableLocation[j] = instructions[j + 14];
                }

                // Create copy of new instructions by overwriting current instructions
                Array.Copy(newInstructions, instructions, instructions.Length);

                // Modify with new instructions
                for (var j = 4; j < 8; j++)
                {
                    // Write four bytes
                    instructions[j] = indirectTableLocation[j - 4];
                }
                for (var j = 11; j < 15; j++)
                {
                    // Write four bytes
                    instructions[j] = jumpTableLocation[j - 11];
                }

                try
                {
                    executableConnection = new ExecutableConnection();
                    executableConnection.Open(filePath, StreamDirectionType.Write);

                    // Write new instructions to target address
                    executableConnection.WriteByteArray(switchIdiomLocation[i], instructions);
                }
                finally
                {
                    if (executableConnection != null)
                    {
                        executableConnection.Close();
                    }
                }
            }
        }
    }
}
