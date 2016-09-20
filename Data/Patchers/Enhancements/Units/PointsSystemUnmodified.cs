namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// The unmodified code that awards race points to finishers.
    /// </summary>
    public class PointsSystemUnmodified : DataPatcherUnitBase
    {
        public PointsSystemUnmodified(string executableFilePath) : base(executableFilePath)
        {
            var taskId = 0;

            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = $"{typeof(PointsSystemUnmodified).Name} Unmodified; TaskId {taskId:D2};",
                VirtualPosition = 0x005B8C5D,
                Instructions = new byte[]
                {
                                                                                        // .text:005B8C5D var_28          = dword ptr -28h
                                                                                        // .text:005B8C5D var_24          = dword ptr -24h
                                                                                        // .text:005B8C5D var_20          = dword ptr -20h
                                                                                        // .text:005B8C5D var_1C          = dword ptr -1Ch
                                                                                        // .text:005B8C5D var_18          = dword ptr -18h
                                                                                        // .text:005B8C5D var_14          = dword ptr -14h
                                                                                        // .text:005B8C5D var_10          = dword ptr -10h
                                                                                        // .text:005B8C5D var_C           = dword ptr -0Ch
                                                                                        // .text:005B8C5D var_8           = dword ptr -8
                                                                                        // .text:005B8C5D var_4           = dword ptr -4
                                                                                        // .text:005B8C5D
                    0x55,                                                               // .text:005B8C5D                 push    ebp
                    0x8B, 0xEC,                                                         // .text:005B8C5E                 mov     ebp, esp
                    0x83, 0xEC, 0x28,                                                   // .text:005B8C60                 sub     esp, 28h
                    0x53,                                                               // .text:005B8C63                 push    ebx
                    0x56,                                                               // .text:005B8C64                 push    esi
                    0x57,                                                               // .text:005B8C65                 push    edi
                    0xC7, 0x45, 0xE4, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8C66                 mov     [ebp+var_1C], 0
                    0xC7, 0x45, 0xE8, 0x0A, 0x00, 0x00, 0x00,                           // .text:005B8C6D                 mov     [ebp+var_18], 0Ah
                    0xC7, 0x45, 0xEC, 0x06, 0x00, 0x00, 0x00,                           // .text:005B8C74                 mov     [ebp+var_14], 6
                    0xC7, 0x45, 0xF0, 0x04, 0x00, 0x00, 0x00,                           // .text:005B8C7B                 mov     [ebp+var_10], 4
                    0xC7, 0x45, 0xF4, 0x03, 0x00, 0x00, 0x00,                           // .text:005B8C82                 mov     [ebp+var_C], 3
                    0xC7, 0x45, 0xF8, 0x02, 0x00, 0x00, 0x00,                           // .text:005B8C89                 mov     [ebp+var_8], 2
                    0xC7, 0x45, 0xFC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8C90                 mov     [ebp+var_4], 1
                    0xC7, 0x45, 0xDC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8C97                 mov     [ebp+var_24], 1
                    0xE9, 0x03, 0x00, 0x00, 0x00,                                       // .text:005B8C9E                 jmp     loc_5B8CA6
                                                                                        // .text:005B8CA3 ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8CA3
                                                                                        // .text:005B8CA3 loc_5B8CA3:                             ; CODE XREF: sub_5B8C5D:loc_5B8D29j
                    0xFF, 0x45, 0xDC,                                                   // .text:005B8CA3                 inc     [ebp+var_24]
                                                                                        // .text:005B8CA6
                                                                                        // .text:005B8CA6 loc_5B8CA6:                             ; CODE XREF: sub_5B8C5D+41j
                    0x83, 0x7D, 0xDC, 0x06,                                             // .text:005B8CA6                 cmp     [ebp+var_24], 6
                    0x0F, 0x8F, 0x7E, 0x00, 0x00, 0x00,                                 // .text:005B8CAA                 jg      loc_5B8D2E
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8CB0                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8CB3                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8CB5                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8CB8                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8CBB                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8CBE                 shl     eax, 4
                    0x8B, 0x80, 0x04, 0x75, 0x96, 0x00,                                 // .text:005B8CC1                 mov     eax, ds:dword_967504[eax]
                    0x89, 0x45, 0xD8,                                                   // .text:005B8CC7                 mov     [ebp+var_28], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8CCA                 mov     eax, [ebp+var_24]
                    0x8B, 0x44, 0x85, 0xE4,                                             // .text:005B8CCD                 mov     eax, [ebp+eax*4+var_1C]
                    0x8B, 0x4D, 0xD8,                                                   // .text:005B8CD1                 mov     ecx, [ebp+var_28]
                    0x8B, 0xD1,                                                         // .text:005B8CD4                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8CD6                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8CD9                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x4A,                                                   // .text:005B8CDC                 lea     ecx, [edx+ecx*2]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8CDF                 lea     ecx, [ecx+ecx*2]
                    0xC1, 0xE1, 0x04,                                                   // .text:005B8CE2                 shl     ecx, 4
                    0x01, 0x81, 0x2C, 0x26, 0x20, 0x01,                                 // .text:005B8CE5                 add     ds:dword_120262C[ecx], eax
                    0x83, 0x7D, 0xDC, 0x01,                                             // .text:005B8CEB                 cmp     [ebp+var_24], 1
                    0x0F, 0x85, 0x34, 0x00, 0x00, 0x00,                                 // .text:005B8CEF                 jnz     loc_5B8D29
                    0x8B, 0x45, 0xD8,                                                   // .text:005B8CF5                 mov     eax, [ebp+var_28]
                    0x8B, 0xC8,                                                         // .text:005B8CF8                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8CFA                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8CFD                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8D00                 lea     eax, [ecx+eax*2]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8D03                 lea     eax, [eax+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8D06                 shl     eax, 4
                    0xFF, 0x80, 0x30, 0x26, 0x20, 0x01,                                 // .text:005B8D09                 inc     ds:dword_1202630[eax]
                    0x8B, 0x45, 0xD8,                                                   // .text:005B8D0F                 mov     eax, [ebp+var_28]
                    0x8B, 0xC8,                                                         // .text:005B8D12                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8D14                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8D17                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8D1A                 lea     eax, [ecx+eax*2]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8D1D                 lea     eax, [eax+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8D20                 shl     eax, 4
                    0xFF, 0x80, 0x3C, 0x26, 0x20, 0x01,                                 // .text:005B8D23                 inc     ds:dword_120263C[eax]
                                                                                        // .text:005B8D29
                                                                                        // .text:005B8D29 loc_5B8D29:                             ; CODE XREF: sub_5B8C5D+92j
                    0xE9, 0x75, 0xFF, 0xFF, 0xFF,                                       // .text:005B8D29                 jmp     loc_5B8CA3
                                                                                        // .text:005B8D2E ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8D2E
                                                                                        // .text:005B8D2E loc_5B8D2E:                             ; CODE XREF: sub_5B8C5D+4Dj
                    0xC7, 0x45, 0xDC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8D2E                 mov     [ebp+var_24], 1
                    0xE9, 0x03, 0x00, 0x00, 0x00,                                       // .text:005B8D35                 jmp     loc_5B8D3D
                                                                                        // .text:005B8D3A ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8D3A
                                                                                        // .text:005B8D3A loc_5B8D3A:                             ; CODE XREF: sub_5B8C5D+269j
                    0xFF, 0x45, 0xDC,                                                   // .text:005B8D3A                 inc     [ebp+var_24]
                                                                                        // .text:005B8D3D
                                                                                        // .text:005B8D3D loc_5B8D3D:                             ; CODE XREF: sub_5B8C5D+D8j
                    0x83, 0x7D, 0xDC, 0x06,                                             // .text:005B8D3D                 cmp     [ebp+var_24], 6
                    0x0F, 0x8F, 0x84, 0x01, 0x00, 0x00,                                 // .text:005B8D41                 jg      loc_5B8ECB
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8D47                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8D4A                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8D4C                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8D4F                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8D52                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8D55                 shl     eax, 4
                    0x8B, 0x80, 0x00, 0x75, 0x96, 0x00,                                 // .text:005B8D58                 mov     eax, ds:dword_967500[eax]
                    0x89, 0x45, 0xE0,                                                   // .text:005B8D5E                 mov     [ebp+var_20], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8D61                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8D64                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8D66                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8D69                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8D6C                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8D6F                 shl     eax, 4
                    0x8B, 0x80, 0x04, 0x75, 0x96, 0x00,                                 // .text:005B8D72                 mov     eax, ds:dword_967504[eax]
                    0x89, 0x45, 0xD8,                                                   // .text:005B8D78                 mov     [ebp+var_28], eax
                    0x83, 0x7D, 0xDC, 0x01,                                             // .text:005B8D7B                 cmp     [ebp+var_24], 1
                    0x0F, 0x85, 0xEB, 0x00, 0x00, 0x00,                                 // .text:005B8D7F                 jnz     loc_5B8E70      ; DATA XREF: sub_511BA4+66o
                                                                                        // .text:005B8D7F                                         ; sub_511D2A+10o
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8D85                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8D88                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8D8A                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8D8D                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8D90                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8D93                 shl     eax, 4
                    0x8B, 0x80, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8D96                 mov     eax, ds:dword_9D1130[eax]
                    0x8B, 0xC8,                                                         // .text:005B8D9C                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8D9E                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8DA1                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8DA4                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8DA7                 lea     eax, [eax+eax*2]
                    0xFF, 0x04, 0xC5, 0x40, 0xC4, 0x16, 0x01,                           // .text:005B8DAA                 inc     ds:dword_116C440[eax*8]
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8DB1                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8DB4                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8DB6                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8DB9                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8DBC                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8DBF                 shl     eax, 4
                    0x8B, 0x80, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8DC2                 mov     eax, ds:dword_9D1130[eax]
                    0x8B, 0xC8,                                                         // .text:005B8DC8                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8DCA                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8DCD                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8DD0                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8DD3                 lea     eax, [eax+eax*2]
                    0x83, 0x3C, 0xC5, 0x40, 0xC4, 0x16, 0x01, 0x01,                     // .text:005B8DD6                 cmp     ds:dword_116C440[eax*8], 1
                    0x0F, 0x85, 0x30, 0x00, 0x00, 0x00,                                 // .text:005B8DDE                 jnz     loc_5B8E14
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8DE4                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8DE7                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8DE9                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8DEC                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8DEF                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8DF2                 shl     eax, 4
                    0x8B, 0x80, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8DF5                 mov     eax, ds:dword_9D1130[eax]
                    0x8B, 0xC8,                                                         // .text:005B8DFB                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8DFD                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E00                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E03                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8E06                 lea     eax, [eax+eax*2]
                    0xC7, 0x04, 0xC5, 0xE8, 0xD1, 0x16, 0x01, 0x01, 0x00, 0x00, 0x00,   // .text:005B8E09                 mov     ds:dword_116D1E8[eax*8], 1
                                                                                        // .text:005B8E14
                                                                                        // .text:005B8E14 loc_5B8E14:                             ; CODE XREF: sub_5B8C5D+181j
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8E14                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8E17                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8E19                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E1C                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8E1F                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8E22                 shl     eax, 4
                    0x8B, 0x80, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8E25                 mov     eax, ds:dword_9D1130[eax]
                    0x8B, 0xC8,                                                         // .text:005B8E2B                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8E2D                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E30                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E33                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8E36                 lea     eax, [eax+eax*2]
                    0xFF, 0x04, 0xC5, 0x44, 0xC4, 0x16, 0x01,                           // .text:005B8E39                 inc     ds:dword_116C444[eax*8]
                    0x8B, 0x45, 0xE0,                                                   // .text:005B8E40                 mov     eax, [ebp+var_20]
                    0x8B, 0xC8,                                                         // .text:005B8E43                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8E45                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E48                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E4B                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8E4E                 lea     eax, [eax+eax*2]
                    0xFF, 0x04, 0xC5, 0x3C, 0xC4, 0x16, 0x01,                           // .text:005B8E51                 inc     ds:dword_116C43C[eax*8]
                    0x8B, 0x45, 0xE0,                                                   // .text:005B8E58                 mov     eax, [ebp+var_20]
                    0x8B, 0xC8,                                                         // .text:005B8E5B                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8E5D                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E60                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E63                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8E66                 lea     eax, [eax+eax*2]
                    0xFF, 0x04, 0xC5, 0x48, 0xC4, 0x16, 0x01,                           // .text:005B8E69                 inc     ds:dword_116C448[eax*8]
                                                                                        // .text:005B8E70
                                                                                        // .text:005B8E70 loc_5B8E70:                             ; CODE XREF: sub_5B8C5D+122j
                    0x8B, 0x45, 0xE0,                                                   // .text:005B8E70                 mov     eax, [ebp+var_20]
                    0x8B, 0xC8,                                                         // .text:005B8E73                 mov     ecx, eax
                    0x8D, 0x04, 0xC0,                                                   // .text:005B8E75                 lea     eax, [eax+eax*8]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E78                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8E7B                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x40,                                                   // .text:005B8E7E                 lea     eax, [eax+eax*2]
                    0xFF, 0x04, 0xC5, 0x84, 0xD0, 0x16, 0x01,                           // .text:005B8E81                 inc     ds:dword_116D084[eax*8]
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8E88                 mov     eax, [ebp+var_24]
                    0x8B, 0x44, 0x85, 0xE4,                                             // .text:005B8E8B                 mov     eax, [ebp+eax*4+var_1C]
                    0x8B, 0x4D, 0xE0,                                                   // .text:005B8E8F                 mov     ecx, [ebp+var_20]
                    0x8B, 0xD1,                                                         // .text:005B8E92                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8E94                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8E97                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8E9A                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8E9D                 lea     ecx, [ecx+ecx*2]
                    0x01, 0x04, 0xCD, 0x2C, 0xC4, 0x16, 0x01,                           // .text:005B8EA0                 add     ds:dword_116C42C[ecx*8], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8EA7                 mov     eax, [ebp+var_24]
                    0x8B, 0x44, 0x85, 0xE4,                                             // .text:005B8EAA                 mov     eax, [ebp+eax*4+var_1C]
                    0x8B, 0x4D, 0xE0,                                                   // .text:005B8EAE                 mov     ecx, [ebp+var_20]
                    0x8B, 0xD1,                                                         // .text:005B8EB1                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8EB3                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8EB6                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8EB9                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8EBC                 lea     ecx, [ecx+ecx*2]
                    0x01, 0x04, 0xCD, 0x30, 0xC4, 0x16, 0x01,                           // .text:005B8EBF                 add     ds:dword_116C430[ecx*8], eax
                    0xE9, 0x6F, 0xFE, 0xFF, 0xFF,                                       // .text:005B8EC6                 jmp     loc_5B8D3A
                                                                                        // .text:005B8ECB ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8ECB
                                                                                        // .text:005B8ECB loc_5B8ECB:                             ; CODE XREF: sub_5B8C5D+E4j
                    0xC7, 0x45, 0xDC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8ECB                 mov     [ebp+var_24], 1
                    0xE9, 0x03, 0x00, 0x00, 0x00,                                       // .text:005B8ED2                 jmp     loc_5B8EDA
                                                                                        // .text:005B8ED7 ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8ED7
                                                                                        // .text:005B8ED7 loc_5B8ED7:                             ; CODE XREF: sub_5B8C5D+2FFj
                    0xFF, 0x45, 0xDC,                                                   // .text:005B8ED7                 inc     [ebp+var_24]
                                                                                        // .text:005B8EDA
                                                                                        // .text:005B8EDA loc_5B8EDA:                             ; CODE XREF: sub_5B8C5D+275j
                    0x83, 0x7D, 0xDC, 0x16,                                             // .text:005B8EDA                 cmp     [ebp+var_24], 16h
                    0x0F, 0x8F, 0x7D, 0x00, 0x00, 0x00,                                 // .text:005B8EDE                 jg      loc_5B8F61
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8EE4                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8EE7                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8EE9                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8EEC                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8EEF                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8EF2                 shl     eax, 4
                    0x8B, 0x80, 0x00, 0x75, 0x96, 0x00,                                 // .text:005B8EF5                 mov     eax, ds:dword_967500[eax]
                    0x89, 0x45, 0xE0,                                                   // .text:005B8EFB                 mov     [ebp+var_20], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8EFE                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8F01                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8F03                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8F06                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8F09                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8F0C                 shl     eax, 4
                    0x8B, 0x80, 0x04, 0x75, 0x96, 0x00,                                 // .text:005B8F0F                 mov     eax, ds:dword_967504[eax]
                    0x89, 0x45, 0xD8,                                                   // .text:005B8F15                 mov     [ebp+var_28], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8F18                 mov     eax, [ebp+var_24]
                    0x8B, 0x4D, 0xE0,                                                   // .text:005B8F1B                 mov     ecx, [ebp+var_20]
                    0x8B, 0xD1,                                                         // .text:005B8F1E                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8F20                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8F23                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8F26                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8F29                 lea     ecx, [ecx+ecx*2]
                    0xC1, 0xE1, 0x03,                                                   // .text:005B8F2C                 shl     ecx, 3
                    0xC7, 0x84, 0x81, 0x4C, 0xC4, 0x16, 0x01, 0x00, 0x00, 0x00, 0x00,   // .text:005B8F2F                 mov     ds:dword_116C44C[ecx+eax*4], 0
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8F3A                 mov     eax, [ebp+var_24]
                    0x8B, 0x4D, 0xD8,                                                   // .text:005B8F3D                 mov     ecx, [ebp+var_28]
                    0x8B, 0xD1,                                                         // .text:005B8F40                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8F42                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8F45                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x4A,                                                   // .text:005B8F48                 lea     ecx, [edx+ecx*2]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8F4B                 lea     ecx, [ecx+ecx*2]
                    0xC1, 0xE1, 0x04,                                                   // .text:005B8F4E                 shl     ecx, 4
                    0xC7, 0x84, 0x81, 0x44, 0x26, 0x20, 0x01, 0x00, 0x00, 0x00, 0x00,   // .text:005B8F51                 mov     ds:dword_1202644[ecx+eax*4], 0
                    0xE9, 0x76, 0xFF, 0xFF, 0xFF,                                       // .text:005B8F5C                 jmp     loc_5B8ED7
                                                                                        // .text:005B8F61 ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8F61
                                                                                        // .text:005B8F61 loc_5B8F61:                             ; CODE XREF: sub_5B8C5D+281j
                    0xC7, 0x45, 0xDC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8F61                 mov     [ebp+var_24], 1
                    0xE9, 0x03, 0x00, 0x00, 0x00,                                       // .text:005B8F68                 jmp     loc_5B8F70
                                                                                        // .text:005B8F6D ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8F6D
                                                                                        // .text:005B8F6D loc_5B8F6D:                             ; CODE XREF: sub_5B8C5D+38Dj
                    0xFF, 0x45, 0xDC,                                                   // .text:005B8F6D                 inc     [ebp+var_24]
                                                                                        // .text:005B8F70
                                                                                        // .text:005B8F70 loc_5B8F70:                             ; CODE XREF: sub_5B8C5D+30Bj
                    0x83, 0x7D, 0xDC, 0x16,                                             // .text:005B8F70                 cmp     [ebp+var_24], 16h
                    0x0F, 0x8F, 0x75, 0x00, 0x00, 0x00,                                 // .text:005B8F74                 jg      loc_5B8FEF
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8F7A                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8F7D                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8F7F                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8F82                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8F85                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8F88                 shl     eax, 4
                    0x8B, 0x80, 0x00, 0x75, 0x96, 0x00,                                 // .text:005B8F8B                 mov     eax, ds:dword_967500[eax]
                    0x89, 0x45, 0xE0,                                                   // .text:005B8F91                 mov     [ebp+var_20], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8F94                 mov     eax, [ebp+var_24]
                    0x8B, 0xC8,                                                         // .text:005B8F97                 mov     ecx, eax
                    0x8D, 0x04, 0x80,                                                   // .text:005B8F99                 lea     eax, [eax+eax*4]
                    0x8D, 0x04, 0x81,                                                   // .text:005B8F9C                 lea     eax, [ecx+eax*4]
                    0x8D, 0x04, 0x41,                                                   // .text:005B8F9F                 lea     eax, [ecx+eax*2]
                    0xC1, 0xE0, 0x04,                                                   // .text:005B8FA2                 shl     eax, 4
                    0x8B, 0x80, 0x04, 0x75, 0x96, 0x00,                                 // .text:005B8FA5                 mov     eax, ds:dword_967504[eax]
                    0x89, 0x45, 0xD8,                                                   // .text:005B8FAB                 mov     [ebp+var_28], eax
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8FAE                 mov     eax, [ebp+var_24]
                    0x8B, 0x4D, 0xE0,                                                   // .text:005B8FB1                 mov     ecx, [ebp+var_20]
                    0x8B, 0xD1,                                                         // .text:005B8FB4                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8FB6                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8FB9                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x8A,                                                   // .text:005B8FBC                 lea     ecx, [edx+ecx*4]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8FBF                 lea     ecx, [ecx+ecx*2]
                    0xC1, 0xE1, 0x03,                                                   // .text:005B8FC2                 shl     ecx, 3
                    0xFF, 0x84, 0x81, 0x4C, 0xC4, 0x16, 0x01,                           // .text:005B8FC5                 inc     ds:dword_116C44C[ecx+eax*4]
                    0x8B, 0x45, 0xDC,                                                   // .text:005B8FCC                 mov     eax, [ebp+var_24]
                    0x8B, 0x4D, 0xD8,                                                   // .text:005B8FCF                 mov     ecx, [ebp+var_28]
                    0x8B, 0xD1,                                                         // .text:005B8FD2                 mov     edx, ecx
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8FD4                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0xC9,                                                   // .text:005B8FD7                 lea     ecx, [ecx+ecx*8]
                    0x8D, 0x0C, 0x4A,                                                   // .text:005B8FDA                 lea     ecx, [edx+ecx*2]
                    0x8D, 0x0C, 0x49,                                                   // .text:005B8FDD                 lea     ecx, [ecx+ecx*2]
                    0xC1, 0xE1, 0x04,                                                   // .text:005B8FE0                 shl     ecx, 4
                    0xFF, 0x84, 0x81, 0x44, 0x26, 0x20, 0x01,                           // .text:005B8FE3                 inc     ds:dword_1202644[ecx+eax*4]
                    0xE9, 0x7E, 0xFF, 0xFF, 0xFF,                                       // .text:005B8FEA                 jmp     loc_5B8F6D
                                                                                        // .text:005B8FEF ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8FEF
                                                                                        // .text:005B8FEF loc_5B8FEF:                             ; CODE XREF: sub_5B8C5D+317j
                    0x5F,                                                               // .text:005B8FEF                 pop     edi
                    0x5E,                                                               // .text:005B8FF0                 pop     esi
                    0x5B,                                                               // .text:005B8FF1                 pop     ebx
                    0xC9,                                                               // .text:005B8FF2                 leave
                    0xC3,                                                               // .text:005B8FF3                 retn
                }
            });
        }
    }
}
