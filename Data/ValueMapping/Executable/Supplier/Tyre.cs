using Data.Entities.Executable.Supplier;

namespace Data.ValueMapping.Executable.Supplier
{
    public class Tyre : ITyre
    {
        // Offset values
        private const int BaseOffset = 0; // TODO
        private const int LocalOffset = 0; // TODO
        private const int ExampleOffset = 0; // TODO

        public int DryHardGrip { get; set; }
        public int DryHardResilience { get; set; }
        public int DryHardStiffness { get; set; }
        public int DryHardTemperature { get; set; }
        public int DrySoftGrip { get; set; }
        public int DrySoftResilience { get; set; }
        public int DrySoftStiffness { get; set; }
        public int DrySoftTemperature { get; set; }
        public int IntermediateGrip { get; set; }
        public int IntermediateResilience { get; set; }
        public int IntermediateStiffness { get; set; }
        public int IntermediateTemperature { get; set; }
        public int WetWeatherGrip { get; set; }
        public int WetWeatherResilience { get; set; }
        public int WetWeatherStiffness { get; set; }
        public int WetWeatherTemperature { get; set; }

        public Tyre(int id)
        {
            // Calculate step offset from zero based index
            var stepOffset = LocalOffset * id;

            //Example = BaseOffset + stepOffset + ExampleOffset; // TODO
        }
    }
}


