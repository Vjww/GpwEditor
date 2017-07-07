namespace Data.ValueMapping.Executable.Config
{
    public class QualifyingViewport
    {
        /*        
            Qualifying viewport defaults
            ----------------------------
            .text:004513C4 C7 05 28 6F 72 00 00 00 00 00                 mov     ds:dword_726F28, 0      // ViewportTopLeft (TV Feed)
            .text:004513CE C7 05 2C 6F 72 00 00 00 00 00                 mov     ds:dword_726F2C, 0      //
            .text:004513D8 C7 05 30 6F 72 00 00 00 00 00                 mov     ds:dword_726F30, 0      //
            .text:004513E2 C7 05 34 6F 72 00 00 00 00 00                 mov     ds:dword_726F34, 0      //
            .text:004513EC C7 05 38 6F 72 00 00 00 00 00                 mov     ds:dword_726F38, 0      //
            .text:004513F6 C7 05 3C 6F 72 00 00 00 00 00                 mov     ds:dword_726F3C, 0      //
            .text:00451400 C7 05 40 6F 72 00 0C 00 00 00                 mov     ds:dword_726F40, 0Ch    //
            .text:0045140A C7 05 9C 6F 72 00 04 00 00 00                 mov     ds:dword_726F9C, 4      // ViewportTopRight (Telemetry)
            .text:00451414 C7 05 A8 6F 72 00 00 00 00 00                 mov     ds:dword_726FA8, 0      //
            .text:0045141E C7 05 A0 6F 72 00 00 00 00 00                 mov     ds:dword_726FA0, 0      //
            .text:00451428 C7 05 A4 6F 72 00 00 00 00 00                 mov     ds:dword_726FA4, 0      //
            .text:00451432 C7 05 AC 6F 72 00 00 00 00 00                 mov     ds:dword_726FAC, 0      //
            .text:0045143C C7 05 B0 6F 72 00 00 00 00 00                 mov     ds:dword_726FB0, 0      //
            .text:00451446 C7 05 B4 6F 72 00 0C 00 00 00                 mov     ds:dword_726FB4, 0Ch    //
            .text:00451450 C7 05 10 70 72 00 03 00 00 00                 mov     ds:dword_727010, 3      // ViewportBottomRight (Circuit Map)
            .text:0045145A C7 05 14 70 72 00 00 00 00 00                 mov     ds:dword_727014, 0      //
            .text:00451464 C7 05 18 70 72 00 00 00 00 00                 mov     ds:dword_727018, 0      //
            .text:0045146E C7 05 1C 70 72 00 00 00 00 00                 mov     ds:dword_72701C, 0      //
            .text:00451478 C7 05 20 70 72 00 00 00 00 00                 mov     ds:dword_727020, 0      //
            .text:00451482 C7 05 24 70 72 00 00 00 00 00                 mov     ds:dword_727024, 0      //
            .text:0045148C C7 05 28 70 72 00 0C 00 00 00                 mov     ds:dword_727028, 0Ch    //
            .text:00451496 C7 05 84 70 72 00 02 00 00 00                 mov     ds:dword_727084, 2      // ViewportBottomLeft (Driver Camera)
            .text:004514A0 A1 40 8D 5F 01                                mov     eax, dword_15F8D40      // 
            .text:004514A5 A3 88 70 72 00                                mov     ds:dword_727088, eax    // PlayerDriverOneIndex
            .text:004514AA C7 05 8C 70 72 00 00 00 00 00                 mov     ds:dword_72708C, 0      //
            .text:004514B4 C7 05 90 70 72 00 00 00 00 00                 mov     ds:dword_727090, 0      //
            .text:004514BE C7 05 94 70 72 00 00 00 00 00                 mov     ds:dword_727094, 0      //
            .text:004514C8 C7 05 98 70 72 00 00 00 00 00                 mov     ds:dword_727098, 0      //
            .text:004514D2 C7 05 9C 70 72 00 0C 00 00 00                 mov     ds:dword_72709C, 0Ch    //
        */

        /* Viewport indices
            0 - TV Feed
            1 - Track Camera
            2 - Driver Camera
            3 - Circuit Map
            4 - Telemetry
        */

        private const int NameIndex = 0; // 5172? - "????"

        private const int BaseOffset = 0; // 0x004513C4
        private const int LocalOffset = 116;
        private const int DisplayOffset = 0;

        public int Name { get; set; }
        public int Display { get; set; }


        public QualifyingViewport(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Display = BaseOffset + stepOffset + DisplayOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4
                };

            return idToResourceIdMap[id];
        }

/*
        //ViewportTypeCameraTL
        //ViewportTypeCameraTR
        //ViewportTypeCameraBR
        //ViewportTypeCameraBL
        //
        //BaseOffsetCameraTL = dword_726F28;
        //BaseOffsetCameraTR = dword_726F9C;
        //BaseOffsetCameraBR = dword_727010;
        //BaseOffsetCameraBL = dword_727084;
        
        //C7 05 @@ @@ @@ @@ ?? 00 00 00               SetViewportType (0 : TV Feed; 1 : Track Camera; 2 : Driver Camera; 3 : Circuit Map; 4 : Telemetry)
        
        // START FUNCTION OPCODES
        
        //foreach viewport in viewports
        //{
        //    WriteInstructions(C7 05 @@ @@ @@ @@ ?? ?? ?? ??).Format(address, value)
        //    if (viewportType == ViewportType.DriverCamera)
        //    {
        //        var driverIdAddress = driverId == 0 ? dword_15F8D40 : dword_15F8D44
        //        WriteInstructions(A1 ?? ?? ?? ??).Format(driverIdAddress)             // e.g. A1 40 8D 5F 01 for dword_15F8D40
        //        WriteInstructions(A3 ?? ?? ?? ??).Format(viewport.BaseOffset + 4)   // e.g. A3 2C 6F 72 00 for dword_726F2C
        //    }
        //    else
        //    {
        //        WriteInstructions(C7 05 @@ @@ @@ @@ 00 00 00 00).Format(address += 10, 0);
        //    }
        //    WriteInstructions(C7 05 @@ @@ @@ @@ 00 00 00 00).Format(address += 10, 0);
        //    WriteInstructions(C7 05 @@ @@ @@ @@ 00 00 00 00).Format(address += 10, 0);
        //    WriteInstructions(C7 05 @@ @@ @@ @@ 00 00 00 00).Format(address += 10, 0);
        //    WriteInstructions(C7 05 @@ @@ @@ @@ 00 00 00 00).Format(address += 10, 0);
        
        //    if (sessionType == SessionType.Qualifying)
        //    {
        //        WriteInstructions(C7 05 @@ @@ @@ @@ 0C 00 00 00).Format(address += 10, 12);
        //    }
        //    else
        //    {
        //        WriteInstructions(C7 05 @@ @@ @@ @@ 00 00 00 00).Format(address += 10, 0);
        //    }
        
        //}
        
        // END FUNCTION OPCODES
*/
    }
}