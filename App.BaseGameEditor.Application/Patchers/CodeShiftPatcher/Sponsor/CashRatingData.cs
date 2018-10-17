namespace App.BaseGameEditor.Application.Patchers.CodeShiftPatcher.Sponsor
{
    internal class CashRatingData
    {
        public static byte[] GetInstructions()
        {
            // TODO: Update green instructions
            return new byte[]
            {
                0xC7, 0x05, 0xF8, 0x62, 0x7E, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 F8 62 7E 00 02 00 00 00 // mov     ds:dword_7E62F8, 2   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x0C, 0x69, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 0C 69 7E 00 03 00 00 00 // mov     ds:dword_7E690C, 3   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x20, 0x6F, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 20 6F 7E 00 05 00 00 00 // mov     ds:dword_7E6F20, 5   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x34, 0x75, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 34 75 7E 00 04 00 00 00 // mov     ds:dword_7E7534, 4   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x48, 0x7B, 0x7E, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 48 7B 7E 00 01 00 00 00 // mov     ds:dword_7E7B48, 1   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x5C, 0x81, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 5C 81 7E 00 05 00 00 00 // mov     ds:dword_7E815C, 5   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x70, 0x87, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 70 87 7E 00 05 00 00 00 // mov     ds:dword_7E8770, 5   // Team Sponsor Cash Rating
                0xC7, 0x05, 0x84, 0x8D, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 84 8D 7E 00 05 00 00 00 // mov     ds:dword_7E8D84, 5   // Tyre Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Tyre Supplier Cash Rating
                0xC7, 0x05, 0x98, 0x93, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 98 93 7E 00 04 00 00 00 // mov     ds:dword_7E9398, 4   // Tyre Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Tyre Supplier Cash Rating
                0x6A, 0x05,                                                 // 6A 05                         // push    5                    // Tyre Supplier Cash Rating
                0xE8, 0x6F, 0x00, 0xFB, 0xFF,                               // E8 BB 0B FB FF                // call    uf_GetRandomNumber   // Tyre Supplier Cash Rating
                0x83, 0xC4, 0x04,                                           // 83 C4 04                      // add     esp, 4               // Tyre Supplier Cash Rating
                0x40,                                                       // 40                            // inc     eax                  // Tyre Supplier Cash Rating
                0xA3, 0xAC, 0x99, 0x7E, 0x00,                               // A3 AC 99 7E 00                // mov     ds:dword_7E99AC, eax // Tyre Supplier Cash Rating
                0xC7, 0x05, 0xC0, 0x9F, 0x7E, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 C0 9F 7E 00 01 00 00 00 // mov     ds:dword_7E9FC0, 1   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0xC7, 0x05, 0xD4, 0xA5, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 D4 A5 7E 00 05 00 00 00 // mov     ds:dword_7EA5D4, 5   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0xC7, 0x05, 0xE8, 0xAB, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 E8 AB 7E 00 03 00 00 00 // mov     ds:dword_7EABE8, 3   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0xC7, 0x05, 0xFC, 0xB1, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 FC B1 7E 00 05 00 00 00 // mov     ds:dword_7EB1FC, 5   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0xC7, 0x05, 0x10, 0xB8, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 10 B8 7E 00 04 00 00 00 // mov     ds:dword_7EB810, 4   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0xC7, 0x05, 0x24, 0xBE, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 24 BE 7E 00 04 00 00 00 // mov     ds:dword_7EBE24, 4   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0xC7, 0x05, 0x38, 0xC4, 0x7E, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 38 C4 7E 00 02 00 00 00 // mov     ds:dword_7EC438, 2   // Engine Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier Cash Rating
                0x6A, 0x05,                                                 // 6A 05                         // push    5                    // Engine Supplier Cash Rating
                0xE8, 0xEF, 0xFF, 0xFA, 0xFF,                               // E8 9F 07 FB FF                // call    uf_GetRandomNumber   // Engine Supplier Cash Rating
                0x83, 0xC4, 0x04,                                           // 83 C4 04                      // add     esp, 4               // Engine Supplier Cash Rating
                0x40,                                                       // 40                            // inc     eax                  // Engine Supplier Cash Rating
                0xA3, 0x4C, 0xCA, 0x7E, 0x00,                               // A3 4C CA 7E 00                // mov     ds:dword_7ECA4C, eax // Engine Supplier Cash Rating
                0xC7, 0x05, 0x60, 0xD0, 0x7E, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 60 D0 7E 00 02 00 00 00 // mov     ds:dword_7ED060, 2   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0x74, 0xD6, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 74 D6 7E 00 05 00 00 00 // mov     ds:dword_7ED674, 5   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0x88, 0xDC, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 88 DC 7E 00 03 00 00 00 // mov     ds:dword_7EDC88, 3   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0x9C, 0xE2, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 9C E2 7E 00 05 00 00 00 // mov     ds:dword_7EE29C, 5   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0xB0, 0xE8, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 B0 E8 7E 00 03 00 00 00 // mov     ds:dword_7EE8B0, 3   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0xC4, 0xEE, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 C4 EE 7E 00 04 00 00 00 // mov     ds:dword_7EEEC4, 4   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0xD8, 0xF4, 0x7E, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 D8 F4 7E 00 01 00 00 00 // mov     ds:dword_7EF4D8, 1   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0xC7, 0x05, 0xEC, 0xFA, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 EC FA 7E 00 04 00 00 00 // mov     ds:dword_7EFAEC, 4   // Fuel Supplier Cash Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier Cash Rating
                0x6A, 0x05,                                                 // 6A 05                         // push    5                    // Fuel Supplier Cash Rating
                0xE8, 0x5F, 0xFF, 0xFA, 0xFF,                               // E8 47 03 FB FF                // call    uf_GetRandomNumber   // Fuel Supplier Cash Rating
                0x83, 0xC4, 0x04,                                           // 83 C4 04                      // add     esp, 4               // Fuel Supplier Cash Rating
                0x40,                                                       // 40                            // inc     eax                  // Fuel Supplier Cash Rating
                0xA3, 0x00, 0x01, 0x7F, 0x00,                               // A3 00 01 7F 00                // mov     ds:dword_7F0100, eax // Fuel Supplier Cash Rating
                0xC7, 0x05, 0x14, 0x07, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 14 07 7F 00 02 00 00 00 // mov     ds:dword_7F0714, 2   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0x28, 0x0D, 0x7F, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 28 0D 7F 00 05 00 00 00 // mov     ds:dword_7F0D28, 5   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0x3C, 0x13, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 3C 13 7F 00 03 00 00 00 // mov     ds:dword_7F133C, 3   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0x50, 0x19, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 50 19 7F 00 03 00 00 00 // mov     ds:dword_7F1950, 3   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0x64, 0x1F, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 64 1F 7F 00 03 00 00 00 // mov     ds:dword_7F1F64, 3   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0x78, 0x25, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 78 25 7F 00 04 00 00 00 // mov     ds:dword_7F2578, 4   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0x8C, 0x2B, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 8C 2B 7F 00 04 00 00 00 // mov     ds:dword_7F2B8C, 4   // Cash Sponsor Cash Rating Arrows
                0xC7, 0x05, 0xA0, 0x31, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 A0 31 7F 00 04 00 00 00 // mov     ds:dword_7F31A0, 4   // Cash Sponsor Cash Rating Benetton
                0xC7, 0x05, 0xB4, 0x37, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 B4 37 7F 00 03 00 00 00 // mov     ds:dword_7F37B4, 3   // Cash Sponsor Cash Rating Benetton
                0xC7, 0x05, 0xC8, 0x3D, 0x7F, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 C8 3D 7F 00 05 00 00 00 // mov     ds:dword_7F3DC8, 5   // Cash Sponsor Cash Rating Benetton
                0xC7, 0x05, 0xDC, 0x43, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 DC 43 7F 00 04 00 00 00 // mov     ds:dword_7F43DC, 4   // Cash Sponsor Cash Rating Benetton
                0xC7, 0x05, 0xF0, 0x49, 0x7F, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 F0 49 7F 00 01 00 00 00 // mov     ds:dword_7F49F0, 1   // Cash Sponsor Cash Rating Benetton
                0xC7, 0x05, 0x04, 0x50, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 04 50 7F 00 02 00 00 00 // mov     ds:dword_7F5004, 2   // Cash Sponsor Cash Rating Benetton
                0xC7, 0x05, 0x18, 0x56, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 18 56 7F 00 04 00 00 00 // mov     ds:dword_7F5618, 4   // Cash Sponsor Cash Rating Ferrari
                0xC7, 0x05, 0x2C, 0x5C, 0x7F, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 2C 5C 7F 00 05 00 00 00 // mov     ds:dword_7F5C2C, 5   // Cash Sponsor Cash Rating Ferrari
                0xC7, 0x05, 0x40, 0x62, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 40 62 7F 00 02 00 00 00 // mov     ds:dword_7F6240, 2   // Cash Sponsor Cash Rating Ferrari
                0xC7, 0x05, 0x54, 0x68, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 54 68 7F 00 02 00 00 00 // mov     ds:dword_7F6854, 2   // Cash Sponsor Cash Rating Ferrari
                0xC7, 0x05, 0x68, 0x6E, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 68 6E 7F 00 03 00 00 00 // mov     ds:dword_7F6E68, 3   // Cash Sponsor Cash Rating Ferrari
                0xC7, 0x05, 0x7C, 0x74, 0x7F, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 7C 74 7F 00 01 00 00 00 // mov     ds:dword_7F747C, 1   // Cash Sponsor Cash Rating Ferrari
                0xC7, 0x05, 0x90, 0x7A, 0x7F, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 90 7A 7F 00 01 00 00 00 // mov     ds:dword_7F7A90, 1   // Cash Sponsor Cash Rating Jordan
                0xC7, 0x05, 0xA4, 0x80, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 A4 80 7F 00 03 00 00 00 // mov     ds:dword_7F80A4, 3   // Cash Sponsor Cash Rating Jordan
                0xC7, 0x05, 0xB8, 0x86, 0x7F, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 B8 86 7F 00 01 00 00 00 // mov     ds:dword_7F86B8, 1   // Cash Sponsor Cash Rating Jordan
                0xC7, 0x05, 0xCC, 0x8C, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 CC 8C 7F 00 04 00 00 00 // mov     ds:dword_7F8CCC, 4   // Cash Sponsor Cash Rating Jordan
                0xC7, 0x05, 0xE0, 0x92, 0x7F, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 E0 92 7F 00 01 00 00 00 // mov     ds:dword_7F92E0, 1   // Cash Sponsor Cash Rating Jordan
                0xC7, 0x05, 0xF4, 0x98, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 F4 98 7F 00 04 00 00 00 // mov     ds:dword_7F98F4, 4   // Cash Sponsor Cash Rating Jordan
                0xC7, 0x05, 0x08, 0x9F, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 08 9F 7F 00 02 00 00 00 // mov     ds:dword_7F9F08, 2   // Cash Sponsor Cash Rating McLaren
                0xC7, 0x05, 0x1C, 0xA5, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 1C A5 7F 00 02 00 00 00 // mov     ds:dword_7FA51C, 2   // Cash Sponsor Cash Rating McLaren
                0xC7, 0x05, 0x30, 0xAB, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 30 AB 7F 00 03 00 00 00 // mov     ds:dword_7FAB30, 3   // Cash Sponsor Cash Rating McLaren
                0xC7, 0x05, 0x44, 0xB1, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 44 B1 7F 00 04 00 00 00 // mov     ds:dword_7FB144, 4   // Cash Sponsor Cash Rating McLaren
                0xC7, 0x05, 0x58, 0xB7, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 58 B7 7F 00 03 00 00 00 // mov     ds:dword_7FB758, 3   // Cash Sponsor Cash Rating McLaren
                0xC7, 0x05, 0x6C, 0xBD, 0x7F, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 6C BD 7F 00 01 00 00 00 // mov     ds:dword_7FBD6C, 1   // Cash Sponsor Cash Rating McLaren
                0xC7, 0x05, 0x80, 0xC3, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 80 C3 7F 00 04 00 00 00 // mov     ds:dword_7FC380, 4   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0x94, 0xC9, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 94 C9 7F 00 02 00 00 00 // mov     ds:dword_7FC994, 2   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0xA8, 0xCF, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 A8 CF 7F 00 03 00 00 00 // mov     ds:dword_7FCFA8, 3   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0xBC, 0xD5, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 BC D5 7F 00 02 00 00 00 // mov     ds:dword_7FD5BC, 2   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0xD0, 0xDB, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 D0 DB 7F 00 03 00 00 00 // mov     ds:dword_7FDBD0, 3   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0xE4, 0xE1, 0x7F, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 E4 E1 7F 00 02 00 00 00 // mov     ds:dword_7FE1E4, 2   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0xF8, 0xE7, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 F8 E7 7F 00 03 00 00 00 // mov     ds:dword_7FE7F8, 3   // Cash Sponsor Cash Rating Minardi
                0xC7, 0x05, 0x0C, 0xEE, 0x7F, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 0C EE 7F 00 03 00 00 00 // mov     ds:dword_7FEE0C, 3   // Cash Sponsor Cash Rating Prost
                0xC7, 0x05, 0x20, 0xF4, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 20 F4 7F 00 04 00 00 00 // mov     ds:dword_7FF420, 4   // Cash Sponsor Cash Rating Prost
                0xC7, 0x05, 0x34, 0xFA, 0x7F, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 34 FA 7F 00 04 00 00 00 // mov     ds:dword_7FFA34, 4   // Cash Sponsor Cash Rating Prost
                0xC7, 0x05, 0x48, 0x00, 0x80, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 48 00 80 00 04 00 00 00 // mov     ds:dword_800048, 4   // Cash Sponsor Cash Rating Prost
                0xC7, 0x05, 0x5C, 0x06, 0x80, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 5C 06 80 00 05 00 00 00 // mov     ds:dword_80065C, 5   // Cash Sponsor Cash Rating Prost
                0xC7, 0x05, 0x70, 0x0C, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 70 0C 80 00 03 00 00 00 // mov     ds:dword_800C70, 3   // Cash Sponsor Cash Rating Prost
                0xC7, 0x05, 0x84, 0x12, 0x80, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 84 12 80 00 01 00 00 00 // mov     ds:dword_801284, 1   // Cash Sponsor Cash Rating Sauber
                0xC7, 0x05, 0x98, 0x18, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 98 18 80 00 02 00 00 00 // mov     ds:dword_801898, 2   // Cash Sponsor Cash Rating Sauber
                0xC7, 0x05, 0xAC, 0x1E, 0x80, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 AC 1E 80 00 01 00 00 00 // mov     ds:dword_801EAC, 1   // Cash Sponsor Cash Rating Sauber
                0xC7, 0x05, 0xC0, 0x24, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 C0 24 80 00 02 00 00 00 // mov     ds:dword_8024C0, 2   // Cash Sponsor Cash Rating Sauber
                0xC7, 0x05, 0xD4, 0x2A, 0x80, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 D4 2A 80 00 05 00 00 00 // mov     ds:dword_802AD4, 5   // Cash Sponsor Cash Rating Sauber
                0xC7, 0x05, 0xE8, 0x30, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 E8 30 80 00 02 00 00 00 // mov     ds:dword_8030E8, 2   // Cash Sponsor Cash Rating Sauber
                0xC7, 0x05, 0xFC, 0x36, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 FC 36 80 00 03 00 00 00 // mov     ds:dword_8036FC, 3   // Cash Sponsor Cash Rating Stewart
                0xC7, 0x05, 0x10, 0x3D, 0x80, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 10 3D 80 00 05 00 00 00 // mov     ds:dword_803D10, 5   // Cash Sponsor Cash Rating Stewart
                0xC7, 0x05, 0x24, 0x43, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 24 43 80 00 03 00 00 00 // mov     ds:dword_804324, 3   // Cash Sponsor Cash Rating Stewart
                0xC7, 0x05, 0x38, 0x49, 0x80, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 38 49 80 00 04 00 00 00 // mov     ds:dword_804938, 4   // Cash Sponsor Cash Rating Stewart
                0xC7, 0x05, 0x4C, 0x4F, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 4C 4F 80 00 02 00 00 00 // mov     ds:dword_804F4C, 2   // Cash Sponsor Cash Rating Stewart
                0xC7, 0x05, 0x60, 0x55, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 60 55 80 00 03 00 00 00 // mov     ds:dword_805560, 3   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0x74, 0x5B, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 74 5B 80 00 03 00 00 00 // mov     ds:dword_805B74, 3   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0x88, 0x61, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 88 61 80 00 02 00 00 00 // mov     ds:dword_806188, 2   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0x9C, 0x67, 0x80, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 9C 67 80 00 04 00 00 00 // mov     ds:dword_80679C, 4   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0xB0, 0x6D, 0x80, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 B0 6D 80 00 05 00 00 00 // mov     ds:dword_806DB0, 5   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0xC4, 0x73, 0x80, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 C4 73 80 00 04 00 00 00 // mov     ds:dword_8073C4, 4   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0xD8, 0x79, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 D8 79 80 00 03 00 00 00 // mov     ds:dword_8079D8, 3   // Cash Sponsor Cash Rating Tyrrell
                0xC7, 0x05, 0xEC, 0x7F, 0x80, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 EC 7F 80 00 01 00 00 00 // mov     ds:dword_807FEC, 1   // Cash Sponsor Cash Rating Williams
                0xC7, 0x05, 0x00, 0x86, 0x80, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 00 86 80 00 05 00 00 00 // mov     ds:dword_808600, 5   // Cash Sponsor Cash Rating Williams
                0xC7, 0x05, 0x14, 0x8C, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 14 8C 80 00 02 00 00 00 // mov     ds:dword_808C14, 2   // Cash Sponsor Cash Rating Williams
                0xC7, 0x05, 0x28, 0x92, 0x80, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 28 92 80 00 01 00 00 00 // mov     ds:dword_809228, 1   // Cash Sponsor Cash Rating Williams
                0xC7, 0x05, 0x3C, 0x98, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 3C 98 80 00 03 00 00 00 // mov     ds:dword_80983C, 3   // Cash Sponsor Cash Rating Williams
                0xC7, 0x05, 0x50, 0x9E, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 50 9E 80 00 03 00 00 00 // mov     ds:dword_809E50, 3   // Cash Sponsor Cash Rating Williams
                0xC7, 0x05, 0x64, 0xA4, 0x80, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 64 A4 80 00 03 00 00 00 // mov     ds:dword_80A464, 3   // Cash Sponsor Cash Rating Unassigned
                0xC7, 0x05, 0x78, 0xAA, 0x80, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 78 AA 80 00 04 00 00 00 // mov     ds:dword_80AA78, 4   // Cash Sponsor Cash Rating Unassigned
                0xC7, 0x05, 0x8C, 0xB0, 0x80, 0x00, 0x02, 0x00, 0x00, 0x00  // C7 05 8C B0 80 00 02 00 00 00 // mov     ds:dword_80B08C, 2   // Cash Sponsor Cash Rating Unassigned
            };
        }
    }
}