/* TODO
(1EAE83)
.text:005EB4E3
.text:005EB4E3                                     ; =============== S U B R O U T I N E =======================================
.text:005EB4E3
.text:005EB4E3                                     ; Attributes: bp-based frame
.text:005EB4E3
.text:005EB4E3                                     sub_5EB4E3      proc near               ; CODE XREF: sub_4027A7j
.text:005EB4E3
.text:005EB4E3                                     var_10          = dword ptr -10h
.text:005EB4E3                                     var_C           = dword ptr -0Ch
.text:005EB4E3                                     var_8           = dword ptr -8
.text:005EB4E3                                     var_4           = dword ptr -4
.text:005EB4E3
.text:005EB4E3 55                                                  push    ebp
.text:005EB4E4 8B EC                                               mov     ebp, esp
.text:005EB4E6 83 EC 10                                            sub     esp, 10h
.text:005EB4E9 53                                                  push    ebx
.text:005EB4EA 56                                                  push    esi
.text:005EB4EB 57                                                  push    edi
.text:005EB4EC E8 1A 69 E1 FF                                      call    sub_401E0B
.text:005EB4F1 C7 45 F8 01 00 00 00                                mov     [ebp+var_8], 1
.text:005EB4F8 E9 03 00 00 00                                      jmp     loc_5EB500
.text:005EB4FD                                     ; ---------------------------------------------------------------------------
.text:005EB4FD
.text:005EB4FD                                     loc_5EB4FD:                             ; CODE XREF: sub_5EB4E3:loc_5EBE9Fj
.text:005EB4FD FF 45 F8                                            inc     [ebp+var_8]
.text:005EB500
.text:005EB500                                     loc_5EB500:                             ; CODE XREF: sub_5EB4E3+15j
.text:005EB500 83 7D F8 0C                                         cmp     [ebp+var_8], 0Ch
.text:005EB504 0F 8D 9A 09 00 00                                   jge     loc_5EBEA4
.text:005EB50A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB50D 8B C8                                               mov     ecx, eax
.text:005EB50F 8D 04 C0                                            lea     eax, [eax+eax*8]
.text:005EB512 8D 04 C0                                            lea     eax, [eax+eax*8]
.text:005EB515 8D 04 41                                            lea     eax, [ecx+eax*2]
.text:005EB518 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB51B C1 E0 04                                            shl     eax, 4
.text:005EB51E 8B 80 50 41 20 01                                   mov     eax, ds:dword_1204150[eax]
.text:005EB524 89 45 FC                                            mov     [ebp+var_4], eax
.text:005EB527 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB52A 8B C8                                               mov     ecx, eax
.text:005EB52C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB52F C1 E0 03                                            shl     eax, 3
.text:005EB532 2B C1                                               sub     eax, ecx
.text:005EB534 C1 E0 06                                            shl     eax, 6
.text:005EB537 03 C1                                               add     eax, ecx
.text:005EB539 C1 E0 02                                            shl     eax, 2
.text:005EB53C C7 84 80 E8 8F 87 00 01 00 00 00                    mov     ds:dword_878FE8[eax+eax*4], 1
.text:005EB547 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB54A 8B C8                                               mov     ecx, eax
.text:005EB54C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB54F C1 E0 03                                            shl     eax, 3
.text:005EB552 2B C1                                               sub     eax, ecx
.text:005EB554 C1 E0 06                                            shl     eax, 6
.text:005EB557 03 C1                                               add     eax, ecx
.text:005EB559 C1 E0 02                                            shl     eax, 2
.text:005EB55C C7 84 80 78 91 87 00 01 00 00 00                    mov     ds:dword_879178[eax+eax*4], 1
.text:005EB567 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB56A 8B C8                                               mov     ecx, eax
.text:005EB56C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB56F C1 E0 03                                            shl     eax, 3
.text:005EB572 2B C1                                               sub     eax, ecx
.text:005EB574 C1 E0 06                                            shl     eax, 6
.text:005EB577 03 C1                                               add     eax, ecx
.text:005EB579 C1 E0 02                                            shl     eax, 2
.text:005EB57C C7 84 80 08 93 87 00 01 00 00 00                    mov     ds:dword_879308[eax+eax*4], 1
.text:005EB587 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB58A 8B C8                                               mov     ecx, eax
.text:005EB58C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB58F C1 E0 03                                            shl     eax, 3
.text:005EB592 2B C1                                               sub     eax, ecx
.text:005EB594 C1 E0 06                                            shl     eax, 6
.text:005EB597 03 C1                                               add     eax, ecx
.text:005EB599 C1 E0 02                                            shl     eax, 2
.text:005EB59C C7 84 80 98 94 87 00 01 00 00 00                    mov     ds:dword_879498[eax+eax*4], 1
.text:005EB5A7 8B 45 FC                                            mov     eax, [ebp+var_4]
.text:005EB5AA 89 45 F0                                            mov     [ebp+var_10], eax
.text:005EB5AD E9 D4 08 00 00                                      jmp     loc_5EBE86
.text:005EB5B2                                     ; ---------------------------------------------------------------------------
.text:005EB5B2
.text:005EB5B2                                     loc_5EB5B2:                             ; CODE XREF: sub_5EB4E3+9B1j
.text:005EB5B2 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB5B5 8B C8                                               mov     ecx, eax
.text:005EB5B7 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB5BA C1 E0 03                                            shl     eax, 3
.text:005EB5BD 2B C1                                               sub     eax, ecx
.text:005EB5BF C1 E0 06                                            shl     eax, 6
.text:005EB5C2 03 C1                                               add     eax, ecx
.text:005EB5C4 C1 E0 02                                            shl     eax, 2
.text:005EB5C7 C7 84 80 28 AF 87 00 05 00 00 00                    mov     ds:dword_87AF28[eax+eax*4], 5
.text:005EB5D2 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB5D5 8B C8                                               mov     ecx, eax
.text:005EB5D7 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB5DA C1 E0 03                                            shl     eax, 3
.text:005EB5DD 2B C1                                               sub     eax, ecx
.text:005EB5DF C1 E0 06                                            shl     eax, 6
.text:005EB5E2 03 C1                                               add     eax, ecx
.text:005EB5E4 C1 E0 02                                            shl     eax, 2
.text:005EB5E7 C7 84 80 68 B5 87 00 06 00 00 00                    mov     ds:dword_87B568[eax+eax*4], 6
.text:005EB5F2 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB5F5 8B C8                                               mov     ecx, eax
.text:005EB5F7 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB5FA C1 E0 03                                            shl     eax, 3
.text:005EB5FD 2B C1                                               sub     eax, ecx
.text:005EB5FF C1 E0 06                                            shl     eax, 6
.text:005EB602 03 C1                                               add     eax, ecx
.text:005EB604 C1 E0 02                                            shl     eax, 2
.text:005EB607 C7 84 80 A8 BB 87 00 06 00 00 00                    mov     ds:dword_87BBA8[eax+eax*4], 6
.text:005EB612 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB615 8B C8                                               mov     ecx, eax
.text:005EB617 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB61A C1 E0 03                                            shl     eax, 3
.text:005EB61D 2B C1                                               sub     eax, ecx
.text:005EB61F C1 E0 06                                            shl     eax, 6
.text:005EB622 03 C1                                               add     eax, ecx
.text:005EB624 C1 E0 02                                            shl     eax, 2
.text:005EB627 C7 84 80 E8 C1 87 00 07 00 00 00                    mov     ds:dword_87C1E8[eax+eax*4], 7
.text:005EB632 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB635 8B C8                                               mov     ecx, eax
.text:005EB637 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB63A C1 E0 03                                            shl     eax, 3
.text:005EB63D 2B C1                                               sub     eax, ecx
.text:005EB63F C1 E0 06                                            shl     eax, 6
.text:005EB642 03 C1                                               add     eax, ecx
.text:005EB644 C1 E0 02                                            shl     eax, 2
.text:005EB647 C7 84 80 68 9C 87 00 00 00 00 00                    mov     ds:dword_879C68[eax+eax*4], 0
.text:005EB652 C7 05 0C 99 7E 00 05 00 00 00                       mov     ds:dword_7E990C, 5
.text:005EB65C C7 05 1C 99 7E 00 06 00 00 00                       mov     ds:dword_7E991C, 6
.text:005EB666 C7 05 2C 99 7E 00 06 00 00 00                       mov     ds:dword_7E992C, 6
.text:005EB670 C7 05 3C 99 7E 00 07 00 00 00                       mov     ds:dword_7E993C, 7
.text:005EB67A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB67D 8B C8                                               mov     ecx, eax
.text:005EB67F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB682 C1 E0 03                                            shl     eax, 3
.text:005EB685 2B C1                                               sub     eax, ecx
.text:005EB687 C1 E0 06                                            shl     eax, 6
.text:005EB68A 03 C1                                               add     eax, ecx
.text:005EB68C C1 E0 02                                            shl     eax, 2
.text:005EB68F C7 84 80 B8 B0 87 00 07 00 00 00                    mov     ds:dword_87B0B8[eax+eax*4], 7
.text:005EB69A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB69D 8B C8                                               mov     ecx, eax
.text:005EB69F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB6A2 C1 E0 03                                            shl     eax, 3
.text:005EB6A5 2B C1                                               sub     eax, ecx
.text:005EB6A7 C1 E0 06                                            shl     eax, 6
.text:005EB6AA 03 C1                                               add     eax, ecx
.text:005EB6AC C1 E0 02                                            shl     eax, 2
.text:005EB6AF C7 84 80 F8 B6 87 00 05 00 00 00                    mov     ds:dword_87B6F8[eax+eax*4], 5
.text:005EB6BA 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB6BD 8B C8                                               mov     ecx, eax
.text:005EB6BF 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB6C2 C1 E0 03                                            shl     eax, 3
.text:005EB6C5 2B C1                                               sub     eax, ecx
.text:005EB6C7 C1 E0 06                                            shl     eax, 6
.text:005EB6CA 03 C1                                               add     eax, ecx
.text:005EB6CC C1 E0 02                                            shl     eax, 2
.text:005EB6CF C7 84 80 38 BD 87 00 05 00 00 00                    mov     ds:dword_87BD38[eax+eax*4], 5
.text:005EB6DA 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB6DD 8B C8                                               mov     ecx, eax
.text:005EB6DF 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB6E2 C1 E0 03                                            shl     eax, 3
.text:005EB6E5 2B C1                                               sub     eax, ecx
.text:005EB6E7 C1 E0 06                                            shl     eax, 6
.text:005EB6EA 03 C1                                               add     eax, ecx
.text:005EB6EC C1 E0 02                                            shl     eax, 2
.text:005EB6EF C7 84 80 78 C3 87 00 07 00 00 00                    mov     ds:dword_87C378[eax+eax*4], 7
.text:005EB6FA 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB6FD 8B C8                                               mov     ecx, eax
.text:005EB6FF 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB702 C1 E0 03                                            shl     eax, 3
.text:005EB705 2B C1                                               sub     eax, ecx
.text:005EB707 C1 E0 06                                            shl     eax, 6
.text:005EB70A 03 C1                                               add     eax, ecx
.text:005EB70C C1 E0 02                                            shl     eax, 2
.text:005EB70F C7 84 80 F8 9D 87 00 00 00 00 00                    mov     ds:dword_879DF8[eax+eax*4], 0
.text:005EB71A C7 05 10 99 7E 00 07 00 00 00                       mov     ds:dword_7E9910, 7
.text:005EB724 C7 05 20 99 7E 00 05 00 00 00                       mov     ds:dword_7E9920, 5
.text:005EB72E C7 05 30 99 7E 00 05 00 00 00                       mov     ds:dword_7E9930, 5
.text:005EB738 C7 05 40 99 7E 00 07 00 00 00                       mov     ds:dword_7E9940, 7
.text:005EB742 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB745 8B C8                                               mov     ecx, eax
.text:005EB747 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB74A C1 E0 03                                            shl     eax, 3
.text:005EB74D 2B C1                                               sub     eax, ecx
.text:005EB74F C1 E0 06                                            shl     eax, 6
.text:005EB752 03 C1                                               add     eax, ecx
.text:005EB754 C1 E0 02                                            shl     eax, 2
.text:005EB757 C7 84 80 48 B2 87 00 06 00 00 00                    mov     ds:dword_87B248[eax+eax*4], 6
.text:005EB762 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB765 8B C8                                               mov     ecx, eax
.text:005EB767 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB76A C1 E0 03                                            shl     eax, 3
.text:005EB76D 2B C1                                               sub     eax, ecx
.text:005EB76F C1 E0 06                                            shl     eax, 6
.text:005EB772 03 C1                                               add     eax, ecx
.text:005EB774 C1 E0 02                                            shl     eax, 2
.text:005EB777 C7 84 80 88 B8 87 00 07 00 00 00                    mov     ds:dword_87B888[eax+eax*4], 7
.text:005EB782 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB785 8B C8                                               mov     ecx, eax
.text:005EB787 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB78A C1 E0 03                                            shl     eax, 3
.text:005EB78D 2B C1                                               sub     eax, ecx
.text:005EB78F C1 E0 06                                            shl     eax, 6
.text:005EB792 03 C1                                               add     eax, ecx
.text:005EB794 C1 E0 02                                            shl     eax, 2
.text:005EB797 C7 84 80 C8 BE 87 00 06 00 00 00                    mov     ds:dword_87BEC8[eax+eax*4], 6
.text:005EB7A2 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB7A5 8B C8                                               mov     ecx, eax
.text:005EB7A7 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB7AA C1 E0 03                                            shl     eax, 3
.text:005EB7AD 2B C1                                               sub     eax, ecx
.text:005EB7AF C1 E0 06                                            shl     eax, 6
.text:005EB7B2 03 C1                                               add     eax, ecx
.text:005EB7B4 C1 E0 02                                            shl     eax, 2
.text:005EB7B7 C7 84 80 08 C5 87 00 05 00 00 00                    mov     ds:dword_87C508[eax+eax*4], 5
.text:005EB7C2 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB7C5 8B C8                                               mov     ecx, eax
.text:005EB7C7 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB7CA C1 E0 03                                            shl     eax, 3
.text:005EB7CD 2B C1                                               sub     eax, ecx
.text:005EB7CF C1 E0 06                                            shl     eax, 6
.text:005EB7D2 03 C1                                               add     eax, ecx
.text:005EB7D4 C1 E0 02                                            shl     eax, 2
.text:005EB7D7 C7 84 80 88 9F 87 00 00 00 00 00                    mov     ds:dword_879F88[eax+eax*4], 0
.text:005EB7E2 C7 05 14 99 7E 00 06 00 00 00                       mov     ds:dword_7E9914, 6
.text:005EB7EC C7 05 24 99 7E 00 07 00 00 00                       mov     ds:dword_7E9924, 7
.text:005EB7F6 C7 05 34 99 7E 00 06 00 00 00                       mov     ds:dword_7E9934, 6
.text:005EB800 C7 05 44 99 7E 00 05 00 00 00                       mov     ds:dword_7E9944, 5
.text:005EB80A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB80D 8B C8                                               mov     ecx, eax
.text:005EB80F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB812 C1 E0 03                                            shl     eax, 3
.text:005EB815 2B C1                                               sub     eax, ecx
.text:005EB817 C1 E0 06                                            shl     eax, 6
.text:005EB81A 03 C1                                               add     eax, ecx
.text:005EB81C C1 E0 02                                            shl     eax, 2
.text:005EB81F C7 84 80 D8 B3 87 00 08 00 00 00                    mov     ds:dword_87B3D8[eax+eax*4], 8
.text:005EB82A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB82D 8B C8                                               mov     ecx, eax
.text:005EB82F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB832 C1 E0 03                                            shl     eax, 3
.text:005EB835 2B C1                                               sub     eax, ecx
.text:005EB837 C1 E0 06                                            shl     eax, 6
.text:005EB83A 03 C1                                               add     eax, ecx
.text:005EB83C C1 E0 02                                            shl     eax, 2
.text:005EB83F C7 84 80 18 BA 87 00 07 00 00 00                    mov     ds:dword_87BA18[eax+eax*4], 7
.text:005EB84A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB84D 8B C8                                               mov     ecx, eax
.text:005EB84F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB852 C1 E0 03                                            shl     eax, 3
.text:005EB855 2B C1                                               sub     eax, ecx
.text:005EB857 C1 E0 06                                            shl     eax, 6
.text:005EB85A 03 C1                                               add     eax, ecx
.text:005EB85C C1 E0 02                                            shl     eax, 2
.text:005EB85F C7 84 80 58 C0 87 00 05 00 00 00                    mov     ds:dword_87C058[eax+eax*4], 5
.text:005EB86A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB86D 8B C8                                               mov     ecx, eax
.text:005EB86F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB872 C1 E0 03                                            shl     eax, 3
.text:005EB875 2B C1                                               sub     eax, ecx
.text:005EB877 C1 E0 06                                            shl     eax, 6
.text:005EB87A 03 C1                                               add     eax, ecx
.text:005EB87C C1 E0 02                                            shl     eax, 2
.text:005EB87F C7 84 80 98 C6 87 00 04 00 00 00                    mov     ds:dword_87C698[eax+eax*4], 4
.text:005EB88A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB88D 8B C8                                               mov     ecx, eax
.text:005EB88F 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB892 C1 E0 03                                            shl     eax, 3
.text:005EB895 2B C1                                               sub     eax, ecx
.text:005EB897 C1 E0 06                                            shl     eax, 6
.text:005EB89A 03 C1                                               add     eax, ecx
.text:005EB89C C1 E0 02                                            shl     eax, 2
.text:005EB89F C7 84 80 18 A1 87 00 00 00 00 00                    mov     ds:dword_87A118[eax+eax*4], 0
.text:005EB8AA C7 05 18 99 7E 00 08 00 00 00                       mov     ds:dword_7E9918, 8
.text:005EB8B4 C7 05 28 99 7E 00 07 00 00 00                       mov     ds:dword_7E9928, 7
.text:005EB8BE C7 05 38 99 7E 00 05 00 00 00                       mov     ds:dword_7E9938, 5
.text:005EB8C8 C7 05 48 99 7E 00 04 00 00 00                       mov     ds:dword_7E9948, 4
.text:005EB8D2 E9 C8 05 00 00                                      jmp     loc_5EBE9F
.text:005EB8D7                                     ; ---------------------------------------------------------------------------
.text:005EB8D7
.text:005EB8D7                                     loc_5EB8D7:                             ; CODE XREF: sub_5EB4E3+9A7j
.text:005EB8D7 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB8DA 8B C8                                               mov     ecx, eax
.text:005EB8DC 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB8DF C1 E0 03                                            shl     eax, 3
.text:005EB8E2 2B C1                                               sub     eax, ecx
.text:005EB8E4 C1 E0 06                                            shl     eax, 6
.text:005EB8E7 03 C1                                               add     eax, ecx
.text:005EB8E9 C1 E0 02                                            shl     eax, 2
.text:005EB8EC C7 84 80 28 AF 87 00 06 00 00 00                    mov     ds:dword_87AF28[eax+eax*4], 6
.text:005EB8F7 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB8FA 8B C8                                               mov     ecx, eax
.text:005EB8FC 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB8FF C1 E0 03                                            shl     eax, 3
.text:005EB902 2B C1                                               sub     eax, ecx
.text:005EB904 C1 E0 06                                            shl     eax, 6
.text:005EB907 03 C1                                               add     eax, ecx
.text:005EB909 C1 E0 02                                            shl     eax, 2
.text:005EB90C C7 84 80 68 B5 87 00 08 00 00 00                    mov     ds:dword_87B568[eax+eax*4], 8
.text:005EB917 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB91A 8B C8                                               mov     ecx, eax
.text:005EB91C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB91F C1 E0 03                                            shl     eax, 3
.text:005EB922 2B C1                                               sub     eax, ecx
.text:005EB924 C1 E0 06                                            shl     eax, 6
.text:005EB927 03 C1                                               add     eax, ecx
.text:005EB929 C1 E0 02                                            shl     eax, 2
.text:005EB92C C7 84 80 A8 BB 87 00 06 00 00 00                    mov     ds:dword_87BBA8[eax+eax*4], 6
.text:005EB937 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB93A 8B C8                                               mov     ecx, eax
.text:005EB93C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB93F C1 E0 03                                            shl     eax, 3
.text:005EB942 2B C1                                               sub     eax, ecx
.text:005EB944 C1 E0 06                                            shl     eax, 6
.text:005EB947 03 C1                                               add     eax, ecx
.text:005EB949 C1 E0 02                                            shl     eax, 2
.text:005EB94C C7 84 80 E8 C1 87 00 04 00 00 00                    mov     ds:dword_87C1E8[eax+eax*4], 4
.text:005EB957 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB95A 8B C8                                               mov     ecx, eax
.text:005EB95C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB95F C1 E0 03                                            shl     eax, 3
.text:005EB962 2B C1                                               sub     eax, ecx
.text:005EB964 C1 E0 06                                            shl     eax, 6
.text:005EB967 03 C1                                               add     eax, ecx
.text:005EB969 C1 E0 02                                            shl     eax, 2
.text:005EB96C C7 84 80 68 9C 87 00 00 00 00 00                    mov     ds:dword_879C68[eax+eax*4], 0
.text:005EB977 C7 05 F8 92 7E 00 06 00 00 00                       mov     ds:dword_7E92F8, 6
.text:005EB981 C7 05 08 93 7E 00 08 00 00 00                       mov     ds:dword_7E9308, 8
.text:005EB98B C7 05 18 93 7E 00 06 00 00 00                       mov     ds:dword_7E9318, 6
.text:005EB995 C7 05 28 93 7E 00 04 00 00 00                       mov     ds:dword_7E9328, 4
.text:005EB99F 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB9A2 8B C8                                               mov     ecx, eax
.text:005EB9A4 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB9A7 C1 E0 03                                            shl     eax, 3
.text:005EB9AA 2B C1                                               sub     eax, ecx
.text:005EB9AC C1 E0 06                                            shl     eax, 6
.text:005EB9AF 03 C1                                               add     eax, ecx
.text:005EB9B1 C1 E0 02                                            shl     eax, 2
.text:005EB9B4 C7 84 80 B8 B0 87 00 08 00 00 00                    mov     ds:dword_87B0B8[eax+eax*4], 8
.text:005EB9BF 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB9C2 8B C8                                               mov     ecx, eax
.text:005EB9C4 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB9C7 C1 E0 03                                            shl     eax, 3
.text:005EB9CA 2B C1                                               sub     eax, ecx
.text:005EB9CC C1 E0 06                                            shl     eax, 6
.text:005EB9CF 03 C1                                               add     eax, ecx
.text:005EB9D1 C1 E0 02                                            shl     eax, 2
.text:005EB9D4 C7 84 80 F8 B6 87 00 06 00 00 00                    mov     ds:dword_87B6F8[eax+eax*4], 6
.text:005EB9DF 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EB9E2 8B C8                                               mov     ecx, eax
.text:005EB9E4 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EB9E7 C1 E0 03                                            shl     eax, 3
.text:005EB9EA 2B C1                                               sub     eax, ecx
.text:005EB9EC C1 E0 06                                            shl     eax, 6
.text:005EB9EF 03 C1                                               add     eax, ecx
.text:005EB9F1 C1 E0 02                                            shl     eax, 2
.text:005EB9F4 C7 84 80 38 BD 87 00 05 00 00 00                    mov     ds:dword_87BD38[eax+eax*4], 5
.text:005EB9FF 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBA02 8B C8                                               mov     ecx, eax
.text:005EBA04 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBA07 C1 E0 03                                            shl     eax, 3
.text:005EBA0A 2B C1                                               sub     eax, ecx
.text:005EBA0C C1 E0 06                                            shl     eax, 6
.text:005EBA0F 03 C1                                               add     eax, ecx
.text:005EBA11 C1 E0 02                                            shl     eax, 2
.text:005EBA14 C7 84 80 78 C3 87 00 05 00 00 00                    mov     ds:dword_87C378[eax+eax*4], 5
.text:005EBA1F 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBA22 8B C8                                               mov     ecx, eax
.text:005EBA24 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBA27 C1 E0 03                                            shl     eax, 3
.text:005EBA2A 2B C1                                               sub     eax, ecx
.text:005EBA2C C1 E0 06                                            shl     eax, 6
.text:005EBA2F 03 C1                                               add     eax, ecx
.text:005EBA31 C1 E0 02                                            shl     eax, 2
.text:005EBA34 C7 84 80 F8 9D 87 00 00 00 00 00                    mov     ds:dword_879DF8[eax+eax*4], 0
.text:005EBA3F C7 05 FC 92 7E 00 08 00 00 00                       mov     ds:dword_7E92FC, 8
.text:005EBA49 C7 05 0C 93 7E 00 06 00 00 00                       mov     ds:dword_7E930C, 6
.text:005EBA53 C7 05 1C 93 7E 00 05 00 00 00                       mov     ds:dword_7E931C, 5
.text:005EBA5D C7 05 2C 93 7E 00 05 00 00 00                       mov     ds:dword_7E932C, 5
.text:005EBA67 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBA6A 8B C8                                               mov     ecx, eax
.text:005EBA6C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBA6F C1 E0 03                                            shl     eax, 3
.text:005EBA72 2B C1                                               sub     eax, ecx
.text:005EBA74 C1 E0 06                                            shl     eax, 6
.text:005EBA77 03 C1                                               add     eax, ecx
.text:005EBA79 C1 E0 02                                            shl     eax, 2
.text:005EBA7C C7 84 80 48 B2 87 00 05 00 00 00                    mov     ds:dword_87B248[eax+eax*4], 5
.text:005EBA87 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBA8A 8B C8                                               mov     ecx, eax
.text:005EBA8C 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBA8F C1 E0 03                                            shl     eax, 3
.text:005EBA92 2B C1                                               sub     eax, ecx
.text:005EBA94 C1 E0 06                                            shl     eax, 6
.text:005EBA97 03 C1                                               add     eax, ecx
.text:005EBA99 C1 E0 02                                            shl     eax, 2
.text:005EBA9C C7 84 80 88 B8 87 00 07 00 00 00                    mov     ds:dword_87B888[eax+eax*4], 7
.text:005EBAA7 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBAAA 8B C8                                               mov     ecx, eax
.text:005EBAAC 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBAAF C1 E0 03                                            shl     eax, 3
.text:005EBAB2 2B C1                                               sub     eax, ecx
.text:005EBAB4 C1 E0 06                                            shl     eax, 6
.text:005EBAB7 03 C1                                               add     eax, ecx
.text:005EBAB9 C1 E0 02                                            shl     eax, 2
.text:005EBABC C7 84 80 C8 BE 87 00 05 00 00 00                    mov     ds:dword_87BEC8[eax+eax*4], 5
.text:005EBAC7 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBACA 8B C8                                               mov     ecx, eax
.text:005EBACC 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBACF C1 E0 03                                            shl     eax, 3
.text:005EBAD2 2B C1                                               sub     eax, ecx
.text:005EBAD4 C1 E0 06                                            shl     eax, 6
.text:005EBAD7 03 C1                                               add     eax, ecx
.text:005EBAD9 C1 E0 02                                            shl     eax, 2
.text:005EBADC C7 84 80 08 C5 87 00 07 00 00 00                    mov     ds:dword_87C508[eax+eax*4], 7
.text:005EBAE7 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBAEA 8B C8                                               mov     ecx, eax
.text:005EBAEC 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBAEF C1 E0 03                                            shl     eax, 3
.text:005EBAF2 2B C1                                               sub     eax, ecx
.text:005EBAF4 C1 E0 06                                            shl     eax, 6
.text:005EBAF7 03 C1                                               add     eax, ecx
.text:005EBAF9 C1 E0 02                                            shl     eax, 2
.text:005EBAFC C7 84 80 88 9F 87 00 00 00 00 00                    mov     ds:dword_879F88[eax+eax*4], 0
.text:005EBB07 C7 05 00 93 7E 00 05 00 00 00                       mov     ds:dword_7E9300, 5
.text:005EBB11 C7 05 10 93 7E 00 07 00 00 00                       mov     ds:dword_7E9310, 7
.text:005EBB1B C7 05 20 93 7E 00 05 00 00 00                       mov     ds:dword_7E9320, 5
.text:005EBB25 C7 05 30 93 7E 00 07 00 00 00                       mov     ds:dword_7E9330, 7
.text:005EBB2F 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBB32 8B C8                                               mov     ecx, eax
.text:005EBB34 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBB37 C1 E0 03                                            shl     eax, 3
.text:005EBB3A 2B C1                                               sub     eax, ecx
.text:005EBB3C C1 E0 06                                            shl     eax, 6
.text:005EBB3F 03 C1                                               add     eax, ecx
.text:005EBB41 C1 E0 02                                            shl     eax, 2
.text:005EBB44 C7 84 80 D8 B3 87 00 05 00 00 00                    mov     ds:dword_87B3D8[eax+eax*4], 5
.text:005EBB4F 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBB52 8B C8                                               mov     ecx, eax
.text:005EBB54 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBB57 C1 E0 03                                            shl     eax, 3
.text:005EBB5A 2B C1                                               sub     eax, ecx
.text:005EBB5C C1 E0 06                                            shl     eax, 6
.text:005EBB5F 03 C1                                               add     eax, ecx
.text:005EBB61 C1 E0 02                                            shl     eax, 2
.text:005EBB64 C7 84 80 18 BA 87 00 07 00 00 00                    mov     ds:dword_87BA18[eax+eax*4], 7
.text:005EBB6F 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBB72 8B C8                                               mov     ecx, eax
.text:005EBB74 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBB77 C1 E0 03                                            shl     eax, 3
.text:005EBB7A 2B C1                                               sub     eax, ecx
.text:005EBB7C C1 E0 06                                            shl     eax, 6
.text:005EBB7F 03 C1                                               add     eax, ecx
.text:005EBB81 C1 E0 02                                            shl     eax, 2
.text:005EBB84 C7 84 80 58 C0 87 00 06 00 00 00                    mov     ds:dword_87C058[eax+eax*4], 6
.text:005EBB8F 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBB92 8B C8                                               mov     ecx, eax
.text:005EBB94 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBB97 C1 E0 03                                            shl     eax, 3
.text:005EBB9A 2B C1                                               sub     eax, ecx
.text:005EBB9C C1 E0 06                                            shl     eax, 6
.text:005EBB9F 03 C1                                               add     eax, ecx
.text:005EBBA1 C1 E0 02                                            shl     eax, 2
.text:005EBBA4 C7 84 80 98 C6 87 00 06 00 00 00                    mov     ds:dword_87C698[eax+eax*4], 6
.text:005EBBAF 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBBB2 8B C8                                               mov     ecx, eax
.text:005EBBB4 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBBB7 C1 E0 03                                            shl     eax, 3
.text:005EBBBA 2B C1                                               sub     eax, ecx
.text:005EBBBC C1 E0 06                                            shl     eax, 6
.text:005EBBBF 03 C1                                               add     eax, ecx
.text:005EBBC1 C1 E0 02                                            shl     eax, 2
.text:005EBBC4 C7 84 80 18 A1 87 00 00 00 00 00                    mov     ds:dword_87A118[eax+eax*4], 0
.text:005EBBCF C7 05 04 93 7E 00 05 00 00 00                       mov     ds:dword_7E9304, 5
.text:005EBBD9 C7 05 14 93 7E 00 07 00 00 00                       mov     ds:dword_7E9314, 7
.text:005EBBE3 C7 05 24 93 7E 00 06 00 00 00                       mov     ds:dword_7E9324, 6
.text:005EBBED C7 05 34 93 7E 00 06 00 00 00                       mov     ds:dword_7E9334, 6
.text:005EBBF7 E9 A3 02 00 00                                      jmp     loc_5EBE9F
.text:005EBBFC                                     ; ---------------------------------------------------------------------------
.text:005EBBFC
.text:005EBBFC                                     loc_5EBBFC:                             ; CODE XREF: sub_5EB4E3+9B7j
.text:005EBBFC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBBFF 8B C8                                               mov     ecx, eax
.text:005EBC01 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBC04 C1 E0 03                                            shl     eax, 3
.text:005EBC07 2B C1                                               sub     eax, ecx
.text:005EBC09 C1 E0 06                                            shl     eax, 6
.text:005EBC0C 03 C1                                               add     eax, ecx
.text:005EBC0E C1 E0 02                                            shl     eax, 2
.text:005EBC11 C7 84 80 28 AF 87 00 04 00 00 00                    mov     ds:dword_87AF28[eax+eax*4], 4
.text:005EBC1C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBC1F 8B C8                                               mov     ecx, eax
.text:005EBC21 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBC24 C1 E0 03                                            shl     eax, 3
.text:005EBC27 2B C1                                               sub     eax, ecx
.text:005EBC29 C1 E0 06                                            shl     eax, 6
.text:005EBC2C 03 C1                                               add     eax, ecx
.text:005EBC2E C1 E0 02                                            shl     eax, 2
.text:005EBC31 C7 84 80 68 B5 87 00 07 00 00 00                    mov     ds:dword_87B568[eax+eax*4], 7
.text:005EBC3C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBC3F 8B C8                                               mov     ecx, eax
.text:005EBC41 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBC44 C1 E0 03                                            shl     eax, 3
.text:005EBC47 2B C1                                               sub     eax, ecx
.text:005EBC49 C1 E0 06                                            shl     eax, 6
.text:005EBC4C 03 C1                                               add     eax, ecx
.text:005EBC4E C1 E0 02                                            shl     eax, 2
.text:005EBC51 C7 84 80 A8 BB 87 00 08 00 00 00                    mov     ds:dword_87BBA8[eax+eax*4], 8
.text:005EBC5C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBC5F 8B C8                                               mov     ecx, eax
.text:005EBC61 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBC64 C1 E0 03                                            shl     eax, 3
.text:005EBC67 2B C1                                               sub     eax, ecx
.text:005EBC69 C1 E0 06                                            shl     eax, 6
.text:005EBC6C 03 C1                                               add     eax, ecx
.text:005EBC6E C1 E0 02                                            shl     eax, 2
.text:005EBC71 C7 84 80 E8 C1 87 00 05 00 00 00                    mov     ds:dword_87C1E8[eax+eax*4], 5
.text:005EBC7C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBC7F 8B C8                                               mov     ecx, eax
.text:005EBC81 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBC84 C1 E0 03                                            shl     eax, 3
.text:005EBC87 2B C1                                               sub     eax, ecx
.text:005EBC89 C1 E0 06                                            shl     eax, 6
.text:005EBC8C 03 C1                                               add     eax, ecx
.text:005EBC8E C1 E0 02                                            shl     eax, 2
.text:005EBC91 C7 84 80 68 9C 87 00 00 00 00 00                    mov     ds:dword_879C68[eax+eax*4], 0
.text:005EBC9C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBC9F 8B C8                                               mov     ecx, eax
.text:005EBCA1 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBCA4 C1 E0 03                                            shl     eax, 3
.text:005EBCA7 2B C1                                               sub     eax, ecx
.text:005EBCA9 C1 E0 06                                            shl     eax, 6
.text:005EBCAC 03 C1                                               add     eax, ecx
.text:005EBCAE C1 E0 02                                            shl     eax, 2
.text:005EBCB1 C7 84 80 B8 B0 87 00 06 00 00 00                    mov     ds:dword_87B0B8[eax+eax*4], 6
.text:005EBCBC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBCBF 8B C8                                               mov     ecx, eax
.text:005EBCC1 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBCC4 C1 E0 03                                            shl     eax, 3
.text:005EBCC7 2B C1                                               sub     eax, ecx
.text:005EBCC9 C1 E0 06                                            shl     eax, 6
.text:005EBCCC 03 C1                                               add     eax, ecx
.text:005EBCCE C1 E0 02                                            shl     eax, 2
.text:005EBCD1 C7 84 80 F8 B6 87 00 04 00 00 00                    mov     ds:dword_87B6F8[eax+eax*4], 4
.text:005EBCDC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBCDF 8B C8                                               mov     ecx, eax
.text:005EBCE1 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBCE4 C1 E0 03                                            shl     eax, 3
.text:005EBCE7 2B C1                                               sub     eax, ecx
.text:005EBCE9 C1 E0 06                                            shl     eax, 6
.text:005EBCEC 03 C1                                               add     eax, ecx
.text:005EBCEE C1 E0 02                                            shl     eax, 2
.text:005EBCF1 C7 84 80 38 BD 87 00 08 00 00 00                    mov     ds:dword_87BD38[eax+eax*4], 8
.text:005EBCFC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBCFF 8B C8                                               mov     ecx, eax
.text:005EBD01 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBD04 C1 E0 03                                            shl     eax, 3
.text:005EBD07 2B C1                                               sub     eax, ecx
.text:005EBD09 C1 E0 06                                            shl     eax, 6
.text:005EBD0C 03 C1                                               add     eax, ecx
.text:005EBD0E C1 E0 02                                            shl     eax, 2
.text:005EBD11 C7 84 80 78 C3 87 00 06 00 00 00                    mov     ds:dword_87C378[eax+eax*4], 6
.text:005EBD1C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBD1F 8B C8                                               mov     ecx, eax
.text:005EBD21 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBD24 C1 E0 03                                            shl     eax, 3
.text:005EBD27 2B C1                                               sub     eax, ecx
.text:005EBD29 C1 E0 06                                            shl     eax, 6
.text:005EBD2C 03 C1                                               add     eax, ecx
.text:005EBD2E C1 E0 02                                            shl     eax, 2
.text:005EBD31 C7 84 80 F8 9D 87 00 00 00 00 00                    mov     ds:dword_879DF8[eax+eax*4], 0
.text:005EBD3C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBD3F 8B C8                                               mov     ecx, eax
.text:005EBD41 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBD44 C1 E0 03                                            shl     eax, 3
.text:005EBD47 2B C1                                               sub     eax, ecx
.text:005EBD49 C1 E0 06                                            shl     eax, 6
.text:005EBD4C 03 C1                                               add     eax, ecx
.text:005EBD4E C1 E0 02                                            shl     eax, 2
.text:005EBD51 C7 84 80 48 B2 87 00 05 00 00 00                    mov     ds:dword_87B248[eax+eax*4], 5
.text:005EBD5C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBD5F 8B C8                                               mov     ecx, eax
.text:005EBD61 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBD64 C1 E0 03                                            shl     eax, 3
.text:005EBD67 2B C1                                               sub     eax, ecx
.text:005EBD69 C1 E0 06                                            shl     eax, 6
.text:005EBD6C 03 C1                                               add     eax, ecx
.text:005EBD6E C1 E0 02                                            shl     eax, 2
.text:005EBD71 C7 84 80 88 B8 87 00 06 00 00 00                    mov     ds:dword_87B888[eax+eax*4], 6
.text:005EBD7C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBD7F 8B C8                                               mov     ecx, eax
.text:005EBD81 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBD84 C1 E0 03                                            shl     eax, 3
.text:005EBD87 2B C1                                               sub     eax, ecx
.text:005EBD89 C1 E0 06                                            shl     eax, 6
.text:005EBD8C 03 C1                                               add     eax, ecx
.text:005EBD8E C1 E0 02                                            shl     eax, 2
.text:005EBD91 C7 84 80 C8 BE 87 00 07 00 00 00                    mov     ds:dword_87BEC8[eax+eax*4], 7
.text:005EBD9C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBD9F 8B C8                                               mov     ecx, eax
.text:005EBDA1 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBDA4 C1 E0 03                                            shl     eax, 3
.text:005EBDA7 2B C1                                               sub     eax, ecx
.text:005EBDA9 C1 E0 06                                            shl     eax, 6
.text:005EBDAC 03 C1                                               add     eax, ecx
.text:005EBDAE C1 E0 02                                            shl     eax, 2
.text:005EBDB1 C7 84 80 08 C5 87 00 06 00 00 00                    mov     ds:dword_87C508[eax+eax*4], 6
.text:005EBDBC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBDBF 8B C8                                               mov     ecx, eax
.text:005EBDC1 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBDC4 C1 E0 03                                            shl     eax, 3
.text:005EBDC7 2B C1                                               sub     eax, ecx
.text:005EBDC9 C1 E0 06                                            shl     eax, 6
.text:005EBDCC 03 C1                                               add     eax, ecx
.text:005EBDCE C1 E0 02                                            shl     eax, 2
.text:005EBDD1 C7 84 80 88 9F 87 00 00 00 00 00                    mov     ds:dword_879F88[eax+eax*4], 0
.text:005EBDDC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBDDF 8B C8                                               mov     ecx, eax
.text:005EBDE1 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBDE4 C1 E0 03                                            shl     eax, 3
.text:005EBDE7 2B C1                                               sub     eax, ecx
.text:005EBDE9 C1 E0 06                                            shl     eax, 6
.text:005EBDEC 03 C1                                               add     eax, ecx
.text:005EBDEE C1 E0 02                                            shl     eax, 2
.text:005EBDF1 C7 84 80 D8 B3 87 00 06 00 00 00                    mov     ds:dword_87B3D8[eax+eax*4], 6
.text:005EBDFC 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBDFF 8B C8                                               mov     ecx, eax
.text:005EBE01 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBE04 C1 E0 03                                            shl     eax, 3
.text:005EBE07 2B C1                                               sub     eax, ecx
.text:005EBE09 C1 E0 06                                            shl     eax, 6
.text:005EBE0C 03 C1                                               add     eax, ecx
.text:005EBE0E C1 E0 02                                            shl     eax, 2
.text:005EBE11 C7 84 80 18 BA 87 00 06 00 00 00                    mov     ds:dword_87BA18[eax+eax*4], 6
.text:005EBE1C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBE1F 8B C8                                               mov     ecx, eax
.text:005EBE21 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBE24 C1 E0 03                                            shl     eax, 3
.text:005EBE27 2B C1                                               sub     eax, ecx
.text:005EBE29 C1 E0 06                                            shl     eax, 6
.text:005EBE2C 03 C1                                               add     eax, ecx
.text:005EBE2E C1 E0 02                                            shl     eax, 2
.text:005EBE31 C7 84 80 58 C0 87 00 07 00 00 00                    mov     ds:dword_87C058[eax+eax*4], 7
.text:005EBE3C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBE3F 8B C8                                               mov     ecx, eax
.text:005EBE41 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBE44 C1 E0 03                                            shl     eax, 3
.text:005EBE47 2B C1                                               sub     eax, ecx
.text:005EBE49 C1 E0 06                                            shl     eax, 6
.text:005EBE4C 03 C1                                               add     eax, ecx
.text:005EBE4E C1 E0 02                                            shl     eax, 2
.text:005EBE51 C7 84 80 98 C6 87 00 05 00 00 00                    mov     ds:dword_87C698[eax+eax*4], 5
.text:005EBE5C 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBE5F 8B C8                                               mov     ecx, eax
.text:005EBE61 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBE64 C1 E0 03                                            shl     eax, 3
.text:005EBE67 2B C1                                               sub     eax, ecx
.text:005EBE69 C1 E0 06                                            shl     eax, 6
.text:005EBE6C 03 C1                                               add     eax, ecx
.text:005EBE6E C1 E0 02                                            shl     eax, 2
.text:005EBE71 C7 84 80 18 A1 87 00 00 00 00 00                    mov     ds:dword_87A118[eax+eax*4], 0
.text:005EBE7C E9 1E 00 00 00                                      jmp     loc_5EBE9F
.text:005EBE81                                     ; ---------------------------------------------------------------------------
.text:005EBE81 E9 19 00 00 00                                      jmp     loc_5EBE9F
.text:005EBE86                                     ; ---------------------------------------------------------------------------
.text:005EBE86
.text:005EBE86                                     loc_5EBE86:                             ; CODE XREF: sub_5EB4E3+CAj
.text:005EBE86 83 7D F0 08                                         cmp     [ebp+var_10], 8
.text:005EBE8A 0F 84 47 FA FF FF                                   jz      loc_5EB8D7
.text:005EBE90 83 7D F0 09                                         cmp     [ebp+var_10], 9
.text:005EBE94 0F 84 18 F7 FF FF                                   jz      loc_5EB5B2
.text:005EBE9A E9 5D FD FF FF                                      jmp     loc_5EBBFC
.text:005EBE9F                                     ; ---------------------------------------------------------------------------
.text:005EBE9F
.text:005EBE9F                                     loc_5EBE9F:                             ; CODE XREF: sub_5EB4E3+3EFj
.text:005EBE9F                                                                             ; sub_5EB4E3+714j ...
.text:005EBE9F E9 59 F6 FF FF                                      jmp     loc_5EB4FD
.text:005EBEA4                                     ; ---------------------------------------------------------------------------
.text:005EBEA4
.text:005EBEA4                                     loc_5EBEA4:                             ; CODE XREF: sub_5EB4E3+21j
.text:005EBEA4 C7 05 20 9F 7E 00 04 00 00 00                       mov     ds:dword_7E9F20, 4
.text:005EBEAE C7 05 30 9F 7E 00 07 00 00 00                       mov     ds:dword_7E9F30, 7
.text:005EBEB8 C7 05 40 9F 7E 00 08 00 00 00                       mov     ds:dword_7E9F40, 8
.text:005EBEC2 C7 05 50 9F 7E 00 05 00 00 00                       mov     ds:dword_7E9F50, 5
.text:005EBECC C7 05 24 9F 7E 00 06 00 00 00                       mov     ds:dword_7E9F24, 6
.text:005EBED6 C7 05 34 9F 7E 00 04 00 00 00                       mov     ds:dword_7E9F34, 4
.text:005EBEE0 C7 05 44 9F 7E 00 08 00 00 00                       mov     ds:dword_7E9F44, 8
.text:005EBEEA C7 05 54 9F 7E 00 06 00 00 00                       mov     ds:dword_7E9F54, 6
.text:005EBEF4 C7 05 28 9F 7E 00 05 00 00 00                       mov     ds:dword_7E9F28, 5
.text:005EBEFE C7 05 38 9F 7E 00 06 00 00 00                       mov     ds:dword_7E9F38, 6
.text:005EBF08 C7 05 48 9F 7E 00 07 00 00 00                       mov     ds:dword_7E9F48, 7
.text:005EBF12 C7 05 58 9F 7E 00 06 00 00 00                       mov     ds:dword_7E9F58, 6
.text:005EBF1C C7 05 2C 9F 7E 00 06 00 00 00                       mov     ds:dword_7E9F2C, 6
.text:005EBF26 C7 05 3C 9F 7E 00 06 00 00 00                       mov     ds:dword_7E9F3C, 6
.text:005EBF30 C7 05 4C 9F 7E 00 07 00 00 00                       mov     ds:dword_7E9F4C, 7
.text:005EBF3A C7 05 5C 9F 7E 00 05 00 00 00                       mov     ds:dword_7E9F5C, 5
.text:005EBF44 E8 61 6A E1 FF                                      call    sub_4029AA
.text:005EBF49 C7 45 F8 01 00 00 00                                mov     [ebp+var_8], 1
.text:005EBF50 E9 03 00 00 00                                      jmp     loc_5EBF58
.text:005EBF55                                     ; ---------------------------------------------------------------------------
.text:005EBF55
.text:005EBF55                                     loc_5EBF55:                             ; CODE XREF: sub_5EB4E3+AA6j
.text:005EBF55                                                                             ; sub_5EB4E3+AB5j ...
.text:005EBF55 FF 45 F8                                            inc     [ebp+var_8]
.text:005EBF58
.text:005EBF58                                     loc_5EBF58:                             ; CODE XREF: sub_5EB4E3+A6Dj
.text:005EBF58 83 7D F8 0C                                         cmp     [ebp+var_8], 0Ch
.text:005EBF5C 0F 8D C0 00 00 00                                   jge     loc_5EC022
.text:005EBF62 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBF65 8B C8                                               mov     ecx, eax
.text:005EBF67 8D 04 C0                                            lea     eax, [eax+eax*8]
.text:005EBF6A 8D 04 C0                                            lea     eax, [eax+eax*8]
.text:005EBF6D 8D 04 41                                            lea     eax, [ecx+eax*2]
.text:005EBF70 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBF73 C1 E0 04                                            shl     eax, 4
.text:005EBF76 8B 80 94 30 20 01                                   mov     eax, ds:dword_1203094[eax]
.text:005EBF7C 89 45 FC                                            mov     [ebp+var_4], eax
.text:005EBF7F 83 7D FC 0B                                         cmp     [ebp+var_4], 0Bh
.text:005EBF83 0F 8D 05 00 00 00                                   jge     loc_5EBF8E
.text:005EBF89 E9 C7 FF FF FF                                      jmp     loc_5EBF55
.text:005EBF8E                                     ; ---------------------------------------------------------------------------
.text:005EBF8E
.text:005EBF8E                                     loc_5EBF8E:                             ; CODE XREF: sub_5EB4E3+AA0j
.text:005EBF8E 83 7D FC 12                                         cmp     [ebp+var_4], 12h
.text:005EBF92 0F 8E 05 00 00 00                                   jle     loc_5EBF9D
.text:005EBF98 E9 B8 FF FF FF                                      jmp     loc_5EBF55
.text:005EBF9D                                     ; ---------------------------------------------------------------------------
.text:005EBF9D
.text:005EBF9D                                     loc_5EBF9D:                             ; CODE XREF: sub_5EB4E3+AAFj
.text:005EBF9D 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EBFA0 8B C8                                               mov     ecx, eax
.text:005EBFA2 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EBFA5 C1 E0 03                                            shl     eax, 3
.text:005EBFA8 2B C1                                               sub     eax, ecx
.text:005EBFAA C1 E0 06                                            shl     eax, 6
.text:005EBFAD 03 C1                                               add     eax, ecx
.text:005EBFAF C1 E0 02                                            shl     eax, 2
.text:005EBFB2 C7 84 80 58 E1 87 00 01 00 00 00                    mov     ds:dword_87E158[eax+eax*4], 1
.text:005EBFBD C7 45 F4 00 00 00 00                                mov     [ebp+var_C], 0
.text:005EBFC4 E9 03 00 00 00                                      jmp     loc_5EBFCC
.text:005EBFC9                                     ; ---------------------------------------------------------------------------
.text:005EBFC9
.text:005EBFC9                                     loc_5EBFC9:                             ; CODE XREF: sub_5EB4E3+B35j
.text:005EBFC9 FF 45 F4                                            inc     [ebp+var_C]
.text:005EBFCC
.text:005EBFCC                                     loc_5EBFCC:                             ; CODE XREF: sub_5EB4E3+AE1j
.text:005EBFCC 83 7D F4 07                                         cmp     [ebp+var_C], 7
.text:005EBFD0 0F 8D 47 00 00 00                                   jge     loc_5EC01D
.text:005EBFD6 8B 45 FC                                            mov     eax, [ebp+var_4]
.text:005EBFD9 83 E8 0B                                            sub     eax, 0Bh
.text:005EBFDC 8B C8                                               mov     ecx, eax
.text:005EBFDE C1 E0 03                                            shl     eax, 3
.text:005EBFE1 2B C1                                               sub     eax, ecx
.text:005EBFE3 03 45 F4                                            add     eax, [ebp+var_C]
.text:005EBFE6 8B 04 85 40 54 60 01                                mov     eax, dword_1605440[eax*4]
.text:005EBFED 8B 4D F4                                            mov     ecx, [ebp+var_C]
.text:005EBFF0 8D 0C 89                                            lea     ecx, [ecx+ecx*4]
.text:005EBFF3 8D 0C 89                                            lea     ecx, [ecx+ecx*4]
.text:005EBFF6 C1 E1 04                                            shl     ecx, 4
.text:005EBFF9 8B 55 F8                                            mov     edx, [ebp+var_8]
.text:005EBFFC 8B DA                                               mov     ebx, edx
.text:005EBFFE 8D 14 52                                            lea     edx, [edx+edx*2]
.text:005EC001 C1 E2 03                                            shl     edx, 3
.text:005EC004 2B D3                                               sub     edx, ebx
.text:005EC006 C1 E2 06                                            shl     edx, 6
.text:005EC009 03 D3                                               add     edx, ebx
.text:005EC00B C1 E2 02                                            shl     edx, 2
.text:005EC00E 8D 14 92                                            lea     edx, [edx+edx*4]
.text:005EC011 89 84 11 28 E9 87 00                                mov     ds:dword_87E928[ecx+edx], eax
.text:005EC018 E9 AC FF FF FF                                      jmp     loc_5EBFC9
.text:005EC01D                                     ; ---------------------------------------------------------------------------
.text:005EC01D
.text:005EC01D                                     loc_5EC01D:                             ; CODE XREF: sub_5EB4E3+AEDj
.text:005EC01D E9 33 FF FF FF                                      jmp     loc_5EBF55
.text:005EC022                                     ; ---------------------------------------------------------------------------
.text:005EC022
.text:005EC022                                     loc_5EC022:                             ; CODE XREF: sub_5EB4E3+A79j
.text:005EC022 C7 45 F8 0B 00 00 00                                mov     [ebp+var_8], 0Bh
.text:005EC029 E9 03 00 00 00                                      jmp     loc_5EC031
.text:005EC02E                                     ; ---------------------------------------------------------------------------
.text:005EC02E
.text:005EC02E                                     loc_5EC02E:                             ; CODE XREF: sub_5EB4E3+C8Cj
.text:005EC02E FF 45 F8                                            inc     [ebp+var_8]
.text:005EC031
.text:005EC031                                     loc_5EC031:                             ; CODE XREF: sub_5EB4E3+B46j
.text:005EC031 83 7D F8 12                                         cmp     [ebp+var_8], 12h
.text:005EC035 0F 8F 39 01 00 00                                   jg      loc_5EC174
.text:005EC03B 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC03E 83 E8 0B                                            sub     eax, 0Bh
.text:005EC041 8B C8                                               mov     ecx, eax
.text:005EC043 C1 E0 03                                            shl     eax, 3
.text:005EC046 2B C1                                               sub     eax, ecx
.text:005EC048 8B 04 85 40 54 60 01                                mov     eax, dword_1605440[eax*4]
.text:005EC04F 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC052 8B D1                                               mov     edx, ecx
.text:005EC054 C1 E1 03                                            shl     ecx, 3
.text:005EC057 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC05A 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC05D 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC060 89 04 8D 10 61 7E 00                                mov     ds:dword_7E6110[ecx*4], eax
.text:005EC067 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC06A 83 E8 0B                                            sub     eax, 0Bh
.text:005EC06D 8B C8                                               mov     ecx, eax
.text:005EC06F C1 E0 03                                            shl     eax, 3
.text:005EC072 2B C1                                               sub     eax, ecx
.text:005EC074 8B 04 85 44 54 60 01                                mov     eax, dword_1605444[eax*4]
.text:005EC07B 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC07E 8B D1                                               mov     edx, ecx
.text:005EC080 C1 E1 03                                            shl     ecx, 3
.text:005EC083 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC086 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC089 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC08C 89 04 8D 14 61 7E 00                                mov     ds:dword_7E6114[ecx*4], eax
.text:005EC093 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC096 83 E8 0B                                            sub     eax, 0Bh
.text:005EC099 8B C8                                               mov     ecx, eax
.text:005EC09B C1 E0 03                                            shl     eax, 3
.text:005EC09E 2B C1                                               sub     eax, ecx
.text:005EC0A0 8B 04 85 48 54 60 01                                mov     eax, dword_1605448[eax*4]
.text:005EC0A7 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC0AA 8B D1                                               mov     edx, ecx
.text:005EC0AC C1 E1 03                                            shl     ecx, 3
.text:005EC0AF 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC0B2 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC0B5 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC0B8 89 04 8D 18 61 7E 00                                mov     ds:dword_7E6118[ecx*4], eax
.text:005EC0BF 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC0C2 83 E8 0B                                            sub     eax, 0Bh
.text:005EC0C5 8B C8                                               mov     ecx, eax
.text:005EC0C7 C1 E0 03                                            shl     eax, 3
.text:005EC0CA 2B C1                                               sub     eax, ecx
.text:005EC0CC 8B 04 85 4C 54 60 01                                mov     eax, dword_160544C[eax*4]
.text:005EC0D3 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC0D6 8B D1                                               mov     edx, ecx
.text:005EC0D8 C1 E1 03                                            shl     ecx, 3
.text:005EC0DB 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC0DE 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC0E1 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC0E4 89 04 8D 1C 61 7E 00                                mov     ds:dword_7E611C[ecx*4], eax
.text:005EC0EB 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC0EE 83 E8 0B                                            sub     eax, 0Bh
.text:005EC0F1 8B C8                                               mov     ecx, eax
.text:005EC0F3 C1 E0 03                                            shl     eax, 3
.text:005EC0F6 2B C1                                               sub     eax, ecx
.text:005EC0F8 8B 04 85 50 54 60 01                                mov     eax, dword_1605450[eax*4]
.text:005EC0FF 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC102 8B D1                                               mov     edx, ecx
.text:005EC104 C1 E1 03                                            shl     ecx, 3
.text:005EC107 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC10A 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC10D 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC110 89 04 8D 20 61 7E 00                                mov     ds:dword_7E6120[ecx*4], eax
.text:005EC117 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC11A 83 E8 0B                                            sub     eax, 0Bh
.text:005EC11D 8B C8                                               mov     ecx, eax
.text:005EC11F C1 E0 03                                            shl     eax, 3
.text:005EC122 2B C1                                               sub     eax, ecx
.text:005EC124 8B 04 85 54 54 60 01                                mov     eax, dword_1605454[eax*4]
.text:005EC12B 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC12E 8B D1                                               mov     edx, ecx
.text:005EC130 C1 E1 03                                            shl     ecx, 3
.text:005EC133 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC136 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC139 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC13C 89 04 8D 24 61 7E 00                                mov     ds:dword_7E6124[ecx*4], eax
.text:005EC143 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC146 83 E8 0B                                            sub     eax, 0Bh
.text:005EC149 8B C8                                               mov     ecx, eax
.text:005EC14B C1 E0 03                                            shl     eax, 3
.text:005EC14E 2B C1                                               sub     eax, ecx
.text:005EC150 8B 04 85 58 54 60 01                                mov     eax, dword_1605458[eax*4]
.text:005EC157 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC15A 8B D1                                               mov     edx, ecx
.text:005EC15C C1 E1 03                                            shl     ecx, 3
.text:005EC15F 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC162 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC165 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC168 89 04 8D 28 61 7E 00                                mov     ds:dword_7E6128[ecx*4], eax
.text:005EC16F E9 BA FE FF FF                                      jmp     loc_5EC02E
.text:005EC174                                     ; ---------------------------------------------------------------------------
.text:005EC174
.text:005EC174                                     loc_5EC174:                             ; CODE XREF: sub_5EB4E3+B52j
.text:005EC174 E8 8F 64 E1 FF                                      call    sub_402608
.text:005EC179 C7 45 F8 01 00 00 00                                mov     [ebp+var_8], 1
.text:005EC180 E9 03 00 00 00                                      jmp     loc_5EC188
.text:005EC185                                     ; ---------------------------------------------------------------------------
.text:005EC185
.text:005EC185                                     loc_5EC185:                             ; CODE XREF: sub_5EB4E3+CD6j
.text:005EC185                                                                             ; sub_5EB4E3+CE5j ...
.text:005EC185 FF 45 F8                                            inc     [ebp+var_8]
.text:005EC188
.text:005EC188                                     loc_5EC188:                             ; CODE XREF: sub_5EB4E3+C9Dj
.text:005EC188 83 7D F8 0C                                         cmp     [ebp+var_8], 0Ch
.text:005EC18C 0F 8D BD 00 00 00                                   jge     loc_5EC24F
.text:005EC192 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC195 8B C8                                               mov     ecx, eax
.text:005EC197 8D 04 C0                                            lea     eax, [eax+eax*8]
.text:005EC19A 8D 04 C0                                            lea     eax, [eax+eax*8]
.text:005EC19D 8D 04 41                                            lea     eax, [ecx+eax*2]
.text:005EC1A0 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EC1A3 C1 E0 04                                            shl     eax, 4
.text:005EC1A6 8B 80 9C 30 20 01                                   mov     eax, ds:dword_120309C[eax]
.text:005EC1AC 89 45 FC                                            mov     [ebp+var_4], eax
.text:005EC1AF 83 7D FC 13                                         cmp     [ebp+var_4], 13h
.text:005EC1B3 0F 8D 05 00 00 00                                   jge     loc_5EC1BE
.text:005EC1B9 E9 C7 FF FF FF                                      jmp     loc_5EC185
.text:005EC1BE                                     ; ---------------------------------------------------------------------------
.text:005EC1BE
.text:005EC1BE                                     loc_5EC1BE:                             ; CODE XREF: sub_5EB4E3+CD0j
.text:005EC1BE 83 7D FC 1B                                         cmp     [ebp+var_4], 1Bh
.text:005EC1C2 0F 8E 05 00 00 00                                   jle     loc_5EC1CD
.text:005EC1C8 E9 B8 FF FF FF                                      jmp     loc_5EC185
.text:005EC1CD                                     ; ---------------------------------------------------------------------------
.text:005EC1CD
.text:005EC1CD                                     loc_5EC1CD:                             ; CODE XREF: sub_5EB4E3+CDFj
.text:005EC1CD 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC1D0 8B C8                                               mov     ecx, eax
.text:005EC1D2 8D 04 40                                            lea     eax, [eax+eax*2]
.text:005EC1D5 C1 E0 03                                            shl     eax, 3
.text:005EC1D8 2B C1                                               sub     eax, ecx
.text:005EC1DA C1 E0 06                                            shl     eax, 6
.text:005EC1DD 03 C1                                               add     eax, ecx
.text:005EC1DF C1 E0 02                                            shl     eax, 2
.text:005EC1E2 C7 84 80 E0 F5 87 00 01 00 00 00                    mov     ds:dword_87F5E0[eax+eax*4], 1
.text:005EC1ED C7 45 F4 00 00 00 00                                mov     [ebp+var_C], 0
.text:005EC1F4 E9 03 00 00 00                                      jmp     loc_5EC1FC
.text:005EC1F9                                     ; ---------------------------------------------------------------------------
.text:005EC1F9
.text:005EC1F9                                     loc_5EC1F9:                             ; CODE XREF: sub_5EB4E3+D62j
.text:005EC1F9 FF 45 F4                                            inc     [ebp+var_C]
.text:005EC1FC
.text:005EC1FC                                     loc_5EC1FC:                             ; CODE XREF: sub_5EB4E3+D11j
.text:005EC1FC 83 7D F4 02                                         cmp     [ebp+var_C], 2
.text:005EC200 0F 8D 44 00 00 00                                   jge     loc_5EC24A
.text:005EC206 8B 45 FC                                            mov     eax, [ebp+var_4]
.text:005EC209 8D 04 45 DA FF FF FF                                lea     eax, ds:0FFFFFFDAh[eax*2]
.text:005EC210 03 45 F4                                            add     eax, [ebp+var_C]
.text:005EC213 8B 04 85 20 55 60 01                                mov     eax, dword_1605520[eax*4]
.text:005EC21A 8B 4D F4                                            mov     ecx, [ebp+var_C]
.text:005EC21D 8D 0C 89                                            lea     ecx, [ecx+ecx*4]
.text:005EC220 8D 0C 89                                            lea     ecx, [ecx+ecx*4]
.text:005EC223 C1 E1 04                                            shl     ecx, 4
.text:005EC226 8B 55 F8                                            mov     edx, [ebp+var_8]
.text:005EC229 8B DA                                               mov     ebx, edx
.text:005EC22B 8D 14 52                                            lea     edx, [edx+edx*2]
.text:005EC22E C1 E2 03                                            shl     edx, 3
.text:005EC231 2B D3                                               sub     edx, ebx
.text:005EC233 C1 E2 06                                            shl     edx, 6
.text:005EC236 03 D3                                               add     edx, ebx
.text:005EC238 C1 E2 02                                            shl     edx, 2
.text:005EC23B 8D 14 92                                            lea     edx, [edx+edx*4]
.text:005EC23E 89 84 11 B0 FD 87 00                                mov     ds:dword_87FDB0[ecx+edx], eax
.text:005EC245 E9 AF FF FF FF                                      jmp     loc_5EC1F9
.text:005EC24A                                     ; ---------------------------------------------------------------------------
.text:005EC24A
.text:005EC24A                                     loc_5EC24A:                             ; CODE XREF: sub_5EB4E3+D1Dj
.text:005EC24A E9 36 FF FF FF                                      jmp     loc_5EC185
.text:005EC24F                                     ; ---------------------------------------------------------------------------
.text:005EC24F
.text:005EC24F                                     loc_5EC24F:                             ; CODE XREF: sub_5EB4E3+CA9j
.text:005EC24F C7 45 F8 13 00 00 00                                mov     [ebp+var_8], 13h
.text:005EC256 E9 03 00 00 00                                      jmp     loc_5EC25E
.text:005EC25B                                     ; ---------------------------------------------------------------------------
.text:005EC25B
.text:005EC25B                                     loc_5EC25B:                             ; CODE XREF: sub_5EB4E3+DC9j
.text:005EC25B FF 45 F8                                            inc     [ebp+var_8]
.text:005EC25E
.text:005EC25E                                     loc_5EC25E:                             ; CODE XREF: sub_5EB4E3+D73j
.text:005EC25E 83 7D F8 1B                                         cmp     [ebp+var_8], 1Bh
.text:005EC262 0F 8F 49 00 00 00                                   jg      loc_5EC2B1
.text:005EC268 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC26B 8B 04 C5 88 54 60 01                                mov     eax, dword_1605488[eax*8]
.text:005EC272 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC275 8B D1                                               mov     edx, ecx
.text:005EC277 C1 E1 03                                            shl     ecx, 3
.text:005EC27A 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC27D 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC280 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC283 89 04 8D 98 62 7E 00                                mov     ds:dword_7E6298[ecx*4], eax
.text:005EC28A 8B 45 F8                                            mov     eax, [ebp+var_8]
.text:005EC28D 8B 04 C5 8C 54 60 01                                mov     eax, dword_160548C[eax*8]
.text:005EC294 8B 4D F8                                            mov     ecx, [ebp+var_8]
.text:005EC297 8B D1                                               mov     edx, ecx
.text:005EC299 C1 E1 03                                            shl     ecx, 3
.text:005EC29C 8D 0C 49                                            lea     ecx, [ecx+ecx*2]
.text:005EC29F 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC2A2 8D 0C 8A                                            lea     ecx, [edx+ecx*4]
.text:005EC2A5 89 04 8D 9C 62 7E 00                                mov     ds:dword_7E629C[ecx*4], eax
.text:005EC2AC E9 AA FF FF FF                                      jmp     loc_5EC25B
.text:005EC2B1                                     ; ---------------------------------------------------------------------------
.text:005EC2B1
.text:005EC2B1                                     loc_5EC2B1:                             ; CODE XREF: sub_5EB4E3+D7Fj
.text:005EC2B1 5F                                                  pop     edi
.text:005EC2B2 5E                                                  pop     esi
.text:005EC2B3 5B                                                  pop     ebx
.text:005EC2B4 C9                                                  leave
.text:005EC2B5 C3                                                  retn
.text:005EC2B5                                     sub_5EB4E3      endp
.text:005EC2B5
 
 
int __cdecl sub_5EB4E3()
{
  int result; // eax@24
  signed int k; // [sp+10h] [bp-Ch]@17
  signed int n; // [sp+10h] [bp-Ch]@31
  signed int i; // [sp+14h] [bp-8h]@1
  signed int j; // [sp+14h] [bp-8h]@10
  signed int l; // [sp+14h] [bp-8h]@21
  signed int m; // [sp+14h] [bp-8h]@24
  signed int ii; // [sp+14h] [bp-8h]@35
  int v8; // [sp+18h] [bp-4h]@3
  int v9; // [sp+18h] [bp-4h]@13
  int v10; // [sp+18h] [bp-4h]@27

  sub_401E0B();
  for ( i = 1; i < 12; ++i )
  {
    v8 = dword_1204150[1956 * i];
    dword_878FE8[7365 * i] = 1;
    dword_879178[7365 * i] = 1;
    dword_879308[7365 * i] = 1;
    dword_879498[7365 * i] = 1;
    if ( v8 == 8 )
    {
      dword_87AF28[7365 * i] = 6;
      dword_87B568[7365 * i] = 8;
      dword_87BBA8[7365 * i] = 6;
      dword_87C1E8[7365 * i] = 4;
      dword_879C68[7365 * i] = 0;
      dword_7E92F8 = 6;
      dword_7E9308 = 8;
      dword_7E9318 = 6;
      dword_7E9328 = 4;
      dword_87B0B8[7365 * i] = 8;
      dword_87B6F8[7365 * i] = 6;
      dword_87BD38[7365 * i] = 5;
      dword_87C378[7365 * i] = 5;
      dword_879DF8[7365 * i] = 0;
      dword_7E92FC = 8;
      dword_7E930C = 6;
      dword_7E931C = 5;
      dword_7E932C = 5;
      dword_87B248[7365 * i] = 5;
      dword_87B888[7365 * i] = 7;
      dword_87BEC8[7365 * i] = 5;
      dword_87C508[7365 * i] = 7;
      dword_879F88[7365 * i] = 0;
      dword_7E9300 = 5;
      dword_7E9310 = 7;
      dword_7E9320 = 5;
      dword_7E9330 = 7;
      dword_87B3D8[7365 * i] = 5;
      dword_87BA18[7365 * i] = 7;
      dword_87C058[7365 * i] = 6;
      dword_87C698[7365 * i] = 6;
      dword_87A118[7365 * i] = 0;
      dword_7E9304 = 5;
      dword_7E9314 = 7;
      dword_7E9324 = 6;
      dword_7E9334 = 6;
    }
    else
    {
      if ( v8 == 9 )
      {
        dword_87AF28[7365 * i] = 5;
        dword_87B568[7365 * i] = 6;
        dword_87BBA8[7365 * i] = 6;
        dword_87C1E8[7365 * i] = 7;
        dword_879C68[7365 * i] = 0;
        dword_7E990C = 5;
        dword_7E991C = 6;
        dword_7E992C = 6;
        dword_7E993C = 7;
        dword_87B0B8[7365 * i] = 7;
        dword_87B6F8[7365 * i] = 5;
        dword_87BD38[7365 * i] = 5;
        dword_87C378[7365 * i] = 7;
        dword_879DF8[7365 * i] = 0;
        dword_7E9910 = 7;
        dword_7E9920 = 5;
        dword_7E9930 = 5;
        dword_7E9940 = 7;
        dword_87B248[7365 * i] = 6;
        dword_87B888[7365 * i] = 7;
        dword_87BEC8[7365 * i] = 6;
        dword_87C508[7365 * i] = 5;
        dword_879F88[7365 * i] = 0;
        dword_7E9914 = 6;
        dword_7E9924 = 7;
        dword_7E9934 = 6;
        dword_7E9944 = 5;
        dword_87B3D8[7365 * i] = 8;
        dword_87BA18[7365 * i] = 7;
        dword_87C058[7365 * i] = 5;
        dword_87C698[7365 * i] = 4;
        dword_87A118[7365 * i] = 0;
        dword_7E9918 = 8;
        dword_7E9928 = 7;
        dword_7E9938 = 5;
        dword_7E9948 = 4;
      }
      else
      {
        dword_87AF28[7365 * i] = 4;
        dword_87B568[7365 * i] = 7;
        dword_87BBA8[7365 * i] = 8;
        dword_87C1E8[7365 * i] = 5;
        dword_879C68[7365 * i] = 0;
        dword_87B0B8[7365 * i] = 6;
        dword_87B6F8[7365 * i] = 4;
        dword_87BD38[7365 * i] = 8;
        dword_87C378[7365 * i] = 6;
        dword_879DF8[7365 * i] = 0;
        dword_87B248[7365 * i] = 5;
        dword_87B888[7365 * i] = 6;
        dword_87BEC8[7365 * i] = 7;
        dword_87C508[7365 * i] = 6;
        dword_879F88[7365 * i] = 0;
        dword_87B3D8[7365 * i] = 6;
        dword_87BA18[7365 * i] = 6;
        dword_87C058[7365 * i] = 7;
        dword_87C698[7365 * i] = 5;
        dword_87A118[7365 * i] = 0;
      }
    }
  }
  dword_7E9F20 = 4;
  dword_7E9F30 = 7;
  dword_7E9F40 = 8;
  dword_7E9F50 = 5;
  dword_7E9F24 = 6;
  dword_7E9F34 = 4;
  dword_7E9F44 = 8;
  dword_7E9F54 = 6;
  dword_7E9F28 = 5;
  dword_7E9F38 = 6;
  dword_7E9F48 = 7;
  dword_7E9F58 = 6;
  dword_7E9F2C = 6;
  dword_7E9F3C = 6;
  dword_7E9F4C = 7;
  dword_7E9F5C = 5;
  sub_4029AA();
  for ( j = 1; j < 12; ++j )
  {
    v9 = dword_1203094[1956 * j];
    if ( v9 >= 11 )
    {
      if ( v9 <= 18 )
      {
        dword_87E158[7365 * j] = 1;
        for ( k = 0; k < 7; ++k )
          *(int *)((char *)&dword_87E928[7365 * j] + 400 * k) = dword_1605440[k + 7 * (v9 - 11)];
      }
    }
  }
  for ( l = 11; l <= 18; ++l )
  {
    dword_7E6110[389 * l] = dword_1605440[7 * (l - 11)];
    dword_7E6114[389 * l] = dword_1605444[7 * (l - 11)];
    dword_7E6118[389 * l] = dword_1605448[7 * (l - 11)];
    dword_7E611C[389 * l] = dword_160544C[7 * (l - 11)];
    dword_7E6120[389 * l] = dword_1605450[7 * (l - 11)];
    dword_7E6124[389 * l] = dword_1605454[7 * (l - 11)];
    dword_7E6128[389 * l] = dword_1605458[7 * (l - 11)];
  }
  result = sub_402608();
  for ( m = 1; m < 12; ++m )
  {
    result = dword_120309C[1956 * m];
    v10 = dword_120309C[1956 * m];
    if ( v10 >= 19 )
    {
      if ( v10 <= 27 )
      {
        result = 5892 * m;
        dword_87F5E0[7365 * m] = 1;
        for ( n = 0; n < 2; ++n )
        {
          result = dword_1605520[n + 2 * v10 - 38];
          *(int *)((char *)&dword_87FDB0[7365 * m] + 400 * n) = result;
        }
      }
    }
  }
  for ( ii = 19; ii <= 27; ++ii )
  {
    dword_7E6298[389 * ii] = dword_1605488[2 * ii];
    result = dword_160548C[2 * ii];
    dword_7E629C[389 * ii] = result;
  }
  return result;
}
*/
