using System.Collections.Generic;

namespace Data.Patchers.Enhancements.Units
{
    /// <summary>
    /// Modify the code to change the race points awarded to one or all
    /// finishing positions. Change the value at line 005B8D13 (in the modified
    /// instructions) to award points to the top most number of positions. And
    /// change values at lines 005B8C6D-005B8D00 to change the points offered
    /// per position.
    /// 
    /// This update is for the points system that ran in F1 from 1991-2002.
    /// 1st = 10
    /// 2nd = 6
    /// 3rd = 4
    /// 4th = 3
    /// 5th = 2
    /// 6th = 1
    /// </summary>
    public class PointsSystemF119912002Update : DataPatcherUnitBase
    {
        public ICollection<DataPatcherUnitTask> GetUnmodifiedInstructions()
        {
            return UnmodifiedInstructions;
        }

        public PointsSystemF119912002Update(string executableFilePath) : base(executableFilePath)
        {
            var taskId = 0;

            UnmodifiedInstructions.Add(new DataPatcherUnitTask
            {
                TaskId = taskId,
                Description = typeof(PointsSystemF119912002Update).Name,
                VirtualPosition = 0x005B8C5D,
                Instructions = new byte[]
                {
                                                                                        // .text:005B8C5D var_68          = dword ptr -68h      ; v1 (Points base offset)
                                                                                        // .text:005B8C5D var_64          = dword ptr -64h      ; Points for  1st position
                                                                                        // .text:005B8C5D var_60          = dword ptr -60h      ; Points for  2nd position
                                                                                        // .text:005B8C5D var_5C          = dword ptr -5Ch      ; Points for  3rd position
                                                                                        // .text:005B8C5D var_58          = dword ptr -58h      ; Points for  4th position
                                                                                        // .text:005B8C5D var_54          = dword ptr -54h      ; Points for  5th position
                                                                                        // .text:005B8C5D var_50          = dword ptr -50h      ; Points for  6th position
                                                                                        // .text:005B8C5D var_4C          = dword ptr -4Ch      ; Points for  7th position
                                                                                        // .text:005B8C5D var_48          = dword ptr -48h      ; Points for  8th position
                                                                                        // .text:005B8C5D var_44          = dword ptr -44h      ; Points for  9th position
                                                                                        // .text:005B8C5D var_40          = dword ptr -40h      ; Points for 10th position
                                                                                        // .text:005B8C5D var_3C          = dword ptr -3Ch      ; Points for 11th position
                                                                                        // .text:005B8C5D var_38          = dword ptr -38h      ; Points for 12th position
                                                                                        // .text:005B8C5D var_34          = dword ptr -34h      ; Points for 13th position
                                                                                        // .text:005B8C5D var_30          = dword ptr -30h      ; Points for 14th position
                                                                                        // .text:005B8C5D var_2C          = dword ptr -2Ch      ; Points for 15th position
                                                                                        // .text:005B8C5D var_28          = dword ptr -28h      ; Points for 16th position
                                                                                        // .text:005B8C5D var_24          = dword ptr -24h      ; Points for 17th position
                                                                                        // .text:005B8C5D var_20          = dword ptr -20h      ; Points for 18th position
                                                                                        // .text:005B8C5D var_1C          = dword ptr -1Ch      ; Points for 19th position
                                                                                        // .text:005B8C5D var_18          = dword ptr -18h      ; Points for 20th position
                                                                                        // .text:005B8C5D var_14          = dword ptr -14h      ; Points for 21st position
                                                                                        // .text:005B8C5D var_10          = dword ptr -10h      ; Points for 22nd position
                                                                                        // .text:005B8C5D var_C           = dword ptr -0Ch      ; v24
                                                                                        // .text:005B8C5D var_8           = dword ptr -8        ; v25
                                                                                        // .text:005B8C5D var_4           = dword ptr -4        ; i
                                                                                        // .text:005B8C5D
                    0x55,                                                               // .text:005B8C5D                 push    ebp
                    0x8B, 0xEC,                                                         // .text:005B8C5E                 mov     ebp, esp
                    0x83, 0xEC, 0x68,                                                   // .text:005B8C60                 sub     esp, 68h
                    0x53,                                                               // .text:005B8C63                 push    ebx
                    0x56,                                                               // .text:005B8C64                 push    esi
                    0x57,                                                               // .text:005B8C65                 push    edi
                    0xC7, 0x45, 0x98, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8C66                 mov     [ebp+var_68], 0
                    0xC7, 0x45, 0x9C, 0x0A, 0x00, 0x00, 0x00,                           // .text:005B8C6D                 mov     [ebp+var_64], 0Ah
                    0xC7, 0x45, 0xA0, 0x06, 0x00, 0x00, 0x00,                           // .text:005B8C74                 mov     [ebp+var_60], 6
                    0xC7, 0x45, 0xA4, 0x04, 0x00, 0x00, 0x00,                           // .text:005B8C7B                 mov     [ebp+var_5C], 4
                    0xC7, 0x45, 0xA8, 0x03, 0x00, 0x00, 0x00,                           // .text:005B8C82                 mov     [ebp+var_58], 3
                    0xC7, 0x45, 0xAC, 0x02, 0x00, 0x00, 0x00,                           // .text:005B8C89                 mov     [ebp+var_54], 2
                    0xC7, 0x45, 0xB0, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8C90                 mov     [ebp+var_50], 1
                    0xC7, 0x45, 0xB4, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8C97                 mov     [ebp+var_4C], 0
                    0xC7, 0x45, 0xB8, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8C9E                 mov     [ebp+var_48], 0
                    0xC7, 0x45, 0xBC, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CA5                 mov     [ebp+var_44], 0
                    0xC7, 0x45, 0xC0, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CAC                 mov     [ebp+var_40], 0
                    0xC7, 0x45, 0xC4, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CB3                 mov     [ebp+var_3C], 0
                    0xC7, 0x45, 0xC8, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CBA                 mov     [ebp+var_38], 0
                    0xC7, 0x45, 0xCC, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CC1                 mov     [ebp+var_34], 0
                    0xC7, 0x45, 0xD0, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CC8                 mov     [ebp+var_30], 0
                    0xC7, 0x45, 0xD4, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CCF                 mov     [ebp+var_2C], 0
                    0xC7, 0x45, 0xD8, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CD6                 mov     [ebp+var_28], 0
                    0xC7, 0x45, 0xDC, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CDD                 mov     [ebp+var_24], 0
                    0xC7, 0x45, 0xE0, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CE4                 mov     [ebp+var_20], 0
                    0xC7, 0x45, 0xE4, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CEB                 mov     [ebp+var_1C], 0
                    0xC7, 0x45, 0xE8, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CF2                 mov     [ebp+var_18], 0
                    0xC7, 0x45, 0xEC, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8CF9                 mov     [ebp+var_14], 0
                    0xC7, 0x45, 0xF0, 0x00, 0x00, 0x00, 0x00,                           // .text:005B8D00                 mov     [ebp+var_10], 0
                    
                                                                                        // ; initialise loop
                    0xC7, 0x45, 0xFC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8D07                 mov     [ebp+var_4], 1
                    0xEB, 0x03,                                                         // .text:005B8D0E                 jmp     short loc_5B8D13
                                                                                        // .text:005B8D10 ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8D10
                    
                                                                                        // ; increment loop
                                                                                        // .text:005B8D10 loc_5B8D10:                             ; CODE XREF: sub_5B8C5D+2B1j
                    0xFF, 0x45, 0xFC,                                                   // .text:005B8D10                 inc     [ebp+var_4]
                                                                                        // .text:005B8D13
                    
                                                                                        // ; for loop
                                                                                        // .text:005B8D13 loc_5B8D13:                             ; CODE XREF: sub_5B8C5D+B1j
                    0x83, 0x7D, 0xFC, 0x06,                                             // .text:005B8D13                 cmp     [ebp+var_4], 6  ; points positions
                    0x0F, 0x8F, 0xF6, 0x01, 0x00, 0x00,                                 // .text:005B8D17                 jg      loc_5B8F13      ; loop termination
                    0x8B, 0x55, 0xFC,                                                   // .text:005B8D1D                 mov     edx, [ebp+var_4]
                    0x69, 0xD2, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8D20                 imul    edx, 2B0h
                    0x8B, 0x82, 0x00, 0x75, 0x96, 0x00,                                 // .text:005B8D26                 mov     eax, ds:dword_967500[edx]
                    0x89, 0x45, 0xF4,                                                   // .text:005B8D2C                 mov     [ebp+var_C], eax
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8D2F                 mov     ecx, [ebp+var_4]
                    0x69, 0xC9, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8D32                 imul    ecx, 2B0h
                    0x8B, 0x91, 0x04, 0x75, 0x96, 0x00,                                 // .text:005B8D38                 mov     edx, ds:dword_967504[ecx]
                    0x89, 0x55, 0xF8,                                                   // .text:005B8D3E                 mov     [ebp+var_8], edx
                    0x8B, 0x45, 0xF8,                                                   // .text:005B8D41                 mov     eax, [ebp+var_8]
                    0x69, 0xC0, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8D44                 imul    eax, 1E90h
                    0x8B, 0x88, 0x2C, 0x26, 0x20, 0x01,                                 // .text:005B8D4A                 mov     ecx, ds:dword_120262C[eax]
                    0x8B, 0x55, 0xFC,                                                   // .text:005B8D50                 mov     edx, [ebp+var_4]
                    0x03, 0x4C, 0x95, 0x98,                                             // .text:005B8D53                 add     ecx, [ebp+edx*4+var_68]
                    0x8B, 0x45, 0xF8,                                                   // .text:005B8D57                 mov     eax, [ebp+var_8]
                    0x69, 0xC0, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8D5A                 imul    eax, 1E90h
                    0x89, 0x88, 0x2C, 0x26, 0x20, 0x01,                                 // .text:005B8D60                 mov     ds:dword_120262C[eax], ecx
                    
                                                                                        // ; outer if
                    0x83, 0x7D, 0xFC, 0x01,                                             // .text:005B8D66                 cmp     [ebp+var_4], 1
                    0x0F, 0x85, 0x33, 0x01, 0x00, 0x00,                                 // .text:005B8D6A                 jnz     loc_5B8EA3
                    0x8B, 0x4D, 0xF8,                                                   // .text:005B8D70                 mov     ecx, [ebp+var_8]
                    0x69, 0xC9, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8D73                 imul    ecx, 1E90h
                    0x8B, 0x91, 0x30, 0x26, 0x20, 0x01,                                 // .text:005B8D79                 mov     edx, ds:dword_1202630[ecx]
                    0x83, 0xC2, 0x01,                                                   // .text:005B8D7F                 add     edx, 1          ; DATA XREF: sub_511BA4+66o
                                                                                        // .text:005B8D7F                                         ; sub_511D2A+10o
                    0x8B, 0x45, 0xF8,                                                   // .text:005B8D82                 mov     eax, [ebp+var_8]
                    0x69, 0xC0, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8D85                 imul    eax, 1E90h
                    0x89, 0x90, 0x30, 0x26, 0x20, 0x01,                                 // .text:005B8D8B                 mov     ds:dword_1202630[eax], edx
                    0x8B, 0x4D, 0xF8,                                                   // .text:005B8D91                 mov     ecx, [ebp+var_8]
                    0x69, 0xC9, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8D94                 imul    ecx, 1E90h
                    0x8B, 0x91, 0x3C, 0x26, 0x20, 0x01,                                 // .text:005B8D9A                 mov     edx, ds:dword_120263C[ecx]
                    0x83, 0xC2, 0x01,                                                   // .text:005B8DA0                 add     edx, 1
                    0x8B, 0x45, 0xF8,                                                   // .text:005B8DA3                 mov     eax, [ebp+var_8]
                    0x69, 0xC0, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8DA6                 imul    eax, 1E90h
                    0x89, 0x90, 0x3C, 0x26, 0x20, 0x01,                                 // .text:005B8DAC                 mov     ds:dword_120263C[eax], edx
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8DB2                 mov     eax, [ebp+var_4]
                    0x69, 0xC0, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8DB5                 imul    eax, 2B0h
                    0x8B, 0x88, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8DBB                 mov     ecx, ds:dword_9D1130[eax]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8DC1                 imul    ecx, 0DF8h
                    0x8B, 0x91, 0x40, 0xC4, 0x16, 0x01,                                 // .text:005B8DC7                 mov     edx, ds:dword_116C440[ecx]
                    0x83, 0xC2, 0x01,                                                   // .text:005B8DCD                 add     edx, 1
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8DD0                 mov     eax, [ebp+var_4]
                    0x69, 0xC0, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8DD3                 imul    eax, 2B0h
                    0x8B, 0x88, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8DD9                 mov     ecx, ds:dword_9D1130[eax]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8DDF                 imul    ecx, 0DF8h
                    0x89, 0x91, 0x40, 0xC4, 0x16, 0x01,                                 // .text:005B8DE5                 mov     ds:dword_116C440[ecx], edx
                    
                                                                                        // ; inner if
                    0x8B, 0x55, 0xFC,                                                   // .text:005B8DEB                 mov     edx, [ebp+var_4]
                    0x69, 0xD2, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8DEE                 imul    edx, 2B0h
                    0x8B, 0x82, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8DF4                 mov     eax, ds:dword_9D1130[edx]
                    0x69, 0xC0, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8DFA                 imul    eax, 0DF8h
                    0x83, 0xB8, 0x40, 0xC4, 0x16, 0x01, 0x01,                           // .text:005B8E00                 cmp     ds:dword_116C440[eax], 1
                    0x75, 0x1F,                                                         // .text:005B8E07                 jnz     short loc_5B8E28
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8E09                 mov     ecx, [ebp+var_4]
                    0x69, 0xC9, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8E0C                 imul    ecx, 2B0h
                    0x8B, 0x91, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8E12                 mov     edx, ds:dword_9D1130[ecx]
                    0x69, 0xD2, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E18                 imul    edx, 0DF8h
                    0xC7, 0x82, 0xE8, 0xD1, 0x16, 0x01, 0x01, 0x00, 0x00, 0x00,         // .text:005B8E1E                 mov     ds:dword_116D1E8[edx], 1
                                                                                        // ; end inner if
                    
                                                                                        // .text:005B8E28
                                                                                        // .text:005B8E28 loc_5B8E28:                             ; CODE XREF: sub_5B8C5D+1AAj
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8E28                 mov     eax, [ebp+var_4]
                    0x69, 0xC0, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8E2B                 imul    eax, 2B0h
                    0x8B, 0x88, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8E31                 mov     ecx, ds:dword_9D1130[eax]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E37                 imul    ecx, 0DF8h
                    0x8B, 0x91, 0x44, 0xC4, 0x16, 0x01,                                 // .text:005B8E3D                 mov     edx, ds:dword_116C444[ecx]
                    0x83, 0xC2, 0x01,                                                   // .text:005B8E43                 add     edx, 1
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8E46                 mov     eax, [ebp+var_4]
                    0x69, 0xC0, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8E49                 imul    eax, 2B0h
                    0x8B, 0x88, 0x30, 0x11, 0x9D, 0x00,                                 // .text:005B8E4F                 mov     ecx, ds:dword_9D1130[eax]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E55                 imul    ecx, 0DF8h
                    0x89, 0x91, 0x44, 0xC4, 0x16, 0x01,                                 // .text:005B8E5B                 mov     ds:dword_116C444[ecx], edx
                    0x8B, 0x55, 0xF4,                                                   // .text:005B8E61                 mov     edx, [ebp+var_C]
                    0x69, 0xD2, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E64                 imul    edx, 0DF8h
                    0x8B, 0x82, 0x3C, 0xC4, 0x16, 0x01,                                 // .text:005B8E6A                 mov     eax, ds:dword_116C43C[edx]
                    0x83, 0xC0, 0x01,                                                   // .text:005B8E70                 add     eax, 1
                    0x8B, 0x4D, 0xF4,                                                   // .text:005B8E73                 mov     ecx, [ebp+var_C]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E76                 imul    ecx, 0DF8h
                    0x89, 0x81, 0x3C, 0xC4, 0x16, 0x01,                                 // .text:005B8E7C                 mov     ds:dword_116C43C[ecx], eax
                    0x8B, 0x55, 0xF4,                                                   // .text:005B8E82                 mov     edx, [ebp-0Ch]
                    0x69, 0xD2, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E85                 imul    edx, 0DF8h
                    0x8B, 0x82, 0x48, 0xC4, 0x16, 0x01,                                 // .text:005B8E8B                 mov     eax, ds:dword_116C448[edx]
                    0x83, 0xC0, 0x01,                                                   // .text:005B8E91                 add     eax, 1
                    0x8B, 0x4D, 0xF4,                                                   // .text:005B8E94                 mov     ecx, [ebp+var_C]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8E97                 imul    ecx, 0DF8h
                    0x89, 0x81, 0x48, 0xC4, 0x16, 0x01,                                 // .text:005B8E9D                 mov     ds:dword_116C448[ecx], eax
                                                                                        // ; end outer if
                    
                                                                                        // .text:005B8EA3
                                                                                        // .text:005B8EA3 loc_5B8EA3:                             ; CODE XREF: sub_5B8C5D+10Dj
                    0x8B, 0x55, 0xF4,                                                   // .text:005B8EA3                 mov     edx, [ebp-0Ch]
                    0x69, 0xD2, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8EA6                 imul    edx, 0DF8h
                    0x8B, 0x82, 0x84, 0xD0, 0x16, 0x01,                                 // .text:005B8EAC                 mov     eax, ds:dword_116D084[edx]
                    0x83, 0xC0, 0x01,                                                   // .text:005B8EB2                 add     eax, 1
                    0x8B, 0x4D, 0xF4,                                                   // .text:005B8EB5                 mov     ecx, [ebp+var_C]
                    0x69, 0xC9, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8EB8                 imul    ecx, 0DF8h
                    0x89, 0x81, 0x84, 0xD0, 0x16, 0x01,                                 // .text:005B8EBE                 mov     ds:dword_116D084[ecx], eax
                    0x8B, 0x55, 0xF4,                                                   // .text:005B8EC4                 mov     edx, [ebp+var_C]
                    0x69, 0xD2, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8EC7                 imul    edx, 0DF8h
                    0x8B, 0x82, 0x2C, 0xC4, 0x16, 0x01,                                 // .text:005B8ECD                 mov     eax, ds:dword_116C42C[edx]
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8ED3                 mov     ecx, [ebp+var_4]
                    0x03, 0x44, 0x8D, 0x98,                                             // .text:005B8ED6                 add     eax, [ebp+ecx*4+var_68]
                    0x8B, 0x55, 0xF4,                                                   // .text:005B8EDA                 mov     edx, [ebp+var_C]
                    0x69, 0xD2, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8EDD                 imul    edx, 0DF8h
                    0x89, 0x82, 0x2C, 0xC4, 0x16, 0x01,                                 // .text:005B8EE3                 mov     ds:dword_116C42C[edx], eax
                    0x8B, 0x45, 0xF4,                                                   // .text:005B8EE9                 mov     eax, [ebp+var_C]
                    0x69, 0xC0, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8EEC                 imul    eax, 0DF8h
                    0x8B, 0x88, 0x30, 0xC4, 0x16, 0x01,                                 // .text:005B8EF2                 mov     ecx, ds:dword_116C430[eax]
                    0x8B, 0x55, 0xFC,                                                   // .text:005B8EF8                 mov     edx, [ebp+var_4]
                    0x03, 0x4C, 0x95, 0x98,                                             // .text:005B8EFB                 add     ecx, [ebp+edx*4+var_68]
                    0x8B, 0x45, 0xF4,                                                   // .text:005B8EFF                 mov     eax, [ebp+var_C]
                    0x69, 0xC0, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8F02                 imul    eax, 0DF8h
                    0x89, 0x88, 0x30, 0xC4, 0x16, 0x01,                                 // .text:005B8F08                 mov     ds:dword_116C430[eax], ecx
                    
                                                                                        // ; top of loop
                    0xE9, 0xFD, 0xFD, 0xFF, 0xFF,                                       // .text:005B8F0E                 jmp     loc_5B8D10
                                                                                        // .text:005B8F13 ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8F13
                    
                                                                                        // ; initialise loop
                                                                                        // .text:005B8F13 loc_5B8F13:                             ; CODE XREF: sub_5B8C5D+BAj
                    0xC7, 0x45, 0xFC, 0x01, 0x00, 0x00, 0x00,                           // .text:005B8F13                 mov     [ebp+var_4], 1
                    0xEB, 0x03,                                                         // .text:005B8F1A                 jmp     short loc_5B8F1F
                                                                                        // .text:005B8F1C ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8F1C
                    
                                                                                        // ; increment loop
                                                                                        // .text:005B8F1C loc_5B8F1C:                             ; CODE XREF: sub_5B8C5D+370j
                    0xFF, 0x45, 0xFC,                                                   // .text:005B8F1C                 inc     [ebp+var_4]
                    
                                                                                        // ; for loop
                                                                                        // .text:005B8F1F
                                                                                        // .text:005B8F1F loc_5B8F1F:                             ; CODE XREF: sub_5B8C5D+2BDj
                    0x83, 0x7D, 0xFC, 0x16,                                             // .text:005B8F1F                 cmp     [ebp+var_4], 16h; number of drivers
                    0x0F, 0x8F, 0xA9, 0x00, 0x00, 0x00,                                 // .text:005B8F23                 jg      loc_5B8FD2      ; loop termination
                    0x8B, 0x55, 0xFC,                                                   // .text:005B8F29                 mov     edx, [ebp+var_4]
                    0x69, 0xD2, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8F2C                 imul    edx, 2B0h
                    0x8B, 0x82, 0x00, 0x75, 0x96, 0x00,                                 // .text:005B8F32                 mov     eax, ds:dword_967500[edx]
                    0x89, 0x45, 0xF4,                                                   // .text:005B8F38                 mov     [ebp+var_C], eax
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8F3B                 mov     ecx, [ebp+var_4]
                    0x69, 0xC9, 0xB0, 0x02, 0x00, 0x00,                                 // .text:005B8F3E                 imul    ecx, 2B0h
                    0x8B, 0x91, 0x04, 0x75, 0x96, 0x00,                                 // .text:005B8F44                 mov     edx, ds:dword_967504[ecx]
                    0x89, 0x55, 0xF8,                                                   // .text:005B8F4A                 mov     [ebp+var_8], edx
                    0x8B, 0x45, 0xF4,                                                   // .text:005B8F4D                 mov     eax, [ebp+var_C]
                    0x69, 0xC0, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8F50                 imul    eax, 0DF8h
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8F56                 mov     ecx, [ebp+var_4]
                    0xC7, 0x84, 0x88, 0x4C, 0xC4, 0x16, 0x01, 0x00, 0x00, 0x00, 0x00,   // .text:005B8F59                 mov     ds:dword_116C44C[eax+ecx*4], 0
                    0x8B, 0x55, 0xF8,                                                   // .text:005B8F64                 mov     edx, [ebp+var_8]
                    0x69, 0xD2, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8F67                 imul    edx, 1E90h
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8F6D                 mov     eax, [ebp+var_4]
                    0xC7, 0x84, 0x82, 0x44, 0x26, 0x20, 0x01, 0x00, 0x00, 0x00, 0x00,   // .text:005B8F70                 mov     ds:dword_1202644[edx+eax*4], 0
                    0x8B, 0x45, 0xF4,                                                   // .text:005B8F7B                 mov     eax, [ebp+var_C]
                    0x69, 0xC0, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8F7E                 imul    eax, 0DF8h
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8F84                 mov     ecx, [ebp+var_4]
                    0x8B, 0x94, 0x88, 0x4C, 0xC4, 0x16, 0x01,                           // .text:005B8F87                 mov     edx, ds:dword_116C44C[eax+ecx*4]
                    0x83, 0xC2, 0x01,                                                   // .text:005B8F8E                 add     edx, 1
                    0x8B, 0x45, 0xF4,                                                   // .text:005B8F91                 mov     eax, [ebp+var_C]
                    0x69, 0xC0, 0xF8, 0x0D, 0x00, 0x00,                                 // .text:005B8F94                 imul    eax, 0DF8h
                    0x8B, 0x4D, 0xFC,                                                   // .text:005B8F9A                 mov     ecx, [ebp+var_4]
                    0x89, 0x94, 0x88, 0x4C, 0xC4, 0x16, 0x01,                           // .text:005B8F9D                 mov     ds:dword_116C44C[eax+ecx*4], edx
                    0x8B, 0x55, 0xF8,                                                   // .text:005B8FA4                 mov     edx, [ebp+var_8]
                    0x69, 0xD2, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8FA7                 imul    edx, 1E90h
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8FAD                 mov     eax, [ebp+var_4]
                    0x8B, 0x8C, 0x82, 0x44, 0x26, 0x20, 0x01,                           // .text:005B8FB0                 mov     ecx, ds:dword_1202644[edx+eax*4]
                    0x83, 0xC1, 0x01,                                                   // .text:005B8FB7                 add     ecx, 1
                    0x8B, 0x55, 0xF8,                                                   // .text:005B8FBA                 mov     edx, [ebp+var_8]
                    0x69, 0xD2, 0x90, 0x1E, 0x00, 0x00,                                 // .text:005B8FBD                 imul    edx, 1E90h
                    0x8B, 0x45, 0xFC,                                                   // .text:005B8FC3                 mov     eax, [ebp+var_4]
                    0x89, 0x8C, 0x82, 0x44, 0x26, 0x20, 0x01,                           // .text:005B8FC6                 mov     ds:dword_1202644[edx+eax*4], ecx
                    
                                                                                        // ; top of loop
                    0xE9, 0x4A, 0xFF, 0xFF, 0xFF,                                       // .text:005B8FCD                 jmp     loc_5B8F1C
                                                                                        // .text:005B8FD2 ; ---------------------------------------------------------------------------
                                                                                        // .text:005B8FD2
                    
                                                                                        // ; end sub
                                                                                        // .text:005B8FD2 loc_5B8FD2:                             ; CODE XREF: sub_5B8C5D+2C6j
                    0x5F,                                                               // .text:005B8FD2                 pop     edi
                    0x5E,                                                               // .text:005B8FD3                 pop     esi
                    0x5B,                                                               // .text:005B8FD4                 pop     ebx
                    0xC9,                                                               // .text:005B8FD5                 leave
                    0xC3,                                                               // .text:005B8FD6                 retn
                                                                                        // .text:005B8FD6 sub_5B8C5D      endp
                                                                                        // .text:005B8FD6
                                                                                        // .text:005B8FD6 ; ---------------------------------------------------------------------------
                    0x90,                                                               // .text:005B8FD7                 db  90h ; É
                    0x90,                                                               // .text:005B8FD8                 db  90h ; É
                    0x90,                                                               // .text:005B8FD9                 db  90h ; É
                    0x90,                                                               // .text:005B8FDA                 db  90h ; É
                    0x90,                                                               // .text:005B8FDB                 db  90h ; É
                    0x90,                                                               // .text:005B8FDC                 db  90h ; É
                    0x90,                                                               // .text:005B8FDD                 db  90h ; É
                    0x90,                                                               // .text:005B8FDE                 db  90h ; É
                    0x90,                                                               // .text:005B8FDF                 db  90h ; É
                    0x90,                                                               // .text:005B8FE0                 db  90h ; É
                    0x90,                                                               // .text:005B8FE1                 db  90h ; É
                    0x90,                                                               // .text:005B8FE2                 db  90h ; É
                    0x90,                                                               // .text:005B8FE3                 db  90h ; É
                    0x90,                                                               // .text:005B8FE4                 db  90h ; É
                    0x90,                                                               // .text:005B8FE5                 db  90h ; É
                    0x90,                                                               // .text:005B8FE6                 db  90h ; É OFF32 SEGDEF [0,90909090]
                    0x90,                                                               // .text:005B8FE7                 db  90h ; É
                    0x90,                                                               // .text:005B8FE8                 db  90h ; É
                    0x90,                                                               // .text:005B8FE9                 db  90h ; É
                    0x90,                                                               // .text:005B8FEA                 db  90h ; É
                    0x90,                                                               // .text:005B8FEB                 db  90h ; É
                    0x90,                                                               // .text:005B8FEC                 db  90h ; É
                    0x90,                                                               // .text:005B8FED                 db  90h ; É
                    0x90,                                                               // .text:005B8FEE                 db  90h ; É
                    0x90,                                                               // .text:005B8FEF                 db  90h ; É
                    0x90,                                                               // .text:005B8FF0                 db  90h ; É
                    0x90,                                                               // .text:005B8FF1                 db  90h ; É
                    0x90,                                                               // .text:005B8FF2                 db  90h ; É
                    0x90                                                                // .text:005B8FF3                 db  90h ; É
                }
            });

            // Use unmodified instructions as modified instructions
            foreach (var dataPatcherUnitTask in UnmodifiedInstructions)
            {
                ModifiedInstructions.Add(new DataPatcherUnitTask
                {
                    TaskId = dataPatcherUnitTask.TaskId,
                    Description = typeof(PointsSystemF119912002Update).Name,
                    VirtualPosition = dataPatcherUnitTask.VirtualPosition,
                    Instructions = dataPatcherUnitTask.Instructions
                });
            }
        }
    }
}
