namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to remove rounding on the car handling value to
    /// eliminate the performance step experienced every 10% of the car
    /// handling value. This is done by neutralising the code that rounds
    /// the car handling value to the nearest 10%.
    /// 
    /// e.g. a 79% car that performs at 70%, will now peform at 79%
    ///      a 80% car that performs at 80%, will now peform at 80%
    ///      a 118% (max) car that performs at 110%, will now peform at 118%
    /// 
    /// Known issue: A car with a handling value that is greater than 110%
    /// may not gain any additional performance if the power rating of the
    /// engine is also significant. As one of the performance calculations
    /// in the overall performance of the car adds the car handling value
    /// (max 118%) to the engine power value (max 10%) to a maximum possible
    /// value of 120%. So a 118% + 10% car will be equal to a 110% + 10% car
    /// as far as this particular calculation is concerned.
    /// </summary>
    public class CarHandlingPerformanceFix : DataPatcherUnitBase
    {
        public CarHandlingPerformanceFix(string executableFilePath) : base(executableFilePath)
        {
            UnmodifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x0053656B,
                Instructions = new byte[]
                {
                                                                //                                ; divide value by 10
                    0xB9, 0x0A, 0x00, 0x00, 0x00,               // .text:0053656B                 mov     ecx, 0Ah
                    0x8B, 0x45, 0xC0,                           // .text:00536570                 mov     eax, [ebp+var_40]
                    0x99,                                       // .text:00536573                 cdq
                    0xF7, 0xF9,                                 // .text:00536574                 idiv    ecx
                    0x89, 0x45, 0xA8,                           // .text:00536576                 mov     [ebp+var_58], eax
                                                                //
                                                                //                                ; make sure value is 0 or greater
                    0x83, 0x7D, 0xA8, 0x01,                     // .text:00536579                 cmp     [ebp+var_58], 1
                    0x0F, 0x8D, 0x0C, 0x00, 0x00, 0x00,         // .text:0053657D                 jge     loc_53658F
                    0xC7, 0x45, 0xA8, 0x00, 0x00, 0x00, 0x00,   // .text:00536583                 mov     [ebp+var_58], 0
                    0xE9, 0x11, 0x00, 0x00, 0x00,               // .text:0053658A                 jmp     loc_5365A0
                                                                //
                                                                // .text:0053658F ; ---------------------------------------------------------------------------
                                                                // .text:0053658F                 ; make sure value is 11 or less
                                                                // .text:0053658F loc_53658F:                             ; CODE XREF: sub_535B90+9EDj
                    0x83, 0x7D, 0xA8, 0x0B,                     // .text:0053658F                 cmp     [ebp+var_58], 0Bh
                    0x0F, 0x8E, 0x07, 0x00, 0x00, 0x00,         // .text:00536593                 jle     loc_5365A0
                    0xC7, 0x45, 0xA8, 0x0B, 0x00, 0x00, 0x00,   // .text:00536599                 mov     [ebp+var_58], 0Bh
                                                                //
                                                                // .text:005365A0                 ; multiply value by 10
                                                                // .text:005365A0 loc_5365A0:                             ; CODE XREF: sub_535B90+9FAj
                                                                // .text:005365A0                                         ; sub_535B90+A03j
                    0x8B, 0x45, 0xA8,                           // .text:005365A0                 mov     eax, [ebp+var_58]
                    0x8D, 0x04, 0x80,                           // .text:005365A3                 lea     eax, [eax+eax*4]
                    0x03, 0xC0,                                 // .text:005365A6                 add     eax, eax
                    0x89, 0x45, 0xA8                            // .text:005365A8                 mov     [ebp+var_58], eax
                }
            });

            ModifiedInstructions.Add(new DataPatcherUnitTask()
            {
                VirtualPosition = 0x0053656B,
                Instructions = new byte[]
                {
                                                                //                                ; move car handling value
                    0x90, 0x90, 0x90, 0x90, 0x90,               // .text:0053656B                 {nop}
                    0x8B, 0x45, 0xC0,                           // .text:00536570                 mov     eax, [ebp+var_40]
                    0x90,                                       // .text:00536573                 {nop}
                    0x90, 0x90,                                 // .text:00536574                 {nop}
                    0x89, 0x45, 0xA8,                           // .text:00536576                 mov     [ebp+var_58], eax
                                                                //
                    0x90, 0x90, 0x90, 0x90,                     // .text:00536579                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90,         // .text:0053657D                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90,   // .text:00536583                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90,               // .text:0053658A                 {nop}
                                                                //
                    0x90, 0x90, 0x90, 0x90,                     // .text:0053658F                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90,         // .text:00536593                 {nop}
                    0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90,   // .text:00536599                 {nop}
                                                                //
                    0x90, 0x90, 0x90,                           // .text:005365A0                 {nop}
                    0x90, 0x90, 0x90,                           // .text:005365A3                 {nop}
                    0x90, 0x90,                                 // .text:005365A6                 {nop}
                    0x90, 0x90, 0x90                            // .text:005365A8                 {nop}
                }
            });
        }
    }
}
