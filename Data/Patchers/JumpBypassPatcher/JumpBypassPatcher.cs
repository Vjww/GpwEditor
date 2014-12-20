using Core.Helpers;
using Data.Enums;
using Data.FileConnection;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Data.Patchers.JumpBypassPatcher
{
    /// <summary>
    /// The Jump Bypass Patcher class makes changes to the instruction set/pattern
    /// in the gpw.exe v1.01b executable file to improve disassembly of the file by
    /// IDA Pro v6.1. There a number of "jump" functions at the beginning of the
    /// disassembly that only serve to call other functions. It is suspected that
    /// these functions are present as a result of SafeDisc protection.
    /// 
    /// By bypassing these functions, the calling code will immediately forward
    /// onto the intended function. This will assist disassembly and improve
    /// performance by removing unnecessary calls in the flow of code.
    /// 
    /// Changes are made to the instruction set where any reference to the jump
    /// function is detected. Calls to the jump functions will now immediately
    /// forward to the function called inside the jump function.
    /// 
    /// Paste text file here...
    /// 
    /// Code logic
    /// - Identifies all jump functions at the start of the file and the forwarding functions within
    /// - Scans the .text section for opcodes that reference the jump functions
    /// - Scans the .rdata and .data section for references to the jump functions
    /// - Applies bypasses by overwritting references to jump functions with the forwarding function within
    /// 
    /// Notes
    /// - OpCode E8 uses a relative offset to locate the function, rather than a absolute value
    /// - The relative offset formula is: referenced_function_position - (opcode_position + 5 bytes) = relative_offset
    /// - This formula applies for both forward and backward referencing (using overflow)
    /// 
    /// Examples
    /// --------
    /// OpCode E8 (forward reference)
    /// old	.text:005FA87B	E8 80 67 E0 FF						call sub_401000
    /// new	.text:005FA87B	E8 77 31 00 00						call sub_5FD9F7
    /// 
    /// OpCode E8 (backward reference)
    /// old	.text:0050045F	E8 0A 0C F0 FF						call sub_40106E
    /// new	.text:0050045F	E8 64 5E F8 FF						call sub_4862C8
    /// 
    /// OpCode 68
    /// old	.text:0040832E	68 B7 12 40 00						push offset sub_4012B7
    /// new	.text:0040832E	68 80 A6 40 00						push offset sub_40A680
    /// 
    /// OpCode C7 04
    /// old	.text:0041CD63	C7 04 85 D8 94 57 01 14 15 40 00	mov ds:dword_15794D8[eax*4], offset loc_401514
    /// new	.text:0041CD63	C7 04 85 D8 94 57 01 34 6F 42 00	mov ds:dword_15794D8[eax*4], offset loc_426F34
    /// 
    /// OpCode C7 05
    /// old	.text:005B34EE	C7 05 5C 89 57 01 41 10 40 00		mov ds:dword_157895C, offset sub_401041
    /// new	.text:005B34EE	C7 05 5C 89 57 01 4B 36 5B 00		mov ds:dword_157895C, offset sub_5B364B
    /// 
    /// OpCode C7 45
    /// old	.text:0053D642	C7 45 FC D0 12 40 00				mov [ebp+var_4], offset loc_4012D0
    /// new	.text:0053D642	C7 45 FC 77 D9 53 00				mov [ebp+var_4], offset loc_53D977
    /// 
    /// OpCode C7 84
    /// old	.text:0041B7E9	C7 84 80 B8 0D 5D 01 00 38 40 00	mov ds:dword_15D0DB8[eax+eax*4], offset loc_403800
    /// new	.text:0041B7E9	C7 84 80 B8 0D 5D 01 6B B8 41 00	mov ds:dword_15D0DB8[eax+eax*4], offset loc_41B86B
    /// 
    /// .rdata section
    /// old	.rdata:015ED05C	E6 10 40 00							dd offset sub_4010E6
    /// new	.rdata:015ED05C	DD 7D 40 00							dd offset sub_407DDD
    /// 
    /// .data section
    /// old	.data:015F2760	E4 30 40 00							off_15F2760 dd offset sub_4030E4
    /// new	.data:015F2760	55 5A 41 00							off_15F2760 dd offset sub_415A55
    /// 
    /// </summary>
    public class JumpBypassPatcher
    {
        private class JumpFunction
        {
            public int Position;
            public int Function;
        }

        /// <summary>
        /// Applys the bypass on all detected references to jump functions.
        /// This method is only intended for use with gpw.exe v1.01b.
        /// Do not invoke this method more than once on the same file.
        /// </summary>
        public void Apply(string filePath)
        {
            // Stats counters
            var textBypassStatsCounter = 0;
            var text68BypassStatsCounter = 0;
            var textE8BypassStatsCounter = 0;
            var textC704BypassStatsCounter = 0;
            var textC705BypassStatsCounter = 0;
            var textC745BypassStatsCounter = 0;
            var textC784BypassStatsCounter = 0;
            var rdataBypassStatsCounter = 0;
            var dataBypassStatsCounter = 0;
            var totalBypassesStatsCounter = 0;

            // Define range where jump functions are located
            const int jumpFunctionFirstReference = 0x00401000; // 0x00000400
            const int jumpFunctionLastReference = 0x0040452A; // 0x0000392A
            const int jumpFunctionReferenceStep = 0x00000005; // Bytes

            // Define range of .text section
            const int textSectionFirstByte = 0x00407A60;
            const int textSectionLastByte = 0x00689FFF;

            // Define range of .rdata section
            const int rdataSectionFirstByte = 0x015ED000;
            const int rdataSectionLastByte = 0x015EF7CF;

            // Define range of .data section
            const int dataSectionFirstByte = 0x015F0000;
            const int dataSectionLastByte = 0x0160CBFF;

            // Create collection to hold details of each jump function
            var jumpFunctions = new Collection<JumpFunction>();

            // Populate collection with the positions of the jump functions
            for (var i = jumpFunctionFirstReference; i <= jumpFunctionLastReference; i += jumpFunctionReferenceStep)
            {
                jumpFunctions.Add(new JumpFunction() { Position = i });
            }

            // Collection of changes to make after read
            var jumpBypasses = new Collection<JumpFunction>();

            // File connection
            ExecutableConnection executableConnection = null;

            // Open file and read
            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(filePath, StreamDirectionType.Read);

                // Populate collection with the referenced function inside each jump function
                foreach (var item in jumpFunctions)
                {
                    var instructions = new byte[4];

                    instructions = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(item.Position) + 1, instructions.Length);

                    item.Function = item.Position + 5 + BitConverter.ToInt32(instructions, 0);
                }

                // Analyse .text section for opcodes with references to jump functions
                for (var i = textSectionFirstByte; i <= textSectionLastByte - 4; i++)
                {
                    // Read two bytes
                    var opcodeCheck = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i), 2);

                    // Check for matching opcodes
                    if (opcodeCheck[0] == 0x68)
                    {
                        // Read last four bytes of five byte signature
                        var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i + 1), 4);
                        var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                        // Do bytes match a reference to a jump function in the collection
                        foreach (var item in jumpFunctions)
                        {
                            if (referenceCheckValue == item.Position)
                            {
                                // Add bypass to collection
                                jumpBypasses.Add(new JumpFunction() { Position = i + 1, Function = item.Function });
                                textBypassStatsCounter++;
                                text68BypassStatsCounter++;
                            }
                        }
                    }
                    else if (opcodeCheck[0] == 0xE8)
                    {
                        // Read last four bytes of five byte signature
                        var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i + 1), 4);
                        var referenceCheckValue = i + 5 + BitConverter.ToInt32(referenceCheckBytes, 0);

                        // Do bytes match a reference to a jump function in the collection
                        foreach (var item in jumpFunctions)
                        {
                            if (referenceCheckValue == item.Position)
                            {
                                // Calc relative function position for opcode xE8
                                var functionOffset = BitConverter.GetBytes(item.Function - (i + 5));

                                // Add bypass to collection
                                jumpBypasses.Add(new JumpFunction() { Position = i + 1, Function = BitConverter.ToInt32(functionOffset, 0) });
                                textBypassStatsCounter++;
                                textE8BypassStatsCounter++;
                            }
                        }
                    }
                    else if ((opcodeCheck[0] == 0xC7) && (opcodeCheck[1] == 0x04))
                    {
                        // Read last four bytes of eleven byte signature
                        var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i + 7), 4);
                        var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                        // Do bytes match a reference to a jump function in the collection
                        foreach (var item in jumpFunctions)
                        {
                            if (referenceCheckValue == item.Position)
                            {
                                // Add bypass to collection
                                jumpBypasses.Add(new JumpFunction() { Position = i + 7, Function = item.Function });
                                textBypassStatsCounter++;
                                textC704BypassStatsCounter++;
                            }
                        }
                    }
                    else if ((opcodeCheck[0] == 0xC7) && (opcodeCheck[1] == 0x05))
                    {
                        // Read last four bytes of ten byte signature
                        var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i + 6), 4);
                        var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                        // Do bytes match a reference to a jump function in the collection
                        foreach (var item in jumpFunctions)
                        {
                            if (referenceCheckValue == item.Position)
                            {
                                // Add bypass to collection
                                jumpBypasses.Add(new JumpFunction() { Position = i + 6, Function = item.Function });
                                textBypassStatsCounter++;
                                textC705BypassStatsCounter++;
                            }
                        }
                    }
                    else if ((opcodeCheck[0] == 0xC7) && (opcodeCheck[1] == 0x45))
                    {
                        // Read last four bytes of seven byte signature
                        var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i + 3), 4);
                        var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                        // Do bytes match a reference to a jump function in the collection
                        foreach (var item in jumpFunctions)
                        {
                            if (referenceCheckValue == item.Position)
                            {
                                // Add bypass to collection
                                jumpBypasses.Add(new JumpFunction() { Position = i + 3, Function = item.Function });
                                textBypassStatsCounter++;
                                textC745BypassStatsCounter++;
                            }
                        }
                    }
                    else if ((opcodeCheck[0] == 0xC7) && (opcodeCheck[1] == 0x84))
                    {
                        // Read last four bytes of eleven byte signature
                        var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i + 7), 4);
                        var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                        // Do bytes match a reference to a jump function in the collection
                        foreach (var item in jumpFunctions)
                        {
                            if (referenceCheckValue == item.Position)
                            {
                                // Add bypass to collection
                                jumpBypasses.Add(new JumpFunction() { Position = i + 7, Function = item.Function });
                                textBypassStatsCounter++;
                                textC784BypassStatsCounter++;
                            }
                        }
                    }
                }

                // Analyse .rdata section for references to jump functions
                for (var i = rdataSectionFirstByte; i <= rdataSectionLastByte - 3; i++)
                {
                    // Read four bytes
                    var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i), 4);
                    var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                    // Do bytes match a reference to a jump function in the collection
                    foreach (var item in jumpFunctions)
                    {
                        if (referenceCheckValue == item.Position)
                        {
                            // Add bypass to collection
                            jumpBypasses.Add(new JumpFunction() { Position = i, Function = item.Function });
                            rdataBypassStatsCounter++;
                        }
                    }
                }

                // Analyse .data section for references to jump functions
                for (var i = dataSectionFirstByte; i <= dataSectionLastByte - 3; i++)
                {
                    // Read four bytes
                    var referenceCheckBytes = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(i), 4);
                    var referenceCheckValue = BitConverter.ToInt32(referenceCheckBytes, 0);

                    // Do bytes match a reference to a jump function in the collection
                    foreach (var item in jumpFunctions)
                    {
                        if (referenceCheckValue == item.Position)
                        {
                            // Add bypass to collection
                            jumpBypasses.Add(new JumpFunction() { Position = i, Function = item.Function });
                            dataBypassStatsCounter++;
                        }
                    }
                }
            }
            finally
            {
                if (executableConnection != null)
                {
                    executableConnection.Close();
                }
            }

            // Open file and write
            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(filePath, StreamDirectionType.Write);

                // Apply bypasses
                foreach (var item in jumpBypasses)
                {
                    // Write four bytes
                    executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(item.Position), BitConverter.GetBytes(item.Function));
                    totalBypassesStatsCounter++;
                }
            }
            finally
            {
                if (executableConnection != null)
                {
                    executableConnection.Close();
                }
            }

            Debug.WriteLine(" .text section bypass count: " + textBypassStatsCounter);
            Debug.WriteLine("   .text opCode    68 count: " + text68BypassStatsCounter);
            Debug.WriteLine("   .text opCode    E8 count: " + textE8BypassStatsCounter);
            Debug.WriteLine("   .text opCode C7 04 count: " + textC704BypassStatsCounter);
            Debug.WriteLine("   .text opCode C7 05 count: " + textC705BypassStatsCounter);
            Debug.WriteLine("   .text opCode C7 45 count: " + textC745BypassStatsCounter);
            Debug.WriteLine("   .text opCode C7 84 count: " + textC784BypassStatsCounter);
            Debug.WriteLine(".rdata section bypass count: " + rdataBypassStatsCounter);
            Debug.WriteLine(" .data section bypass count: " + dataBypassStatsCounter);
            Debug.WriteLine("----------------------------");
            Debug.WriteLine("             Total bypasses: " + totalBypassesStatsCounter);
        }
    }
}
