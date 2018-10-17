namespace App.BaseGameEditor.Application.Patchers.CodeShiftPatcher.Sponsor
{
    internal class RadRatingData
    {
        public static byte[] GetInstructions()
        {
            // TODO: Update green instructions
            return new byte[]
            {
                0xC7, 0x05, 0x0C, 0x91, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 0C 91 7E 00 04 00 00 00 // mov     ds:dword_7E910C, 4   // Tyre Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Tyre Supplier R&D Rating
                0xC7, 0x05, 0x20, 0x97, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 20 97 7E 00 05 00 00 00 // mov     ds:dword_7E9720, 5   // Tyre Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Tyre Supplier R&D Rating
                0x6A, 0x05,                                                 // 6A 05                         // push    5                    // Tyre Supplier R&D Rating
                0xE8, 0x69, 0xFC, 0xFA, 0xFF,                               // E8 AB 0B FB FF                // call    uf_GetRandomNumber   // Tyre Supplier R&D Rating
                0x83, 0xC4, 0x04,                                           // 83 C4 04                      // add     esp, 4               // Tyre Supplier R&D Rating
                0x40,                                                       // 40                            // inc     eax                  // Tyre Supplier R&D Rating
                0xA3, 0x34, 0x9D, 0x7E, 0x00,                               // A3 34 9D 7E 00                // mov     ds:dword_7E9D34, eax // Tyre Supplier R&D Rating
                0xC7, 0x05, 0x48, 0xA3, 0x7E, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 48 A3 7E 00 01 00 00 00 // mov     ds:dword_7EA348, 1   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0xC7, 0x05, 0x5C, 0xA9, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 5C A9 7E 00 04 00 00 00 // mov     ds:dword_7EA95C, 4   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0xC7, 0x05, 0x70, 0xAF, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 70 AF 7E 00 05 00 00 00 // mov     ds:dword_7EAF70, 5   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0xC7, 0x05, 0x84, 0xB5, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 84 B5 7E 00 05 00 00 00 // mov     ds:dword_7EB584, 5   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0xC7, 0x05, 0x98, 0xBB, 0x7E, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 98 BB 7E 00 02 00 00 00 // mov     ds:dword_7EBB98, 2   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0xC7, 0x05, 0xAC, 0xC1, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 AC C1 7E 00 03 00 00 00 // mov     ds:dword_7EC1AC, 3   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0xC7, 0x05, 0xC0, 0xC7, 0x7E, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 C0 C7 7E 00 02 00 00 00 // mov     ds:dword_7EC7C0, 2   // Engine Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Engine Supplier R&D Rating
                0x6A, 0x05,                                                 // 6A 05                         // push    5                    // Engine Supplier R&D Rating
                0xE8, 0xE9, 0xFB, 0xFA, 0xFF,                               // E8 8F 07 FB FF                // call    uf_GetRandomNumber   // Engine Supplier R&D Rating
                0x83, 0xC4, 0x04,                                           // 83 C4 04                      // add     esp, 4               // Engine Supplier R&D Rating
                0x40,                                                       // 40                            // inc     eax                  // Engine Supplier R&D Rating
                0xA3, 0xD4, 0xCD, 0x7E, 0x00,                               // A3 D4 CD 7E 00                // mov     ds:dword_7ECDD4, eax // Engine Supplier R&D Rating
                0xC7, 0x05, 0xE8, 0xD3, 0x7E, 0x00, 0x01, 0x00, 0x00, 0x00, // C7 05 E8 D3 7E 00 01 00 00 00 // mov     ds:dword_7ED3E8, 1   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0xFC, 0xD9, 0x7E, 0x00, 0x04, 0x00, 0x00, 0x00, // C7 05 FC D9 7E 00 04 00 00 00 // mov     ds:dword_7ED9FC, 4   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0x10, 0xE0, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 10 E0 7E 00 03 00 00 00 // mov     ds:dword_7EE010, 3   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0x24, 0xE6, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 24 E6 7E 00 03 00 00 00 // mov     ds:dword_7EE624, 3   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0x38, 0xEC, 0x7E, 0x00, 0x02, 0x00, 0x00, 0x00, // C7 05 38 EC 7E 00 02 00 00 00 // mov     ds:dword_7EEC38, 2   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0x4C, 0xF2, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 4C F2 7E 00 03 00 00 00 // mov     ds:dword_7EF24C, 3   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0x60, 0xF8, 0x7E, 0x00, 0x05, 0x00, 0x00, 0x00, // C7 05 60 F8 7E 00 05 00 00 00 // mov     ds:dword_7EF860, 5   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0xC7, 0x05, 0x74, 0xFE, 0x7E, 0x00, 0x03, 0x00, 0x00, 0x00, // C7 05 74 FE 7E 00 03 00 00 00 // mov     ds:dword_7EFE74, 3   // Fuel Supplier R&D Rating
                0x90, 0x90, 0x90, 0x90, 0x90, 0x90,                         // 90 90 90 90 90 90             // nop                          // Fuel Supplier R&D Rating
                0x6A, 0x05,                                                 // 6A 05                         // push    5                    // Fuel Supplier R&D Rating
                0xE8, 0x59, 0xFB, 0xFA, 0xFF,                               // E8 37 03 FB FF                // call    uf_GetRandomNumber   // Fuel Supplier R&D Rating
                0x83, 0xC4, 0x04,                                           // 83 C4 04                      // add     esp, 4               // Fuel Supplier R&D Rating
                0x40,                                                       // 40                            // inc     eax                  // Fuel Supplier R&D Rating
                0xA3, 0x88, 0x04, 0x7F, 0x00                                // A3 88 04 7F 00                // mov     ds:dword_7F0488, eax // Fuel Supplier R&D Rating
            };
        }
    }
}