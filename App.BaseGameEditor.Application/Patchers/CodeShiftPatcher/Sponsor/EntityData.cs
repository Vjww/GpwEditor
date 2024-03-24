using System;
using System.Collections.Generic;
using App.Shared.Data.Calculators;

namespace App.BaseGameEditor.Application.Patchers.CodeShiftPatcher.Sponsor
{
    public class EntityData
    {
        private readonly IdentityCalculator _identityCalculator;

        public EntityData(IdentityCalculator identityCalculator)
        {
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public byte[] GetInstructions()
        {
            return GetDynamicInstructions();
        }

        private byte[] GetDynamicInstructions()
        {
            var entityTypeMemoryAddressBase = 0x007E62C6;
            var entityTypeMemoryAddressOffset = 0x00000614;
            var resourceStringIndexBase = 0x0000130C;
            var resourceStringSubRelativeAddressBase = 0x0002BCDC;
            var resourceStringSubRelativeAddressOffset = 0x00000028;
            var entityStructIndexValueBase = 0x00000618;
            var entityStructIndexValueOffset = 0x00000614;
            var strcpySubRelativeAddressBase = 0x00194B39;
            var strcpySubRelativeAddressOffset = 0x00000028;

            var instructions = new List<byte>();

            for (var i = 0; i < 98; i++)
            {
                var entityType = Convert.ToByte(_identityCalculator.GetSponsorTypeId(i));
                var entityTypeMemoryAddress = entityTypeMemoryAddressBase + entityTypeMemoryAddressOffset * i;
                var resourceStringIndex = resourceStringIndexBase + i;
                var resourceStringSubRelativeAddress = resourceStringSubRelativeAddressBase - resourceStringSubRelativeAddressOffset * i;
                var entityStructIndexValue = entityStructIndexValueBase + entityStructIndexValueOffset * i;
                var strcpySubRelativeAddress = strcpySubRelativeAddressBase - strcpySubRelativeAddressOffset * i;

                // 0xC6, 0x05, 0xC6, 0x62, 0x7E, 0x00, 0x01 // mov     ds:byte_7E62C6, 1
                instructions.AddRange(new byte[] { 0xC6, 0x05 });
                instructions.AddRange(BitConverter.GetBytes(entityTypeMemoryAddress));
                instructions.Add(entityType);

                // 0x68, 0x0C, 0x13, 0x00, 0x00,            // push    130Ch                   
                instructions.AddRange(new byte[] { 0x68 });
                instructions.AddRange(BitConverter.GetBytes(resourceStringIndex));

                // 0xE8, 0xDC, 0xBC, 0x02, 0x00,            // call    sub_51371B              
                instructions.AddRange(new byte[] { 0xE8 });
                instructions.AddRange(BitConverter.GetBytes(resourceStringSubRelativeAddress));

                // 0x83, 0xC4, 0x04,                        // add     esp, 4                  
                instructions.AddRange(new byte[] { 0x83, 0xC4, 0x04 });

                // 0x50,                                    // push    eax             ; Source
                instructions.AddRange(new byte[] { 0x50 });

                // 0xB8, 0x90, 0x5C, 0x7E, 0x00,            // mov     eax, offset dword_7E5C90
                instructions.AddRange(new byte[] { 0xB8, 0x90, 0x5C, 0x7E, 0x00 });

                // 0x05, 0x18, 0x06, 0x00, 0x00,            // add     eax, 618h               
                instructions.AddRange(new byte[] { 0x05 });
                instructions.AddRange(BitConverter.GetBytes(entityStructIndexValue));

                // 0x50,                                    // push    eax             ; Dest  
                instructions.AddRange(new byte[] { 0x50 });

                // 0xE8, 0x39, 0x4B, 0x19, 0x00,            // call    _strcpy                 
                instructions.AddRange(new byte[] { 0xE8 });
                instructions.AddRange(BitConverter.GetBytes(strcpySubRelativeAddress));

                // 0x83, 0xC4, 0x08,                        // add     esp, 8                  
                instructions.AddRange(new byte[] { 0x83, 0xC4, 0x08 });
            }

            return instructions.ToArray();
        }

        private static byte[] GetStaticInstructions()
        {
            // TODO: Update green instructions
            return new byte[]
            {
                0xC6, 0x05, 0xC6, 0x62, 0x7E, 0x00, 0x01, // C6 05 C6 62 7E 00 01 // mov     ds:byte_7E62C6, 1        // Team Sponsor Entity
                0x68, 0x0C, 0x13, 0x00, 0x00,             // 68 0C 13 00 00       // push    130Ch                    // Team Sponsor Entity
                0xE8, 0xDC, 0xBC, 0x02, 0x00,             // E8 DC BC 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x18, 0x06, 0x00, 0x00,             // 05 18 06 00 00       // add     eax, 618h                // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0x39, 0x4B, 0x19, 0x00,             // E8 39 4B 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0xDA, 0x68, 0x7E, 0x00, 0x01, // C6 05 DA 68 7E 00 01 // mov     ds:byte_7E68DA, 1        // Team Sponsor Entity
                0x68, 0x0D, 0x13, 0x00, 0x00,             // 68 0D 13 00 00       // push    130Dh                    // Team Sponsor Entity
                0xE8, 0xB4, 0xBC, 0x02, 0x00,             // E8 A0 BC 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x2C, 0x0C, 0x00, 0x00,             // 05 2C 0C 00 00       // add     eax, 0C2Ch               // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0x11, 0x4B, 0x19, 0x00,             // E8 FD 4A 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0xEE, 0x6E, 0x7E, 0x00, 0x01, // C6 05 EE 6E 7E 00 01 // mov     ds:byte_7E6EEE, 1        // Team Sponsor Entity
                0x68, 0x0E, 0x13, 0x00, 0x00,             // 68 0E 13 00 00       // push    130Eh                    // Team Sponsor Entity
                0xE8, 0x64, 0xBC, 0x02, 0x00,             // E8 64 BC 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x40, 0x12, 0x00, 0x00,             // 05 40 12 00 00       // add     eax, 1240h               // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0xC1, 0x4A, 0x19, 0x00,             // E8 C1 4A 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0x02, 0x75, 0x7E, 0x00, 0x01, // C6 05 02 75 7E 00 01 // mov     ds:byte_7E7502, 1        // Team Sponsor Entity
                0x68, 0x0F, 0x13, 0x00, 0x00,             // 68 0F 13 00 00       // push    130Fh                    // Team Sponsor Entity
                0xE8, 0x28, 0xBC, 0x02, 0x00,             // E8 28 BC 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x54, 0x18, 0x00, 0x00,             // 05 54 18 00 00       // add     eax, 1854h               // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0x85, 0x4A, 0x19, 0x00,             // E8 85 4A 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0x16, 0x7B, 0x7E, 0x00, 0x01, // C6 05 16 7B 7E 00 01 // mov     ds:byte_7E7B16, 1        // Team Sponsor Entity
                0x68, 0x10, 0x13, 0x00, 0x00,             // 68 10 13 00 00       // push    1310h                    // Team Sponsor Entity
                0xE8, 0xEC, 0xBB, 0x02, 0x00,             // E8 EC BB 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x68, 0x1E, 0x00, 0x00,             // 05 68 1E 00 00       // add     eax, 1E68h               // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0x49, 0x4A, 0x19, 0x00,             // E8 49 4A 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0x2A, 0x81, 0x7E, 0x00, 0x01, // C6 05 2A 81 7E 00 01 // mov     ds:byte_7E812A, 1        // Team Sponsor Entity
                0x68, 0x11, 0x13, 0x00, 0x00,             // 68 11 13 00 00       // push    1311h                    // Team Sponsor Entity
                0xE8, 0xB0, 0xBB, 0x02, 0x00,             // E8 B0 BB 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x7C, 0x24, 0x00, 0x00,             // 05 7C 24 00 00       // add     eax, 247Ch               // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0x0D, 0x4A, 0x19, 0x00,             // E8 0D 4A 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0x3E, 0x87, 0x7E, 0x00, 0x01, // C6 05 3E 87 7E 00 01 // mov     ds:byte_7E873E, 1        // Team Sponsor Entity
                0x68, 0x12, 0x13, 0x00, 0x00,             // 68 12 13 00 00       // push    1312h                    // Team Sponsor Entity
                0xE8, 0x74, 0xBB, 0x02, 0x00,             // E8 74 BB 02 00       // call    sub_51371B               // Team Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Team Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Team Sponsor Entity
                0x05, 0x90, 0x2A, 0x00, 0x00,             // 05 90 2A 00 00       // add     eax, 2A90h               // Team Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Team Sponsor Entity
                0xE8, 0xD1, 0x49, 0x19, 0x00,             // E8 D1 49 19 00       // call    _strcpy                  // Team Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Team Sponsor Entity
                0xC6, 0x05, 0x52, 0x8D, 0x7E, 0x00, 0x03, // C6 05 52 8D 7E 00 03 // mov     ds:byte_7E8D52, 3        // Tyre Supplier Entity
                0x68, 0x13, 0x13, 0x00, 0x00,             // 68 13 13 00 00       // push    1313h                    // Tyre Supplier Entity
                0xE8, 0x38, 0xBB, 0x02, 0x00,             // E8 38 BB 02 00       // call    sub_51371B               // Tyre Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Tyre Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Tyre Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Tyre Supplier Entity
                0x05, 0xA4, 0x30, 0x00, 0x00,             // 05 A4 30 00 00       // add     eax, 30A4h               // Tyre Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Tyre Supplier Entity
                0xE8, 0x95, 0x49, 0x19, 0x00,             // E8 95 49 19 00       // call    _strcpy                  // Tyre Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Tyre Supplier Entity
                0xC6, 0x05, 0x66, 0x93, 0x7E, 0x00, 0x03, // C6 05 66 93 7E 00 03 // mov     ds:byte_7E9366, 3        // Tyre Supplier Entity
                0x68, 0x14, 0x13, 0x00, 0x00,             // 68 14 13 00 00       // push    1314h                    // Tyre Supplier Entity
                0xE8, 0xD0, 0xB9, 0x02, 0x00,             // E8 D0 B9 02 00       // call    sub_51371B               // Tyre Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Tyre Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Tyre Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Tyre Supplier Entity
                0x05, 0xB8, 0x36, 0x00, 0x00,             // 05 B8 36 00 00       // add     eax, 36B8h               // Tyre Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Tyre Supplier Entity
                0xE8, 0x2D, 0x48, 0x19, 0x00,             // E8 2D 48 19 00       // call    _strcpy                  // Tyre Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Tyre Supplier Entity
                0xC6, 0x05, 0x7A, 0x99, 0x7E, 0x00, 0x03, // C6 05 7A 99 7E 00 03 // mov     ds:byte_7E997A, 3        // Tyre Supplier Entity
                0x68, 0x15, 0x13, 0x00, 0x00,             // 68 15 13 00 00       // push    1315h                    // Tyre Supplier Entity
                0xE8, 0x9A, 0xB8, 0x02, 0x00,             // E8 9A B8 02 00       // call    sub_51371B               // Tyre Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Tyre Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Tyre Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Tyre Supplier Entity
                0x05, 0xCC, 0x3C, 0x00, 0x00,             // 05 CC 3C 00 00       // add     eax, 3CCCh               // Tyre Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Tyre Supplier Entity
                0xE8, 0xF7, 0x46, 0x19, 0x00,             // E8 F7 46 19 00       // call    _strcpy                  // Tyre Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Tyre Supplier Entity
                0xC6, 0x05, 0x8E, 0x9F, 0x7E, 0x00, 0x02, // C6 05 8E 9F 7E 00 02 // mov     ds:byte_7E9F8E, 2        // Engine Supplier Entity
                0x68, 0x16, 0x13, 0x00, 0x00,             // 68 16 13 00 00       // push    1316h                    // Engine Supplier Entity
                0xE8, 0x48, 0xB8, 0x02, 0x00,             // E8 48 B8 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0xE0, 0x42, 0x00, 0x00,             // 05 E0 42 00 00       // add     eax, 42E0h               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0xA5, 0x46, 0x19, 0x00,             // E8 A5 46 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0xA2, 0xA5, 0x7E, 0x00, 0x02, // C6 05 A2 A5 7E 00 02 // mov     ds:byte_7EA5A2, 2        // Engine Supplier Entity
                0x68, 0x17, 0x13, 0x00, 0x00,             // 68 17 13 00 00       // push    1317h                    // Engine Supplier Entity
                0xE8, 0xDA, 0xB7, 0x02, 0x00,             // E8 DA B7 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0xF4, 0x48, 0x00, 0x00,             // 05 F4 48 00 00       // add     eax, 48F4h               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0x37, 0x46, 0x19, 0x00,             // E8 37 46 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0xB6, 0xAB, 0x7E, 0x00, 0x02, // C6 05 B6 AB 7E 00 02 // mov     ds:byte_7EABB6, 2        // Engine Supplier Entity
                0x68, 0x18, 0x13, 0x00, 0x00,             // 68 18 13 00 00       // push    1318h                    // Engine Supplier Entity
                0xE8, 0x3A, 0xB7, 0x02, 0x00,             // E8 3A B7 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0x08, 0x4F, 0x00, 0x00,             // 05 08 4F 00 00       // add     eax, 4F08h               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0x97, 0x45, 0x19, 0x00,             // E8 97 45 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0xCA, 0xB1, 0x7E, 0x00, 0x02, // C6 05 CA B1 7E 00 02 // mov     ds:byte_7EB1CA, 2        // Engine Supplier Entity
                0x68, 0x19, 0x13, 0x00, 0x00,             // 68 19 13 00 00       // push    1319h                    // Engine Supplier Entity
                0xE8, 0x68, 0xB6, 0x02, 0x00,             // E8 68 B6 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0x1C, 0x55, 0x00, 0x00,             // 05 1C 55 00 00       // add     eax, 551Ch               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0xC5, 0x44, 0x19, 0x00,             // E8 C5 44 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0xDE, 0xB7, 0x7E, 0x00, 0x02, // C6 05 DE B7 7E 00 02 // mov     ds:byte_7EB7DE, 2        // Engine Supplier Entity
                0x68, 0x1A, 0x13, 0x00, 0x00,             // 68 1A 13 00 00       // push    131Ah                    // Engine Supplier Entity
                0xE8, 0xFA, 0xB5, 0x02, 0x00,             // E8 FA B5 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0x30, 0x5B, 0x00, 0x00,             // 05 30 5B 00 00       // add     eax, 5B30h               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0x57, 0x44, 0x19, 0x00,             // E8 57 44 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0xF2, 0xBD, 0x7E, 0x00, 0x02, // C6 05 F2 BD 7E 00 02 // mov     ds:byte_7EBDF2, 2        // Engine Supplier Entity
                0x68, 0x1B, 0x13, 0x00, 0x00,             // 68 1B 13 00 00       // push    131Bh                    // Engine Supplier Entity
                0xE8, 0x8C, 0xB5, 0x02, 0x00,             // E8 8C B5 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0x44, 0x61, 0x00, 0x00,             // 05 44 61 00 00       // add     eax, 6144h               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0xE9, 0x43, 0x19, 0x00,             // E8 E9 43 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0x06, 0xC4, 0x7E, 0x00, 0x02, // C6 05 06 C4 7E 00 02 // mov     ds:byte_7EC406, 2        // Engine Supplier Entity
                0x68, 0x1C, 0x13, 0x00, 0x00,             // 68 1C 13 00 00       // push    131Ch                    // Engine Supplier Entity
                0xE8, 0x1E, 0xB5, 0x02, 0x00,             // E8 1E B5 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0x58, 0x67, 0x00, 0x00,             // 05 58 67 00 00       // add     eax, 6758h               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0x7B, 0x43, 0x19, 0x00,             // E8 7B 43 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0x1A, 0xCA, 0x7E, 0x00, 0x02, // C6 05 1A CA 7E 00 02 // mov     ds:byte_7ECA1A, 2        // Engine Supplier Entity
                0x68, 0x1D, 0x13, 0x00, 0x00,             // 68 1D 13 00 00       // push    131Dh                    // Engine Supplier Entity
                0xE8, 0x7E, 0xB4, 0x02, 0x00,             // E8 7E B4 02 00       // call    sub_51371B               // Engine Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Engine Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Engine Supplier Entity
                0x05, 0x6C, 0x6D, 0x00, 0x00,             // 05 6C 6D 00 00       // add     eax, 6D6Ch               // Engine Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Engine Supplier Entity
                0xE8, 0xDB, 0x42, 0x19, 0x00,             // E8 DB 42 19 00       // call    _strcpy                  // Engine Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Engine Supplier Entity
                0xC6, 0x05, 0x2E, 0xD0, 0x7E, 0x00, 0x04, // C6 05 2E D0 7E 00 04 // mov     ds:byte_7ED02E, 4        // Fuel Supplier Entity
                0x68, 0x1E, 0x13, 0x00, 0x00,             // 68 1E 13 00 00       // push    131Eh                    // Fuel Supplier Entity
                0xE8, 0x2C, 0xB4, 0x02, 0x00,             // E8 2C B4 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0x80, 0x73, 0x00, 0x00,             // 05 80 73 00 00       // add     eax, 7380h               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x89, 0x42, 0x19, 0x00,             // E8 89 42 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0x42, 0xD6, 0x7E, 0x00, 0x04, // C6 05 42 D6 7E 00 04 // mov     ds:byte_7ED642, 4        // Fuel Supplier Entity
                0x68, 0x1F, 0x13, 0x00, 0x00,             // 68 1F 13 00 00       // push    131Fh                    // Fuel Supplier Entity
                0xE8, 0xBE, 0xB3, 0x02, 0x00,             // E8 BE B3 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0x94, 0x79, 0x00, 0x00,             // 05 94 79 00 00       // add     eax, 7994h               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x1B, 0x42, 0x19, 0x00,             // E8 1B 42 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0x56, 0xDC, 0x7E, 0x00, 0x04, // C6 05 56 DC 7E 00 04 // mov     ds:byte_7EDC56, 4        // Fuel Supplier Entity
                0x68, 0x20, 0x13, 0x00, 0x00,             // 68 20 13 00 00       // push    1320h                    // Fuel Supplier Entity
                0xE8, 0x1E, 0xB3, 0x02, 0x00,             // E8 1E B3 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0xA8, 0x7F, 0x00, 0x00,             // 05 A8 7F 00 00       // add     eax, 7FA8h               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x7B, 0x41, 0x19, 0x00,             // E8 7B 41 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0x6A, 0xE2, 0x7E, 0x00, 0x04, // C6 05 6A E2 7E 00 04 // mov     ds:byte_7EE26A, 4        // Fuel Supplier Entity
                0x68, 0x21, 0x13, 0x00, 0x00,             // 68 21 13 00 00       // push    1321h                    // Fuel Supplier Entity
                0xE8, 0xB0, 0xB2, 0x02, 0x00,             // E8 B0 B2 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0xBC, 0x85, 0x00, 0x00,             // 05 BC 85 00 00       // add     eax, 85BCh               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x0D, 0x41, 0x19, 0x00,             // E8 0D 41 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0x7E, 0xE8, 0x7E, 0x00, 0x04, // C6 05 7E E8 7E 00 04 // mov     ds:byte_7EE87E, 4        // Fuel Supplier Entity
                0x68, 0x22, 0x13, 0x00, 0x00,             // 68 22 13 00 00       // push    1322h                    // Fuel Supplier Entity
                0xE8, 0x42, 0xB2, 0x02, 0x00,             // E8 42 B2 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0xD0, 0x8B, 0x00, 0x00,             // 05 D0 8B 00 00       // add     eax, 8BD0h               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x9F, 0x40, 0x19, 0x00,             // E8 9F 40 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0x92, 0xEE, 0x7E, 0x00, 0x04, // C6 05 92 EE 7E 00 04 // mov     ds:byte_7EEE92, 4        // Fuel Supplier Entity
                0x68, 0x23, 0x13, 0x00, 0x00,             // 68 23 13 00 00       // push    1323h                    // Fuel Supplier Entity
                0xE8, 0xD4, 0xB1, 0x02, 0x00,             // E8 D4 B1 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0xE4, 0x91, 0x00, 0x00,             // 05 E4 91 00 00       // add     eax, 91E4h               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x31, 0x40, 0x19, 0x00,             // E8 31 40 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0xA6, 0xF4, 0x7E, 0x00, 0x04, // C6 05 A6 F4 7E 00 04 // mov     ds:byte_7EF4A6, 4        // Fuel Supplier Entity
                0x68, 0x24, 0x13, 0x00, 0x00,             // 68 24 13 00 00       // push    1324h                    // Fuel Supplier Entity
                0xE8, 0x66, 0xB1, 0x02, 0x00,             // E8 66 B1 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0xF8, 0x97, 0x00, 0x00,             // 05 F8 97 00 00       // add     eax, 97F8h               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0xC3, 0x3F, 0x19, 0x00,             // E8 C3 3F 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0xBA, 0xFA, 0x7E, 0x00, 0x04, // C6 05 BA FA 7E 00 04 // mov     ds:byte_7EFABA, 4        // Fuel Supplier Entity
                0x68, 0x25, 0x13, 0x00, 0x00,             // 68 25 13 00 00       // push    1325h                    // Fuel Supplier Entity
                0xE8, 0x94, 0xB0, 0x02, 0x00,             // E8 94 B0 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0x0C, 0x9E, 0x00, 0x00,             // 05 0C 9E 00 00       // add     eax, 9E0Ch               // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0xF1, 0x3E, 0x19, 0x00,             // E8 F1 3E 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0xCE, 0x00, 0x7F, 0x00, 0x04, // C6 05 CE 00 7F 00 04 // mov     ds:byte_7F00CE, 4        // Fuel Supplier Entity
                0x68, 0x26, 0x13, 0x00, 0x00,             // 68 26 13 00 00       // push    1326h                    // Fuel Supplier Entity
                0xE8, 0x26, 0xB0, 0x02, 0x00,             // E8 26 B0 02 00       // call    sub_51371B               // Fuel Supplier Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Source // Fuel Supplier Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Fuel Supplier Entity
                0x05, 0x20, 0xA4, 0x00, 0x00,             // 05 20 A4 00 00       // add     eax, 0A420h              // Fuel Supplier Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Fuel Supplier Entity
                0xE8, 0x83, 0x3E, 0x19, 0x00,             // E8 83 3E 19 00       // call    _strcpy                  // Fuel Supplier Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Fuel Supplier Entity
                0xC6, 0x05, 0xE2, 0x06, 0x7F, 0x00, 0x05, // C6 05 E2 06 7F 00 05 // mov     ds:byte_7F06E2, 5        // Cash Sponsor Entity
                0x68, 0x27, 0x13, 0x00, 0x00,             // 68 27 13 00 00       // push    1327h                    // Cash Sponsor Entity
                0xE8, 0xD4, 0xAF, 0x02, 0x00,             // E8 D4 AF 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x34, 0xAA, 0x00, 0x00,             // 05 34 AA 00 00       // add     eax, 0AA34h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x31, 0x3E, 0x19, 0x00,             // E8 31 3E 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xF6, 0x0C, 0x7F, 0x00, 0x05, // C6 05 F6 0C 7F 00 05 // mov     ds:byte_7F0CF6, 5        // Cash Sponsor Entity
                0x68, 0x28, 0x13, 0x00, 0x00,             // 68 28 13 00 00       // push    1328h                    // Cash Sponsor Entity
                0xE8, 0x98, 0xAF, 0x02, 0x00,             // E8 98 AF 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x48, 0xB0, 0x00, 0x00,             // 05 48 B0 00 00       // add     eax, 0B048h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xF5, 0x3D, 0x19, 0x00,             // E8 F5 3D 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x0A, 0x13, 0x7F, 0x00, 0x05, // C6 05 0A 13 7F 00 05 // mov     ds:byte_7F130A, 5        // Cash Sponsor Entity
                0x68, 0x29, 0x13, 0x00, 0x00,             // 68 29 13 00 00       // push    1329h                    // Cash Sponsor Entity
                0xE8, 0x5C, 0xAF, 0x02, 0x00,             // E8 5C AF 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x5C, 0xB6, 0x00, 0x00,             // 05 5C B6 00 00       // add     eax, 0B65Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xB9, 0x3D, 0x19, 0x00,             // E8 B9 3D 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x1E, 0x19, 0x7F, 0x00, 0x05, // C6 05 1E 19 7F 00 05 // mov     ds:byte_7F191E, 5        // Cash Sponsor Entity
                0x68, 0x2A, 0x13, 0x00, 0x00,             // 68 2A 13 00 00       // push    132Ah                    // Cash Sponsor Entity
                0xE8, 0x20, 0xAF, 0x02, 0x00,             // E8 20 AF 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x70, 0xBC, 0x00, 0x00,             // 05 70 BC 00 00       // add     eax, 0BC70h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x7D, 0x3D, 0x19, 0x00,             // E8 7D 3D 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x32, 0x1F, 0x7F, 0x00, 0x05, // C6 05 32 1F 7F 00 05 // mov     ds:byte_7F1F32, 5        // Cash Sponsor Entity
                0x68, 0x2B, 0x13, 0x00, 0x00,             // 68 2B 13 00 00       // push    132Bh                    // Cash Sponsor Entity
                0xE8, 0xE4, 0xAE, 0x02, 0x00,             // E8 E4 AE 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x84, 0xC2, 0x00, 0x00,             // 05 84 C2 00 00       // add     eax, 0C284h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x41, 0x3D, 0x19, 0x00,             // E8 41 3D 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x46, 0x25, 0x7F, 0x00, 0x05, // C6 05 46 25 7F 00 05 // mov     ds:byte_7F2546, 5        // Cash Sponsor Entity
                0x68, 0x2C, 0x13, 0x00, 0x00,             // 68 2C 13 00 00       // push    132Ch                    // Cash Sponsor Entity
                0xE8, 0xA8, 0xAE, 0x02, 0x00,             // E8 A8 AE 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x98, 0xC8, 0x00, 0x00,             // 05 98 C8 00 00       // add     eax, 0C898h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x05, 0x3D, 0x19, 0x00,             // E8 05 3D 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x5A, 0x2B, 0x7F, 0x00, 0x05, // C6 05 5A 2B 7F 00 05 // mov     ds:byte_7F2B5A, 5        // Cash Sponsor Entity
                0x68, 0x2D, 0x13, 0x00, 0x00,             // 68 2D 13 00 00       // push    132Dh                    // Cash Sponsor Entity
                0xE8, 0x6C, 0xAE, 0x02, 0x00,             // E8 6C AE 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xAC, 0xCE, 0x00, 0x00,             // 05 AC CE 00 00       // add     eax, 0CEACh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xC9, 0x3C, 0x19, 0x00,             // E8 C9 3C 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x6E, 0x31, 0x7F, 0x00, 0x05, // C6 05 6E 31 7F 00 05 // mov     ds:byte_7F316E, 5        // Cash Sponsor Entity
                0x68, 0x2E, 0x13, 0x00, 0x00,             // 68 2E 13 00 00       // push    132Eh                    // Cash Sponsor Entity
                0xE8, 0x30, 0xAE, 0x02, 0x00,             // E8 30 AE 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xC0, 0xD4, 0x00, 0x00,             // 05 C0 D4 00 00       // add     eax, 0D4C0h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x8D, 0x3C, 0x19, 0x00,             // E8 8D 3C 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x82, 0x37, 0x7F, 0x00, 0x05, // C6 05 82 37 7F 00 05 // mov     ds:byte_7F3782, 5        // Cash Sponsor Entity
                0x68, 0x2F, 0x13, 0x00, 0x00,             // 68 2F 13 00 00       // push    132Fh                    // Cash Sponsor Entity
                0xE8, 0xF4, 0xAD, 0x02, 0x00,             // E8 F4 AD 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xD4, 0xDA, 0x00, 0x00,             // 05 D4 DA 00 00       // add     eax, 0DAD4h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x51, 0x3C, 0x19, 0x00,             // E8 51 3C 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x96, 0x3D, 0x7F, 0x00, 0x05, // C6 05 96 3D 7F 00 05 // mov     ds:byte_7F3D96, 5        // Cash Sponsor Entity
                0x68, 0x30, 0x13, 0x00, 0x00,             // 68 30 13 00 00       // push    1330h                    // Cash Sponsor Entity
                0xE8, 0xB8, 0xAD, 0x02, 0x00,             // E8 B8 AD 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xE8, 0xE0, 0x00, 0x00,             // 05 E8 E0 00 00       // add     eax, 0E0E8h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x15, 0x3C, 0x19, 0x00,             // E8 15 3C 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xAA, 0x43, 0x7F, 0x00, 0x05, // C6 05 AA 43 7F 00 05 // mov     ds:byte_7F43AA, 5        // Cash Sponsor Entity
                0x68, 0x31, 0x13, 0x00, 0x00,             // 68 31 13 00 00       // push    1331h                    // Cash Sponsor Entity
                0xE8, 0x7C, 0xAD, 0x02, 0x00,             // E8 7C AD 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xFC, 0xE6, 0x00, 0x00,             // 05 FC E6 00 00       // add     eax, 0E6FCh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xD9, 0x3B, 0x19, 0x00,             // E8 D9 3B 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xBE, 0x49, 0x7F, 0x00, 0x05, // C6 05 BE 49 7F 00 05 // mov     ds:byte_7F49BE, 5        // Cash Sponsor Entity
                0x68, 0x32, 0x13, 0x00, 0x00,             // 68 32 13 00 00       // push    1332h                    // Cash Sponsor Entity
                0xE8, 0x40, 0xAD, 0x02, 0x00,             // E8 40 AD 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x10, 0xED, 0x00, 0x00,             // 05 10 ED 00 00       // add     eax, 0ED10h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x9D, 0x3B, 0x19, 0x00,             // E8 9D 3B 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xD2, 0x4F, 0x7F, 0x00, 0x05, // C6 05 D2 4F 7F 00 05 // mov     ds:byte_7F4FD2, 5        // Cash Sponsor Entity
                0x68, 0x33, 0x13, 0x00, 0x00,             // 68 33 13 00 00       // push    1333h                    // Cash Sponsor Entity
                0xE8, 0x04, 0xAD, 0x02, 0x00,             // E8 04 AD 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x24, 0xF3, 0x00, 0x00,             // 05 24 F3 00 00       // add     eax, 0F324h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x61, 0x3B, 0x19, 0x00,             // E8 61 3B 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xE6, 0x55, 0x7F, 0x00, 0x05, // C6 05 E6 55 7F 00 05 // mov     ds:byte_7F55E6, 5        // Cash Sponsor Entity
                0x68, 0x34, 0x13, 0x00, 0x00,             // 68 34 13 00 00       // push    1334h                    // Cash Sponsor Entity
                0xE8, 0xC8, 0xAC, 0x02, 0x00,             // E8 C8 AC 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x38, 0xF9, 0x00, 0x00,             // 05 38 F9 00 00       // add     eax, 0F938h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x25, 0x3B, 0x19, 0x00,             // E8 25 3B 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xFA, 0x5B, 0x7F, 0x00, 0x05, // C6 05 FA 5B 7F 00 05 // mov     ds:byte_7F5BFA, 5        // Cash Sponsor Entity
                0x68, 0x35, 0x13, 0x00, 0x00,             // 68 35 13 00 00       // push    1335h                    // Cash Sponsor Entity
                0xE8, 0x8C, 0xAC, 0x02, 0x00,             // E8 8C AC 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x4C, 0xFF, 0x00, 0x00,             // 05 4C FF 00 00       // add     eax, 0FF4Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xE9, 0x3A, 0x19, 0x00,             // E8 E9 3A 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x0E, 0x62, 0x7F, 0x00, 0x05, // C6 05 0E 62 7F 00 05 // mov     ds:byte_7F620E, 5        // Cash Sponsor Entity
                0x68, 0x36, 0x13, 0x00, 0x00,             // 68 36 13 00 00       // push    1336h                    // Cash Sponsor Entity
                0xE8, 0x50, 0xAC, 0x02, 0x00,             // E8 50 AC 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x60, 0x05, 0x01, 0x00,             // 05 60 05 01 00       // add     eax, 10560h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xAD, 0x3A, 0x19, 0x00,             // E8 AD 3A 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x22, 0x68, 0x7F, 0x00, 0x05, // C6 05 22 68 7F 00 05 // mov     ds:byte_7F6822, 5        // Cash Sponsor Entity
                0x68, 0x37, 0x13, 0x00, 0x00,             // 68 37 13 00 00       // push    1337h                    // Cash Sponsor Entity
                0xE8, 0x14, 0xAC, 0x02, 0x00,             // E8 14 AC 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x74, 0x0B, 0x01, 0x00,             // 05 74 0B 01 00       // add     eax, 10B74h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x71, 0x3A, 0x19, 0x00,             // E8 71 3A 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x36, 0x6E, 0x7F, 0x00, 0x05, // C6 05 36 6E 7F 00 05 // mov     ds:byte_7F6E36, 5        // Cash Sponsor Entity
                0x68, 0x38, 0x13, 0x00, 0x00,             // 68 38 13 00 00       // push    1338h                    // Cash Sponsor Entity
                0xE8, 0xD8, 0xAB, 0x02, 0x00,             // E8 D8 AB 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x88, 0x11, 0x01, 0x00,             // 05 88 11 01 00       // add     eax, 11188h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x35, 0x3A, 0x19, 0x00,             // E8 35 3A 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x4A, 0x74, 0x7F, 0x00, 0x05, // C6 05 4A 74 7F 00 05 // mov     ds:byte_7F744A, 5        // Cash Sponsor Entity
                0x68, 0x39, 0x13, 0x00, 0x00,             // 68 39 13 00 00       // push    1339h                    // Cash Sponsor Entity
                0xE8, 0x9C, 0xAB, 0x02, 0x00,             // E8 9C AB 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x9C, 0x17, 0x01, 0x00,             // 05 9C 17 01 00       // add     eax, 1179Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xF9, 0x39, 0x19, 0x00,             // E8 F9 39 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x5E, 0x7A, 0x7F, 0x00, 0x05, // C6 05 5E 7A 7F 00 05 // mov     ds:byte_7F7A5E, 5        // Cash Sponsor Entity
                0x68, 0x3A, 0x13, 0x00, 0x00,             // 68 3A 13 00 00       // push    133Ah                    // Cash Sponsor Entity
                0xE8, 0x60, 0xAB, 0x02, 0x00,             // E8 60 AB 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xB0, 0x1D, 0x01, 0x00,             // 05 B0 1D 01 00       // add     eax, 11DB0h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xBD, 0x39, 0x19, 0x00,             // E8 BD 39 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x72, 0x80, 0x7F, 0x00, 0x05, // C6 05 72 80 7F 00 05 // mov     ds:byte_7F8072, 5        // Cash Sponsor Entity
                0x68, 0x3B, 0x13, 0x00, 0x00,             // 68 3B 13 00 00       // push    133Bh                    // Cash Sponsor Entity
                0xE8, 0x24, 0xAB, 0x02, 0x00,             // E8 24 AB 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xC4, 0x23, 0x01, 0x00,             // 05 C4 23 01 00       // add     eax, 123C4h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x81, 0x39, 0x19, 0x00,             // E8 81 39 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x86, 0x86, 0x7F, 0x00, 0x05, // C6 05 86 86 7F 00 05 // mov     ds:byte_7F8686, 5        // Cash Sponsor Entity
                0x68, 0x3C, 0x13, 0x00, 0x00,             // 68 3C 13 00 00       // push    133Ch                    // Cash Sponsor Entity
                0xE8, 0xE8, 0xAA, 0x02, 0x00,             // E8 E8 AA 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xD8, 0x29, 0x01, 0x00,             // 05 D8 29 01 00       // add     eax, 129D8h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x45, 0x39, 0x19, 0x00,             // E8 45 39 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x9A, 0x8C, 0x7F, 0x00, 0x05, // C6 05 9A 8C 7F 00 05 // mov     ds:byte_7F8C9A, 5        // Cash Sponsor Entity
                0x68, 0x3D, 0x13, 0x00, 0x00,             // 68 3D 13 00 00       // push    133Dh                    // Cash Sponsor Entity
                0xE8, 0xAC, 0xAA, 0x02, 0x00,             // E8 AC AA 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xEC, 0x2F, 0x01, 0x00,             // 05 EC 2F 01 00       // add     eax, 12FECh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x09, 0x39, 0x19, 0x00,             // E8 09 39 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xAE, 0x92, 0x7F, 0x00, 0x05, // C6 05 AE 92 7F 00 05 // mov     ds:byte_7F92AE, 5        // Cash Sponsor Entity
                0x68, 0x3E, 0x13, 0x00, 0x00,             // 68 3E 13 00 00       // push    133Eh                    // Cash Sponsor Entity
                0xE8, 0x70, 0xAA, 0x02, 0x00,             // E8 70 AA 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x00, 0x36, 0x01, 0x00,             // 05 00 36 01 00       // add     eax, 13600h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xCD, 0x38, 0x19, 0x00,             // E8 CD 38 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xC2, 0x98, 0x7F, 0x00, 0x05, // C6 05 C2 98 7F 00 05 // mov     ds:byte_7F98C2, 5        // Cash Sponsor Entity
                0x68, 0x3F, 0x13, 0x00, 0x00,             // 68 3F 13 00 00       // push    133Fh                    // Cash Sponsor Entity
                0xE8, 0x34, 0xAA, 0x02, 0x00,             // E8 34 AA 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x14, 0x3C, 0x01, 0x00,             // 05 14 3C 01 00       // add     eax, 13C14h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x91, 0x38, 0x19, 0x00,             // E8 91 38 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xD6, 0x9E, 0x7F, 0x00, 0x05, // C6 05 D6 9E 7F 00 05 // mov     ds:byte_7F9ED6, 5        // Cash Sponsor Entity
                0x68, 0x40, 0x13, 0x00, 0x00,             // 68 40 13 00 00       // push    1340h                    // Cash Sponsor Entity
                0xE8, 0xF8, 0xA9, 0x02, 0x00,             // E8 F8 A9 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x28, 0x42, 0x01, 0x00,             // 05 28 42 01 00       // add     eax, 14228h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x55, 0x38, 0x19, 0x00,             // E8 55 38 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xEA, 0xA4, 0x7F, 0x00, 0x05, // C6 05 EA A4 7F 00 05 // mov     ds:byte_7FA4EA, 5        // Cash Sponsor Entity
                0x68, 0x41, 0x13, 0x00, 0x00,             // 68 41 13 00 00       // push    1341h                    // Cash Sponsor Entity
                0xE8, 0xBC, 0xA9, 0x02, 0x00,             // E8 BC A9 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x3C, 0x48, 0x01, 0x00,             // 05 3C 48 01 00       // add     eax, 1483Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x19, 0x38, 0x19, 0x00,             // E8 19 38 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xFE, 0xAA, 0x7F, 0x00, 0x05, // C6 05 FE AA 7F 00 05 // mov     ds:byte_7FAAFE, 5        // Cash Sponsor Entity
                0x68, 0x42, 0x13, 0x00, 0x00,             // 68 42 13 00 00       // push    1342h                    // Cash Sponsor Entity
                0xE8, 0x80, 0xA9, 0x02, 0x00,             // E8 80 A9 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x50, 0x4E, 0x01, 0x00,             // 05 50 4E 01 00       // add     eax, 14E50h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xDD, 0x37, 0x19, 0x00,             // E8 DD 37 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x12, 0xB1, 0x7F, 0x00, 0x05, // C6 05 12 B1 7F 00 05 // mov     ds:byte_7FB112, 5        // Cash Sponsor Entity
                0x68, 0x43, 0x13, 0x00, 0x00,             // 68 43 13 00 00       // push    1343h                    // Cash Sponsor Entity
                0xE8, 0x44, 0xA9, 0x02, 0x00,             // E8 44 A9 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x64, 0x54, 0x01, 0x00,             // 05 64 54 01 00       // add     eax, 15464h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xA1, 0x37, 0x19, 0x00,             // E8 A1 37 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x26, 0xB7, 0x7F, 0x00, 0x05, // C6 05 26 B7 7F 00 05 // mov     ds:byte_7FB726, 5        // Cash Sponsor Entity
                0x68, 0x44, 0x13, 0x00, 0x00,             // 68 44 13 00 00       // push    1344h                    // Cash Sponsor Entity
                0xE8, 0x08, 0xA9, 0x02, 0x00,             // E8 08 A9 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x78, 0x5A, 0x01, 0x00,             // 05 78 5A 01 00       // add     eax, 15A78h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x65, 0x37, 0x19, 0x00,             // E8 65 37 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x3A, 0xBD, 0x7F, 0x00, 0x05, // C6 05 3A BD 7F 00 05 // mov     ds:byte_7FBD3A, 5        // Cash Sponsor Entity
                0x68, 0x45, 0x13, 0x00, 0x00,             // 68 45 13 00 00       // push    1345h                    // Cash Sponsor Entity
                0xE8, 0xCC, 0xA8, 0x02, 0x00,             // E8 CC A8 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x8C, 0x60, 0x01, 0x00,             // 05 8C 60 01 00       // add     eax, 1608Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x29, 0x37, 0x19, 0x00,             // E8 29 37 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x4E, 0xC3, 0x7F, 0x00, 0x05, // C6 05 4E C3 7F 00 05 // mov     ds:byte_7FC34E, 5        // Cash Sponsor Entity
                0x68, 0x46, 0x13, 0x00, 0x00,             // 68 46 13 00 00       // push    1346h                    // Cash Sponsor Entity
                0xE8, 0x90, 0xA8, 0x02, 0x00,             // E8 90 A8 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xA0, 0x66, 0x01, 0x00,             // 05 A0 66 01 00       // add     eax, 166A0h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xED, 0x36, 0x19, 0x00,             // E8 ED 36 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x62, 0xC9, 0x7F, 0x00, 0x05, // C6 05 62 C9 7F 00 05 // mov     ds:byte_7FC962, 5        // Cash Sponsor Entity
                0x68, 0x47, 0x13, 0x00, 0x00,             // 68 47 13 00 00       // push    1347h                    // Cash Sponsor Entity
                0xE8, 0x54, 0xA8, 0x02, 0x00,             // E8 54 A8 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xB4, 0x6C, 0x01, 0x00,             // 05 B4 6C 01 00       // add     eax, 16CB4h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xB1, 0x36, 0x19, 0x00,             // E8 B1 36 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x76, 0xCF, 0x7F, 0x00, 0x05, // C6 05 76 CF 7F 00 05 // mov     ds:byte_7FCF76, 5        // Cash Sponsor Entity
                0x68, 0x48, 0x13, 0x00, 0x00,             // 68 48 13 00 00       // push    1348h                    // Cash Sponsor Entity
                0xE8, 0x18, 0xA8, 0x02, 0x00,             // E8 18 A8 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xC8, 0x72, 0x01, 0x00,             // 05 C8 72 01 00       // add     eax, 172C8h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x75, 0x36, 0x19, 0x00,             // E8 75 36 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x8A, 0xD5, 0x7F, 0x00, 0x05, // C6 05 8A D5 7F 00 05 // mov     ds:byte_7FD58A, 5        // Cash Sponsor Entity
                0x68, 0x49, 0x13, 0x00, 0x00,             // 68 49 13 00 00       // push    1349h                    // Cash Sponsor Entity
                0xE8, 0xDC, 0xA7, 0x02, 0x00,             // E8 DC A7 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xDC, 0x78, 0x01, 0x00,             // 05 DC 78 01 00       // add     eax, 178DCh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x39, 0x36, 0x19, 0x00,             // E8 39 36 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x9E, 0xDB, 0x7F, 0x00, 0x05, // C6 05 9E DB 7F 00 05 // mov     ds:byte_7FDB9E, 5        // Cash Sponsor Entity
                0x68, 0x4A, 0x13, 0x00, 0x00,             // 68 4A 13 00 00       // push    134Ah                    // Cash Sponsor Entity
                0xE8, 0xA0, 0xA7, 0x02, 0x00,             // E8 A0 A7 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xF0, 0x7E, 0x01, 0x00,             // 05 F0 7E 01 00       // add     eax, 17EF0h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xFD, 0x35, 0x19, 0x00,             // E8 FD 35 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xB2, 0xE1, 0x7F, 0x00, 0x05, // C6 05 B2 E1 7F 00 05 // mov     ds:byte_7FE1B2, 5        // Cash Sponsor Entity
                0x68, 0x4B, 0x13, 0x00, 0x00,             // 68 4B 13 00 00       // push    134Bh                    // Cash Sponsor Entity
                0xE8, 0x64, 0xA7, 0x02, 0x00,             // E8 64 A7 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x04, 0x85, 0x01, 0x00,             // 05 04 85 01 00       // add     eax, 18504h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xC1, 0x35, 0x19, 0x00,             // E8 C1 35 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xC6, 0xE7, 0x7F, 0x00, 0x05, // C6 05 C6 E7 7F 00 05 // mov     ds:byte_7FE7C6, 5        // Cash Sponsor Entity
                0x68, 0x4C, 0x13, 0x00, 0x00,             // 68 4C 13 00 00       // push    134Ch                    // Cash Sponsor Entity
                0xE8, 0x28, 0xA7, 0x02, 0x00,             // E8 28 A7 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x18, 0x8B, 0x01, 0x00,             // 05 18 8B 01 00       // add     eax, 18B18h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x85, 0x35, 0x19, 0x00,             // E8 85 35 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xDA, 0xED, 0x7F, 0x00, 0x05, // C6 05 DA ED 7F 00 05 // mov     ds:byte_7FEDDA, 5        // Cash Sponsor Entity
                0x68, 0x4D, 0x13, 0x00, 0x00,             // 68 4D 13 00 00       // push    134Dh                    // Cash Sponsor Entity
                0xE8, 0xEC, 0xA6, 0x02, 0x00,             // E8 EC A6 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x2C, 0x91, 0x01, 0x00,             // 05 2C 91 01 00       // add     eax, 1912Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x49, 0x35, 0x19, 0x00,             // E8 49 35 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xEE, 0xF3, 0x7F, 0x00, 0x05, // C6 05 EE F3 7F 00 05 // mov     ds:byte_7FF3EE, 5        // Cash Sponsor Entity
                0x68, 0x4E, 0x13, 0x00, 0x00,             // 68 4E 13 00 00       // push    134Eh                    // Cash Sponsor Entity
                0xE8, 0xB0, 0xA6, 0x02, 0x00,             // E8 B0 A6 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x40, 0x97, 0x01, 0x00,             // 05 40 97 01 00       // add     eax, 19740h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x0D, 0x35, 0x19, 0x00,             // E8 0D 35 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x02, 0xFA, 0x7F, 0x00, 0x05, // C6 05 02 FA 7F 00 05 // mov     ds:byte_7FFA02, 5        // Cash Sponsor Entity
                0x68, 0x4F, 0x13, 0x00, 0x00,             // 68 4F 13 00 00       // push    134Fh                    // Cash Sponsor Entity
                0xE8, 0x74, 0xA6, 0x02, 0x00,             // E8 74 A6 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x54, 0x9D, 0x01, 0x00,             // 05 54 9D 01 00       // add     eax, 19D54h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xD1, 0x34, 0x19, 0x00,             // E8 D1 34 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x16, 0x00, 0x80, 0x00, 0x05, // C6 05 16 00 80 00 05 // mov     ds:byte_800016, 5        // Cash Sponsor Entity
                0x68, 0x50, 0x13, 0x00, 0x00,             // 68 50 13 00 00       // push    1350h                    // Cash Sponsor Entity
                0xE8, 0x38, 0xA6, 0x02, 0x00,             // E8 38 A6 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x68, 0xA3, 0x01, 0x00,             // 05 68 A3 01 00       // add     eax, 1A368h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x95, 0x34, 0x19, 0x00,             // E8 95 34 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x2A, 0x06, 0x80, 0x00, 0x05, // C6 05 2A 06 80 00 05 // mov     ds:byte_80062A, 5        // Cash Sponsor Entity
                0x68, 0x51, 0x13, 0x00, 0x00,             // 68 51 13 00 00       // push    1351h                    // Cash Sponsor Entity
                0xE8, 0xFC, 0xA5, 0x02, 0x00,             // E8 FC A5 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x7C, 0xA9, 0x01, 0x00,             // 05 7C A9 01 00       // add     eax, 1A97Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x59, 0x34, 0x19, 0x00,             // E8 59 34 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x3E, 0x0C, 0x80, 0x00, 0x05, // C6 05 3E 0C 80 00 05 // mov     ds:byte_800C3E, 5        // Cash Sponsor Entity
                0x68, 0x52, 0x13, 0x00, 0x00,             // 68 52 13 00 00       // push    1352h                    // Cash Sponsor Entity
                0xE8, 0xC0, 0xA5, 0x02, 0x00,             // E8 C0 A5 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x90, 0xAF, 0x01, 0x00,             // 05 90 AF 01 00       // add     eax, 1AF90h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x1D, 0x34, 0x19, 0x00,             // E8 1D 34 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x52, 0x12, 0x80, 0x00, 0x05, // C6 05 52 12 80 00 05 // mov     ds:byte_801252, 5        // Cash Sponsor Entity
                0x68, 0x53, 0x13, 0x00, 0x00,             // 68 53 13 00 00       // push    1353h                    // Cash Sponsor Entity
                0xE8, 0x84, 0xA5, 0x02, 0x00,             // E8 84 A5 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xA4, 0xB5, 0x01, 0x00,             // 05 A4 B5 01 00       // add     eax, 1B5A4h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xE1, 0x33, 0x19, 0x00,             // E8 E1 33 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x66, 0x18, 0x80, 0x00, 0x05, // C6 05 66 18 80 00 05 // mov     ds:byte_801866, 5        // Cash Sponsor Entity
                0x68, 0x54, 0x13, 0x00, 0x00,             // 68 54 13 00 00       // push    1354h                    // Cash Sponsor Entity
                0xE8, 0x48, 0xA5, 0x02, 0x00,             // E8 48 A5 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xB8, 0xBB, 0x01, 0x00,             // 05 B8 BB 01 00       // add     eax, 1BBB8h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xA5, 0x33, 0x19, 0x00,             // E8 A5 33 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x7A, 0x1E, 0x80, 0x00, 0x05, // C6 05 7A 1E 80 00 05 // mov     ds:byte_801E7A, 5        // Cash Sponsor Entity
                0x68, 0x55, 0x13, 0x00, 0x00,             // 68 55 13 00 00       // push    1355h                    // Cash Sponsor Entity
                0xE8, 0x0C, 0xA5, 0x02, 0x00,             // E8 0C A5 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xCC, 0xC1, 0x01, 0x00,             // 05 CC C1 01 00       // add     eax, 1C1CCh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x69, 0x33, 0x19, 0x00,             // E8 69 33 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x8E, 0x24, 0x80, 0x00, 0x05, // C6 05 8E 24 80 00 05 // mov     ds:byte_80248E, 5        // Cash Sponsor Entity
                0x68, 0x56, 0x13, 0x00, 0x00,             // 68 56 13 00 00       // push    1356h                    // Cash Sponsor Entity
                0xE8, 0xD0, 0xA4, 0x02, 0x00,             // E8 D0 A4 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xE0, 0xC7, 0x01, 0x00,             // 05 E0 C7 01 00       // add     eax, 1C7E0h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x2D, 0x33, 0x19, 0x00,             // E8 2D 33 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xA2, 0x2A, 0x80, 0x00, 0x05, // C6 05 A2 2A 80 00 05 // mov     ds:byte_802AA2, 5        // Cash Sponsor Entity
                0x68, 0x57, 0x13, 0x00, 0x00,             // 68 57 13 00 00       // push    1357h                    // Cash Sponsor Entity
                0xE8, 0x94, 0xA4, 0x02, 0x00,             // E8 94 A4 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xF4, 0xCD, 0x01, 0x00,             // 05 F4 CD 01 00       // add     eax, 1CDF4h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xF1, 0x32, 0x19, 0x00,             // E8 F1 32 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xB6, 0x30, 0x80, 0x00, 0x05, // C6 05 B6 30 80 00 05 // mov     ds:byte_8030B6, 5        // Cash Sponsor Entity
                0x68, 0x58, 0x13, 0x00, 0x00,             // 68 58 13 00 00       // push    1358h                    // Cash Sponsor Entity
                0xE8, 0x58, 0xA4, 0x02, 0x00,             // E8 58 A4 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x08, 0xD4, 0x01, 0x00,             // 05 08 D4 01 00       // add     eax, 1D408h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xB5, 0x32, 0x19, 0x00,             // E8 B5 32 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xCA, 0x36, 0x80, 0x00, 0x05, // C6 05 CA 36 80 00 05 // mov     ds:byte_8036CA, 5        // Cash Sponsor Entity
                0x68, 0x59, 0x13, 0x00, 0x00,             // 68 59 13 00 00       // push    1359h                    // Cash Sponsor Entity
                0xE8, 0x1C, 0xA4, 0x02, 0x00,             // E8 1C A4 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x1C, 0xDA, 0x01, 0x00,             // 05 1C DA 01 00       // add     eax, 1DA1Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x79, 0x32, 0x19, 0x00,             // E8 79 32 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xDE, 0x3C, 0x80, 0x00, 0x05, // C6 05 DE 3C 80 00 05 // mov     ds:byte_803CDE, 5        // Cash Sponsor Entity
                0x68, 0x5A, 0x13, 0x00, 0x00,             // 68 5A 13 00 00       // push    135Ah                    // Cash Sponsor Entity
                0xE8, 0xE0, 0xA3, 0x02, 0x00,             // E8 E0 A3 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x30, 0xE0, 0x01, 0x00,             // 05 30 E0 01 00       // add     eax, 1E030h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x3D, 0x32, 0x19, 0x00,             // E8 3D 32 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xF2, 0x42, 0x80, 0x00, 0x05, // C6 05 F2 42 80 00 05 // mov     ds:byte_8042F2, 5        // Cash Sponsor Entity
                0x68, 0x5B, 0x13, 0x00, 0x00,             // 68 5B 13 00 00       // push    135Bh                    // Cash Sponsor Entity
                0xE8, 0xA4, 0xA3, 0x02, 0x00,             // E8 A4 A3 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x44, 0xE6, 0x01, 0x00,             // 05 44 E6 01 00       // add     eax, 1E644h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x01, 0x32, 0x19, 0x00,             // E8 01 32 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x06, 0x49, 0x80, 0x00, 0x05, // C6 05 06 49 80 00 05 // mov     ds:byte_804906, 5        // Cash Sponsor Entity
                0x68, 0x5C, 0x13, 0x00, 0x00,             // 68 5C 13 00 00       // push    135Ch                    // Cash Sponsor Entity
                0xE8, 0x68, 0xA3, 0x02, 0x00,             // E8 68 A3 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x58, 0xEC, 0x01, 0x00,             // 05 58 EC 01 00       // add     eax, 1EC58h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xC5, 0x31, 0x19, 0x00,             // E8 C5 31 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x1A, 0x4F, 0x80, 0x00, 0x05, // C6 05 1A 4F 80 00 05 // mov     ds:byte_804F1A, 5        // Cash Sponsor Entity
                0x68, 0x5D, 0x13, 0x00, 0x00,             // 68 5D 13 00 00       // push    135Dh                    // Cash Sponsor Entity
                0xE8, 0x2C, 0xA3, 0x02, 0x00,             // E8 2C A3 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x6C, 0xF2, 0x01, 0x00,             // 05 6C F2 01 00       // add     eax, 1F26Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x89, 0x31, 0x19, 0x00,             // E8 89 31 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x2E, 0x55, 0x80, 0x00, 0x05, // C6 05 2E 55 80 00 05 // mov     ds:byte_80552E, 5        // Cash Sponsor Entity
                0x68, 0x5E, 0x13, 0x00, 0x00,             // 68 5E 13 00 00       // push    135Eh                    // Cash Sponsor Entity
                0xE8, 0xF0, 0xA2, 0x02, 0x00,             // E8 F0 A2 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x80, 0xF8, 0x01, 0x00,             // 05 80 F8 01 00       // add     eax, 1F880h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x4D, 0x31, 0x19, 0x00,             // E8 4D 31 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x42, 0x5B, 0x80, 0x00, 0x05, // C6 05 42 5B 80 00 05 // mov     ds:byte_805B42, 5        // Cash Sponsor Entity
                0x68, 0x5F, 0x13, 0x00, 0x00,             // 68 5F 13 00 00       // push    135Fh                    // Cash Sponsor Entity
                0xE8, 0xB4, 0xA2, 0x02, 0x00,             // E8 B4 A2 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x94, 0xFE, 0x01, 0x00,             // 05 94 FE 01 00       // add     eax, 1FE94h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x11, 0x31, 0x19, 0x00,             // E8 11 31 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x56, 0x61, 0x80, 0x00, 0x05, // C6 05 56 61 80 00 05 // mov     ds:byte_806156, 5        // Cash Sponsor Entity
                0x68, 0x60, 0x13, 0x00, 0x00,             // 68 60 13 00 00       // push    1360h                    // Cash Sponsor Entity
                0xE8, 0x78, 0xA2, 0x02, 0x00,             // E8 78 A2 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xA8, 0x04, 0x02, 0x00,             // 05 A8 04 02 00       // add     eax, 204A8h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xD5, 0x30, 0x19, 0x00,             // E8 D5 30 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x6A, 0x67, 0x80, 0x00, 0x05, // C6 05 6A 67 80 00 05 // mov     ds:byte_80676A, 5        // Cash Sponsor Entity
                0x68, 0x61, 0x13, 0x00, 0x00,             // 68 61 13 00 00       // push    1361h                    // Cash Sponsor Entity
                0xE8, 0x3C, 0xA2, 0x02, 0x00,             // E8 3C A2 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xBC, 0x0A, 0x02, 0x00,             // 05 BC 0A 02 00       // add     eax, 20ABCh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x99, 0x30, 0x19, 0x00,             // E8 99 30 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x7E, 0x6D, 0x80, 0x00, 0x05, // C6 05 7E 6D 80 00 05 // mov     ds:byte_806D7E, 5        // Cash Sponsor Entity
                0x68, 0x62, 0x13, 0x00, 0x00,             // 68 62 13 00 00       // push    1362h                    // Cash Sponsor Entity
                0xE8, 0x00, 0xA2, 0x02, 0x00,             // E8 00 A2 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xD0, 0x10, 0x02, 0x00,             // 05 D0 10 02 00       // add     eax, 210D0h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x5D, 0x30, 0x19, 0x00,             // E8 5D 30 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x92, 0x73, 0x80, 0x00, 0x05, // C6 05 92 73 80 00 05 // mov     ds:byte_807392, 5        // Cash Sponsor Entity
                0x68, 0x63, 0x13, 0x00, 0x00,             // 68 63 13 00 00       // push    1363h                    // Cash Sponsor Entity
                0xE8, 0xC4, 0xA1, 0x02, 0x00,             // E8 C4 A1 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xE4, 0x16, 0x02, 0x00,             // 05 E4 16 02 00       // add     eax, 216E4h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x21, 0x30, 0x19, 0x00,             // E8 21 30 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xA6, 0x79, 0x80, 0x00, 0x05, // C6 05 A6 79 80 00 05 // mov     ds:byte_8079A6, 5        // Cash Sponsor Entity
                0x68, 0x64, 0x13, 0x00, 0x00,             // 68 64 13 00 00       // push    1364h                    // Cash Sponsor Entity
                0xE8, 0x88, 0xA1, 0x02, 0x00,             // E8 88 A1 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xF8, 0x1C, 0x02, 0x00,             // 05 F8 1C 02 00       // add     eax, 21CF8h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xE5, 0x2F, 0x19, 0x00,             // E8 E5 2F 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xBA, 0x7F, 0x80, 0x00, 0x05, // C6 05 BA 7F 80 00 05 // mov     ds:byte_807FBA, 5        // Cash Sponsor Entity
                0x68, 0x65, 0x13, 0x00, 0x00,             // 68 65 13 00 00       // push    1365h                    // Cash Sponsor Entity
                0xE8, 0x4C, 0xA1, 0x02, 0x00,             // E8 4C A1 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x0C, 0x23, 0x02, 0x00,             // 05 0C 23 02 00       // add     eax, 2230Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xA9, 0x2F, 0x19, 0x00,             // E8 A9 2F 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xCE, 0x85, 0x80, 0x00, 0x05, // C6 05 CE 85 80 00 05 // mov     ds:byte_8085CE, 5        // Cash Sponsor Entity
                0x68, 0x66, 0x13, 0x00, 0x00,             // 68 66 13 00 00       // push    1366h                    // Cash Sponsor Entity
                0xE8, 0x10, 0xA1, 0x02, 0x00,             // E8 10 A1 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x20, 0x29, 0x02, 0x00,             // 05 20 29 02 00       // add     eax, 22920h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x6D, 0x2F, 0x19, 0x00,             // E8 6D 2F 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xE2, 0x8B, 0x80, 0x00, 0x05, // C6 05 E2 8B 80 00 05 // mov     ds:byte_808BE2, 5        // Cash Sponsor Entity
                0x68, 0x67, 0x13, 0x00, 0x00,             // 68 67 13 00 00       // push    1367h                    // Cash Sponsor Entity
                0xE8, 0xD4, 0xA0, 0x02, 0x00,             // E8 D4 A0 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x34, 0x2F, 0x02, 0x00,             // 05 34 2F 02 00       // add     eax, 22F34h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x31, 0x2F, 0x19, 0x00,             // E8 31 2F 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0xF6, 0x91, 0x80, 0x00, 0x05, // C6 05 F6 91 80 00 05 // mov     ds:byte_8091F6, 5        // Cash Sponsor Entity
                0x68, 0x68, 0x13, 0x00, 0x00,             // 68 68 13 00 00       // push    1368h                    // Cash Sponsor Entity
                0xE8, 0x98, 0xA0, 0x02, 0x00,             // E8 98 A0 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x48, 0x35, 0x02, 0x00,             // 05 48 35 02 00       // add     eax, 23548h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xF5, 0x2E, 0x19, 0x00,             // E8 F5 2E 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x0A, 0x98, 0x80, 0x00, 0x05, // C6 05 0A 98 80 00 05 // mov     ds:byte_80980A, 5        // Cash Sponsor Entity
                0x68, 0x69, 0x13, 0x00, 0x00,             // 68 69 13 00 00       // push    1369h                    // Cash Sponsor Entity
                0xE8, 0x5C, 0xA0, 0x02, 0x00,             // E8 5C A0 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x5C, 0x3B, 0x02, 0x00,             // 05 5C 3B 02 00       // add     eax, 23B5Ch              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xB9, 0x2E, 0x19, 0x00,             // E8 B9 2E 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x1E, 0x9E, 0x80, 0x00, 0x05, // C6 05 1E 9E 80 00 05 // mov     ds:byte_809E1E, 5        // Cash Sponsor Entity
                0x68, 0x6A, 0x13, 0x00, 0x00,             // 68 6A 13 00 00       // push    136Ah                    // Cash Sponsor Entity
                0xE8, 0x20, 0xA0, 0x02, 0x00,             // E8 20 A0 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x70, 0x41, 0x02, 0x00,             // 05 70 41 02 00       // add     eax, 24170h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x7D, 0x2E, 0x19, 0x00,             // E8 7D 2E 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x32, 0xA4, 0x80, 0x00, 0x05, // C6 05 32 A4 80 00 05 // mov     ds:byte_80A432, 5        // Cash Sponsor Entity
                0x68, 0x6B, 0x13, 0x00, 0x00,             // 68 6B 13 00 00       // push    136Bh                    // Cash Sponsor Entity
                0xE8, 0xE4, 0x9F, 0x02, 0x00,             // E8 E4 9F 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x84, 0x47, 0x02, 0x00,             // 05 84 47 02 00       // add     eax, 24784h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x41, 0x2E, 0x19, 0x00,             // E8 41 2E 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x46, 0xAA, 0x80, 0x00, 0x05, // C6 05 46 AA 80 00 05 // mov     ds:byte_80AA46, 5        // Cash Sponsor Entity
                0x68, 0x6C, 0x13, 0x00, 0x00,             // 68 6C 13 00 00       // push    136Ch                    // Cash Sponsor Entity
                0xE8, 0xB2, 0x9F, 0x02, 0x00,             // E8 B2 9F 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0x98, 0x4D, 0x02, 0x00,             // 05 98 4D 02 00       // add     eax, 24D98h              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0x0F, 0x2E, 0x19, 0x00,             // E8 0F 2E 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08,                         // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
                0xC6, 0x05, 0x5A, 0xB0, 0x80, 0x00, 0x05, // C6 05 5A B0 80 00 05 // mov     ds:byte_80B05A, 5        // Cash Sponsor Entity
                0x68, 0x6D, 0x13, 0x00, 0x00,             // 68 6D 13 00 00       // push    136Dh                    // Cash Sponsor Entity
                0xE8, 0x80, 0x9F, 0x02, 0x00,             // E8 80 9F 02 00       // call    sub_51371B               // Cash Sponsor Entity
                0x83, 0xC4, 0x04,                         // 83 C4 04             // add     esp, 4                   // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Source // Cash Sponsor Entity
                0xB8, 0x90, 0x5C, 0x7E, 0x00,             // B8 90 5C 7E 00       // mov     eax, offset dword_7E5C90 // Cash Sponsor Entity
                0x05, 0xAC, 0x53, 0x02, 0x00,             // 05 AC 53 02 00       // add     eax, 253ACh              // Cash Sponsor Entity
                0x50,                                     // 50                   // push    eax             ; Dest   // Cash Sponsor Entity
                0xE8, 0xDD, 0x2D, 0x19, 0x00,             // E8 DD 2D 19 00       // call    _strcpy                  // Cash Sponsor Entity
                0x83, 0xC4, 0x08                          // 83 C4 08             // add     esp, 8                   // Cash Sponsor Entity
            };
        }
    }
}