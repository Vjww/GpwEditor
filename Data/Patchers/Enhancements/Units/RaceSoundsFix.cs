namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to eliminate calls made to memset() to prevent the game
    /// from crashing on Win XP/Vista/7 when preparing memory areas for loading
    /// race sounds. It appears memset() is passed an invalid location or size
    /// and attempts to reset memory outside of the game's memory area, causing
    /// the following two unhandled exceptions to be experienced by the user.
    /// 
    /// Unhandled exception at 0x0049aa6b in gpw.exe: 0xC0000005: Access violation reading location 0x0771e202.
    /// Unhandled exception at 0x0049b41e in gpw.exe: 0xC0000005: Access violation reading location 0x01c4b04e.
    /// 
    /// By neutralising the code that calls the memset() function the unhandled
    /// exceptions no longer occur and the game continues to run, outweighing
    /// the risk that the memory remains uninitialised.
    /// </summary>
    public class RaceSoundsFix : DataPatcherUnitBase
    {
        public RaceSoundsFix(string executableFilePath) : base(executableFilePath)
        {
            // Task A
            // Resolve unhandled exception at 0x0049aa6b in gpw.exe: 0xC0000005: Access violation reading location 0x0771e202.
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x0049AA5F,
                Instructions = new byte[]
                {
                    0x8B, 0x45, 0xE8,               // .text:0049AA5F                 mov     eax, [ebp+var_18]
                    0x2B, 0x45, 0xEC,               // .text:0049AA62                 sub     eax, [ebp+var_14]
                    0x50,                           // .text:0049AA65                 push    eax             ; Size
                    0xA1, 0x18, 0xF2, 0x72, 0x00,   // .text:0049AA66                 mov     eax, ds:dword_72F218
                    0x66, 0x8B, 0x40, 0x0E,         // .text:0049AA6B                 mov     ax, [eax+0Eh]
                    0x25, 0xFF, 0xFF, 0x00, 0x00,   // .text:0049AA6F                 and     eax, 0FFFFh
                    0x83, 0xE8, 0x08,               // .text:0049AA74                 sub     eax, 8
                    0x83, 0xF8, 0x01,               // .text:0049AA77                 cmp     eax, 1
                    0x1B, 0xC0,                     // .text:0049AA7A                 sbb     eax, eax
                    0x25, 0x80, 0x00, 0x00, 0x00,   // .text:0049AA7C                 and     eax, 80h
                    0x50,                           // .text:0049AA81                 push    eax             ; Val
                    0x8B, 0x45, 0xEC,               // .text:0049AA82                 mov     eax, [ebp+var_14]
                    0x03, 0x45, 0xF8,               // .text:0049AA85                 add     eax, [ebp+var_8]
                    0x50,                           // .text:0049AA88                 push    eax             ; Dst
                    0xE8, 0xBA, 0x20, 0x1E, 0x00,   // .text:0049AA89                 call    _memset
                    0x83, 0xC4, 0x0C                // .text:0049AA8E                 add     esp, 0Ch
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x0049AA5F,
                Instructions = new byte[]
                {
                    0x90, 0x90, 0x90,               // .text:0049AA5F                 {nop}
                    0x90, 0x90, 0x90,               // .text:0049AA62                 {nop}
                    0x90,                           // .text:0049AA65                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,   // .text:0049AA66                 {nop}
                    0x90, 0x90, 0x90, 0x90,         // .text:0049AA6B                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,   // .text:0049AA6F                 {nop}
                    0x90, 0x90, 0x90,               // .text:0049AA74                 {nop}
                    0x90, 0x90, 0x90,               // .text:0049AA77                 {nop}
                    0x90, 0x90,                     // .text:0049AA7A                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,   // .text:0049AA7C                 {nop}
                    0x90,                           // .text:0049AA81                 {nop}
                    0x90, 0x90, 0x90,               // .text:0049AA82                 {nop}
                    0x90, 0x90, 0x90,               // .text:0049AA85                 {nop}
                    0x90,                           // .text:0049AA88                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,   // .text:0049AA89                 {nop}
                    0x90, 0x90, 0x90                // .text:0049AA8E                 {nop}
                }
            });
            // End

            // Task B
            // Resolve unhandled exception at 0x0049b41e in gpw.exe: 0xC0000005: Access violation reading location 0x01c4b04e.
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x0049B40A,
                Instructions = new byte[]
                {
                    0x8B, 0x45, 0xE8,                           // .text:0049B40A                 mov     eax, [ebp+var_18]
                    0x2B, 0x45, 0xEC,                           // .text:0049B40D                 sub     eax, [ebp+var_14]
                    0x50,                                       // .text:0049B410                 push    eax             ; Size
                    0x8B, 0x45, 0x0C,                           // .text:0049B411                 mov     eax, [ebp+arg_4]
                    0xC1, 0xE0, 0x02,                           // .text:0049B414                 shl     eax, 2
                    0x8B, 0x84, 0x80, 0x68, 0xF4, 0x72, 0x00,   // .text:0049B417                 mov     eax, ds:dword_72F468[eax+eax*4]
                    0x66, 0x8B, 0x40, 0x0E,                     // .text:0049B41E                 mov     ax, [eax+0Eh]
                    0x25, 0xFF, 0xFF, 0x00, 0x00,               // .text:0049B422                 and     eax, 0FFFFh
                    0x83, 0xE8, 0x08,                           // .text:0049B427                 sub     eax, 8
                    0x83, 0xF8, 0x01,                           // .text:0049B42A                 cmp     eax, 1
                    0x1B, 0xC0,                                 // .text:0049B42D                 sbb     eax, eax
                    0x25, 0x80, 0x00, 0x00, 0x00,               // .text:0049B42F                 and     eax, 80h
                    0x50,                                       // .text:0049B434                 push    eax             ; Val
                    0x8B, 0x45, 0xEC,                           // .text:0049B435                 mov     eax, [ebp+var_14]
                    0x03, 0x45, 0xF8,                           // .text:0049B438                 add     eax, [ebp+Dst]
                    0x50,                                       // .text:0049B43B                 push    eax             ; Dst
                    0xE8, 0x07, 0x17, 0x1E, 0x00,               // .text:0049B43C                 call    _memset
                    0x83, 0xC4, 0x0C                            // .text:0049B441                 add     esp, 0Ch
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x0049B40A,
                Instructions = new byte[]
                {
                    0x90, 0x90, 0x90,                           // .text:0049B40A                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B40D                 {nop}
                    0x90,                                       // .text:0049B410                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B411                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B414                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90,   // .text:0049B417                 {nop}
                    0x90, 0x90, 0x90, 0x90,                     // .text:0049B41E                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,               // .text:0049B422                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B427                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B42A                 {nop}
                    0x90, 0x90,                                 // .text:0049B42D                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,               // .text:0049B42F                 {nop}
                    0x90,                                       // .text:0049B434                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B435                 {nop}
                    0x90, 0x90, 0x90,                           // .text:0049B438                 {nop}
                    0x90,                                       // .text:0049B43B                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,               // .text:0049B43C                 {nop}
                    0x90, 0x90, 0x90                            // .text:0049B441                 {nop}
                }
            });
            // End
        }
    }
}
