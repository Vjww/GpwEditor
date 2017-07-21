namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to change the calculation used to determine next year's
    /// car handling percentage for the player's team and the AI teams.  The
    /// new calculation factors in the skill levels of both the Chief Designer
    /// (25%) and the Technical Director (75%) and multiplies this value by a
    /// percentage weighting (shown in the brackets).
    /// 
    /// Task A: For player teams a random aspect is introduced into the
    /// calculation to reduce the final percentage by anywhere between 
    /// 0% and 10%.
    /// 
    /// Task B: For AI teams a random aspect is introduced into the calculation
    /// to adjust the final percentage by +/- 10%.
    /// 
    /// </summary>
    public class CarDesignCalculationUpdate : DataPatcherUnitBase
    {
        public CarDesignCalculationUpdate(string executableFilePath) : base(executableFilePath)
        {
            var taskId = 0;

            // Task A (player team)
            #region Task A Unmodified
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(CarDesignCalculationUpdate).Name,
                VirtualPosition = 0x0050C449,
                Instructions = new byte[]
                {
                                                                // .text:0050C449 var_8           = dword ptr -8
                                                                // .text:0050C449 var_4           = dword ptr -4
                                                                // .text:0050C449 arg_0           = dword ptr  8
                                                                //
                    0x55,                                       // .text:0050C449                 push    ebp
                    0x8B, 0xEC,                                 // .text:0050C44A                 mov     ebp, esp
                    0x83, 0xEC, 0x08,                           // .text:0050C44C                 sub     esp, 8
                    0x53,                                       // .text:0050C44F                 push    ebx
                    0x56,                                       // .text:0050C450                 push    esi
                    0x57,                                       // .text:0050C451                 push    edi
                    0x8B, 0x45, 0x08,                           // .text:0050C452                 mov     eax, [ebp+arg_0]
                    0x50,                                       // .text:0050C455                 push    eax
                    0xE8, 0x69, 0xFF, 0xFF, 0xFF,               // .text:0050C456                 call    sub_50C3C4
                    0x83, 0xC4, 0x04,                           // .text:0050C45B                 add     esp, 4
                    0x8B, 0x4D, 0x08,                           // .text:0050C45E                 mov     ecx, [ebp+arg_0]
                    0x8B, 0xD1,                                 // .text:0050C461                 mov     edx, ecx
                    0xC1, 0xE1, 0x08,                           // .text:0050C463                 shl     ecx, 8
                    0x2B, 0xCA,                                 // .text:0050C466                 sub     ecx, edx
                    0x8D, 0x0C, 0x49,                           // .text:0050C468                 lea     ecx, [ecx+ecx*2]
                    0x2B, 0xCA,                                 // .text:0050C46B                 sub     ecx, edx
                    0x89, 0x81, 0xA0, 0xF4, 0x8C, 0x00,         // .text:0050C46D                 mov     ds:dword_8CF4A0[ecx], eax
                    0xA1, 0xA8, 0x60, 0x5F, 0x01,               // .text:0050C473                 mov     eax, dword_15F60A8
                    0x50,                                       // .text:0050C478                 push    eax
                    0x8B, 0x45, 0x08,                           // .text:0050C479                 mov     eax, [ebp+arg_0]
                    0x50,                                       // .text:0050C47C                 push    eax
                    0xE8, 0x35, 0xA1, 0xF7, 0xFF,               // .text:0050C47D                 call    sub_4865B7
                    0x83, 0xC4, 0x08,                           // .text:0050C482                 add     esp, 8
                    0x89, 0x45, 0xFC,                           // .text:0050C485                 mov     [ebp+var_4], eax
                    0x8B, 0x45, 0xFC,                           // .text:0050C488                 mov     eax, [ebp+var_4]
                    0x8D, 0x04, 0x85, 0xFC, 0xFF, 0xFF, 0xFF,   // .text:0050C48B                 lea     eax, ds:0FFFFFFFCh[eax*4]
                    0x8D, 0x04, 0x80,                           // .text:0050C492                 lea     eax, [eax+eax*4]
                    0x89, 0x45, 0xF8,                           // .text:0050C495                 mov     [ebp+var_8], eax
                    0x8B, 0x45, 0x08,                           // .text:0050C498                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C49B                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C49D                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C4A0                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C4A2                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C4A5                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x05,   // .text:0050C4A7                 cmp     ds:dword_8CF4A0[eax], 5
                    0x0F, 0x8F, 0x08, 0x00, 0x00, 0x00,         // .text:0050C4AE                 jg      loc_50C4BC
                    0xFF, 0x45, 0xF8,                           // .text:0050C4B4                 inc     [ebp+var_8]
                    0xE9, 0xBA, 0x02, 0x00, 0x00,               // .text:0050C4B7                 jmp     loc_50C776
                                                                // .text:0050C4BC ; ---------------------------------------------------------------------------
                                                                // .text:0050C4BC
                                                                // .text:0050C4BC loc_50C4BC:                             ; CODE XREF: sub_50C449+65j
                    0x8B, 0x45, 0x08,                           // .text:0050C4BC                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C4BF                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C4C1                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C4C4                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C4C6                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C4C9                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x0A,   // .text:0050C4CB                 cmp     ds:dword_8CF4A0[eax], 0Ah
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C4D2                 jg      loc_50C4E1
                    0x83, 0x45, 0xF8, 0x02,                     // .text:0050C4D8                 add     [ebp+var_8], 2
                    0xE9, 0x95, 0x02, 0x00, 0x00,               // .text:0050C4DC                 jmp     loc_50C776
                                                                // .text:0050C4E1 ; ---------------------------------------------------------------------------
                                                                // .text:0050C4E1
                                                                // .text:0050C4E1 loc_50C4E1:                             ; CODE XREF: sub_50C449+89j
                    0x8B, 0x45, 0x08,                           // .text:0050C4E1                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C4E4                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C4E6                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C4E9                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C4EB                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C4EE                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x0F,   // .text:0050C4F0                 cmp     ds:dword_8CF4A0[eax], 0Fh
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C4F7                 jg      loc_50C506
                    0x83, 0x45, 0xF8, 0x03,                     // .text:0050C4FD                 add     [ebp+var_8], 3
                    0xE9, 0x70, 0x02, 0x00, 0x00,               // .text:0050C501                 jmp     loc_50C776
                                                                // .text:0050C506 ; ---------------------------------------------------------------------------
                                                                // .text:0050C506
                                                                // .text:0050C506 loc_50C506:                             ; CODE XREF: sub_50C449+AEj
                    0x8B, 0x45, 0x08,                           // .text:0050C506                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C509                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C50B                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C50E                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C510                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C513                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x14,   // .text:0050C515                 cmp     ds:dword_8CF4A0[eax], 14h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C51C                 jg      loc_50C52B
                    0x83, 0x45, 0xF8, 0x04,                     // .text:0050C522                 add     [ebp+var_8], 4
                    0xE9, 0x4B, 0x02, 0x00, 0x00,               // .text:0050C526                 jmp     loc_50C776
                                                                // .text:0050C52B ; ---------------------------------------------------------------------------
                                                                // .text:0050C52B
                                                                // .text:0050C52B loc_50C52B:                             ; CODE XREF: sub_50C449+D3j
                    0x8B, 0x45, 0x08,                           // .text:0050C52B                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C52E                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C530                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C533                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C535                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C538                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x19,   // .text:0050C53A                 cmp     ds:dword_8CF4A0[eax], 19h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C541                 jg      loc_50C550
                    0x83, 0x45, 0xF8, 0x05,                     // .text:0050C547                 add     [ebp+var_8], 5
                    0xE9, 0x26, 0x02, 0x00, 0x00,               // .text:0050C54B                 jmp     loc_50C776
                                                                // .text:0050C550 ; ---------------------------------------------------------------------------
                                                                // .text:0050C550
                                                                // .text:0050C550 loc_50C550:                             ; CODE XREF: sub_50C449+F8j
                    0x8B, 0x45, 0x08,                           // .text:0050C550                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C553                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C555                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C558                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C55A                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C55D                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x1E,   // .text:0050C55F                 cmp     ds:dword_8CF4A0[eax], 1Eh
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C566                 jg      loc_50C575
                    0x83, 0x45, 0xF8, 0x06,                     // .text:0050C56C                 add     [ebp+var_8], 6
                    0xE9, 0x01, 0x02, 0x00, 0x00,               // .text:0050C570                 jmp     loc_50C776
                                                                // .text:0050C575 ; ---------------------------------------------------------------------------
                                                                // .text:0050C575
                                                                // .text:0050C575 loc_50C575:                             ; CODE XREF: sub_50C449+11Dj
                    0x8B, 0x45, 0x08,                           // .text:0050C575                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C578                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C57A                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C57D                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C57F                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C582                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x23,   // .text:0050C584                 cmp     ds:dword_8CF4A0[eax], 23h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C58B                 jg      loc_50C59A
                    0x83, 0x45, 0xF8, 0x07,                     // .text:0050C591                 add     [ebp+var_8], 7
                    0xE9, 0xDC, 0x01, 0x00, 0x00,               // .text:0050C595                 jmp     loc_50C776
                                                                // .text:0050C59A ; ---------------------------------------------------------------------------
                                                                // .text:0050C59A
                                                                // .text:0050C59A loc_50C59A:                             ; CODE XREF: sub_50C449+142j
                    0x8B, 0x45, 0x08,                           // .text:0050C59A                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C59D                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C59F                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C5A2                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C5A4                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C5A7                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x28,   // .text:0050C5A9                 cmp     ds:dword_8CF4A0[eax], 28h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C5B0                 jg      loc_50C5BF
                    0x83, 0x45, 0xF8, 0x08,                     // .text:0050C5B6                 add     [ebp+var_8], 8
                    0xE9, 0xB7, 0x01, 0x00, 0x00,               // .text:0050C5BA                 jmp     loc_50C776
                                                                // .text:0050C5BF ; ---------------------------------------------------------------------------
                                                                // .text:0050C5BF
                                                                // .text:0050C5BF loc_50C5BF:                             ; CODE XREF: sub_50C449+167j
                    0x8B, 0x45, 0x08,                           // .text:0050C5BF                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C5C2                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C5C4                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C5C7                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C5C9                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C5CC                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x2D,   // .text:0050C5CE                 cmp     ds:dword_8CF4A0[eax], 2Dh
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C5D5                 jg      loc_50C5E4
                    0x83, 0x45, 0xF8, 0x09,                     // .text:0050C5DB                 add     [ebp+var_8], 9
                    0xE9, 0x92, 0x01, 0x00, 0x00,               // .text:0050C5DF                 jmp     loc_50C776
                                                                // .text:0050C5E4 ; ---------------------------------------------------------------------------
                                                                // .text:0050C5E4
                                                                // .text:0050C5E4 loc_50C5E4:                             ; CODE XREF: sub_50C449+18Cj
                    0x8B, 0x45, 0x08,                           // .text:0050C5E4                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C5E7                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C5E9                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C5EC                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C5EE                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C5F1                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x32,   // .text:0050C5F3                 cmp     ds:dword_8CF4A0[eax], 32h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C5FA                 jg      loc_50C609
                    0x83, 0x45, 0xF8, 0x0A,                     // .text:0050C600                 add     [ebp+var_8], 0Ah
                    0xE9, 0x6D, 0x01, 0x00, 0x00,               // .text:0050C604                 jmp     loc_50C776
                                                                // .text:0050C609 ; ---------------------------------------------------------------------------
                                                                // .text:0050C609
                                                                // .text:0050C609 loc_50C609:                             ; CODE XREF: sub_50C449+1B1j
                    0x8B, 0x45, 0x08,                           // .text:0050C609                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C60C                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C60E                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C611                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C613                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C616                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x37,   // .text:0050C618                 cmp     ds:dword_8CF4A0[eax], 37h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C61F                 jg      loc_50C62E
                    0x83, 0x45, 0xF8, 0x0B,                     // .text:0050C625                 add     [ebp+var_8], 0Bh
                    0xE9, 0x48, 0x01, 0x00, 0x00,               // .text:0050C629                 jmp     loc_50C776
                                                                // .text:0050C62E ; ---------------------------------------------------------------------------
                                                                // .text:0050C62E
                                                                // .text:0050C62E loc_50C62E:                             ; CODE XREF: sub_50C449+1D6j
                    0x8B, 0x45, 0x08,                           // .text:0050C62E                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C631                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C633                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C636                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C638                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C63B                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x3C,   // .text:0050C63D                 cmp     ds:dword_8CF4A0[eax], 3Ch
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C644                 jg      loc_50C653
                    0x83, 0x45, 0xF8, 0x0C,                     // .text:0050C64A                 add     [ebp+var_8], 0Ch
                    0xE9, 0x23, 0x01, 0x00, 0x00,               // .text:0050C64E                 jmp     loc_50C776
                                                                // .text:0050C653 ; ---------------------------------------------------------------------------
                                                                // .text:0050C653
                                                                // .text:0050C653 loc_50C653:                             ; CODE XREF: sub_50C449+1FBj
                    0x8B, 0x45, 0x08,                           // .text:0050C653                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C656                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C658                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C65B                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C65D                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C660                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x41,   // .text:0050C662                 cmp     ds:dword_8CF4A0[eax], 41h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C669                 jg      loc_50C678
                    0x83, 0x45, 0xF8, 0x0D,                     // .text:0050C66F                 add     [ebp+var_8], 0Dh
                    0xE9, 0xFE, 0x00, 0x00, 0x00,               // .text:0050C673                 jmp     loc_50C776
                                                                // .text:0050C678 ; ---------------------------------------------------------------------------
                                                                // .text:0050C678
                                                                // .text:0050C678 loc_50C678:                             ; CODE XREF: sub_50C449+220j
                    0x8B, 0x45, 0x08,                           // .text:0050C678                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C67B                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C67D                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C680                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C682                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C685                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x46,   // .text:0050C687                 cmp     ds:dword_8CF4A0[eax], 46h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C68E                 jg      loc_50C69D
                    0x83, 0x45, 0xF8, 0x0E,                     // .text:0050C694                 add     [ebp+var_8], 0Eh
                    0xE9, 0xD9, 0x00, 0x00, 0x00,               // .text:0050C698                 jmp     loc_50C776
                                                                // .text:0050C69D ; ---------------------------------------------------------------------------
                                                                // .text:0050C69D
                                                                // .text:0050C69D loc_50C69D:                             ; CODE XREF: sub_50C449+245j
                    0x8B, 0x45, 0x08,                           // .text:0050C69D                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C6A0                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C6A2                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C6A5                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C6A7                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C6AA                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x4B,   // .text:0050C6AC                 cmp     ds:dword_8CF4A0[eax], 4Bh
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C6B3                 jg      loc_50C6C2
                    0x83, 0x45, 0xF8, 0x0F,                     // .text:0050C6B9                 add     [ebp+var_8], 0Fh
                    0xE9, 0xB4, 0x00, 0x00, 0x00,               // .text:0050C6BD                 jmp     loc_50C776
                                                                // .text:0050C6C2 ; ---------------------------------------------------------------------------
                                                                // .text:0050C6C2
                                                                // .text:0050C6C2 loc_50C6C2:                             ; CODE XREF: sub_50C449+26Aj
                    0x8B, 0x45, 0x08,                           // .text:0050C6C2                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C6C5                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C6C7                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C6CA                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C6CC                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C6CF                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x50,   // .text:0050C6D1                 cmp     ds:dword_8CF4A0[eax], 50h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C6D8                 jg      loc_50C6E7
                    0x83, 0x45, 0xF8, 0x10,                     // .text:0050C6DE                 add     [ebp+var_8], 10h
                    0xE9, 0x8F, 0x00, 0x00, 0x00,               // .text:0050C6E2                 jmp     loc_50C776
                                                                // .text:0050C6E7 ; ---------------------------------------------------------------------------
                                                                // .text:0050C6E7
                                                                // .text:0050C6E7 loc_50C6E7:                             ; CODE XREF: sub_50C449+28Fj
                    0x8B, 0x45, 0x08,                           // .text:0050C6E7                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C6EA                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C6EC                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C6EF                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C6F1                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C6F4                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x55,   // .text:0050C6F6                 cmp     ds:dword_8CF4A0[eax], 55h
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C6FD                 jg      loc_50C70C
                    0x83, 0x45, 0xF8, 0x11,                     // .text:0050C703                 add     [ebp+var_8], 11h
                    0xE9, 0x6A, 0x00, 0x00, 0x00,               // .text:0050C707                 jmp     loc_50C776
                                                                // .text:0050C70C ; ---------------------------------------------------------------------------
                                                                // .text:0050C70C
                                                                // .text:0050C70C loc_50C70C:                             ; CODE XREF: sub_50C449+2B4j
                    0x8B, 0x45, 0x08,                           // .text:0050C70C                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C70F                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C711                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C714                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C716                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C719                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x5A,   // .text:0050C71B                 cmp     ds:dword_8CF4A0[eax], 5Ah
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C722                 jg      loc_50C731
                    0x83, 0x45, 0xF8, 0x12,                     // .text:0050C728                 add     [ebp+var_8], 12h
                    0xE9, 0x45, 0x00, 0x00, 0x00,               // .text:0050C72C                 jmp     loc_50C776
                                                                // .text:0050C731 ; ---------------------------------------------------------------------------
                                                                // .text:0050C731
                                                                // .text:0050C731 loc_50C731:                             ; CODE XREF: sub_50C449+2D9j
                    0x8B, 0x45, 0x08,                           // .text:0050C731                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C734                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C736                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C739                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C73B                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C73E                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x5F,   // .text:0050C740                 cmp     ds:dword_8CF4A0[eax], 5Fh
                    0x0F, 0x8F, 0x09, 0x00, 0x00, 0x00,         // .text:0050C747                 jg      loc_50C756
                    0x83, 0x45, 0xF8, 0x13,                     // .text:0050C74D                 add     [ebp+var_8], 13h
                    0xE9, 0x20, 0x00, 0x00, 0x00,               // .text:0050C751                 jmp     loc_50C776
                                                                // .text:0050C756 ; ---------------------------------------------------------------------------
                                                                // .text:0050C756
                                                                // .text:0050C756 loc_50C756:                             ; CODE XREF: sub_50C449+2FEj
                    0x8B, 0x45, 0x08,                           // .text:0050C756                 mov     eax, [ebp+arg_0]
                    0x8B, 0xC8,                                 // .text:0050C759                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                           // .text:0050C75B                 shl     eax, 8
                    0x2B, 0xC1,                                 // .text:0050C75E                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                           // .text:0050C760                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                 // .text:0050C763                 sub     eax, ecx
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x64,   // .text:0050C765                 cmp     ds:dword_8CF4A0[eax], 64h
                    0x0F, 0x8F, 0x04, 0x00, 0x00, 0x00,         // .text:0050C76C                 jg      loc_50C776
                    0x83, 0x45, 0xF8, 0x14,                     // .text:0050C772                 add     [ebp+var_8], 14h
                                                                // .text:0050C776
                                                                // .text:0050C776 loc_50C776:                             ; CODE XREF: sub_50C449+6Ej
                                                                // .text:0050C776                                         ; sub_50C449+93j ...
                    0x8B, 0x45, 0xF8,                           // .text:0050C776                 mov     eax, [ebp+var_8]
                    0x8B, 0x4D, 0x08,                           // .text:0050C779                 mov     ecx, [ebp+arg_0]
                    0x8B, 0xD1,                                 // .text:0050C77C                 mov     edx, ecx
                    0xC1, 0xE1, 0x08,                           // .text:0050C77E                 shl     ecx, 8
                    0x2B, 0xCA,                                 // .text:0050C781                 sub     ecx, edx
                    0x8D, 0x0C, 0x49,                           // .text:0050C783                 lea     ecx, [ecx+ecx*2]
                    0x2B, 0xCA,                                 // .text:0050C786                 sub     ecx, edx
                    0x89, 0x81, 0x08, 0xF5, 0x8C, 0x00,         // .text:0050C788                 mov     ds:dword_8CF508[ecx], eax
                    0x6A, 0x01,                                 // .text:0050C78E                 push    1
                    0x8B, 0x45, 0x08,                           // .text:0050C790                 mov     eax, [ebp+arg_0]
                    0x50,                                       // .text:0050C793                 push    eax
                    0xE8, 0x79, 0x02, 0x00, 0x00,               // .text:0050C794                 call    sub_50CA12
                    0x83, 0xC4, 0x08,                           // .text:0050C799                 add     esp, 8
                    0x5F,                                       // .text:0050C79C                 pop     edi
                    0x5E,                                       // .text:0050C79D                 pop     esi
                    0x5B,                                       // .text:0050C79E                 pop     ebx
                    0xC9,                                       // .text:0050C79F                 leave
                    0xC3                                        // .text:0050C7A0                 retn
                }
            });
            #endregion

            #region Task A Modified
            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(CarDesignCalculationUpdate).Name,
                VirtualPosition = 0x0050C449,
                Instructions = new byte[]
                {
                                                                // .text:0050C449 var_8           = dword ptr -8
                                                                // .text:0050C449 var_4           = dword ptr -4
                                                                // .text:0050C449 arg_0           = dword ptr  8
                                                                // .text:0050C449
                    0x55,                                       // .text:0050C449                 push    ebp
                    0x8B, 0xEC,                                 // .text:0050C44A                 mov     ebp, esp
                    0x83, 0xEC, 0x08,                           // .text:0050C44C                 sub     esp, 8
                    0x53,                                       // .text:0050C44F                 push    ebx
                    0x56,                                       // .text:0050C450                 push    esi
                    0x57,                                       // .text:0050C451                 push    edi

                                                                // ; get design efficiency
                    0x8B, 0x45, 0x08,                           // .text:0050C452                 mov     eax, [ebp+arg_0]
                    0x50,                                       // .text:0050C455                 push    eax
                    0xE8, 0x69, 0xFF, 0xFF, 0xFF,               // .text:0050C456                 call    sub_50C3C4
                    0x83, 0xC4, 0x04,                           // .text:0050C45B                 add     esp, 4
                    0x8B, 0x4D, 0x08,                           // .text:0050C45E                 mov     ecx, [ebp+arg_0]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C461                 imul    ecx, 2FCh
                    0x89, 0x81, 0xA0, 0xF4, 0x8C, 0x00,         // .text:0050C467                 mov     ds:dword_8CF4A0[ecx], eax

                                                                // ; get designer skill
                    0x8B, 0x15, 0xA8, 0x60, 0x5F, 0x01,         // .text:0050C46D                 mov     edx, dword_15F60A8
                    0x52,                                       // .text:0050C473                 push    edx
                    0x8B, 0x45, 0x08,                           // .text:0050C474                 mov     eax, [ebp+8]
                    0x50,                                       // .text:0050C477                 push    eax
                    0xE8, 0x3A, 0xA1, 0xF7, 0xFF,               // .text:0050C478                 call    sub_4865B7
                    0x83, 0xC4, 0x08,                           // .text:0050C47D                 add     esp, 8
                    0x89, 0x45, 0xF8,                           // .text:0050C480                 mov     [ebp+var_8], eax

                                                                // ; multiply by factor
                    0x8B, 0x4D, 0xF8,                           // .text:0050C483                 mov     ecx, [ebp+var_8]
                    0x83, 0xE9, 0x01,                           // .text:0050C486                 sub     ecx, 1
                    0x6B, 0xC9, 0x05,                           // .text:0050C489                 imul    ecx, 5
                    0x89, 0x4D, 0xFC,                           // .text:0050C48C                 mov     [ebp+var_4], ecx

                                                                // ; get engineer skill
                    0x8B, 0x15, 0xAC, 0x60, 0x5F, 0x01,         // .text:0050C48F                 mov     edx, dword_15F60AC
                    0x52,                                       // .text:0050C495                 push    edx
                    0x8B, 0x45, 0x08,                           // .text:0050C496                 mov     eax, [ebp+arg_0]
                    0x50,                                       // .text:0050C499                 push    eax
                    0xE8, 0x18, 0xA1, 0xF7, 0xFF,               // .text:0050C49A                 call    sub_4865B7
                    0x83, 0xC4, 0x08,                           // .text:0050C49F                 add     esp, 8
                    0x89, 0x45, 0xF8,                           // .text:0050C4A2                 mov     [ebp+var_8], eax

                                                                // ; multiply by factor
                    0x8B, 0x4D, 0xF8,                           // .text:0050C4A5                 mov     ecx, [ebp+var_8]
                    0x83, 0xE9, 0x01,                           // .text:0050C4A8                 sub     ecx, 1
                    0x6B, 0xC9, 0x0F,                           // .text:0050C4AB                 imul    ecx, 0Fh
                    0x8B, 0x55, 0xFC,                           // .text:0050C4AE                 mov     edx, [ebp+var_4]

                                                                // ; add to handling (carry over ecx)
                    0x03, 0xCA,                                 // .text:0050C4B1                 add     ecx, edx
                    0x89, 0x4D, 0xFC,                           // .text:0050C4B3                 mov     [ebp+var_4], ecx

                                                                // ; add handling efficiency bonus to handling (if/else if)
                    0x8B, 0x55, 0x08,                           // .text:0050C4B6                 mov     edx, [ebp+arg_0]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C4B9                 imul    edx, 2FCh
                    0x83, 0xBA, 0xA0, 0xF4, 0x8C, 0x00, 0x0A,   // .text:0050C4BF                 cmp     ds:dword_8CF4A0[edx], 0Ah
                    0x7F, 0x0E,                                 // .text:0050C4C6                 jg      short loc_50C4D6
                    0x8B, 0x45, 0xFC,                           // .text:0050C4C8                 mov     eax, [ebp+var_4]
                    0x83, 0xC0, 0x02,                           // .text:0050C4CB                 add     eax, 2
                    0x89, 0x45, 0xFC,                           // .text:0050C4CE                 mov     [ebp+var_4], eax
                    0xE9, 0xCF, 0x01, 0x00, 0x00,               // .text:0050C4D1                 jmp     loc_50C6A5
                                                                // .text:0050C4D6 ; ---------------------------------------------------------------------------
                                                                // .text:0050C4D6
                                                                // .text:0050C4D6 loc_50C4D6:                             ; CODE XREF: sub_50C449+7Dj
                    0x8B, 0x4D, 0x08,                           // .text:0050C4D6                 mov     ecx, [ebp+arg_0]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C4D9                 imul    ecx, 2FCh
                    0x83, 0xB9, 0xA0, 0xF4, 0x8C, 0x00, 0x14,   // .text:0050C4DF                 cmp     ds:dword_8CF4A0[ecx], 14h
                    0x7F, 0x0E,                                 // .text:0050C4E6                 jg      short loc_50C4F6
                    0x8B, 0x55, 0xFC,                           // .text:0050C4E8                 mov     edx, [ebp+var_4]
                    0x83, 0xC2, 0x04,                           // .text:0050C4EB                 add     edx, 4
                    0x89, 0x55, 0xFC,                           // .text:0050C4EE                 mov     [ebp+var_4], edx
                    0xE9, 0xAF, 0x01, 0x00, 0x00,               // .text:0050C4F1                 jmp     loc_50C6A5
                                                                // .text:0050C4F6 ; ---------------------------------------------------------------------------
                                                                // .text:0050C4F6
                                                                // .text:0050C4F6 loc_50C4F6:                             ; CODE XREF: sub_50C449+9Dj
                    0x8B, 0x45, 0x08,                           // .text:0050C4F6                 mov     eax, [ebp+arg_0]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C4F9                 imul    eax, 2FCh
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x1E,   // .text:0050C4FF                 cmp     ds:dword_8CF4A0[eax], 1Eh
                    0x7F, 0x0E,                                 // .text:0050C506                 jg      short loc_50C516
                    0x8B, 0x4D, 0xFC,                           // .text:0050C508                 mov     ecx, [ebp+var_4]
                    0x83, 0xC1, 0x06,                           // .text:0050C50B                 add     ecx, 6
                    0x89, 0x4D, 0xFC,                           // .text:0050C50E                 mov     [ebp+var_4], ecx
                    0xE9, 0x8F, 0x01, 0x00, 0x00,               // .text:0050C511                 jmp     loc_50C6A5
                                                                // .text:0050C516 ; ---------------------------------------------------------------------------
                                                                // .text:0050C516
                                                                // .text:0050C516 loc_50C516:                             ; CODE XREF: sub_50C449+BDj
                    0x8B, 0x55, 0x08,                           // .text:0050C516                 mov     edx, [ebp+arg_0]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C519                 imul    edx, 2FCh
                    0x83, 0xBA, 0xA0, 0xF4, 0x8C, 0x00, 0x28,   // .text:0050C51F                 cmp     ds:dword_8CF4A0[edx], 28h
                    0x7F, 0x0E,                                 // .text:0050C526                 jg      short loc_50C536
                    0x8B, 0x45, 0xFC,                           // .text:0050C528                 mov     eax, [ebp+var_4]
                    0x83, 0xC0, 0x08,                           // .text:0050C52B                 add     eax, 8
                    0x89, 0x45, 0xFC,                           // .text:0050C52E                 mov     [ebp+var_4], eax
                    0xE9, 0x6F, 0x01, 0x00, 0x00,               // .text:0050C531                 jmp     loc_50C6A5
                                                                // .text:0050C536 ; ---------------------------------------------------------------------------
                                                                // .text:0050C536
                                                                // .text:0050C536 loc_50C536:                             ; CODE XREF: sub_50C449+DDj
                    0x8B, 0x4D, 0x08,                           // .text:0050C536                 mov     ecx, [ebp+arg_0]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C539                 imul    ecx, 2FCh
                    0x83, 0xB9, 0xA0, 0xF4, 0x8C, 0x00, 0x2D,   // .text:0050C53F                 cmp     ds:dword_8CF4A0[ecx], 2Dh
                    0x7F, 0x0E,                                 // .text:0050C546                 jg      short loc_50C556
                    0x8B, 0x55, 0xFC,                           // .text:0050C548                 mov     edx, [ebp+var_4]
                    0x83, 0xC2, 0x09,                           // .text:0050C54B                 add     edx, 9
                    0x89, 0x55, 0xFC,                           // .text:0050C54E                 mov     [ebp+var_4], edx
                    0xE9, 0x4F, 0x01, 0x00, 0x00,               // .text:0050C551                 jmp     loc_50C6A5
                                                                // .text:0050C556 ; ---------------------------------------------------------------------------
                                                                // .text:0050C556
                                                                // .text:0050C556 loc_50C556:                             ; CODE XREF: sub_50C449+FDj
                    0x8B, 0x45, 0x08,                           // .text:0050C556                 mov     eax, [ebp+arg_0]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C559                 imul    eax, 2FCh
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x32,   // .text:0050C55F                 cmp     ds:dword_8CF4A0[eax], 32h
                    0x7F, 0x0E,                                 // .text:0050C566                 jg      short loc_50C576
                    0x8B, 0x4D, 0xFC,                           // .text:0050C568                 mov     ecx, [ebp+var_4]
                    0x83, 0xC1, 0x0A,                           // .text:0050C56B                 add     ecx, 0Ah
                    0x89, 0x4D, 0xFC,                           // .text:0050C56E                 mov     [ebp+var_4], ecx
                    0xE9, 0x2F, 0x01, 0x00, 0x00,               // .text:0050C571                 jmp     loc_50C6A5
                                                                // .text:0050C576 ; ---------------------------------------------------------------------------
                                                                // .text:0050C576
                                                                // .text:0050C576 loc_50C576:                             ; CODE XREF: sub_50C449+11Dj
                    0x8B, 0x55, 0x08,                           // .text:0050C576                 mov     edx, [ebp+arg_0]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C579                 imul    edx, 2FCh
                    0x83, 0xBA, 0xA0, 0xF4, 0x8C, 0x00, 0x37,   // .text:0050C57F                 cmp     ds:dword_8CF4A0[edx], 37h
                    0x7F, 0x0E,                                 // .text:0050C586                 jg      short loc_50C596
                    0x8B, 0x45, 0xFC,                           // .text:0050C588                 mov     eax, [ebp+var_4]
                    0x83, 0xC0, 0x0B,                           // .text:0050C58B                 add     eax, 0Bh
                    0x89, 0x45, 0xFC,                           // .text:0050C58E                 mov     [ebp+var_4], eax
                    0xE9, 0x0F, 0x01, 0x00, 0x00,               // .text:0050C591                 jmp     loc_50C6A5
                                                                // .text:0050C596 ; ---------------------------------------------------------------------------
                                                                // .text:0050C596
                                                                // .text:0050C596 loc_50C596:                             ; CODE XREF: sub_50C449+13Dj
                    0x8B, 0x4D, 0x08,                           // .text:0050C596                 mov     ecx, [ebp+arg_0]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C599                 imul    ecx, 2FCh
                    0x83, 0xB9, 0xA0, 0xF4, 0x8C, 0x00, 0x3C,   // .text:0050C59F                 cmp     ds:dword_8CF4A0[ecx], 3Ch
                    0x7F, 0x0E,                                 // .text:0050C5A6                 jg      short loc_50C5B6
                    0x8B, 0x55, 0xFC,                           // .text:0050C5A8                 mov     edx, [ebp+var_4]
                    0x83, 0xC2, 0x0C,                           // .text:0050C5AB                 add     edx, 0Ch
                    0x89, 0x55, 0xFC,                           // .text:0050C5AE                 mov     [ebp+var_4], edx
                    0xE9, 0xEF, 0x00, 0x00, 0x00,               // .text:0050C5B1                 jmp     loc_50C6A5
                                                                // .text:0050C5B6 ; ---------------------------------------------------------------------------
                                                                // .text:0050C5B6
                                                                // .text:0050C5B6 loc_50C5B6:                             ; CODE XREF: sub_50C449+15Dj
                    0x8B, 0x45, 0x08,                           // .text:0050C5B6                 mov     eax, [ebp+arg_0]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C5B9                 imul    eax, 2FCh
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x41,   // .text:0050C5BF                 cmp     ds:dword_8CF4A0[eax], 41h
                    0x7F, 0x0E,                                 // .text:0050C5C6                 jg      short loc_50C5D6
                    0x8B, 0x4D, 0xFC,                           // .text:0050C5C8                 mov     ecx, [ebp+var_4]
                    0x83, 0xC1, 0x0D,                           // .text:0050C5CB                 add     ecx, 0Dh
                    0x89, 0x4D, 0xFC,                           // .text:0050C5CE                 mov     dword ptr (unk_15ECFFF-15ED003h)[ebp], ecx
                    0xE9, 0xCF, 0x00, 0x00, 0x00,               // .text:0050C5D1                 jmp     loc_50C6A5
                                                                // .text:0050C5D6 ; ---------------------------------------------------------------------------
                                                                // .text:0050C5D6
                                                                // .text:0050C5D6 loc_50C5D6:                             ; CODE XREF: sub_50C449+17Dj
                    0x8B, 0x55, 0x08,                           // .text:0050C5D6                 mov     edx, [ebp+arg_0]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C5D9                 imul    edx, 2FCh
                    0x83, 0xBA, 0xA0, 0xF4, 0x8C, 0x00, 0x46,   // .text:0050C5DF                 cmp     ds:dword_8CF4A0[edx], 46h
                    0x7F, 0x0E,                                 // .text:0050C5E6                 jg      short loc_50C5F6
                    0x8B, 0x45, 0xFC,                           // .text:0050C5E8                 mov     eax, [ebp+var_4]
                    0x83, 0xC0, 0x0E,                           // .text:0050C5EB                 add     eax, 0Eh
                    0x89, 0x45, 0xFC,                           // .text:0050C5EE                 mov     [ebp+var_4], eax
                    0xE9, 0xAF, 0x00, 0x00, 0x00,               // .text:0050C5F1                 jmp     loc_50C6A5
                                                                // .text:0050C5F6 ; ---------------------------------------------------------------------------
                                                                // .text:0050C5F6
                                                                // .text:0050C5F6 loc_50C5F6:                             ; CODE XREF: sub_50C449+19Dj
                    0x8B, 0x4D, 0x08,                           // .text:0050C5F6                 mov     ecx, [ebp+arg_0]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C5F9                 imul    ecx, 2FCh
                    0x83, 0xB9, 0xA0, 0xF4, 0x8C, 0x00, 0x4B,   // .text:0050C5FF                 cmp     ds:dword_8CF4A0[ecx], 4Bh
                    0x7F, 0x0E,                                 // .text:0050C606                 jg      short loc_50C616
                    0x8B, 0x55, 0xFC,                           // .text:0050C608                 mov     edx, [ebp+var_4]
                    0x83, 0xC2, 0x0F,                           // .text:0050C60B                 add     edx, 0Fh
                    0x89, 0x55, 0xFC,                           // .text:0050C60E                 mov     [ebp+var_4], edx
                    0xE9, 0x8F, 0x00, 0x00, 0x00,               // .text:0050C611                 jmp     loc_50C6A5
                                                                // .text:0050C616 ; ---------------------------------------------------------------------------
                                                                // .text:0050C616
                                                                // .text:0050C616 loc_50C616:                             ; CODE XREF: sub_50C449+1BDj
                    0x8B, 0x45, 0x08,                           // .text:0050C616                 mov     eax, [ebp+arg_0]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C619                 imul    eax, 2FCh
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x50,   // .text:0050C61F                 cmp     ds:dword_8CF4A0[eax], 50h
                    0x7F, 0x0B,                                 // .text:0050C626                 jg      short loc_50C633
                    0x8B, 0x4D, 0xFC,                           // .text:0050C628                 mov     ecx, [ebp+var_4]
                    0x83, 0xC1, 0x10,                           // .text:0050C62B                 add     ecx, 10h
                    0x89, 0x4D, 0xFC,                           // .text:0050C62E                 mov     [ebp+var_4], ecx
                    0xEB, 0x72,                                 // .text:0050C631                 jmp     short loc_50C6A5
                                                                // .text:0050C633 ; ---------------------------------------------------------------------------
                                                                // .text:0050C633
                                                                // .text:0050C633 loc_50C633:                             ; CODE XREF: sub_50C449+1DDj
                    0x8B, 0x55, 0x08,                           // .text:0050C633                 mov     edx, [ebp+arg_0]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C636                 imul    edx, 2FCh
                    0x83, 0xBA, 0xA0, 0xF4, 0x8C, 0x00, 0x55,   // .text:0050C63C                 cmp     ds:dword_8CF4A0[edx], 55h
                    0x7F, 0x0B,                                 // .text:0050C643                 jg      short loc_50C650
                    0x8B, 0x45, 0xFC,                           // .text:0050C645                 mov     eax, [ebp+var_4]
                    0x83, 0xC0, 0x11,                           // .text:0050C648                 add     eax, 11h
                    0x89, 0x45, 0xFC,                           // .text:0050C64B                 mov     [ebp+var_4], eax
                    0xEB, 0x55,                                 // .text:0050C64E                 jmp     short loc_50C6A5
                                                                // .text:0050C650 ; ---------------------------------------------------------------------------
                                                                // .text:0050C650
                                                                // .text:0050C650 loc_50C650:                             ; CODE XREF: sub_50C449+1FAj
                    0x8B, 0x4D, 0x08,                           // .text:0050C650                 mov     ecx, [ebp+arg_0]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C653                 imul    ecx, 2FCh
                    0x83, 0xB9, 0xA0, 0xF4, 0x8C, 0x00, 0x5A,   // .text:0050C659                 cmp     ds:dword_8CF4A0[ecx], 5Ah
                    0x7F, 0x0B,                                 // .text:0050C660                 jg      short loc_50C66D
                    0x8B, 0x55, 0xFC,                           // .text:0050C662                 mov     edx, [ebp+var_4]
                    0x83, 0xC2, 0x12,                           // .text:0050C665                 add     edx, 12h
                    0x89, 0x55, 0xFC,                           // .text:0050C668                 mov     [ebp+var_4], edx
                    0xEB, 0x38,                                 // .text:0050C66B                 jmp     short loc_50C6A5
                                                                // .text:0050C66D ; ---------------------------------------------------------------------------
                                                                // .text:0050C66D
                                                                // .text:0050C66D loc_50C66D:                             ; CODE XREF: sub_50C449+217j
                    0x8B, 0x45, 0x08,                           // .text:0050C66D                 mov     eax, [ebp+arg_0]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C670                 imul    eax, 2FCh
                    0x83, 0xB8, 0xA0, 0xF4, 0x8C, 0x00, 0x5F,   // .text:0050C676                 cmp     ds:dword_8CF4A0[eax], 5Fh
                    0x7F, 0x0B,                                 // .text:0050C67D                 jg      short loc_50C68A
                    0x8B, 0x4D, 0xFC,                           // .text:0050C67F                 mov     ecx, [ebp+var_4]
                    0x83, 0xC1, 0x13,                           // .text:0050C682                 add     ecx, 13h
                    0x89, 0x4D, 0xFC,                           // .text:0050C685                 mov     [ebp+var_4], ecx
                    0xEB, 0x1B,                                 // .text:0050C688                 jmp     short loc_50C6A5
                                                                // .text:0050C68A ; ---------------------------------------------------------------------------
                                                                // .text:0050C68A

                                                                // ; if 100% efficiency, add 20% handling
                                                                // .text:0050C68A loc_50C68A:                             ; CODE XREF: sub_50C449+234j
                    0x8B, 0x55, 0x08,                           // .text:0050C68A                 mov     edx, [ebp+arg_0]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C68D                 imul    edx, 2FCh
                    0x83, 0xBA, 0xA0, 0xF4, 0x8C, 0x00, 0x64,   // .text:0050C693                 cmp     ds:dword_8CF4A0[edx], 64h
                    0x7F, 0x09,                                 // .text:0050C69A                 jg      short loc_50C6A5
                    0x8B, 0x45, 0xFC,                           // .text:0050C69C                 mov     eax, [ebp+var_4]
                    0x83, 0xC0, 0x14,                           // .text:0050C69F                 add     eax, 14h
                    0x89, 0x45, 0xFC,                           // .text:0050C6A2                 mov     [ebp+var_4], eax
                                                                // .text:0050C6A5

                                                                // ; get random value
                                                                // ; rand() % 11 = 0-10
                                                                // .text:0050C6A5 loc_50C6A5:                             ; CODE XREF: sub_50C449+88j
                                                                // .text:0050C6A5                                         ; sub_50C449+A8j ...
                    0xE8, 0xE4, 0x11, 0x17, 0x00,               // .text:0050C6A5                 call    sub_67D88E      ; random number in eax
                    0x99,                                       // .text:0050C6AA                 cdq
                    0xB9, 0x0B, 0x00, 0x00, 0x00,               // .text:0050C6AB                 mov     ecx, 0Bh        ; prepare to divide eax by ecx
                    0xF7, 0xF9,                                 // .text:0050C6B0                 idiv    ecx             ; quotient in eax, remainder in edx
                    0x89, 0x55, 0xF8,                           // .text:0050C6B2                 mov     [ebp+var_8], edx

                                                                // ; calc random impact
                                                                // ; 10 - Random0To10 = 0-10
                    0x8B, 0x55, 0xF8,                           // .text:0050C6B5                 mov     edx, [ebp+var_8]
                    0xB8, 0x0A, 0x00, 0x00, 0x00,               // .text:0050C6B8                 mov     eax, 0Ah
                    0x2B, 0xC2,                                 // .text:0050C6BD                 sub     eax, edx
                    0x89, 0x45, 0xF8,                           // .text:0050C6BF                 mov     [ebp+var_8], eax

                                                                // ; sub random impact from handling
                    0x8B, 0x55, 0xFC,                           // .text:0050C6C2                 mov     edx, [ebp+var_4]
                    0x8B, 0x45, 0xF8,                           // .text:0050C6C5                 mov     eax, [ebp+var_8]
                    0x2B, 0xD0,                                 // .text:0050C6C8                 sub     edx, eax
                    0x89, 0x55, 0xFC,                           // .text:0050C6CA                 mov     [ebp+var_4], edx

                                                                // ; sub difficulty impact from handling
                    0x8B, 0x55, 0xFC,                           // .text:0050C6CD                 mov     edx, [ebp+var_4]
                    0xB8, 0x00, 0x00, 0x00, 0x00,               // .text:0050C6D0                 mov     eax, 0
                    0x2B, 0xD0,                                 // .text:0050C6D5                 sub     edx, eax
                    0x89, 0x55, 0xFC,                           // .text:0050C6D7                 mov     [ebp+var_4], edx

                                                                // ; if handling is less than or equal to zero, make zero
                    0x83, 0x7D, 0xFC, 0x00,                     // .text:0050C6DA                 cmp     [ebp+var_4], 0
                    0x7F, 0x07,                                 // .text:0050C6DE                 jg      short loc_50C6E7
                    0xC7, 0x45, 0xFC, 0x00, 0x00, 0x00, 0x00,   // .text:0050C6E0                 mov     [ebp+var_4], 0
                                                                // .text:0050C6E7

                                                                // ; player car effectively loses handling percentage
                                                                // ; e.g. 100% car will be anywhere between 90-100% car
                                                                // ; store final handling
                                                                // .text:0050C6E7 loc_50C6E7:                             ; CODE XREF: sub_50C449+295j
                    0x8B, 0x45, 0x08,                           // .text:0050C6E7                 mov     eax, [ebp+arg_0]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050C6EA                 imul    eax, 2FCh
                    0x8B, 0x4D, 0xFC,                           // .text:0050C6F0                 mov     ecx, [ebp+var_4]
                    0x89, 0x88, 0x08, 0xF5, 0x8C, 0x00,         // .text:0050C6F3                 mov     ds:dword_8CF508[eax], ecx

                                                                // ; end sub
                    0x6A, 0x01,                                 // .text:0050C6F9                 push    1
                    0x8B, 0x55, 0x08,                           // .text:0050C6FB                 mov     edx, [ebp+arg_0]
                    0x52,                                       // .text:0050C6FE                 push    edx
                    0xE8, 0x0E, 0x03, 0x00, 0x00,               // .text:0050C6FF                 call    sub_50CA12
                    0x83, 0xC4, 0x08,                           // .text:0050C704                 add     esp, 8
                    0x5F,                                       // .text:0050C707                 pop     edi
                    0x5E,                                       // .text:0050C708                 pop     esi
                    0x5B,                                       // .text:0050C709                 pop     ebx
                    0xC9,                                       // .text:0050C70A                 leave
                    0xC3,                                       // .text:0050C70B                 retn
                                                                // .text:0050C70B sub_50C449      endp
                                                                // .text:0050C70B
                                                                // .text:0050C70B ; ---------------------------------------------------------------------------
                    0xCC,                                       // .text:0050C70C                 db  CCh ; É
                    0xCC,                                       // .text:0050C70D                 db  CCh ; É
                    0xCC,                                       // .text:0050C70E                 db  CCh ; É
                    0xCC,                                       // .text:0050C70F                 db  CCh ; É
                    0xCC,                                       // .text:0050C710                 db  CCh ; É
                    0xCC,                                       // .text:0050C711                 db  CCh ; É
                    0xCC,                                       // .text:0050C712                 db  CCh ; É
                    0xCC,                                       // .text:0050C713                 db  CCh ; É
                    0xCC,                                       // .text:0050C714                 db  CCh ; É
                    0xCC,                                       // .text:0050C715                 db  CCh ; É
                    0xCC,                                       // .text:0050C716                 db  CCh ; É
                    0xCC,                                       // .text:0050C717                 db  CCh ; É
                    0xCC,                                       // .text:0050C718                 db  CCh ; É
                    0xCC,                                       // .text:0050C719                 db  CCh ; É
                    0xCC,                                       // .text:0050C71A                 db  CCh ; É
                    0xCC,                                       // .text:0050C71B                 db  CCh ; É
                    0xCC,                                       // .text:0050C71C                 db  CCh ; É
                    0xCC,                                       // .text:0050C71D                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050C71E                 db  CCh ; É
                    0xCC,                                       // .text:0050C71F                 db  CCh ; É
                    0xCC,                                       // .text:0050C720                 db  CCh ; É
                    0xCC,                                       // .text:0050C721                 db  CCh ; É
                    0xCC,                                       // .text:0050C722                 db  CCh ; É
                    0xCC,                                       // .text:0050C723                 db  CCh ; É
                    0xCC,                                       // .text:0050C724                 db  CCh ; É
                    0xCC,                                       // .text:0050C725                 db  CCh ; É
                    0xCC,                                       // .text:0050C726                 db  CCh ; É
                    0xCC,                                       // .text:0050C727                 db  CCh ; É
                    0xCC,                                       // .text:0050C728                 db  CCh ; É
                    0xCC,                                       // .text:0050C729                 db  CCh ; É
                    0xCC,                                       // .text:0050C72A                 db  CCh ; É
                    0xCC,                                       // .text:0050C72B                 db  CCh ; É
                    0xCC,                                       // .text:0050C72C                 db  CCh ; É
                    0xCC,                                       // .text:0050C72D                 db  CCh ; É
                    0xCC,                                       // .text:0050C72E                 db  CCh ; É
                    0xCC,                                       // .text:0050C72F                 db  CCh ; É
                    0xCC,                                       // .text:0050C730                 db  CCh ; É
                    0xCC,                                       // .text:0050C731                 db  CCh ; É
                    0xCC,                                       // .text:0050C732                 db  CCh ; É
                    0xCC,                                       // .text:0050C733                 db  CCh ; É
                    0xCC,                                       // .text:0050C734                 db  CCh ; É
                    0xCC,                                       // .text:0050C735                 db  CCh ; É
                    0xCC,                                       // .text:0050C736                 db  CCh ; É
                    0xCC,                                       // .text:0050C737                 db  CCh ; É
                    0xCC,                                       // .text:0050C738                 db  CCh ; É
                    0xCC,                                       // .text:0050C739                 db  CCh ; É
                    0xCC,                                       // .text:0050C73A                 db  CCh ; É
                    0xCC,                                       // .text:0050C73B                 db  CCh ; É
                    0xCC,                                       // .text:0050C73C                 db  CCh ; É
                    0xCC,                                       // .text:0050C73D                 db  CCh ; É
                    0xCC,                                       // .text:0050C73E                 db  CCh ; É
                    0xCC,                                       // .text:0050C73F                 db  CCh ; É
                    0xCC,                                       // .text:0050C740                 db  CCh ; É
                    0xCC,                                       // .text:0050C741                 db  CCh ; É
                    0xCC,                                       // .text:0050C742                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050C743                 db  CCh ; É
                    0xCC,                                       // .text:0050C744                 db  CCh ; É
                    0xCC,                                       // .text:0050C745                 db  CCh ; É
                    0xCC,                                       // .text:0050C746                 db  CCh ; É
                    0xCC,                                       // .text:0050C747                 db  CCh ; É
                    0xCC,                                       // .text:0050C748                 db  CCh ; É
                    0xCC,                                       // .text:0050C749                 db  CCh ; É
                    0xCC,                                       // .text:0050C74A                 db  CCh ; É
                    0xCC,                                       // .text:0050C74B                 db  CCh ; É
                    0xCC,                                       // .text:0050C74C                 db  CCh ; É
                    0xCC,                                       // .text:0050C74D                 db  CCh ; É
                    0xCC,                                       // .text:0050C74E                 db  CCh ; É
                    0xCC,                                       // .text:0050C74F                 db  CCh ; É
                    0xCC,                                       // .text:0050C750                 db  CCh ; É
                    0xCC,                                       // .text:0050C751                 db  CCh ; É
                    0xCC,                                       // .text:0050C752                 db  CCh ; É
                    0xCC,                                       // .text:0050C753                 db  CCh ; É
                    0xCC,                                       // .text:0050C754                 db  CCh ; É
                    0xCC,                                       // .text:0050C755                 db  CCh ; É
                    0xCC,                                       // .text:0050C756                 db  CCh ; É
                    0xCC,                                       // .text:0050C757                 db  CCh ; É
                    0xCC,                                       // .text:0050C758                 db  CCh ; É
                    0xCC,                                       // .text:0050C759                 db  CCh ; É
                    0xCC,                                       // .text:0050C75A                 db  CCh ; É
                    0xCC,                                       // .text:0050C75B                 db  CCh ; É
                    0xCC,                                       // .text:0050C75C                 db  CCh ; É
                    0xCC,                                       // .text:0050C75D                 db  CCh ; É
                    0xCC,                                       // .text:0050C75E                 db  CCh ; É
                    0xCC,                                       // .text:0050C75F                 db  CCh ; É
                    0xCC,                                       // .text:0050C760                 db  CCh ; É
                    0xCC,                                       // .text:0050C761                 db  CCh ; É
                    0xCC,                                       // .text:0050C762                 db  CCh ; É
                    0xCC,                                       // .text:0050C763                 db  CCh ; É
                    0xCC,                                       // .text:0050C764                 db  CCh ; É
                    0xCC,                                       // .text:0050C765                 db  CCh ; É
                    0xCC,                                       // .text:0050C766                 db  CCh ; É
                    0xCC,                                       // .text:0050C767                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050C768                 db  CCh ; É
                    0xCC,                                       // .text:0050C769                 db  CCh ; É
                    0xCC,                                       // .text:0050C76A                 db  CCh ; É
                    0xCC,                                       // .text:0050C76B                 db  CCh ; É
                    0xCC,                                       // .text:0050C76C                 db  CCh ; É
                    0xCC,                                       // .text:0050C76D                 db  CCh ; É
                    0xCC,                                       // .text:0050C76E                 db  CCh ; É
                    0xCC,                                       // .text:0050C76F                 db  CCh ; É
                    0xCC,                                       // .text:0050C770                 db  CCh ; É
                    0xCC,                                       // .text:0050C771                 db  CCh ; É
                    0xCC,                                       // .text:0050C772                 db  CCh ; É
                    0xCC,                                       // .text:0050C773                 db  CCh ; É
                    0xCC,                                       // .text:0050C774                 db  CCh ; É
                    0xCC,                                       // .text:0050C775                 db  CCh ; É
                    0xCC,                                       // .text:0050C776                 db  CCh ; É
                    0xCC,                                       // .text:0050C777                 db  CCh ; É
                    0xCC,                                       // .text:0050C778                 db  CCh ; É
                    0xCC,                                       // .text:0050C779                 db  CCh ; É
                    0xCC,                                       // .text:0050C77A                 db  CCh ; É
                    0xCC,                                       // .text:0050C77B                 db  CCh ; É
                    0xCC,                                       // .text:0050C77C                 db  CCh ; É
                    0xCC,                                       // .text:0050C77D                 db  CCh ; É
                    0xCC,                                       // .text:0050C77E                 db  CCh ; É
                    0xCC,                                       // .text:0050C77F                 db  CCh ; É
                    0xCC,                                       // .text:0050C780                 db  CCh ; É
                    0xCC,                                       // .text:0050C781                 db  CCh ; É
                    0xCC,                                       // .text:0050C782                 db  CCh ; É
                    0xCC,                                       // .text:0050C783                 db  CCh ; É
                    0xCC,                                       // .text:0050C784                 db  CCh ; É
                    0xCC,                                       // .text:0050C785                 db  CCh ; É
                    0xCC,                                       // .text:0050C786                 db  CCh ; É
                    0xCC,                                       // .text:0050C787                 db  CCh ; É
                    0xCC,                                       // .text:0050C788                 db  CCh ; É
                    0xCC,                                       // .text:0050C789                 db  CCh ; É
                    0xCC,                                       // .text:0050C78A                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050C78B                 db  CCh ; É
                    0xCC,                                       // .text:0050C78C                 db  CCh ; É
                    0xCC,                                       // .text:0050C78D                 db  CCh ; É
                    0xCC,                                       // .text:0050C78E                 db  CCh ; É
                    0xCC,                                       // .text:0050C78F                 db  CCh ; É
                    0xCC,                                       // .text:0050C790                 db  CCh ; É
                    0xCC,                                       // .text:0050C791                 db  CCh ; É
                    0xCC,                                       // .text:0050C792                 db  CCh ; É
                    0xCC,                                       // .text:0050C793                 db  CCh ; É
                    0xCC,                                       // .text:0050C794                 db  CCh ; É
                    0xCC,                                       // .text:0050C795                 db  CCh ; É
                    0xCC,                                       // .text:0050C796                 db  CCh ; É
                    0xCC,                                       // .text:0050C797                 db  CCh ; É
                    0xCC,                                       // .text:0050C798                 db  CCh ; É
                    0xCC,                                       // .text:0050C799                 db  CCh ; É
                    0xCC,                                       // .text:0050C79A                 db  CCh ; É
                    0xCC,                                       // .text:0050C79B                 db  CCh ; É
                    0xCC,                                       // .text:0050C79C                 db  CCh ; É
                    0xCC,                                       // .text:0050C79D                 db  CCh ; É
                    0xCC,                                       // .text:0050C79E                 db  CCh ; É
                    0xCC,                                       // .text:0050C79F                 db  CCh ; É
                    0xCC                                        // .text:0050C7A0                 db  CCh ; É
                }
            });
            #endregion
            // End

            taskId++;

            // Task B (AI teams)
            #region Task B Unmodified
            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(CarDesignCalculationUpdate).Name,
                VirtualPosition = 0x0050D41E,
                Instructions = new byte[]
                {
                                                                                // .text:0050D41E var_1F0         = dword ptr -1F0h
                                                                                // .text:0050D41E var_1EC         = dword ptr -1ECh
                                                                                // .text:0050D41E var_1E8         = dword ptr -1E8h
                                                                                // .text:0050D41E var_1E4         = dword ptr -1E4h
                                                                                // .text:0050D41E var_1E0         = dword ptr -1E0h
                                                                                // .text:0050D41E var_1DC         = dword ptr -1DCh
                                                                                // .text:0050D41E var_1D8         = dword ptr -1D8h
                                                                                // .text:0050D41E var_1D4         = dword ptr -1D4h
                                                                                // .text:0050D41E var_1D0         = dword ptr -1D0h
                                                                                // .text:0050D41E var_1CC         = dword ptr -1CCh
                                                                                // .text:0050D41E var_1C8         = dword ptr -1C8h
                                                                                // .text:0050D41E var_1C4         = dword ptr -1C4h
                                                                                // .text:0050D41E var_1C0         = dword ptr -1C0h
                                                                                // .text:0050D41E var_1BC         = dword ptr -1BCh
                                                                                // .text:0050D41E var_1B8         = dword ptr -1B8h
                                                                                // .text:0050D41E var_1B4         = dword ptr -1B4h
                                                                                // .text:0050D41E var_1B0         = dword ptr -1B0h
                                                                                // .text:0050D41E var_1AC         = dword ptr -1ACh
                                                                                // .text:0050D41E var_1A8         = dword ptr -1A8h
                                                                                // .text:0050D41E var_1A4         = dword ptr -1A4h
                                                                                // .text:0050D41E var_1A0         = dword ptr -1A0h
                                                                                // .text:0050D41E var_19C         = dword ptr -19Ch
                                                                                // .text:0050D41E var_198         = dword ptr -198h
                                                                                // .text:0050D41E var_194         = dword ptr -194h
                                                                                // .text:0050D41E var_190         = dword ptr -190h
                                                                                // .text:0050D41E var_18C         = dword ptr -18Ch
                                                                                // .text:0050D41E var_188         = dword ptr -188h
                                                                                // .text:0050D41E var_184         = dword ptr -184h
                                                                                // .text:0050D41E var_180         = dword ptr -180h
                                                                                // .text:0050D41E var_17C         = dword ptr -17Ch
                                                                                // .text:0050D41E var_178         = dword ptr -178h
                                                                                // .text:0050D41E var_174         = dword ptr -174h
                                                                                // .text:0050D41E var_170         = dword ptr -170h
                                                                                // .text:0050D41E var_16C         = dword ptr -16Ch
                                                                                // .text:0050D41E var_168         = dword ptr -168h
                                                                                // .text:0050D41E var_164         = dword ptr -164h
                                                                                // .text:0050D41E var_160         = dword ptr -160h
                                                                                // .text:0050D41E var_15C         = dword ptr -15Ch
                                                                                // .text:0050D41E var_158         = dword ptr -158h
                                                                                // .text:0050D41E var_154         = dword ptr -154h
                                                                                // .text:0050D41E var_150         = dword ptr -150h
                                                                                // .text:0050D41E var_14C         = dword ptr -14Ch
                                                                                // .text:0050D41E var_148         = dword ptr -148h
                                                                                // .text:0050D41E var_144         = dword ptr -144h
                                                                                // .text:0050D41E var_140         = dword ptr -140h
                                                                                // .text:0050D41E var_13C         = dword ptr -13Ch
                                                                                // .text:0050D41E var_138         = dword ptr -138h
                                                                                // .text:0050D41E var_134         = dword ptr -134h
                                                                                // .text:0050D41E var_130         = dword ptr -130h
                                                                                // .text:0050D41E var_12C         = dword ptr -12Ch
                                                                                // .text:0050D41E var_128         = dword ptr -128h
                                                                                // .text:0050D41E var_124         = dword ptr -124h
                                                                                // .text:0050D41E var_120         = dword ptr -120h
                                                                                // .text:0050D41E var_11C         = dword ptr -11Ch
                                                                                // .text:0050D41E var_118         = dword ptr -118h
                                                                                // .text:0050D41E var_114         = dword ptr -114h
                                                                                // .text:0050D41E var_110         = dword ptr -110h
                                                                                // .text:0050D41E var_10C         = dword ptr -10Ch
                                                                                // .text:0050D41E var_108         = dword ptr -108h
                                                                                // .text:0050D41E var_104         = dword ptr -104h
                                                                                // .text:0050D41E var_100         = dword ptr -100h
                                                                                // .text:0050D41E var_FC          = dword ptr -0FCh
                                                                                // .text:0050D41E var_F8          = dword ptr -0F8h
                                                                                // .text:0050D41E var_F4          = dword ptr -0F4h
                                                                                // .text:0050D41E var_F0          = dword ptr -0F0h
                                                                                // .text:0050D41E var_EC          = dword ptr -0ECh
                                                                                // .text:0050D41E var_E8          = dword ptr -0E8h
                                                                                // .text:0050D41E var_E4          = dword ptr -0E4h
                                                                                // .text:0050D41E var_E0          = dword ptr -0E0h
                                                                                // .text:0050D41E var_DC          = dword ptr -0DCh
                                                                                // .text:0050D41E var_D8          = dword ptr -0D8h
                                                                                // .text:0050D41E var_D4          = dword ptr -0D4h
                                                                                // .text:0050D41E var_D0          = dword ptr -0D0h
                                                                                // .text:0050D41E var_CC          = dword ptr -0CCh
                                                                                // .text:0050D41E var_C8          = dword ptr -0C8h
                                                                                // .text:0050D41E var_C4          = dword ptr -0C4h
                                                                                // .text:0050D41E var_C0          = dword ptr -0C0h
                                                                                // .text:0050D41E var_BC          = dword ptr -0BCh
                                                                                // .text:0050D41E var_B8          = dword ptr -0B8h
                                                                                // .text:0050D41E var_B4          = dword ptr -0B4h
                                                                                // .text:0050D41E var_B0          = dword ptr -0B0h
                                                                                // .text:0050D41E var_AC          = dword ptr -0ACh
                                                                                // .text:0050D41E var_A8          = dword ptr -0A8h
                                                                                // .text:0050D41E var_A4          = dword ptr -0A4h
                                                                                // .text:0050D41E var_A0          = dword ptr -0A0h
                                                                                // .text:0050D41E var_9C          = dword ptr -9Ch
                                                                                // .text:0050D41E var_98          = dword ptr -98h
                                                                                // .text:0050D41E var_94          = dword ptr -94h
                                                                                // .text:0050D41E var_90          = dword ptr -90h
                                                                                // .text:0050D41E var_8C          = dword ptr -8Ch
                                                                                // .text:0050D41E var_88          = dword ptr -88h
                                                                                // .text:0050D41E var_84          = dword ptr -84h
                                                                                // .text:0050D41E var_80          = dword ptr -80h
                                                                                // .text:0050D41E var_7C          = dword ptr -7Ch
                                                                                // .text:0050D41E var_78          = dword ptr -78h
                                                                                // .text:0050D41E var_74          = dword ptr -74h
                                                                                // .text:0050D41E var_70          = dword ptr -70h
                                                                                // .text:0050D41E var_6C          = dword ptr -6Ch
                                                                                // .text:0050D41E var_68          = dword ptr -68h
                                                                                // .text:0050D41E var_64          = dword ptr -64h
                                                                                // .text:0050D41E var_60          = dword ptr -60h
                                                                                // .text:0050D41E var_5C          = dword ptr -5Ch
                                                                                // .text:0050D41E var_58          = dword ptr -58h
                                                                                // .text:0050D41E var_54          = dword ptr -54h
                                                                                // .text:0050D41E var_50          = dword ptr -50h
                                                                                // .text:0050D41E var_4C          = dword ptr -4Ch
                                                                                // .text:0050D41E var_48          = dword ptr -48h
                                                                                // .text:0050D41E var_44          = dword ptr -44h
                                                                                // .text:0050D41E var_40          = dword ptr -40h
                                                                                // .text:0050D41E var_3C          = dword ptr -3Ch
                                                                                // .text:0050D41E var_38          = dword ptr -38h
                                                                                // .text:0050D41E var_34          = dword ptr -34h
                                                                                // .text:0050D41E var_30          = dword ptr -30h
                                                                                // .text:0050D41E var_2C          = dword ptr -2Ch
                                                                                // .text:0050D41E var_28          = dword ptr -28h
                                                                                // .text:0050D41E var_24          = dword ptr -24h
                                                                                // .text:0050D41E var_20          = dword ptr -20h
                                                                                // .text:0050D41E var_1C          = dword ptr -1Ch
                                                                                // .text:0050D41E var_18          = dword ptr -18h
                                                                                // .text:0050D41E var_14          = dword ptr -14h
                                                                                // .text:0050D41E var_10          = dword ptr -10h
                                                                                // .text:0050D41E var_C           = dword ptr -0Ch
                                                                                // .text:0050D41E var_8           = dword ptr -8
                                                                                // .text:0050D41E var_4           = dword ptr -4
                                                                                // .text:0050D41E 
                    0x55,                                                       // .text:0050D41E                 push    ebp
                    0x8B, 0xEC,                                                 // .text:0050D41F                 mov     ebp, esp
                    0x81, 0xEC, 0xF0, 0x01, 0x00, 0x00,                         // .text:0050D421                 sub     esp, 1F0h
                    0x53,                                                       // .text:0050D427                 push    ebx
                    0x56,                                                       // .text:0050D428                 push    esi
                    0x57,                                                       // .text:0050D429                 push    edi
                    0xC7, 0x85, 0x20, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D42A                 mov     [ebp+var_1E0], 0
                    0xC7, 0x85, 0x24, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D434                 mov     [ebp+var_1DC], 0
                    0xC7, 0x85, 0x28, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D43E                 mov     [ebp+var_1D8], 0
                    0xC7, 0x85, 0x2C, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D448                 mov     [ebp+var_1D4], 0
                    0xC7, 0x85, 0x30, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D452                 mov     [ebp+var_1D0], 0
                    0xC7, 0x85, 0x34, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D45C                 mov     [ebp+var_1CC], 0
                    0xC7, 0x85, 0x38, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D466                 mov     [ebp+var_1C8], 0
                    0xC7, 0x85, 0x3C, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D470                 mov     [ebp+var_1C4], 0
                    0xC7, 0x85, 0x40, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D47A                 mov     [ebp+var_1C0], 0
                    0xC7, 0x85, 0x44, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D484                 mov     [ebp+var_1BC], 0
                    0xC7, 0x85, 0x48, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D48E                 mov     [ebp+var_1B8], 10h
                    0xC7, 0x85, 0x4C, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D498                 mov     [ebp+var_1B4], 10h
                    0xC7, 0x85, 0x50, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D4A2                 mov     [ebp+var_1B0], 11h
                    0xC7, 0x85, 0x54, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D4AC                 mov     [ebp+var_1AC], 11h
                    0xC7, 0x85, 0x58, 0xFE, 0xFF, 0xFF, 0x12, 0x00, 0x00, 0x00, // .text:0050D4B6                 mov     [ebp+var_1A8], 12h
                    0xC7, 0x85, 0x5C, 0xFE, 0xFF, 0xFF, 0x12, 0x00, 0x00, 0x00, // .text:0050D4C0                 mov     [ebp+var_1A4], 12h
                    0xC7, 0x85, 0x60, 0xFE, 0xFF, 0xFF, 0x13, 0x00, 0x00, 0x00, // .text:0050D4CA                 mov     [ebp+var_1A0], 13h
                    0xC7, 0x85, 0x64, 0xFE, 0xFF, 0xFF, 0x13, 0x00, 0x00, 0x00, // .text:0050D4D4                 mov     [ebp+var_19C], 13h
                    0xC7, 0x85, 0x68, 0xFE, 0xFF, 0xFF, 0x14, 0x00, 0x00, 0x00, // .text:0050D4DE                 mov     [ebp+var_198], 14h
                    0xC7, 0x85, 0x6C, 0xFE, 0xFF, 0xFF, 0x14, 0x00, 0x00, 0x00, // .text:0050D4E8                 mov     [ebp+var_194], 14h
                    0xC7, 0x85, 0x70, 0xFE, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D4F2                 mov     [ebp+var_190], 0Fh
                    0xC7, 0x85, 0x74, 0xFE, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D4FC                 mov     [ebp+var_18C], 0Fh
                    0xC7, 0x85, 0x78, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D506                 mov     [ebp+var_188], 10h
                    0xC7, 0x85, 0x7C, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D510                 mov     [ebp+var_184], 10h
                    0xC7, 0x85, 0x80, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D51A                 mov     [ebp+var_180], 11h
                    0xC7, 0x85, 0x84, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D524                 mov     [ebp+var_17C], 11h
                    0xC7, 0x85, 0x88, 0xFE, 0xFF, 0xFF, 0x12, 0x00, 0x00, 0x00, // .text:0050D52E                 mov     [ebp+var_178], 12h
                    0xC7, 0x85, 0x8C, 0xFE, 0xFF, 0xFF, 0x12, 0x00, 0x00, 0x00, // .text:0050D538                 mov     [ebp+var_174], 12h
                    0xC7, 0x85, 0x90, 0xFE, 0xFF, 0xFF, 0x13, 0x00, 0x00, 0x00, // .text:0050D542                 mov     [ebp+var_170], 13h
                    0xC7, 0x85, 0x94, 0xFE, 0xFF, 0xFF, 0x13, 0x00, 0x00, 0x00, // .text:0050D54C                 mov     [ebp+var_16C], 13h
                    0xC7, 0x85, 0x98, 0xFE, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D556                 mov     [ebp+var_168], 0Eh
                    0xC7, 0x85, 0x9C, 0xFE, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D560                 mov     [ebp+var_164], 0Eh
                    0xC7, 0x85, 0xA0, 0xFE, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D56A                 mov     [ebp+var_160], 0Fh
                    0xC7, 0x85, 0xA4, 0xFE, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D574                 mov     [ebp+var_15C], 0Fh
                    0xC7, 0x85, 0xA8, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D57E                 mov     [ebp+var_158], 10h
                    0xC7, 0x85, 0xAC, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D588                 mov     [ebp+var_154], 10h
                    0xC7, 0x85, 0xB0, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D592                 mov     [ebp+var_150], 11h
                    0xC7, 0x85, 0xB4, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D59C                 mov     [ebp+var_14C], 11h
                    0xC7, 0x85, 0xB8, 0xFE, 0xFF, 0xFF, 0x12, 0x00, 0x00, 0x00, // .text:0050D5A6                 mov     [ebp+var_148], 12h
                    0xC7, 0x85, 0xBC, 0xFE, 0xFF, 0xFF, 0x12, 0x00, 0x00, 0x00, // .text:0050D5B0                 mov     [ebp+var_144], 12h
                    0xC7, 0x85, 0xC0, 0xFE, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D5BA                 mov     [ebp+var_140], 0Dh
                    0xC7, 0x85, 0xC4, 0xFE, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D5C4                 mov     [ebp+var_13C], 0Dh
                    0xC7, 0x85, 0xC8, 0xFE, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D5CE                 mov     [ebp+var_138], 0Eh
                    0xC7, 0x85, 0xCC, 0xFE, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D5D8                 mov     [ebp+var_134], 0Eh
                    0xC7, 0x85, 0xD0, 0xFE, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D5E2                 mov     [ebp+var_130], 0Fh
                    0xC7, 0x85, 0xD4, 0xFE, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D5EC                 mov     [ebp+var_12C], 0Fh
                    0xC7, 0x85, 0xD8, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D5F6                 mov     [ebp+var_128], 10h
                    0xC7, 0x85, 0xDC, 0xFE, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D600                 mov     [ebp+var_124], 10h
                    0xC7, 0x85, 0xE0, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D60A                 mov     [ebp+var_120], 11h
                    0xC7, 0x85, 0xE4, 0xFE, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, // .text:0050D614                 mov     [ebp+var_11C], 11h
                    0xC7, 0x85, 0xE8, 0xFE, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D61E                 mov     [ebp+var_118], 0Ch
                    0xC7, 0x85, 0xEC, 0xFE, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D628                 mov     [ebp+var_114], 0Ch
                    0xC7, 0x85, 0xF0, 0xFE, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D632                 mov     [ebp+var_110], 0Dh
                    0xC7, 0x85, 0xF4, 0xFE, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D63C                 mov     [ebp+var_10C], 0Dh
                    0xC7, 0x85, 0xF8, 0xFE, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D646                 mov     [ebp+var_108], 0Eh
                    0xC7, 0x85, 0xFC, 0xFE, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D650                 mov     [ebp+var_104], 0Eh
                    0xC7, 0x85, 0x00, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D65A                 mov     [ebp+var_100], 0Fh
                    0xC7, 0x85, 0x04, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D664                 mov     [ebp+var_FC], 0Fh
                    0xC7, 0x85, 0x08, 0xFF, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D66E                 mov     [ebp+var_F8], 10h
                    0xC7, 0x85, 0x0C, 0xFF, 0xFF, 0xFF, 0x10, 0x00, 0x00, 0x00, // .text:0050D678                 mov     [ebp+var_F4], 10h
                    0xC7, 0x85, 0x10, 0xFF, 0xFF, 0xFF, 0x0B, 0x00, 0x00, 0x00, // .text:0050D682                 mov     [ebp+var_F0], 0Bh
                    0xC7, 0x85, 0x14, 0xFF, 0xFF, 0xFF, 0x0B, 0x00, 0x00, 0x00, // .text:0050D68C                 mov     [ebp+var_EC], 0Bh
                    0xC7, 0x85, 0x18, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D696                 mov     [ebp+var_E8], 0Ch
                    0xC7, 0x85, 0x1C, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D6A0                 mov     [ebp+var_E4], 0Ch
                    0xC7, 0x85, 0x20, 0xFF, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D6AA                 mov     [ebp+var_E0], 0Dh
                    0xC7, 0x85, 0x24, 0xFF, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D6B4                 mov     [ebp+var_DC], 0Dh
                    0xC7, 0x85, 0x28, 0xFF, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D6BE                 mov     [ebp+var_D8], 0Eh
                    0xC7, 0x85, 0x2C, 0xFF, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D6C8                 mov     [ebp+var_D4], 0Eh
                    0xC7, 0x85, 0x30, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D6D2                 mov     [ebp+var_D0], 0Fh
                    0xC7, 0x85, 0x34, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00, // .text:0050D6DC                 mov     [ebp+var_CC], 0Fh
                    0xC7, 0x85, 0x38, 0xFF, 0xFF, 0xFF, 0x0A, 0x00, 0x00, 0x00, // .text:0050D6E6                 mov     [ebp+var_C8], 0Ah
                    0xC7, 0x85, 0x3C, 0xFF, 0xFF, 0xFF, 0x0A, 0x00, 0x00, 0x00, // .text:0050D6F0                 mov     [ebp+var_C4], 0Ah
                    0xC7, 0x85, 0x40, 0xFF, 0xFF, 0xFF, 0x0B, 0x00, 0x00, 0x00, // .text:0050D6FA                 mov     [ebp+var_C0], 0Bh
                    0xC7, 0x85, 0x44, 0xFF, 0xFF, 0xFF, 0x0B, 0x00, 0x00, 0x00, // .text:0050D704                 mov     [ebp+var_BC], 0Bh
                    0xC7, 0x85, 0x48, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D70E                 mov     [ebp+var_B8], 0Ch
                    0xC7, 0x85, 0x4C, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D718                 mov     [ebp+var_B4], 0Ch
                    0xC7, 0x85, 0x50, 0xFF, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D722                 mov     [ebp+var_B0], 0Dh
                    0xC7, 0x85, 0x54, 0xFF, 0xFF, 0xFF, 0x0D, 0x00, 0x00, 0x00, // .text:0050D72C                 mov     [ebp+var_AC], 0Dh
                    0xC7, 0x85, 0x58, 0xFF, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D736                 mov     [ebp+var_A8], 0Eh
                    0xC7, 0x85, 0x5C, 0xFF, 0xFF, 0xFF, 0x0E, 0x00, 0x00, 0x00, // .text:0050D740                 mov     [ebp+var_A4], 0Eh
                    0xC7, 0x85, 0x60, 0xFF, 0xFF, 0xFF, 0x09, 0x00, 0x00, 0x00, // .text:0050D74A                 mov     [ebp+var_A0], 9
                    0xC7, 0x85, 0x64, 0xFF, 0xFF, 0xFF, 0x09, 0x00, 0x00, 0x00, // .text:0050D754                 mov     [ebp+var_9C], 9
                    0xC7, 0x85, 0x68, 0xFF, 0xFF, 0xFF, 0x0A, 0x00, 0x00, 0x00, // .text:0050D75E                 mov     [ebp+var_98], 0Ah
                    0xC7, 0x85, 0x6C, 0xFF, 0xFF, 0xFF, 0x0A, 0x00, 0x00, 0x00, // .text:0050D768                 mov     [ebp+var_94], 0Ah
                    0xC7, 0x85, 0x70, 0xFF, 0xFF, 0xFF, 0x0B, 0x00, 0x00, 0x00, // .text:0050D772                 mov     [ebp+var_90], 0Bh
                    0xC7, 0x85, 0x74, 0xFF, 0xFF, 0xFF, 0x0B, 0x00, 0x00, 0x00, // .text:0050D77C                 mov     [ebp+var_8C], 0Bh
                    0xC7, 0x85, 0x78, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D786                 mov     [ebp+var_88], 0Ch
                    0xC7, 0x85, 0x7C, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, // .text:0050D790                 mov     [ebp+var_84], 0Ch
                    0xC7, 0x45, 0x80, 0x0D, 0x00, 0x00, 0x00,                   // .text:0050D79A                 mov     [ebp+var_80], 0Dh
                    0xC7, 0x45, 0x84, 0x0D, 0x00, 0x00, 0x00,                   // .text:0050D7A1                 mov     [ebp+var_7C], 0Dh
                    0xC7, 0x45, 0x88, 0x08, 0x00, 0x00, 0x00,                   // .text:0050D7A8                 mov     [ebp+var_78], 8
                    0xC7, 0x45, 0x8C, 0x08, 0x00, 0x00, 0x00,                   // .text:0050D7AF                 mov     [ebp+var_74], 8
                    0xC7, 0x45, 0x90, 0x09, 0x00, 0x00, 0x00,                   // .text:0050D7B6                 mov     [ebp+var_70], 9
                    0xC7, 0x45, 0x94, 0x09, 0x00, 0x00, 0x00,                   // .text:0050D7BD                 mov     [ebp+var_6C], 9
                    0xC7, 0x45, 0x98, 0x0A, 0x00, 0x00, 0x00,                   // .text:0050D7C4                 mov     [ebp+var_68], 0Ah
                    0xC7, 0x45, 0x9C, 0x0A, 0x00, 0x00, 0x00,                   // .text:0050D7CB                 mov     [ebp+var_64], 0Ah
                    0xC7, 0x45, 0xA0, 0x0B, 0x00, 0x00, 0x00,                   // .text:0050D7D2                 mov     [ebp+var_60], 0Bh
                    0xC7, 0x45, 0xA4, 0x0B, 0x00, 0x00, 0x00,                   // .text:0050D7D9                 mov     [ebp+var_5C], 0Bh
                    0xC7, 0x45, 0xA8, 0x0C, 0x00, 0x00, 0x00,                   // .text:0050D7E0                 mov     [ebp+var_58], 0Ch
                    0xC7, 0x45, 0xAC, 0x0C, 0x00, 0x00, 0x00,                   // .text:0050D7E7                 mov     [ebp+var_54], 0Ch
                    0xC7, 0x45, 0xB0, 0x07, 0x00, 0x00, 0x00,                   // .text:0050D7EE                 mov     [ebp+var_50], 7
                    0xC7, 0x45, 0xB4, 0x07, 0x00, 0x00, 0x00,                   // .text:0050D7F5                 mov     [ebp+var_4C], 7
                    0xC7, 0x45, 0xB8, 0x08, 0x00, 0x00, 0x00,                   // .text:0050D7FC                 mov     [ebp+var_48], 8
                    0xC7, 0x45, 0xBC, 0x08, 0x00, 0x00, 0x00,                   // .text:0050D803                 mov     [ebp+var_44], 8
                    0xC7, 0x45, 0xC0, 0x09, 0x00, 0x00, 0x00,                   // .text:0050D80A                 mov     [ebp+var_40], 9
                    0xC7, 0x45, 0xC4, 0x09, 0x00, 0x00, 0x00,                   // .text:0050D811                 mov     [ebp+var_3C], 9
                    0xC7, 0x45, 0xC8, 0x0A, 0x00, 0x00, 0x00,                   // .text:0050D818                 mov     [ebp+var_38], 0Ah
                    0xC7, 0x45, 0xCC, 0x0A, 0x00, 0x00, 0x00,                   // .text:0050D81F                 mov     [ebp+var_34], 0Ah
                    0xC7, 0x45, 0xD0, 0x0B, 0x00, 0x00, 0x00,                   // .text:0050D826                 mov     [ebp+var_30], 0Bh
                    0xC7, 0x45, 0xD4, 0x0B, 0x00, 0x00, 0x00,                   // .text:0050D82D                 mov     [ebp+var_2C], 0Bh
                    0xC7, 0x45, 0xD8, 0x06, 0x00, 0x00, 0x00,                   // .text:0050D834                 mov     [ebp+var_28], 6
                    0xC7, 0x45, 0xDC, 0x06, 0x00, 0x00, 0x00,                   // .text:0050D83B                 mov     [ebp+var_24], 6
                    0xC7, 0x45, 0xE0, 0x07, 0x00, 0x00, 0x00,                   // .text:0050D842                 mov     [ebp+var_20], 7
                    0xC7, 0x45, 0xE4, 0x07, 0x00, 0x00, 0x00,                   // .text:0050D849                 mov     [ebp+var_1C], 7
                    0xC7, 0x45, 0xE8, 0x08, 0x00, 0x00, 0x00,                   // .text:0050D850                 mov     [ebp+var_18], 8
                    0xC7, 0x45, 0xEC, 0x08, 0x00, 0x00, 0x00,                   // .text:0050D857                 mov     [ebp+var_14], 8
                    0xC7, 0x45, 0xF0, 0x09, 0x00, 0x00, 0x00,                   // .text:0050D85E                 mov     [ebp+var_10], 9
                    0xC7, 0x45, 0xF4, 0x09, 0x00, 0x00, 0x00,                   // .text:0050D865                 mov     [ebp+var_C], 9
                    0xC7, 0x45, 0xF8, 0x0A, 0x00, 0x00, 0x00,                   // .text:0050D86C                 mov     [ebp+var_8], 0Ah
                    0xC7, 0x45, 0xFC, 0x0A, 0x00, 0x00, 0x00,                   // .text:0050D873                 mov     [ebp+var_4], 0Ah
                    0xC7, 0x85, 0x14, 0xFE, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00, // .text:0050D87A                 mov     [ebp+var_1EC], 1
                    0xE9, 0x06, 0x00, 0x00, 0x00,                               // .text:0050D884                 jmp     loc_50D88F
                                                                                // .text:0050D889 ; ---------------------------------------------------------------------------
                                                                                // .text:0050D889 
                                                                                // .text:0050D889 loc_50D889:                             ; CODE XREF: sub_50D41E+4A9j
                                                                                // .text:0050D889                                         ; sub_50D41E+5CAj
                    0xFF, 0x85, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D889                 inc     [ebp+var_1EC]
                                                                                // .text:0050D88F 
                                                                                // .text:0050D88F loc_50D88F:                             ; CODE XREF: sub_50D41E+466j
                    0x83, 0xBD, 0x14, 0xFE, 0xFF, 0xFF, 0x0B,                   // .text:0050D88F                 cmp     [ebp+var_1EC], 0Bh
                    0x0F, 0x8F, 0x51, 0x01, 0x00, 0x00,                         // .text:0050D896                 jg      loc_50D9ED
                    0x8B, 0x85, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D89C                 mov     eax, [ebp+var_1EC]
                    0x8B, 0xC8,                                                 // .text:0050D8A2                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                           // .text:0050D8A4                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0xC0,                                           // .text:0050D8A7                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x41,                                           // .text:0050D8AA                 lea     eax, [ecx+eax*2]
                    0x8D, 0x04, 0x40,                                           // .text:0050D8AD                 lea     eax, [eax+eax*2]
                    0xC1, 0xE0, 0x04,                                           // .text:0050D8B0                 shl     eax, 4
                    0x66, 0x8B, 0x80, 0xD8, 0x39, 0x20, 0x01,                   // .text:0050D8B3                 mov     ax, ds:word_12039D8[eax]
                    0x25, 0xFF, 0xFF, 0x00, 0x00,                               // .text:0050D8BA                 and     eax, 0FFFFh
                    0x85, 0xC0,                                                 // .text:0050D8BF                 test    eax, eax
                    0x0F, 0x84, 0x05, 0x00, 0x00, 0x00,                         // .text:0050D8C1                 jz      loc_50D8CC
                    0xE9, 0xBD, 0xFF, 0xFF, 0xFF,                               // .text:0050D8C7                 jmp     loc_50D889
                                                                                // .text:0050D8CC ; ---------------------------------------------------------------------------
                                                                                // .text:0050D8CC 
                                                                                // .text:0050D8CC loc_50D8CC:                             ; CODE XREF: sub_50D41E+4A3j
                    0xA1, 0xAC, 0x60, 0x5F, 0x01,                               // .text:0050D8CC                 mov     eax, dword_15F60AC
                    0x50,                                                       // .text:0050D8D1                 push    eax
                    0x8B, 0x85, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D8D2                 mov     eax, [ebp+var_1EC]
                    0x50,                                                       // .text:0050D8D8                 push    eax
                    0xE8, 0xD9, 0x8C, 0xF7, 0xFF,                               // .text:0050D8D9                 call    sub_4865B7
                    0x83, 0xC4, 0x08,                                           // .text:0050D8DE                 add     esp, 8
                    0x89, 0x85, 0x1C, 0xFE, 0xFF, 0xFF,                         // .text:0050D8E1                 mov     [ebp+var_1E4], eax
                    0x83, 0xBD, 0x1C, 0xFE, 0xFF, 0xFF, 0x00,                   // .text:0050D8E7                 cmp     [ebp+var_1E4], 0
                    0x0F, 0x85, 0x0F, 0x00, 0x00, 0x00,                         // .text:0050D8EE                 jnz     loc_50D903
                    0xC7, 0x85, 0x10, 0xFE, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, // .text:0050D8F4                 mov     [ebp+var_1F0], 0
                    0xE9, 0x16, 0x00, 0x00, 0x00,                               // .text:0050D8FE                 jmp     loc_50D919
                                                                                // .text:0050D903 ; ---------------------------------------------------------------------------
                                                                                // .text:0050D903 
                                                                                // .text:0050D903 loc_50D903:                             ; CODE XREF: sub_50D41E+4D0j
                    0x8B, 0x85, 0x1C, 0xFE, 0xFF, 0xFF,                         // .text:0050D903                 mov     eax, [ebp+var_1E4]
                    0x8D, 0x04, 0x85, 0xFC, 0xFF, 0xFF, 0xFF,                   // .text:0050D909                 lea     eax, ds:0FFFFFFFCh[eax*4]
                    0x8D, 0x04, 0x80,                                           // .text:0050D910                 lea     eax, [eax+eax*4]
                    0x89, 0x85, 0x10, 0xFE, 0xFF, 0xFF,                         // .text:0050D913                 mov     [ebp+var_1F0], eax
                                                                                // .text:0050D919 
                                                                                // .text:0050D919 loc_50D919:                             ; CODE XREF: sub_50D41E+4E0j
                    0x6A, 0x64,                                                 // .text:0050D919                 push    64h
                    0xE8, 0x3A, 0xB1, 0xF8, 0xFF,                               // .text:0050D91B                 call    sub_498A5A
                    0x83, 0xC4, 0x04,                                           // .text:0050D920                 add     esp, 4
                    0x89, 0x85, 0x18, 0xFE, 0xFF, 0xFF,                         // .text:0050D923                 mov     [ebp+var_1E8], eax
                    0x8B, 0x85, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D929                 mov     eax, [ebp+var_1EC]
                    0x8B, 0xC8,                                                 // .text:0050D92F                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                           // .text:0050D931                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0xC0,                                           // .text:0050D934                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x41,                                           // .text:0050D937                 lea     eax, [ecx+eax*2]
                    0x8D, 0x04, 0x40,                                           // .text:0050D93A                 lea     eax, [eax+eax*2]
                    0xC1, 0xE0, 0x04,                                           // .text:0050D93D                 shl     eax, 4
                    0x8B, 0x88, 0x94, 0x25, 0x20, 0x01,                         // .text:0050D940                 mov     ecx, ds:dword_1202594[eax]
                    0x8D, 0x0C, 0x89,                                           // .text:0050D946                 lea     ecx, [ecx+ecx*4]
                    0xBB, 0x0A, 0x00, 0x00, 0x00,                               // .text:0050D949                 mov     ebx, 0Ah
                    0x8B, 0x85, 0x18, 0xFE, 0xFF, 0xFF,                         // .text:0050D94E                 mov     eax, [ebp+var_1E8]
                    0x99,                                                       // .text:0050D954                 cdq
                    0xF7, 0xFB,                                                 // .text:0050D955                 idiv    ebx
                    0xC1, 0xE0, 0x02,                                           // .text:0050D957                 shl     eax, 2
                    0x8D, 0x0C, 0xC8,                                           // .text:0050D95A                 lea     ecx, [eax+ecx*8]
                    0x8B, 0x84, 0x0D, 0x20, 0xFE, 0xFF, 0xFF,                   // .text:0050D95D                 mov     eax, [ebp+ecx+var_1E0]
                    0x01, 0x85, 0x10, 0xFE, 0xFF, 0xFF,                         // .text:0050D964                 add     [ebp+var_1F0], eax
                    0x8B, 0x85, 0x10, 0xFE, 0xFF, 0xFF,                         // .text:0050D96A                 mov     eax, [ebp+var_1F0]
                    0x8B, 0x8D, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D970                 mov     ecx, [ebp+var_1EC]
                    0x8B, 0xD1,                                                 // .text:0050D976                 mov     edx, ecx
                    0xC1, 0xE1, 0x08,                                           // .text:0050D978                 shl     ecx, 8
                    0x2B, 0xCA,                                                 // .text:0050D97B                 sub     ecx, edx
                    0x8D, 0x0C, 0x49,                                           // .text:0050D97D                 lea     ecx, [ecx+ecx*2]
                    0x2B, 0xCA,                                                 // .text:0050D980                 sub     ecx, edx
                    0x89, 0x81, 0x28, 0xF5, 0x8C, 0x00,                         // .text:0050D982                 mov     ds:dword_8CF528[ecx], eax
                    0x8B, 0x85, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D988                 mov     eax, [ebp+var_1EC]
                    0x8B, 0xC8,                                                 // .text:0050D98E                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                                           // .text:0050D990                 shl     eax, 8
                    0x2B, 0xC1,                                                 // .text:0050D993                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                                           // .text:0050D995                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                                 // .text:0050D998                 sub     eax, ecx
                    0x8B, 0x80, 0x28, 0xF5, 0x8C, 0x00,                         // .text:0050D99A                 mov     eax, ds:dword_8CF528[eax]
                    0x8B, 0x8D, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D9A0                 mov     ecx, [ebp+var_1EC]
                    0x8B, 0xD1,                                                 // .text:0050D9A6                 mov     edx, ecx
                    0xC1, 0xE1, 0x08,                                           // .text:0050D9A8                 shl     ecx, 8
                    0x2B, 0xCA,                                                 // .text:0050D9AB                 sub     ecx, edx
                    0x8D, 0x0C, 0x49,                                           // .text:0050D9AD                 lea     ecx, [ecx+ecx*2]
                    0x2B, 0xCA,                                                 // .text:0050D9B0                 sub     ecx, edx
                    0x89, 0x81, 0x30, 0xF5, 0x8C, 0x00,                         // .text:0050D9B2                 mov     ds:dword_8CF530[ecx], eax
                    0x8B, 0x85, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D9B8                 mov     eax, [ebp+var_1EC]
                    0x8B, 0xC8,                                                 // .text:0050D9BE                 mov     ecx, eax
                    0xC1, 0xE0, 0x08,                                           // .text:0050D9C0                 shl     eax, 8
                    0x2B, 0xC1,                                                 // .text:0050D9C3                 sub     eax, ecx
                    0x8D, 0x04, 0x40,                                           // .text:0050D9C5                 lea     eax, [eax+eax*2]
                    0x2B, 0xC1,                                                 // .text:0050D9C8                 sub     eax, ecx
                    0x8B, 0x80, 0x30, 0xF5, 0x8C, 0x00,                         // .text:0050D9CA                 mov     eax, ds:dword_8CF530[eax]
                    0x8B, 0x8D, 0x14, 0xFE, 0xFF, 0xFF,                         // .text:0050D9D0                 mov     ecx, [ebp+var_1EC]
                    0x8B, 0xD1,                                                 // .text:0050D9D6                 mov     edx, ecx
                    0xC1, 0xE1, 0x08,                                           // .text:0050D9D8                 shl     ecx, 8
                    0x2B, 0xCA,                                                 // .text:0050D9DB                 sub     ecx, edx
                    0x8D, 0x0C, 0x49,                                           // .text:0050D9DD                 lea     ecx, [ecx+ecx*2]
                    0x2B, 0xCA,                                                 // .text:0050D9E0                 sub     ecx, edx
                    0x89, 0x81, 0x2C, 0xF5, 0x8C, 0x00,                         // .text:0050D9E2                 mov     ds:dword_8CF52C[ecx], eax
                    0xE9, 0x9C, 0xFE, 0xFF, 0xFF,                               // .text:0050D9E8                 jmp     loc_50D889
                                                                                // .text:0050D9ED ; ---------------------------------------------------------------------------
                                                                                // .text:0050D9ED 
                                                                                // .text:0050D9ED loc_50D9ED:                             ; CODE XREF: sub_50D41E+478j
                    0x5F,                                                       // .text:0050D9ED                 pop     edi
                    0x5E,                                                       // .text:0050D9EE                 pop     esi
                    0x5B,                                                       // .text:0050D9EF                 pop     ebx
                    0xC9,                                                       // .text:0050D9F0                 leave
                    0xC3                                                        // .text:0050D9F1                 retn
                }
            });
            #endregion

            #region Task B Modified
            ModifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(CarDesignCalculationUpdate).Name,
                VirtualPosition = 0x0050D41E,
                Instructions = new byte[]
                {
                                                                // .text:0050D41E var_10          = dword ptr -10h
                                                                // .text:0050D41E var_C           = dword ptr -0Ch
                                                                // .text:0050D41E var_8           = dword ptr -8
                                                                // .text:0050D41E var_4           = dword ptr -4
                                                                // .text:0050D41E
                    0x55,                                       // .text:0050D41E                 push    ebp
                    0x8B, 0xEC,                                 // .text:0050D41F                 mov     ebp, esp
                    0x83, 0xEC, 0x10,                           // .text:0050D421                 sub     esp, 10h
                    0x53,                                       // .text:0050D424                 push    ebx
                    0x56,                                       // .text:0050D425                 push    esi
                    0x57,                                       // .text:0050D426                 push    edi

                                                                // ; initialise loop
                    0xC7, 0x45, 0xF8, 0x01, 0x00, 0x00, 0x00,   // .text:0050D427                 mov     [ebp+var_8], 1
                    0xEB, 0x09,                                 // .text:0050D42E                 jmp     short loc_50D439
                                                                // .text:0050D430 ; ---------------------------------------------------------------------------
                                                                // .text:0050D430

                                                                // ; increment loop
                                                                // .text:0050D430 loc_50D430:                             ; CODE XREF: sub_50D41E+3Bj
                                                                // .text:0050D430                                         ; sub_50D41E+118j
                    0x8B, 0x45, 0xF8,                           // .text:0050D430                 mov     eax, [ebp+var_8]
                    0x83, 0xC0, 0x01,                           // .text:0050D433                 add     eax, 1
                    0x89, 0x45, 0xF8,                           // .text:0050D436                 mov     [ebp+var_8], eax
                                                                // .text:0050D439

                                                                // ; for loop
                                                                // .text:0050D439 loc_50D439:                             ; CODE XREF: sub_50D41E+10j
                    0x83, 0x7D, 0xF8, 0x0B,                     // .text:0050D439                 cmp     [ebp+var_8], 0Bh  ; number of teams
                    0x0F, 0x8F, 0xF8, 0x00, 0x00, 0x00,         // .text:0050D43D                 jg      loc_50D53B        ; loop termination
                    0x8B, 0x4D, 0xF8,                           // .text:0050D443                 mov     ecx, [ebp+var_8]
                    0x69, 0xC9, 0x90, 0x1E, 0x00, 0x00,         // .text:0050D446                 imul    ecx, 1E90h
                    0x33, 0xD2,                                 // .text:0050D44C                 xor     edx, edx
                    0x66, 0x8B, 0x91, 0xD8, 0x39, 0x20, 0x01,   // .text:0050D44E                 mov     dx, ds:word_12039D8[ecx]
                    0x85, 0xD2,                                 // .text:0050D455                 test    edx, edx          ; if players team
                    0x74, 0x02,                                 // .text:0050D457                 jz      short loc_50D45B  ; else skip next line
                    0xEB, 0xD5,                                 // .text:0050D459                 jmp     short loc_50D430  ; top of loop
                                                                // .text:0050D45B ; ---------------------------------------------------------------------------
                                                                // .text:0050D45B

                                                                // ; get designer skill
                                                                // .text:0050D45B loc_50D45B:                             ; CODE XREF: sub_50D41E+39j
                    0xA1, 0xA8, 0x60, 0x5F, 0x01,               // .text:0050D45B                 mov     eax, dword_15F60A8
                    0x50,                                       // .text:0050D460                 push    eax
                    0x8B, 0x4D, 0xF8,                           // .text:0050D461                 mov     ecx, [ebp+var_8]
                    0x51,                                       // .text:0050D464                 push    ecx
                    0xE8, 0x4D, 0x91, 0xF7, 0xFF,               // .text:0050D465                 call    sub_4865B7
                    0x83, 0xC4, 0x08,                           // .text:0050D46A                 add     esp, 8
                    0x89, 0x45, 0xF0,                           // .text:0050D46D                 mov     [ebp+var_10], eax
                    0x83, 0x7D, 0xF0, 0x00,                     // .text:0050D470                 cmp     [ebp+var_10], 0   ; if 0
                    0x75, 0x07,                                 // .text:0050D474                 jnz     short loc_50D47D  ; else skip next line
                    0xC7, 0x45, 0xF0, 0x01, 0x00, 0x00, 0x00,   // .text:0050D476                 mov     [ebp+var_10], 1   ; make 1
                                                                // .text:0050D47D

                                                                // ; multiply by factor
                                                                // .text:0050D47D loc_50D47D:                             ; CODE XREF: sub_50D41E+56j
                    0x8B, 0x55, 0xF0,                           // .text:0050D47D                 mov     edx, [ebp+var_10]
                    0x83, 0xEA, 0x01,                           // .text:0050D480                 sub     edx, 1
                    0x6B, 0xD2, 0x05,                           // .text:0050D483                 imul    edx, 5            ; factor
                    0x89, 0x55, 0xFC,                           // .text:0050D486                 mov     [ebp+var_4], edx

                                                                // ; get engineer skill
                    0xA1, 0xAC, 0x60, 0x5F, 0x01,               // .text:0050D489                 mov     eax, dword_15F60AC
                    0x50,                                       // .text:0050D48E                 push    eax
                    0x8B, 0x4D, 0xF8,                           // .text:0050D48F                 mov     ecx, [ebp+var_8]
                    0x51,                                       // .text:0050D492                 push    ecx
                    0xE8, 0x1F, 0x91, 0xF7, 0xFF,               // .text:0050D493                 call    sub_4865B7
                    0x83, 0xC4, 0x08,                           // .text:0050D498                 add     esp, 8
                    0x89, 0x45, 0xF0,                           // .text:0050D49B                 mov     [ebp+var_10], eax
                    0x83, 0x7D, 0xF0, 0x00,                     // .text:0050D49E                 cmp     [ebp+var_10], 0   ; if 0
                    0x75, 0x07,                                 // .text:0050D4A2                 jnz     short loc_50D4AB  ; else skip next line
                    0xC7, 0x45, 0xF0, 0x01, 0x00, 0x00, 0x00,   // .text:0050D4A4                 mov     [ebp+var_10], 1   ; make 1
                                                                // .text:0050D4AB

                                                                // ; multiply by factor
                                                                // .text:0050D4AB loc_50D4AB:                             ; CODE XREF: sub_50D41E+84j
                    0x8B, 0x55, 0xF0,                           // .text:0050D4AB                 mov     edx, [ebp+var_10]
                    0x83, 0xEA, 0x01,                           // .text:0050D4AE                 sub     edx, 1
                    0x6B, 0xD2, 0x0F,                           // .text:0050D4B1                 imul    edx, 0Fh          ; factor
                    0x03, 0x55, 0xFC,                           // .text:0050D4B4                 add     edx, [ebp+var_4]  ; add to handling
                    0x89, 0x55, 0xFC,                           // .text:0050D4B7                 mov     [ebp+var_4], edx  ; store new handling

                                                                // ; get random value
                                                                // ; rand() % 21 = 0-20
                    0xE8, 0xCF, 0x03, 0x17, 0x00,               // .text:0050D4BA                 call    sub_67D88E        ; random number in eax
                    0x99,                                       // .text:0050D4BF                 cdq
                    0xB9, 0x15, 0x00, 0x00, 0x00,               // .text:0050D4C0                 mov     ecx, 15h          ; prepare to divide eax by ecx
                    0xF7, 0xF9,                                 // .text:0050D4C5                 idiv    ecx               ; quotient in eax, remainder in edx
                    0x89, 0x55, 0xF4,                           // .text:0050D4C7                 mov     [ebp+var_C], edx

                                                                // ; calc handling impact
                                                                // ; 31 - ChampionshipPosition1To11 - Random0To20 = 0-30
                    0x8B, 0x55, 0xF4,                           // .text:0050D4CA                 mov     edx, [ebp+var_C]
                    0xB8, 0x1F, 0x00, 0x00, 0x00,               // .text:0050D4CD                 mov     eax, 1Fh          ; 31
                    0x2B, 0xC2,                                 // .text:0050D4D2                 sub     eax, edx          ; subtract Random0To20
                    0x8B, 0x4D, 0xF8,                           // .text:0050D4D4                 mov     ecx, [ebp+var_8]
                    0x69, 0xC9, 0x90, 0x1E, 0x00, 0x00,         // .text:0050D4D7                 imul    ecx, 1E90h
                    0x8B, 0x91, 0x94, 0x25, 0x20, 0x01,         // .text:0050D4DD                 mov     edx, ds:dword_1202594[ecx]
                    0x2B, 0xC2,                                 // .text:0050D4E3                 sub     eax, edx          ; sub ChampionshipPosition1To11
                    0x89, 0x45, 0xF4,                           // .text:0050D4E5                 mov     [ebp+var_C], eax

                                                                // ; add handling impact to handling
                    0x8B, 0x55, 0xFC,                           // .text:0050D4E8                 mov     edx, [ebp+var_4]
                    0x8B, 0x45, 0xF4,                           // .text:0050D4EB                 mov     eax, [ebp+var_C]
                    0x03, 0xD0,                                 // .text:0050D4EE                 add     edx, eax
                    0x89, 0x55, 0xFC,                           // .text:0050D4F0                 mov     [ebp+var_4], edx

                                                                // ; if handling is less than or equal to zero, make zero
                    0x83, 0x7D, 0xFC, 0x00,                     // .text:0050D4F3                 cmp     [ebp+var_4], 0    ; if 0 or less
                    0x7F, 0x07,                                 // .text:0050D4F7                 jg      short loc_50D500  ; else skip next line
                    0xC7, 0x45, 0xFC, 0x00, 0x00, 0x00, 0x00,   // .text:0050D4F9                 mov     [ebp+var_4], 0    ; make 0
                                                                // .text:0050D500

                                                                // ; Level 1 Designer & Level 1 Engineer & 11th place
                                                                // ; = Min of 0% and Max of 20%
                                                                // ; Level 5 Designer & Level 5 Engineer & 1st place
                                                                // ; = Min of 90% and Max of 110%

                                                                // ; populate handling variables
                                                                // .text:0050D500 loc_50D500:                             ; CODE XREF: sub_50D41E+D9j
                    0x8B, 0x45, 0xF8,                           // .text:0050D500                 mov     eax, [ebp+var_8]
                    0x69, 0xC0, 0xFC, 0x02, 0x00, 0x00,         // .text:0050D503                 imul    eax, 2FCh
                    0x8B, 0x4D, 0xFC,                           // .text:0050D509                 mov     ecx, [ebp+var_4]
                    0x89, 0x88, 0x28, 0xF5, 0x8C, 0x00,         // .text:0050D50C                 mov     ds:dword_8CF528[eax], ecx
                    0x8B, 0x55, 0xF8,                           // .text:0050D512                 mov     edx, [ebp+var_8]
                    0x69, 0xD2, 0xFC, 0x02, 0x00, 0x00,         // .text:0050D515                 imul    edx, 2FCh
                    0x8B, 0x45, 0xFC,                           // .text:0050D51B                 mov     eax, [ebp+var_4]
                    0x89, 0x82, 0x30, 0xF5, 0x8C, 0x00,         // .text:0050D51E                 mov     ds:dword_8CF530[edx], eax
                    0x8B, 0x4D, 0xF8,                           // .text:0050D524                 mov     ecx, [ebp+var_8]
                    0x69, 0xC9, 0xFC, 0x02, 0x00, 0x00,         // .text:0050D527                 imul    ecx, 2FCh
                    0x8B, 0x55, 0xFC,                           // .text:0050D52D                 mov     edx, [ebp+var_4]
                    0x89, 0x91, 0x2C, 0xF5, 0x8C, 0x00,         // .text:0050D530                 mov     ds:dword_8CF52C[ecx], edx

                                                                // ; top of loop
                    0xE9, 0xF5, 0xFE, 0xFF, 0xFF,               // .text:0050D536                 jmp     loc_50D430
                                                                // .text:0050D53B ; ---------------------------------------------------------------------------
                                                                // .text:0050D53B

                                                                // ; end sub
                                                                // .text:0050D53B loc_50D53B:                             ; CODE XREF: sub_50D41E+1Fj
                    0x5F,                                       // .text:0050D53B                 pop     edi
                    0x5E,                                       // .text:0050D53C                 pop     esi
                    0x5B,                                       // .text:0050D53D                 pop     ebx
                    0xC9,                                       // .text:0050D53E                 leave
                    0xC3,                                       // .text:0050D53F                 retn
                                                                // .text:0050D53F sub_50D41E      endp
                                                                // .text:0050D53F
                                                                // .text:0050D53F ; ---------------------------------------------------------------------------
                    0xCC,                                       // .text:0050D540                 db  CCh ; É
                    0xCC,                                       // .text:0050D541                 db  CCh ; É
                    0xCC,                                       // .text:0050D542                 db  CCh ; É
                    0xCC,                                       // .text:0050D543                 db  CCh ; É
                    0xCC,                                       // .text:0050D544                 db  CCh ; É
                    0xCC,                                       // .text:0050D545                 db  CCh ; É
                    0xCC,                                       // .text:0050D546                 db  CCh ; É
                    0xCC,                                       // .text:0050D547                 db  CCh ; É
                    0xCC,                                       // .text:0050D548                 db  CCh ; É
                    0xCC,                                       // .text:0050D549                 db  CCh ; É
                    0xCC,                                       // .text:0050D54A                 db  CCh ; É
                    0xCC,                                       // .text:0050D54B                 db  CCh ; É
                    0xCC,                                       // .text:0050D54C                 db  CCh ; É
                    0xCC,                                       // .text:0050D54D                 db  CCh ; É
                    0xCC,                                       // .text:0050D54E                 db  CCh ; É
                    0xCC,                                       // .text:0050D54F                 db  CCh ; É
                    0xCC,                                       // .text:0050D550                 db  CCh ; É
                    0xCC,                                       // .text:0050D551                 db  CCh ; É
                    0xCC,                                       // .text:0050D552                 db  CCh ; É
                    0xCC,                                       // .text:0050D553                 db  CCh ; É
                    0xCC,                                       // .text:0050D554                 db  CCh ; É
                    0xCC,                                       // .text:0050D555                 db  CCh ; É
                    0xCC,                                       // .text:0050D556                 db  CCh ; É
                    0xCC,                                       // .text:0050D557                 db  CCh ; É
                    0xCC,                                       // .text:0050D558                 db  CCh ; É
                    0xCC,                                       // .text:0050D559                 db  CCh ; É
                    0xCC,                                       // .text:0050D55A                 db  CCh ; É
                    0xCC,                                       // .text:0050D55B                 db  CCh ; É
                    0xCC,                                       // .text:0050D55C                 db  CCh ; É
                    0xCC,                                       // .text:0050D55D                 db  CCh ; É
                    0xCC,                                       // .text:0050D55E                 db  CCh ; É
                    0xCC,                                       // .text:0050D55F                 db  CCh ; É
                    0xCC,                                       // .text:0050D560                 db  CCh ; É
                    0xCC,                                       // .text:0050D561                 db  CCh ; É
                    0xCC,                                       // .text:0050D562                 db  CCh ; É
                    0xCC,                                       // .text:0050D563                 db  CCh ; É
                    0xCC,                                       // .text:0050D564                 db  CCh ; É
                    0xCC,                                       // .text:0050D565                 db  CCh ; É
                    0xCC,                                       // .text:0050D566                 db  CCh ; É
                    0xCC,                                       // .text:0050D567                 db  CCh ; É
                    0xCC,                                       // .text:0050D568                 db  CCh ; É
                    0xCC,                                       // .text:0050D569                 db  CCh ; É
                    0xCC,                                       // .text:0050D56A                 db  CCh ; É
                    0xCC,                                       // .text:0050D56B                 db  CCh ; É
                    0xCC,                                       // .text:0050D56C                 db  CCh ; É
                    0xCC,                                       // .text:0050D56D                 db  CCh ; É
                    0xCC,                                       // .text:0050D56E                 db  CCh ; É
                    0xCC,                                       // .text:0050D56F                 db  CCh ; É
                    0xCC,                                       // .text:0050D570                 db  CCh ; É
                    0xCC,                                       // .text:0050D571                 db  CCh ; É
                    0xCC,                                       // .text:0050D572                 db  CCh ; É
                    0xCC,                                       // .text:0050D573                 db  CCh ; É
                    0xCC,                                       // .text:0050D574                 db  CCh ; É
                    0xCC,                                       // .text:0050D575                 db  CCh ; É
                    0xCC,                                       // .text:0050D576                 db  CCh ; É
                    0xCC,                                       // .text:0050D577                 db  CCh ; É
                    0xCC,                                       // .text:0050D578                 db  CCh ; É
                    0xCC,                                       // .text:0050D579                 db  CCh ; É
                    0xCC,                                       // .text:0050D57A                 db  CCh ; É
                    0xCC,                                       // .text:0050D57B                 db  CCh ; É
                    0xCC,                                       // .text:0050D57C                 db  CCh ; É
                    0xCC,                                       // .text:0050D57D                 db  CCh ; É
                    0xCC,                                       // .text:0050D57E                 db  CCh ; É
                    0xCC,                                       // .text:0050D57F                 db  CCh ; É
                    0xCC,                                       // .text:0050D580                 db  CCh ; É
                    0xCC,                                       // .text:0050D581                 db  CCh ; É
                    0xCC,                                       // .text:0050D582                 db  CCh ; É
                    0xCC,                                       // .text:0050D583                 db  CCh ; É
                    0xCC,                                       // .text:0050D584                 db  CCh ; É
                    0xCC,                                       // .text:0050D585                 db  CCh ; É
                    0xCC,                                       // .text:0050D586                 db  CCh ; É
                    0xCC,                                       // .text:0050D587                 db  CCh ; É
                    0xCC,                                       // .text:0050D588                 db  CCh ; É
                    0xCC,                                       // .text:0050D589                 db  CCh ; É
                    0xCC,                                       // .text:0050D58A                 db  CCh ; É
                    0xCC,                                       // .text:0050D58B                 db  CCh ; É
                    0xCC,                                       // .text:0050D58C                 db  CCh ; É
                    0xCC,                                       // .text:0050D58D                 db  CCh ; É
                    0xCC,                                       // .text:0050D58E                 db  CCh ; É
                    0xCC,                                       // .text:0050D58F                 db  CCh ; É
                    0xCC,                                       // .text:0050D590                 db  CCh ; É
                    0xCC,                                       // .text:0050D591                 db  CCh ; É
                    0xCC,                                       // .text:0050D592                 db  CCh ; É
                    0xCC,                                       // .text:0050D593                 db  CCh ; É
                    0xCC,                                       // .text:0050D594                 db  CCh ; É
                    0xCC,                                       // .text:0050D595                 db  CCh ; É
                    0xCC,                                       // .text:0050D596                 db  CCh ; É
                    0xCC,                                       // .text:0050D597                 db  CCh ; É
                    0xCC,                                       // .text:0050D598                 db  CCh ; É
                    0xCC,                                       // .text:0050D599                 db  CCh ; É
                    0xCC,                                       // .text:0050D59A                 db  CCh ; É
                    0xCC,                                       // .text:0050D59B                 db  CCh ; É
                    0xCC,                                       // .text:0050D59C                 db  CCh ; É
                    0xCC,                                       // .text:0050D59D                 db  CCh ; É
                    0xCC,                                       // .text:0050D59E                 db  CCh ; É
                    0xCC,                                       // .text:0050D59F                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A0                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A1                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A2                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A3                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A4                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A5                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A6                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A7                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A8                 db  CCh ; É
                    0xCC,                                       // .text:0050D5A9                 db  CCh ; É
                    0xCC,                                       // .text:0050D5AA                 db  CCh ; É
                    0xCC,                                       // .text:0050D5AB                 db  CCh ; É
                    0xCC,                                       // .text:0050D5AC                 db  CCh ; É
                    0xCC,                                       // .text:0050D5AD                 db  CCh ; É
                    0xCC,                                       // .text:0050D5AE                 db  CCh ; É
                    0xCC,                                       // .text:0050D5AF                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B0                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B1                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B2                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B3                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B4                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B5                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B6                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B7                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B8                 db  CCh ; É
                    0xCC,                                       // .text:0050D5B9                 db  CCh ; É
                    0xCC,                                       // .text:0050D5BA                 db  CCh ; É
                    0xCC,                                       // .text:0050D5BB                 db  CCh ; É
                    0xCC,                                       // .text:0050D5BC                 db  CCh ; É
                    0xCC,                                       // .text:0050D5BD                 db  CCh ; É
                    0xCC,                                       // .text:0050D5BE                 db  CCh ; É
                    0xCC,                                       // .text:0050D5BF                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C0                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C1                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C2                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C3                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C4                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C5                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C6                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C7                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C8                 db  CCh ; É
                    0xCC,                                       // .text:0050D5C9                 db  CCh ; É
                    0xCC,                                       // .text:0050D5CA                 db  CCh ; É
                    0xCC,                                       // .text:0050D5CB                 db  CCh ; É
                    0xCC,                                       // .text:0050D5CC                 db  CCh ; É
                    0xCC,                                       // .text:0050D5CD                 db  CCh ; É
                    0xCC,                                       // .text:0050D5CE                 db  CCh ; É
                    0xCC,                                       // .text:0050D5CF                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D0                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D1                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D2                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D3                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D4                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D5                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D6                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D7                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D8                 db  CCh ; É
                    0xCC,                                       // .text:0050D5D9                 db  CCh ; É
                    0xCC,                                       // .text:0050D5DA                 db  CCh ; É
                    0xCC,                                       // .text:0050D5DB                 db  CCh ; É
                    0xCC,                                       // .text:0050D5DC                 db  CCh ; É
                    0xCC,                                       // .text:0050D5DD                 db  CCh ; É
                    0xCC,                                       // .text:0050D5DE                 db  CCh ; É
                    0xCC,                                       // .text:0050D5DF                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E0                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E1                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E2                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E3                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E4                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E5                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E6                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E7                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E8                 db  CCh ; É
                    0xCC,                                       // .text:0050D5E9                 db  CCh ; É
                    0xCC,                                       // .text:0050D5EA                 db  CCh ; É
                    0xCC,                                       // .text:0050D5EB                 db  CCh ; É
                    0xCC,                                       // .text:0050D5EC                 db  CCh ; É
                    0xCC,                                       // .text:0050D5ED                 db  CCh ; É
                    0xCC,                                       // .text:0050D5EE                 db  CCh ; É
                    0xCC,                                       // .text:0050D5EF                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F0                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F1                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F2                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F3                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F4                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F5                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F6                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F7                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F8                 db  CCh ; É
                    0xCC,                                       // .text:0050D5F9                 db  CCh ; É
                    0xCC,                                       // .text:0050D5FA                 db  CCh ; É
                    0xCC,                                       // .text:0050D5FB                 db  CCh ; É
                    0xCC,                                       // .text:0050D5FC                 db  CCh ; É
                    0xCC,                                       // .text:0050D5FD                 db  CCh ; É
                    0xCC,                                       // .text:0050D5FE                 db  CCh ; É
                    0xCC,                                       // .text:0050D5FF                 db  CCh ; É
                    0xCC,                                       // .text:0050D600                 db  CCh ; É
                    0xCC,                                       // .text:0050D601                 db  CCh ; É
                    0xCC,                                       // .text:0050D602                 db  CCh ; É
                    0xCC,                                       // .text:0050D603                 db  CCh ; É
                    0xCC,                                       // .text:0050D604                 db  CCh ; É
                    0xCC,                                       // .text:0050D605                 db  CCh ; É
                    0xCC,                                       // .text:0050D606                 db  CCh ; É
                    0xCC,                                       // .text:0050D607                 db  CCh ; É
                    0xCC,                                       // .text:0050D608                 db  CCh ; É
                    0xCC,                                       // .text:0050D609                 db  CCh ; É
                    0xCC,                                       // .text:0050D60A                 db  CCh ; É
                    0xCC,                                       // .text:0050D60B                 db  CCh ; É
                    0xCC,                                       // .text:0050D60C                 db  CCh ; É
                    0xCC,                                       // .text:0050D60D                 db  CCh ; É
                    0xCC,                                       // .text:0050D60E                 db  CCh ; É
                    0xCC,                                       // .text:0050D60F                 db  CCh ; É
                    0xCC,                                       // .text:0050D610                 db  CCh ; É
                    0xCC,                                       // .text:0050D611                 db  CCh ; É
                    0xCC,                                       // .text:0050D612                 db  CCh ; É
                    0xCC,                                       // .text:0050D613                 db  CCh ; É
                    0xCC,                                       // .text:0050D614                 db  CCh ; É
                    0xCC,                                       // .text:0050D615                 db  CCh ; É
                    0xCC,                                       // .text:0050D616                 db  CCh ; É
                    0xCC,                                       // .text:0050D617                 db  CCh ; É
                    0xCC,                                       // .text:0050D618                 db  CCh ; É
                    0xCC,                                       // .text:0050D619                 db  CCh ; É
                    0xCC,                                       // .text:0050D61A                 db  CCh ; É
                    0xCC,                                       // .text:0050D61B                 db  CCh ; É
                    0xCC,                                       // .text:0050D61C                 db  CCh ; É
                    0xCC,                                       // .text:0050D61D                 db  CCh ; É
                    0xCC,                                       // .text:0050D61E                 db  CCh ; É
                    0xCC,                                       // .text:0050D61F                 db  CCh ; É
                    0xCC,                                       // .text:0050D620                 db  CCh ; É
                    0xCC,                                       // .text:0050D621                 db  CCh ; É
                    0xCC,                                       // .text:0050D622                 db  CCh ; É
                    0xCC,                                       // .text:0050D623                 db  CCh ; É
                    0xCC,                                       // .text:0050D624                 db  CCh ; É
                    0xCC,                                       // .text:0050D625                 db  CCh ; É
                    0xCC,                                       // .text:0050D626                 db  CCh ; É
                    0xCC,                                       // .text:0050D627                 db  CCh ; É
                    0xCC,                                       // .text:0050D628                 db  CCh ; É
                    0xCC,                                       // .text:0050D629                 db  CCh ; É
                    0xCC,                                       // .text:0050D62A                 db  CCh ; É
                    0xCC,                                       // .text:0050D62B                 db  CCh ; É
                    0xCC,                                       // .text:0050D62C                 db  CCh ; É
                    0xCC,                                       // .text:0050D62D                 db  CCh ; É
                    0xCC,                                       // .text:0050D62E                 db  CCh ; É
                    0xCC,                                       // .text:0050D62F                 db  CCh ; É
                    0xCC,                                       // .text:0050D630                 db  CCh ; É
                    0xCC,                                       // .text:0050D631                 db  CCh ; É
                    0xCC,                                       // .text:0050D632                 db  CCh ; É
                    0xCC,                                       // .text:0050D633                 db  CCh ; É
                    0xCC,                                       // .text:0050D634                 db  CCh ; É
                    0xCC,                                       // .text:0050D635                 db  CCh ; É
                    0xCC,                                       // .text:0050D636                 db  CCh ; É
                    0xCC,                                       // .text:0050D637                 db  CCh ; É
                    0xCC,                                       // .text:0050D638                 db  CCh ; É
                    0xCC,                                       // .text:0050D639                 db  CCh ; É
                    0xCC,                                       // .text:0050D63A                 db  CCh ; É
                    0xCC,                                       // .text:0050D63B                 db  CCh ; É
                    0xCC,                                       // .text:0050D63C                 db  CCh ; É
                    0xCC,                                       // .text:0050D63D                 db  CCh ; É
                    0xCC,                                       // .text:0050D63E                 db  CCh ; É
                    0xCC,                                       // .text:0050D63F                 db  CCh ; É
                    0xCC,                                       // .text:0050D640                 db  CCh ; É
                    0xCC,                                       // .text:0050D641                 db  CCh ; É
                    0xCC,                                       // .text:0050D642                 db  CCh ; É
                    0xCC,                                       // .text:0050D643                 db  CCh ; É
                    0xCC,                                       // .text:0050D644                 db  CCh ; É
                    0xCC,                                       // .text:0050D645                 db  CCh ; É
                    0xCC,                                       // .text:0050D646                 db  CCh ; É
                    0xCC,                                       // .text:0050D647                 db  CCh ; É
                    0xCC,                                       // .text:0050D648                 db  CCh ; É
                    0xCC,                                       // .text:0050D649                 db  CCh ; É
                    0xCC,                                       // .text:0050D64A                 db  CCh ; É
                    0xCC,                                       // .text:0050D64B                 db  CCh ; É
                    0xCC,                                       // .text:0050D64C                 db  CCh ; É
                    0xCC,                                       // .text:0050D64D                 db  CCh ; É
                    0xCC,                                       // .text:0050D64E                 db  CCh ; É
                    0xCC,                                       // .text:0050D64F                 db  CCh ; É
                    0xCC,                                       // .text:0050D650                 db  CCh ; É
                    0xCC,                                       // .text:0050D651                 db  CCh ; É
                    0xCC,                                       // .text:0050D652                 db  CCh ; É
                    0xCC,                                       // .text:0050D653                 db  CCh ; É
                    0xCC,                                       // .text:0050D654                 db  CCh ; É
                    0xCC,                                       // .text:0050D655                 db  CCh ; É
                    0xCC,                                       // .text:0050D656                 db  CCh ; É
                    0xCC,                                       // .text:0050D657                 db  CCh ; É
                    0xCC,                                       // .text:0050D658                 db  CCh ; É
                    0xCC,                                       // .text:0050D659                 db  CCh ; É
                    0xCC,                                       // .text:0050D65A                 db  CCh ; É
                    0xCC,                                       // .text:0050D65B                 db  CCh ; É
                    0xCC,                                       // .text:0050D65C                 db  CCh ; É
                    0xCC,                                       // .text:0050D65D                 db  CCh ; É
                    0xCC,                                       // .text:0050D65E                 db  CCh ; É
                    0xCC,                                       // .text:0050D65F                 db  CCh ; É
                    0xCC,                                       // .text:0050D660                 db  CCh ; É
                    0xCC,                                       // .text:0050D661                 db  CCh ; É
                    0xCC,                                       // .text:0050D662                 db  CCh ; É
                    0xCC,                                       // .text:0050D663                 db  CCh ; É
                    0xCC,                                       // .text:0050D664                 db  CCh ; É
                    0xCC,                                       // .text:0050D665                 db  CCh ; É
                    0xCC,                                       // .text:0050D666                 db  CCh ; É
                    0xCC,                                       // .text:0050D667                 db  CCh ; É
                    0xCC,                                       // .text:0050D668                 db  CCh ; É
                    0xCC,                                       // .text:0050D669                 db  CCh ; É
                    0xCC,                                       // .text:0050D66A                 db  CCh ; É
                    0xCC,                                       // .text:0050D66B                 db  CCh ; É
                    0xCC,                                       // .text:0050D66C                 db  CCh ; É
                    0xCC,                                       // .text:0050D66D                 db  CCh ; É
                    0xCC,                                       // .text:0050D66E                 db  CCh ; É
                    0xCC,                                       // .text:0050D66F                 db  CCh ; É
                    0xCC,                                       // .text:0050D670                 db  CCh ; É
                    0xCC,                                       // .text:0050D671                 db  CCh ; É
                    0xCC,                                       // .text:0050D672                 db  CCh ; É
                    0xCC,                                       // .text:0050D673                 db  CCh ; É
                    0xCC,                                       // .text:0050D674                 db  CCh ; É
                    0xCC,                                       // .text:0050D675                 db  CCh ; É
                    0xCC,                                       // .text:0050D676                 db  CCh ; É
                    0xCC,                                       // .text:0050D677                 db  CCh ; É
                    0xCC,                                       // .text:0050D678                 db  CCh ; É
                    0xCC,                                       // .text:0050D679                 db  CCh ; É
                    0xCC,                                       // .text:0050D67A                 db  CCh ; É
                    0xCC,                                       // .text:0050D67B                 db  CCh ; É
                    0xCC,                                       // .text:0050D67C                 db  CCh ; É
                    0xCC,                                       // .text:0050D67D                 db  CCh ; É
                    0xCC,                                       // .text:0050D67E                 db  CCh ; É
                    0xCC,                                       // .text:0050D67F                 db  CCh ; É
                    0xCC,                                       // .text:0050D680                 db  CCh ; É
                    0xCC,                                       // .text:0050D681                 db  CCh ; É
                    0xCC,                                       // .text:0050D682                 db  CCh ; É
                    0xCC,                                       // .text:0050D683                 db  CCh ; É
                    0xCC,                                       // .text:0050D684                 db  CCh ; É
                    0xCC,                                       // .text:0050D685                 db  CCh ; É
                    0xCC,                                       // .text:0050D686                 db  CCh ; É
                    0xCC,                                       // .text:0050D687                 db  CCh ; É
                    0xCC,                                       // .text:0050D688                 db  CCh ; É
                    0xCC,                                       // .text:0050D689                 db  CCh ; É
                    0xCC,                                       // .text:0050D68A                 db  CCh ; É
                    0xCC,                                       // .text:0050D68B                 db  CCh ; É
                    0xCC,                                       // .text:0050D68C                 db  CCh ; É
                    0xCC,                                       // .text:0050D68D                 db  CCh ; É
                    0xCC,                                       // .text:0050D68E                 db  CCh ; É
                    0xCC,                                       // .text:0050D68F                 db  CCh ; É
                    0xCC,                                       // .text:0050D690                 db  CCh ; É
                    0xCC,                                       // .text:0050D691                 db  CCh ; É
                    0xCC,                                       // .text:0050D692                 db  CCh ; É
                    0xCC,                                       // .text:0050D693                 db  CCh ; É
                    0xCC,                                       // .text:0050D694                 db  CCh ; É
                    0xCC,                                       // .text:0050D695                 db  CCh ; É
                    0xCC,                                       // .text:0050D696                 db  CCh ; É
                    0xCC,                                       // .text:0050D697                 db  CCh ; É
                    0xCC,                                       // .text:0050D698                 db  CCh ; É
                    0xCC,                                       // .text:0050D699                 db  CCh ; É
                    0xCC,                                       // .text:0050D69A                 db  CCh ; É
                    0xCC,                                       // .text:0050D69B                 db  CCh ; É
                    0xCC,                                       // .text:0050D69C                 db  CCh ; É
                    0xCC,                                       // .text:0050D69D                 db  CCh ; É
                    0xCC,                                       // .text:0050D69E                 db  CCh ; É
                    0xCC,                                       // .text:0050D69F                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A0                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A1                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A2                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A3                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A4                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A5                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A6                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A7                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A8                 db  CCh ; É
                    0xCC,                                       // .text:0050D6A9                 db  CCh ; É
                    0xCC,                                       // .text:0050D6AA                 db  CCh ; É
                    0xCC,                                       // .text:0050D6AB                 db  CCh ; É
                    0xCC,                                       // .text:0050D6AC                 db  CCh ; É
                    0xCC,                                       // .text:0050D6AD                 db  CCh ; É
                    0xCC,                                       // .text:0050D6AE                 db  CCh ; É
                    0xCC,                                       // .text:0050D6AF                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B0                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B1                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B2                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B3                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B4                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B5                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B6                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B7                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B8                 db  CCh ; É
                    0xCC,                                       // .text:0050D6B9                 db  CCh ; É
                    0xCC,                                       // .text:0050D6BA                 db  CCh ; É
                    0xCC,                                       // .text:0050D6BB                 db  CCh ; É
                    0xCC,                                       // .text:0050D6BC                 db  CCh ; É
                    0xCC,                                       // .text:0050D6BD                 db  CCh ; É
                    0xCC,                                       // .text:0050D6BE                 db  CCh ; É
                    0xCC,                                       // .text:0050D6BF                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C0                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C1                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C2                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C3                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C4                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C5                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C6                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C7                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C8                 db  CCh ; É
                    0xCC,                                       // .text:0050D6C9                 db  CCh ; É
                    0xCC,                                       // .text:0050D6CA                 db  CCh ; É
                    0xCC,                                       // .text:0050D6CB                 db  CCh ; É
                    0xCC,                                       // .text:0050D6CC                 db  CCh ; É
                    0xCC,                                       // .text:0050D6CD                 db  CCh ; É
                    0xCC,                                       // .text:0050D6CE                 db  CCh ; É
                    0xCC,                                       // .text:0050D6CF                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D0                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D1                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D2                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D3                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D4                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D5                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D6                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D7                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D8                 db  CCh ; É
                    0xCC,                                       // .text:0050D6D9                 db  CCh ; É
                    0xCC,                                       // .text:0050D6DA                 db  CCh ; É
                    0xCC,                                       // .text:0050D6DB                 db  CCh ; É
                    0xCC,                                       // .text:0050D6DC                 db  CCh ; É
                    0xCC,                                       // .text:0050D6DD                 db  CCh ; É
                    0xCC,                                       // .text:0050D6DE                 db  CCh ; É
                    0xCC,                                       // .text:0050D6DF                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E0                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E1                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E2                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E3                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E4                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E5                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E6                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E7                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E8                 db  CCh ; É
                    0xCC,                                       // .text:0050D6E9                 db  CCh ; É
                    0xCC,                                       // .text:0050D6EA                 db  CCh ; É
                    0xCC,                                       // .text:0050D6EB                 db  CCh ; É
                    0xCC,                                       // .text:0050D6EC                 db  CCh ; É
                    0xCC,                                       // .text:0050D6ED                 db  CCh ; É
                    0xCC,                                       // .text:0050D6EE                 db  CCh ; É
                    0xCC,                                       // .text:0050D6EF                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F0                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F1                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F2                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F3                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F4                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F5                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F6                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F7                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F8                 db  CCh ; É
                    0xCC,                                       // .text:0050D6F9                 db  CCh ; É
                    0xCC,                                       // .text:0050D6FA                 db  CCh ; É
                    0xCC,                                       // .text:0050D6FB                 db  CCh ; É
                    0xCC,                                       // .text:0050D6FC                 db  CCh ; É
                    0xCC,                                       // .text:0050D6FD                 db  CCh ; É
                    0xCC,                                       // .text:0050D6FE                 db  CCh ; É
                    0xCC,                                       // .text:0050D6FF                 db  CCh ; É
                    0xCC,                                       // .text:0050D700                 db  CCh ; É
                    0xCC,                                       // .text:0050D701                 db  CCh ; É
                    0xCC,                                       // .text:0050D702                 db  CCh ; É
                    0xCC,                                       // .text:0050D703                 db  CCh ; É
                    0xCC,                                       // .text:0050D704                 db  CCh ; É
                    0xCC,                                       // .text:0050D705                 db  CCh ; É
                    0xCC,                                       // .text:0050D706                 db  CCh ; É
                    0xCC,                                       // .text:0050D707                 db  CCh ; É
                    0xCC,                                       // .text:0050D708                 db  CCh ; É
                    0xCC,                                       // .text:0050D709                 db  CCh ; É
                    0xCC,                                       // .text:0050D70A                 db  CCh ; É
                    0xCC,                                       // .text:0050D70B                 db  CCh ; É
                    0xCC,                                       // .text:0050D70C                 db  CCh ; É
                    0xCC,                                       // .text:0050D70D                 db  CCh ; É
                    0xCC,                                       // .text:0050D70E                 db  CCh ; É
                    0xCC,                                       // .text:0050D70F                 db  CCh ; É
                    0xCC,                                       // .text:0050D710                 db  CCh ; É
                    0xCC,                                       // .text:0050D711                 db  CCh ; É
                    0xCC,                                       // .text:0050D712                 db  CCh ; É
                    0xCC,                                       // .text:0050D713                 db  CCh ; É
                    0xCC,                                       // .text:0050D714                 db  CCh ; É
                    0xCC,                                       // .text:0050D715                 db  CCh ; É
                    0xCC,                                       // .text:0050D716                 db  CCh ; É
                    0xCC,                                       // .text:0050D717                 db  CCh ; É
                    0xCC,                                       // .text:0050D718                 db  CCh ; É
                    0xCC,                                       // .text:0050D719                 db  CCh ; É
                    0xCC,                                       // .text:0050D71A                 db  CCh ; É
                    0xCC,                                       // .text:0050D71B                 db  CCh ; É
                    0xCC,                                       // .text:0050D71C                 db  CCh ; É
                    0xCC,                                       // .text:0050D71D                 db  CCh ; É
                    0xCC,                                       // .text:0050D71E                 db  CCh ; É
                    0xCC,                                       // .text:0050D71F                 db  CCh ; É
                    0xCC,                                       // .text:0050D720                 db  CCh ; É
                    0xCC,                                       // .text:0050D721                 db  CCh ; É
                    0xCC,                                       // .text:0050D722                 db  CCh ; É
                    0xCC,                                       // .text:0050D723                 db  CCh ; É
                    0xCC,                                       // .text:0050D724                 db  CCh ; É
                    0xCC,                                       // .text:0050D725                 db  CCh ; É
                    0xCC,                                       // .text:0050D726                 db  CCh ; É
                    0xCC,                                       // .text:0050D727                 db  CCh ; É
                    0xCC,                                       // .text:0050D728                 db  CCh ; É
                    0xCC,                                       // .text:0050D729                 db  CCh ; É
                    0xCC,                                       // .text:0050D72A                 db  CCh ; É
                    0xCC,                                       // .text:0050D72B                 db  CCh ; É
                    0xCC,                                       // .text:0050D72C                 db  CCh ; É
                    0xCC,                                       // .text:0050D72D                 db  CCh ; É
                    0xCC,                                       // .text:0050D72E                 db  CCh ; É
                    0xCC,                                       // .text:0050D72F                 db  CCh ; É
                    0xCC,                                       // .text:0050D730                 db  CCh ; É
                    0xCC,                                       // .text:0050D731                 db  CCh ; É
                    0xCC,                                       // .text:0050D732                 db  CCh ; É
                    0xCC,                                       // .text:0050D733                 db  CCh ; É
                    0xCC,                                       // .text:0050D734                 db  CCh ; É
                    0xCC,                                       // .text:0050D735                 db  CCh ; É
                    0xCC,                                       // .text:0050D736                 db  CCh ; É
                    0xCC,                                       // .text:0050D737                 db  CCh ; É
                    0xCC,                                       // .text:0050D738                 db  CCh ; É
                    0xCC,                                       // .text:0050D739                 db  CCh ; É
                    0xCC,                                       // .text:0050D73A                 db  CCh ; É
                    0xCC,                                       // .text:0050D73B                 db  CCh ; É
                    0xCC,                                       // .text:0050D73C                 db  CCh ; É
                    0xCC,                                       // .text:0050D73D                 db  CCh ; É
                    0xCC,                                       // .text:0050D73E                 db  CCh ; É
                    0xCC,                                       // .text:0050D73F                 db  CCh ; É
                    0xCC,                                       // .text:0050D740                 db  CCh ; É
                    0xCC,                                       // .text:0050D741                 db  CCh ; É
                    0xCC,                                       // .text:0050D742                 db  CCh ; É
                    0xCC,                                       // .text:0050D743                 db  CCh ; É
                    0xCC,                                       // .text:0050D744                 db  CCh ; É
                    0xCC,                                       // .text:0050D745                 db  CCh ; É
                    0xCC,                                       // .text:0050D746                 db  CCh ; É
                    0xCC,                                       // .text:0050D747                 db  CCh ; É
                    0xCC,                                       // .text:0050D748                 db  CCh ; É
                    0xCC,                                       // .text:0050D749                 db  CCh ; É
                    0xCC,                                       // .text:0050D74A                 db  CCh ; É
                    0xCC,                                       // .text:0050D74B                 db  CCh ; É
                    0xCC,                                       // .text:0050D74C                 db  CCh ; É
                    0xCC,                                       // .text:0050D74D                 db  CCh ; É
                    0xCC,                                       // .text:0050D74E                 db  CCh ; É
                    0xCC,                                       // .text:0050D74F                 db  CCh ; É
                    0xCC,                                       // .text:0050D750                 db  CCh ; É
                    0xCC,                                       // .text:0050D751                 db  CCh ; É
                    0xCC,                                       // .text:0050D752                 db  CCh ; É
                    0xCC,                                       // .text:0050D753                 db  CCh ; É
                    0xCC,                                       // .text:0050D754                 db  CCh ; É
                    0xCC,                                       // .text:0050D755                 db  CCh ; É
                    0xCC,                                       // .text:0050D756                 db  CCh ; É
                    0xCC,                                       // .text:0050D757                 db  CCh ; É
                    0xCC,                                       // .text:0050D758                 db  CCh ; É
                    0xCC,                                       // .text:0050D759                 db  CCh ; É
                    0xCC,                                       // .text:0050D75A                 db  CCh ; É
                    0xCC,                                       // .text:0050D75B                 db  CCh ; É
                    0xCC,                                       // .text:0050D75C                 db  CCh ; É
                    0xCC,                                       // .text:0050D75D                 db  CCh ; É
                    0xCC,                                       // .text:0050D75E                 db  CCh ; É
                    0xCC,                                       // .text:0050D75F                 db  CCh ; É
                    0xCC,                                       // .text:0050D760                 db  CCh ; É
                    0xCC,                                       // .text:0050D761                 db  CCh ; É
                    0xCC,                                       // .text:0050D762                 db  CCh ; É
                    0xCC,                                       // .text:0050D763                 db  CCh ; É
                    0xCC,                                       // .text:0050D764                 db  CCh ; É
                    0xCC,                                       // .text:0050D765                 db  CCh ; É
                    0xCC,                                       // .text:0050D766                 db  CCh ; É
                    0xCC,                                       // .text:0050D767                 db  CCh ; É
                    0xCC,                                       // .text:0050D768                 db  CCh ; É
                    0xCC,                                       // .text:0050D769                 db  CCh ; É
                    0xCC,                                       // .text:0050D76A                 db  CCh ; É
                    0xCC,                                       // .text:0050D76B                 db  CCh ; É
                    0xCC,                                       // .text:0050D76C                 db  CCh ; É
                    0xCC,                                       // .text:0050D76D                 db  CCh ; É
                    0xCC,                                       // .text:0050D76E                 db  CCh ; É
                    0xCC,                                       // .text:0050D76F                 db  CCh ; É
                    0xCC,                                       // .text:0050D770                 db  CCh ; É
                    0xCC,                                       // .text:0050D771                 db  CCh ; É
                    0xCC,                                       // .text:0050D772                 db  CCh ; É
                    0xCC,                                       // .text:0050D773                 db  CCh ; É
                    0xCC,                                       // .text:0050D774                 db  CCh ; É
                    0xCC,                                       // .text:0050D775                 db  CCh ; É
                    0xCC,                                       // .text:0050D776                 db  CCh ; É
                    0xCC,                                       // .text:0050D777                 db  CCh ; É
                    0xCC,                                       // .text:0050D778                 db  CCh ; É
                    0xCC,                                       // .text:0050D779                 db  CCh ; É
                    0xCC,                                       // .text:0050D77A                 db  CCh ; É
                    0xCC,                                       // .text:0050D77B                 db  CCh ; É
                    0xCC,                                       // .text:0050D77C                 db  CCh ; É
                    0xCC,                                       // .text:0050D77D                 db  CCh ; É
                    0xCC,                                       // .text:0050D77E                 db  CCh ; É
                    0xCC,                                       // .text:0050D77F                 db  CCh ; É
                    0xCC,                                       // .text:0050D780                 db  CCh ; É
                    0xCC,                                       // .text:0050D781                 db  CCh ; É
                    0xCC,                                       // .text:0050D782                 db  CCh ; É
                    0xCC,                                       // .text:0050D783                 db  CCh ; É
                    0xCC,                                       // .text:0050D784                 db  CCh ; É
                    0xCC,                                       // .text:0050D785                 db  CCh ; É
                    0xCC,                                       // .text:0050D786                 db  CCh ; É
                    0xCC,                                       // .text:0050D787                 db  CCh ; É
                    0xCC,                                       // .text:0050D788                 db  CCh ; É
                    0xCC,                                       // .text:0050D789                 db  CCh ; É
                    0xCC,                                       // .text:0050D78A                 db  CCh ; É
                    0xCC,                                       // .text:0050D78B                 db  CCh ; É
                    0xCC,                                       // .text:0050D78C                 db  CCh ; É
                    0xCC,                                       // .text:0050D78D                 db  CCh ; É
                    0xCC,                                       // .text:0050D78E                 db  CCh ; É
                    0xCC,                                       // .text:0050D78F                 db  CCh ; É
                    0xCC,                                       // .text:0050D790                 db  CCh ; É
                    0xCC,                                       // .text:0050D791                 db  CCh ; É
                    0xCC,                                       // .text:0050D792                 db  CCh ; É
                    0xCC,                                       // .text:0050D793                 db  CCh ; É
                    0xCC,                                       // .text:0050D794                 db  CCh ; É
                    0xCC,                                       // .text:0050D795                 db  CCh ; É
                    0xCC,                                       // .text:0050D796                 db  CCh ; É
                    0xCC,                                       // .text:0050D797                 db  CCh ; É
                    0xCC,                                       // .text:0050D798                 db  CCh ; É
                    0xCC,                                       // .text:0050D799                 db  CCh ; É
                    0xCC,                                       // .text:0050D79A                 db  CCh ; É
                    0xCC,                                       // .text:0050D79B                 db  CCh ; É
                    0xCC,                                       // .text:0050D79C                 db  CCh ; É
                    0xCC,                                       // .text:0050D79D                 db  CCh ; É
                    0xCC,                                       // .text:0050D79E                 db  CCh ; É
                    0xCC,                                       // .text:0050D79F                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A0                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A1                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A2                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A3                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A4                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A5                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A6                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A7                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A8                 db  CCh ; É
                    0xCC,                                       // .text:0050D7A9                 db  CCh ; É
                    0xCC,                                       // .text:0050D7AA                 db  CCh ; É
                    0xCC,                                       // .text:0050D7AB                 db  CCh ; É
                    0xCC,                                       // .text:0050D7AC                 db  CCh ; É
                    0xCC,                                       // .text:0050D7AD                 db  CCh ; É
                    0xCC,                                       // .text:0050D7AE                 db  CCh ; É
                    0xCC,                                       // .text:0050D7AF                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B0                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B1                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B2                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B3                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B4                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B5                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B6                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B7                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B8                 db  CCh ; É
                    0xCC,                                       // .text:0050D7B9                 db  CCh ; É
                    0xCC,                                       // .text:0050D7BA                 db  CCh ; É
                    0xCC,                                       // .text:0050D7BB                 db  CCh ; É
                    0xCC,                                       // .text:0050D7BC                 db  CCh ; É
                    0xCC,                                       // .text:0050D7BD                 db  CCh ; É
                    0xCC,                                       // .text:0050D7BE                 db  CCh ; É
                    0xCC,                                       // .text:0050D7BF                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C0                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C1                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C2                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C3                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C4                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C5                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C6                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C7                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C8                 db  CCh ; É
                    0xCC,                                       // .text:0050D7C9                 db  CCh ; É
                    0xCC,                                       // .text:0050D7CA                 db  CCh ; É
                    0xCC,                                       // .text:0050D7CB                 db  CCh ; É
                    0xCC,                                       // .text:0050D7CC                 db  CCh ; É
                    0xCC,                                       // .text:0050D7CD                 db  CCh ; É
                    0xCC,                                       // .text:0050D7CE                 db  CCh ; É
                    0xCC,                                       // .text:0050D7CF                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D0                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D1                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D2                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D3                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D4                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D5                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D6                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D7                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D8                 db  CCh ; É
                    0xCC,                                       // .text:0050D7D9                 db  CCh ; É
                    0xCC,                                       // .text:0050D7DA                 db  CCh ; É
                    0xCC,                                       // .text:0050D7DB                 db  CCh ; É
                    0xCC,                                       // .text:0050D7DC                 db  CCh ; É
                    0xCC,                                       // .text:0050D7DD                 db  CCh ; É
                    0xCC,                                       // .text:0050D7DE                 db  CCh ; É
                    0xCC,                                       // .text:0050D7DF                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E0                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E1                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E2                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E3                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E4                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E5                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E6                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E7                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E8                 db  CCh ; É
                    0xCC,                                       // .text:0050D7E9                 db  CCh ; É
                    0xCC,                                       // .text:0050D7EA                 db  CCh ; É
                    0xCC,                                       // .text:0050D7EB                 db  CCh ; É
                    0xCC,                                       // .text:0050D7EC                 db  CCh ; É
                    0xCC,                                       // .text:0050D7ED                 db  CCh ; É
                    0xCC,                                       // .text:0050D7EE                 db  CCh ; É
                    0xCC,                                       // .text:0050D7EF                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F0                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F1                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F2                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F3                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F4                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F5                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F6                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F7                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F8                 db  CCh ; É
                    0xCC,                                       // .text:0050D7F9                 db  CCh ; É
                    0xCC,                                       // .text:0050D7FA                 db  CCh ; É
                    0xCC,                                       // .text:0050D7FB                 db  CCh ; É
                    0xCC,                                       // .text:0050D7FC                 db  CCh ; É
                    0xCC,                                       // .text:0050D7FD                 db  CCh ; É
                    0xCC,                                       // .text:0050D7FE                 db  CCh ; É
                    0xCC,                                       // .text:0050D7FF                 db  CCh ; É
                    0xCC,                                       // .text:0050D800                 db  CCh ; É
                    0xCC,                                       // .text:0050D801                 db  CCh ; É
                    0xCC,                                       // .text:0050D802                 db  CCh ; É
                    0xCC,                                       // .text:0050D803                 db  CCh ; É
                    0xCC,                                       // .text:0050D804                 db  CCh ; É
                    0xCC,                                       // .text:0050D805                 db  CCh ; É
                    0xCC,                                       // .text:0050D806                 db  CCh ; É
                    0xCC,                                       // .text:0050D807                 db  CCh ; É
                    0xCC,                                       // .text:0050D808                 db  CCh ; É
                    0xCC,                                       // .text:0050D809                 db  CCh ; É
                    0xCC,                                       // .text:0050D80A                 db  CCh ; É
                    0xCC,                                       // .text:0050D80B                 db  CCh ; É
                    0xCC,                                       // .text:0050D80C                 db  CCh ; É
                    0xCC,                                       // .text:0050D80D                 db  CCh ; É
                    0xCC,                                       // .text:0050D80E                 db  CCh ; É
                    0xCC,                                       // .text:0050D80F                 db  CCh ; É
                    0xCC,                                       // .text:0050D810                 db  CCh ; É
                    0xCC,                                       // .text:0050D811                 db  CCh ; É
                    0xCC,                                       // .text:0050D812                 db  CCh ; É
                    0xCC,                                       // .text:0050D813                 db  CCh ; É
                    0xCC,                                       // .text:0050D814                 db  CCh ; É
                    0xCC,                                       // .text:0050D815                 db  CCh ; É
                    0xCC,                                       // .text:0050D816                 db  CCh ; É
                    0xCC,                                       // .text:0050D817                 db  CCh ; É
                    0xCC,                                       // .text:0050D818                 db  CCh ; É
                    0xCC,                                       // .text:0050D819                 db  CCh ; É
                    0xCC,                                       // .text:0050D81A                 db  CCh ; É
                    0xCC,                                       // .text:0050D81B                 db  CCh ; É
                    0xCC,                                       // .text:0050D81C                 db  CCh ; É
                    0xCC,                                       // .text:0050D81D                 db  CCh ; É
                    0xCC,                                       // .text:0050D81E                 db  CCh ; É
                    0xCC,                                       // .text:0050D81F                 db  CCh ; É
                    0xCC,                                       // .text:0050D820                 db  CCh ; É
                    0xCC,                                       // .text:0050D821                 db  CCh ; É
                    0xCC,                                       // .text:0050D822                 db  CCh ; É
                    0xCC,                                       // .text:0050D823                 db  CCh ; É
                    0xCC,                                       // .text:0050D824                 db  CCh ; É
                    0xCC,                                       // .text:0050D825                 db  CCh ; É
                    0xCC,                                       // .text:0050D826                 db  CCh ; É
                    0xCC,                                       // .text:0050D827                 db  CCh ; É
                    0xCC,                                       // .text:0050D828                 db  CCh ; É
                    0xCC,                                       // .text:0050D829                 db  CCh ; É
                    0xCC,                                       // .text:0050D82A                 db  CCh ; É
                    0xCC,                                       // .text:0050D82B                 db  CCh ; É
                    0xCC,                                       // .text:0050D82C                 db  CCh ; É
                    0xCC,                                       // .text:0050D82D                 db  CCh ; É
                    0xCC,                                       // .text:0050D82E                 db  CCh ; É
                    0xCC,                                       // .text:0050D82F                 db  CCh ; É
                    0xCC,                                       // .text:0050D830                 db  CCh ; É
                    0xCC,                                       // .text:0050D831                 db  CCh ; É
                    0xCC,                                       // .text:0050D832                 db  CCh ; É
                    0xCC,                                       // .text:0050D833                 db  CCh ; É
                    0xCC,                                       // .text:0050D834                 db  CCh ; É
                    0xCC,                                       // .text:0050D835                 db  CCh ; É
                    0xCC,                                       // .text:0050D836                 db  CCh ; É
                    0xCC,                                       // .text:0050D837                 db  CCh ; É
                    0xCC,                                       // .text:0050D838                 db  CCh ; É
                    0xCC,                                       // .text:0050D839                 db  CCh ; É
                    0xCC,                                       // .text:0050D83A                 db  CCh ; É
                    0xCC,                                       // .text:0050D83B                 db  CCh ; É
                    0xCC,                                       // .text:0050D83C                 db  CCh ; É
                    0xCC,                                       // .text:0050D83D                 db  CCh ; É
                    0xCC,                                       // .text:0050D83E                 db  CCh ; É
                    0xCC,                                       // .text:0050D83F                 db  CCh ; É
                    0xCC,                                       // .text:0050D840                 db  CCh ; É
                    0xCC,                                       // .text:0050D841                 db  CCh ; É
                    0xCC,                                       // .text:0050D842                 db  CCh ; É
                    0xCC,                                       // .text:0050D843                 db  CCh ; É
                    0xCC,                                       // .text:0050D844                 db  CCh ; É
                    0xCC,                                       // .text:0050D845                 db  CCh ; É
                    0xCC,                                       // .text:0050D846                 db  CCh ; É
                    0xCC,                                       // .text:0050D847                 db  CCh ; É
                    0xCC,                                       // .text:0050D848                 db  CCh ; É
                    0xCC,                                       // .text:0050D849                 db  CCh ; É
                    0xCC,                                       // .text:0050D84A                 db  CCh ; É
                    0xCC,                                       // .text:0050D84B                 db  CCh ; É
                    0xCC,                                       // .text:0050D84C                 db  CCh ; É
                    0xCC,                                       // .text:0050D84D                 db  CCh ; É
                    0xCC,                                       // .text:0050D84E                 db  CCh ; É
                    0xCC,                                       // .text:0050D84F                 db  CCh ; É
                    0xCC,                                       // .text:0050D850                 db  CCh ; É
                    0xCC,                                       // .text:0050D851                 db  CCh ; É
                    0xCC,                                       // .text:0050D852                 db  CCh ; É
                    0xCC,                                       // .text:0050D853                 db  CCh ; É
                    0xCC,                                       // .text:0050D854                 db  CCh ; É
                    0xCC,                                       // .text:0050D855                 db  CCh ; É
                    0xCC,                                       // .text:0050D856                 db  CCh ; É
                    0xCC,                                       // .text:0050D857                 db  CCh ; É
                    0xCC,                                       // .text:0050D858                 db  CCh ; É
                    0xCC,                                       // .text:0050D859                 db  CCh ; É
                    0xCC,                                       // .text:0050D85A                 db  CCh ; É
                    0xCC,                                       // .text:0050D85B                 db  CCh ; É
                    0xCC,                                       // .text:0050D85C                 db  CCh ; É
                    0xCC,                                       // .text:0050D85D                 db  CCh ; É
                    0xCC,                                       // .text:0050D85E                 db  CCh ; É
                    0xCC,                                       // .text:0050D85F                 db  CCh ; É
                    0xCC,                                       // .text:0050D860                 db  CCh ; É
                    0xCC,                                       // .text:0050D861                 db  CCh ; É
                    0xCC,                                       // .text:0050D862                 db  CCh ; É
                    0xCC,                                       // .text:0050D863                 db  CCh ; É
                    0xCC,                                       // .text:0050D864                 db  CCh ; É
                    0xCC,                                       // .text:0050D865                 db  CCh ; É
                    0xCC,                                       // .text:0050D866                 db  CCh ; É
                    0xCC,                                       // .text:0050D867                 db  CCh ; É
                    0xCC,                                       // .text:0050D868                 db  CCh ; É
                    0xCC,                                       // .text:0050D869                 db  CCh ; É
                    0xCC,                                       // .text:0050D86A                 db  CCh ; É
                    0xCC,                                       // .text:0050D86B                 db  CCh ; É
                    0xCC,                                       // .text:0050D86C                 db  CCh ; É
                    0xCC,                                       // .text:0050D86D                 db  CCh ; É
                    0xCC,                                       // .text:0050D86E                 db  CCh ; É
                    0xCC,                                       // .text:0050D86F                 db  CCh ; É
                    0xCC,                                       // .text:0050D870                 db  CCh ; É
                    0xCC,                                       // .text:0050D871                 db  CCh ; É
                    0xCC,                                       // .text:0050D872                 db  CCh ; É
                    0xCC,                                       // .text:0050D873                 db  CCh ; É
                    0xCC,                                       // .text:0050D874                 db  CCh ; É
                    0xCC,                                       // .text:0050D875                 db  CCh ; É
                    0xCC,                                       // .text:0050D876                 db  CCh ; É
                    0xCC,                                       // .text:0050D877                 db  CCh ; É
                    0xCC,                                       // .text:0050D878                 db  CCh ; É
                    0xCC,                                       // .text:0050D879                 db  CCh ; É
                    0xCC,                                       // .text:0050D87A                 db  CCh ; É
                    0xCC,                                       // .text:0050D87B                 db  CCh ; É
                    0xCC,                                       // .text:0050D87C                 db  CCh ; É
                    0xCC,                                       // .text:0050D87D                 db  CCh ; É
                    0xCC,                                       // .text:0050D87E                 db  CCh ; É
                    0xCC,                                       // .text:0050D87F                 db  CCh ; É
                    0xCC,                                       // .text:0050D880                 db  CCh ; É
                    0xCC,                                       // .text:0050D881                 db  CCh ; É
                    0xCC,                                       // .text:0050D882                 db  CCh ; É
                    0xCC,                                       // .text:0050D883                 db  CCh ; É
                    0xCC,                                       // .text:0050D884                 db  CCh ; É
                    0xCC,                                       // .text:0050D885                 db  CCh ; É
                    0xCC,                                       // .text:0050D886                 db  CCh ; É
                    0xCC,                                       // .text:0050D887                 db  CCh ; É
                    0xCC,                                       // .text:0050D888                 db  CCh ; É
                    0xCC,                                       // .text:0050D889                 db  CCh ; É
                    0xCC,                                       // .text:0050D88A                 db  CCh ; É
                    0xCC,                                       // .text:0050D88B                 db  CCh ; É
                    0xCC,                                       // .text:0050D88C                 db  CCh ; É
                    0xCC,                                       // .text:0050D88D                 db  CCh ; É
                    0xCC,                                       // .text:0050D88E                 db  CCh ; É
                    0xCC,                                       // .text:0050D88F                 db  CCh ; É
                    0xCC,                                       // .text:0050D890                 db  CCh ; É
                    0xCC,                                       // .text:0050D891                 db  CCh ; É
                    0xCC,                                       // .text:0050D892                 db  CCh ; É
                    0xCC,                                       // .text:0050D893                 db  CCh ; É
                    0xCC,                                       // .text:0050D894                 db  CCh ; É
                    0xCC,                                       // .text:0050D895                 db  CCh ; É
                    0xCC,                                       // .text:0050D896                 db  CCh ; É
                    0xCC,                                       // .text:0050D897                 db  CCh ; É
                    0xCC,                                       // .text:0050D898                 db  CCh ; É
                    0xCC,                                       // .text:0050D899                 db  CCh ; É
                    0xCC,                                       // .text:0050D89A                 db  CCh ; É
                    0xCC,                                       // .text:0050D89B                 db  CCh ; É
                    0xCC,                                       // .text:0050D89C                 db  CCh ; É
                    0xCC,                                       // .text:0050D89D                 db  CCh ; É
                    0xCC,                                       // .text:0050D89E                 db  CCh ; É
                    0xCC,                                       // .text:0050D89F                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A0                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A1                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A2                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A3                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A4                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A5                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A6                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A7                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A8                 db  CCh ; É
                    0xCC,                                       // .text:0050D8A9                 db  CCh ; É
                    0xCC,                                       // .text:0050D8AA                 db  CCh ; É
                    0xCC,                                       // .text:0050D8AB                 db  CCh ; É
                    0xCC,                                       // .text:0050D8AC                 db  CCh ; É
                    0xCC,                                       // .text:0050D8AD                 db  CCh ; É
                    0xCC,                                       // .text:0050D8AE                 db  CCh ; É
                    0xCC,                                       // .text:0050D8AF                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B0                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B1                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B2                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B3                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B4                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B5                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B6                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D8B7                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B8                 db  CCh ; É
                    0xCC,                                       // .text:0050D8B9                 db  CCh ; É
                    0xCC,                                       // .text:0050D8BA                 db  CCh ; É
                    0xCC,                                       // .text:0050D8BB                 db  CCh ; É
                    0xCC,                                       // .text:0050D8BC                 db  CCh ; É
                    0xCC,                                       // .text:0050D8BD                 db  CCh ; É
                    0xCC,                                       // .text:0050D8BE                 db  CCh ; É
                    0xCC,                                       // .text:0050D8BF                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C0                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C1                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C2                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C3                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C4                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C5                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C6                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C7                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C8                 db  CCh ; É
                    0xCC,                                       // .text:0050D8C9                 db  CCh ; É
                    0xCC,                                       // .text:0050D8CA                 db  CCh ; É
                    0xCC,                                       // .text:0050D8CB                 db  CCh ; É
                    0xCC,                                       // .text:0050D8CC                 db  CCh ; É
                    0xCC,                                       // .text:0050D8CD                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D8CE                 db  CCh ; É
                    0xCC,                                       // .text:0050D8CF                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D0                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D1                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D2                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D3                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D4                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D5                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D6                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D7                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D8                 db  CCh ; É
                    0xCC,                                       // .text:0050D8D9                 db  CCh ; É
                    0xCC,                                       // .text:0050D8DA                 db  CCh ; É
                    0xCC,                                       // .text:0050D8DB                 db  CCh ; É
                    0xCC,                                       // .text:0050D8DC                 db  CCh ; É
                    0xCC,                                       // .text:0050D8DD                 db  CCh ; É
                    0xCC,                                       // .text:0050D8DE                 db  CCh ; É
                    0xCC,                                       // .text:0050D8DF                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E0                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E1                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E2                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E3                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E4                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E5                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E6                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E7                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E8                 db  CCh ; É
                    0xCC,                                       // .text:0050D8E9                 db  CCh ; É
                    0xCC,                                       // .text:0050D8EA                 db  CCh ; É
                    0xCC,                                       // .text:0050D8EB                 db  CCh ; É
                    0xCC,                                       // .text:0050D8EC                 db  CCh ; É
                    0xCC,                                       // .text:0050D8ED                 db  CCh ; É
                    0xCC,                                       // .text:0050D8EE                 db  CCh ; É
                    0xCC,                                       // .text:0050D8EF                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F0                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F1                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F2                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F3                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F4                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F5                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F6                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F7                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F8                 db  CCh ; É
                    0xCC,                                       // .text:0050D8F9                 db  CCh ; É
                    0xCC,                                       // .text:0050D8FA                 db  CCh ; É
                    0xCC,                                       // .text:0050D8FB                 db  CCh ; É
                    0xCC,                                       // .text:0050D8FC                 db  CCh ; É
                    0xCC,                                       // .text:0050D8FD                 db  CCh ; É
                    0xCC,                                       // .text:0050D8FE                 db  CCh ; É
                    0xCC,                                       // .text:0050D8FF                 db  CCh ; É
                    0xCC,                                       // .text:0050D900                 db  CCh ; É
                    0xCC,                                       // .text:0050D901                 db  CCh ; É
                    0xCC,                                       // .text:0050D902                 db  CCh ; É
                    0xCC,                                       // .text:0050D903                 db  CCh ; É
                    0xCC,                                       // .text:0050D904                 db  CCh ; É
                    0xCC,                                       // .text:0050D905                 db  CCh ; É
                    0xCC,                                       // .text:0050D906                 db  CCh ; É
                    0xCC,                                       // .text:0050D907                 db  CCh ; É
                    0xCC,                                       // .text:0050D908                 db  CCh ; É
                    0xCC,                                       // .text:0050D909                 db  CCh ; É
                    0xCC,                                       // .text:0050D90A                 db  CCh ; É
                    0xCC,                                       // .text:0050D90B                 db  CCh ; É
                    0xCC,                                       // .text:0050D90C                 db  CCh ; É
                    0xCC,                                       // .text:0050D90D                 db  CCh ; É
                    0xCC,                                       // .text:0050D90E                 db  CCh ; É
                    0xCC,                                       // .text:0050D90F                 db  CCh ; É
                    0xCC,                                       // .text:0050D910                 db  CCh ; É
                    0xCC,                                       // .text:0050D911                 db  CCh ; É
                    0xCC,                                       // .text:0050D912                 db  CCh ; É
                    0xCC,                                       // .text:0050D913                 db  CCh ; É
                    0xCC,                                       // .text:0050D914                 db  CCh ; É
                    0xCC,                                       // .text:0050D915                 db  CCh ; É
                    0xCC,                                       // .text:0050D916                 db  CCh ; É
                    0xCC,                                       // .text:0050D917                 db  CCh ; É
                    0xCC,                                       // .text:0050D918                 db  CCh ; É
                    0xCC,                                       // .text:0050D919                 db  CCh ; É
                    0xCC,                                       // .text:0050D91A                 db  CCh ; É
                    0xCC,                                       // .text:0050D91B                 db  CCh ; É
                    0xCC,                                       // .text:0050D91C                 db  CCh ; É
                    0xCC,                                       // .text:0050D91D                 db  CCh ; É
                    0xCC,                                       // .text:0050D91E                 db  CCh ; É
                    0xCC,                                       // .text:0050D91F                 db  CCh ; É
                    0xCC,                                       // .text:0050D920                 db  CCh ; É
                    0xCC,                                       // .text:0050D921                 db  CCh ; É
                    0xCC,                                       // .text:0050D922                 db  CCh ; É
                    0xCC,                                       // .text:0050D923                 db  CCh ; É
                    0xCC,                                       // .text:0050D924                 db  CCh ; É
                    0xCC,                                       // .text:0050D925                 db  CCh ; É
                    0xCC,                                       // .text:0050D926                 db  CCh ; É
                    0xCC,                                       // .text:0050D927                 db  CCh ; É
                    0xCC,                                       // .text:0050D928                 db  CCh ; É
                    0xCC,                                       // .text:0050D929                 db  CCh ; É
                    0xCC,                                       // .text:0050D92A                 db  CCh ; É
                    0xCC,                                       // .text:0050D92B                 db  CCh ; É
                    0xCC,                                       // .text:0050D92C                 db  CCh ; É
                    0xCC,                                       // .text:0050D92D                 db  CCh ; É
                    0xCC,                                       // .text:0050D92E                 db  CCh ; É
                    0xCC,                                       // .text:0050D92F                 db  CCh ; É
                    0xCC,                                       // .text:0050D930                 db  CCh ; É
                    0xCC,                                       // .text:0050D931                 db  CCh ; É
                    0xCC,                                       // .text:0050D932                 db  CCh ; É
                    0xCC,                                       // .text:0050D933                 db  CCh ; É
                    0xCC,                                       // .text:0050D934                 db  CCh ; É
                    0xCC,                                       // .text:0050D935                 db  CCh ; É
                    0xCC,                                       // .text:0050D936                 db  CCh ; É
                    0xCC,                                       // .text:0050D937                 db  CCh ; É
                    0xCC,                                       // .text:0050D938                 db  CCh ; É
                    0xCC,                                       // .text:0050D939                 db  CCh ; É
                    0xCC,                                       // .text:0050D93A                 db  CCh ; É
                    0xCC,                                       // .text:0050D93B                 db  CCh ; É
                    0xCC,                                       // .text:0050D93C                 db  CCh ; É
                    0xCC,                                       // .text:0050D93D                 db  CCh ; É
                    0xCC,                                       // .text:0050D93E                 db  CCh ; É
                    0xCC,                                       // .text:0050D93F                 db  CCh ; É
                    0xCC,                                       // .text:0050D940                 db  CCh ; É
                    0xCC,                                       // .text:0050D941                 db  CCh ; É
                    0xCC,                                       // .text:0050D942                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D943                 db  CCh ; É
                    0xCC,                                       // .text:0050D944                 db  CCh ; É
                    0xCC,                                       // .text:0050D945                 db  CCh ; É
                    0xCC,                                       // .text:0050D946                 db  CCh ; É
                    0xCC,                                       // .text:0050D947                 db  CCh ; É
                    0xCC,                                       // .text:0050D948                 db  CCh ; É
                    0xCC,                                       // .text:0050D949                 db  CCh ; É
                    0xCC,                                       // .text:0050D94A                 db  CCh ; É
                    0xCC,                                       // .text:0050D94B                 db  CCh ; É
                    0xCC,                                       // .text:0050D94C                 db  CCh ; É
                    0xCC,                                       // .text:0050D94D                 db  CCh ; É
                    0xCC,                                       // .text:0050D94E                 db  CCh ; É
                    0xCC,                                       // .text:0050D94F                 db  CCh ; É
                    0xCC,                                       // .text:0050D950                 db  CCh ; É
                    0xCC,                                       // .text:0050D951                 db  CCh ; É
                    0xCC,                                       // .text:0050D952                 db  CCh ; É
                    0xCC,                                       // .text:0050D953                 db  CCh ; É
                    0xCC,                                       // .text:0050D954                 db  CCh ; É
                    0xCC,                                       // .text:0050D955                 db  CCh ; É
                    0xCC,                                       // .text:0050D956                 db  CCh ; É
                    0xCC,                                       // .text:0050D957                 db  CCh ; É
                    0xCC,                                       // .text:0050D958                 db  CCh ; É
                    0xCC,                                       // .text:0050D959                 db  CCh ; É
                    0xCC,                                       // .text:0050D95A                 db  CCh ; É
                    0xCC,                                       // .text:0050D95B                 db  CCh ; É
                    0xCC,                                       // .text:0050D95C                 db  CCh ; É
                    0xCC,                                       // .text:0050D95D                 db  CCh ; É
                    0xCC,                                       // .text:0050D95E                 db  CCh ; É
                    0xCC,                                       // .text:0050D95F                 db  CCh ; É
                    0xCC,                                       // .text:0050D960                 db  CCh ; É
                    0xCC,                                       // .text:0050D961                 db  CCh ; É
                    0xCC,                                       // .text:0050D962                 db  CCh ; É
                    0xCC,                                       // .text:0050D963                 db  CCh ; É
                    0xCC,                                       // .text:0050D964                 db  CCh ; É
                    0xCC,                                       // .text:0050D965                 db  CCh ; É
                    0xCC,                                       // .text:0050D966                 db  CCh ; É
                    0xCC,                                       // .text:0050D967                 db  CCh ; É
                    0xCC,                                       // .text:0050D968                 db  CCh ; É
                    0xCC,                                       // .text:0050D969                 db  CCh ; É
                    0xCC,                                       // .text:0050D96A                 db  CCh ; É
                    0xCC,                                       // .text:0050D96B                 db  CCh ; É
                    0xCC,                                       // .text:0050D96C                 db  CCh ; É
                    0xCC,                                       // .text:0050D96D                 db  CCh ; É
                    0xCC,                                       // .text:0050D96E                 db  CCh ; É
                    0xCC,                                       // .text:0050D96F                 db  CCh ; É
                    0xCC,                                       // .text:0050D970                 db  CCh ; É
                    0xCC,                                       // .text:0050D971                 db  CCh ; É
                    0xCC,                                       // .text:0050D972                 db  CCh ; É
                    0xCC,                                       // .text:0050D973                 db  CCh ; É
                    0xCC,                                       // .text:0050D974                 db  CCh ; É
                    0xCC,                                       // .text:0050D975                 db  CCh ; É
                    0xCC,                                       // .text:0050D976                 db  CCh ; É
                    0xCC,                                       // .text:0050D977                 db  CCh ; É
                    0xCC,                                       // .text:0050D978                 db  CCh ; É
                    0xCC,                                       // .text:0050D979                 db  CCh ; É
                    0xCC,                                       // .text:0050D97A                 db  CCh ; É
                    0xCC,                                       // .text:0050D97B                 db  CCh ; É
                    0xCC,                                       // .text:0050D97C                 db  CCh ; É
                    0xCC,                                       // .text:0050D97D                 db  CCh ; É
                    0xCC,                                       // .text:0050D97E                 db  CCh ; É
                    0xCC,                                       // .text:0050D97F                 db  CCh ; É
                    0xCC,                                       // .text:0050D980                 db  CCh ; É
                    0xCC,                                       // .text:0050D981                 db  CCh ; É
                    0xCC,                                       // .text:0050D982                 db  CCh ; É
                    0xCC,                                       // .text:0050D983                 db  CCh ; É
                    0xCC,                                       // .text:0050D984                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D985                 db  CCh ; É
                    0xCC,                                       // .text:0050D986                 db  CCh ; É
                    0xCC,                                       // .text:0050D987                 db  CCh ; É
                    0xCC,                                       // .text:0050D988                 db  CCh ; É
                    0xCC,                                       // .text:0050D989                 db  CCh ; É
                    0xCC,                                       // .text:0050D98A                 db  CCh ; É
                    0xCC,                                       // .text:0050D98B                 db  CCh ; É
                    0xCC,                                       // .text:0050D98C                 db  CCh ; É
                    0xCC,                                       // .text:0050D98D                 db  CCh ; É
                    0xCC,                                       // .text:0050D98E                 db  CCh ; É
                    0xCC,                                       // .text:0050D98F                 db  CCh ; É
                    0xCC,                                       // .text:0050D990                 db  CCh ; É
                    0xCC,                                       // .text:0050D991                 db  CCh ; É
                    0xCC,                                       // .text:0050D992                 db  CCh ; É
                    0xCC,                                       // .text:0050D993                 db  CCh ; É
                    0xCC,                                       // .text:0050D994                 db  CCh ; É
                    0xCC,                                       // .text:0050D995                 db  CCh ; É
                    0xCC,                                       // .text:0050D996                 db  CCh ; É
                    0xCC,                                       // .text:0050D997                 db  CCh ; É
                    0xCC,                                       // .text:0050D998                 db  CCh ; É
                    0xCC,                                       // .text:0050D999                 db  CCh ; É
                    0xCC,                                       // .text:0050D99A                 db  CCh ; É
                    0xCC,                                       // .text:0050D99B                 db  CCh ; É
                    0xCC,                                       // .text:0050D99C                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D99D                 db  CCh ; É
                    0xCC,                                       // .text:0050D99E                 db  CCh ; É
                    0xCC,                                       // .text:0050D99F                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A0                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A1                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A2                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A3                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A4                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A5                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A6                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A7                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A8                 db  CCh ; É
                    0xCC,                                       // .text:0050D9A9                 db  CCh ; É
                    0xCC,                                       // .text:0050D9AA                 db  CCh ; É
                    0xCC,                                       // .text:0050D9AB                 db  CCh ; É
                    0xCC,                                       // .text:0050D9AC                 db  CCh ; É
                    0xCC,                                       // .text:0050D9AD                 db  CCh ; É
                    0xCC,                                       // .text:0050D9AE                 db  CCh ; É
                    0xCC,                                       // .text:0050D9AF                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B0                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B1                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B2                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B3                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B4                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D9B5                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B6                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B7                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B8                 db  CCh ; É
                    0xCC,                                       // .text:0050D9B9                 db  CCh ; É
                    0xCC,                                       // .text:0050D9BA                 db  CCh ; É
                    0xCC,                                       // .text:0050D9BB                 db  CCh ; É
                    0xCC,                                       // .text:0050D9BC                 db  CCh ; É
                    0xCC,                                       // .text:0050D9BD                 db  CCh ; É
                    0xCC,                                       // .text:0050D9BE                 db  CCh ; É
                    0xCC,                                       // .text:0050D9BF                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C0                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C1                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C2                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C3                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C4                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C5                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C6                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C7                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C8                 db  CCh ; É
                    0xCC,                                       // .text:0050D9C9                 db  CCh ; É
                    0xCC,                                       // .text:0050D9CA                 db  CCh ; É
                    0xCC,                                       // .text:0050D9CB                 db  CCh ; É
                    0xCC,                                       // .text:0050D9CC                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D9CD                 db  CCh ; É
                    0xCC,                                       // .text:0050D9CE                 db  CCh ; É
                    0xCC,                                       // .text:0050D9CF                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D0                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D1                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D2                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D3                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D4                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D5                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D6                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D7                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D8                 db  CCh ; É
                    0xCC,                                       // .text:0050D9D9                 db  CCh ; É
                    0xCC,                                       // .text:0050D9DA                 db  CCh ; É
                    0xCC,                                       // .text:0050D9DB                 db  CCh ; É
                    0xCC,                                       // .text:0050D9DC                 db  CCh ; É
                    0xCC,                                       // .text:0050D9DD                 db  CCh ; É
                    0xCC,                                       // .text:0050D9DE                 db  CCh ; É
                    0xCC,                                       // .text:0050D9DF                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E0                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E1                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E2                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E3                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E4                 db  CCh ; É OFF32 SEGDEF [0,90909090]
                    0xCC,                                       // .text:0050D9E5                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E6                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E7                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E8                 db  CCh ; É
                    0xCC,                                       // .text:0050D9E9                 db  CCh ; É
                    0xCC,                                       // .text:0050D9EA                 db  CCh ; É
                    0xCC,                                       // .text:0050D9EB                 db  CCh ; É
                    0xCC,                                       // .text:0050D9EC                 db  CCh ; É
                    0xCC,                                       // .text:0050D9ED                 db  CCh ; É
                    0xCC,                                       // .text:0050D9EE                 db  CCh ; É
                    0xCC,                                       // .text:0050D9EF                 db  CCh ; É
                    0xCC,                                       // .text:0050D9F0                 db  CCh ; É
                    0xCC                                        // .text:0050D9F1                 db  CCh ; É
                }
            });
            #endregion
            // End
        }
    }
}