namespace Data.ValueMapping.Executable.Config
{
    public class Viewport
    {
        // TODO Sort this file
        /* Viewport indices
            0 - TV Feed
            1 - Track Camera
            2 - Driver Camera
            3 - Circuit Map
            4 - Telemetry
        
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

        Race viewport defaults
        ----------------------
        .text:0048D753 C7 05 28 6F 72 00 00 00 00 00                 mov     ds:dword_726F28, 0      // ViewportTopLeft (TV Feed)
        .text:0048D75D C7 05 2C 6F 72 00 00 00 00 00                 mov     ds:dword_726F2C, 0      //
        .text:0048D767 C7 05 30 6F 72 00 00 00 00 00                 mov     ds:dword_726F30, 0      //
        .text:0048D771 C7 05 34 6F 72 00 00 00 00 00                 mov     ds:dword_726F34, 0      //
        .text:0048D77B C7 05 38 6F 72 00 00 00 00 00                 mov     ds:dword_726F38, 0      //
        .text:0048D785 C7 05 3C 6F 72 00 00 00 00 00                 mov     ds:dword_726F3C, 0      //
        .text:0048D78F C7 05 40 6F 72 00 00 00 00 00                 mov     ds:dword_726F40, 0      //
        .text:0048D799 C7 05 9C 6F 72 00 04 00 00 00                 mov     ds:dword_726F9C, 4      // ViewportTopRight (Telemetry)
        .text:0048D7A3 C7 05 A8 6F 72 00 00 00 00 00                 mov     ds:dword_726FA8, 0      //
        .text:0048D7AD C7 05 A0 6F 72 00 00 00 00 00                 mov     ds:dword_726FA0, 0      //
        .text:0048D7B7 C7 05 A4 6F 72 00 00 00 00 00                 mov     ds:dword_726FA4, 0      //
        .text:0048D7C1 C7 05 AC 6F 72 00 00 00 00 00                 mov     ds:dword_726FAC, 0      //
        .text:0048D7CB C7 05 B0 6F 72 00 00 00 00 00                 mov     ds:dword_726FB0, 0      //
        .text:0048D7D5 C7 05 B4 6F 72 00 00 00 00 00                 mov     ds:dword_726FB4, 0      //
        .text:0048D7DF C7 05 10 70 72 00 03 00 00 00                 mov     ds:dword_727010, 3      // ViewportBottomRight (Circuit Map)
        .text:0048D7E9 C7 05 14 70 72 00 00 00 00 00                 mov     ds:dword_727014, 0      //
        .text:0048D7F3 C7 05 18 70 72 00 00 00 00 00                 mov     ds:dword_727018, 0      //
        .text:0048D7FD C7 05 1C 70 72 00 00 00 00 00                 mov     ds:dword_72701C, 0      //
        .text:0048D807 C7 05 20 70 72 00 00 00 00 00                 mov     ds:dword_727020, 0      //
        .text:0048D811 C7 05 24 70 72 00 00 00 00 00                 mov     ds:dword_727024, 0      //
        .text:0048D81B C7 05 28 70 72 00 00 00 00 00                 mov     ds:dword_727028, 0      //
        .text:0048D825 C7 05 84 70 72 00 02 00 00 00                 mov     ds:dword_727084, 2      // ViewportBottomLeft (Driver Camera)
        .text:0048D82F A1 40 8D 5F 01                                mov     eax, dword_15F8D40      // 
        .text:0048D834 A3 88 70 72 00                                mov     ds:dword_727088, eax    // PlayerDriverOneIndex
        .text:0048D839 C7 05 8C 70 72 00 00 00 00 00                 mov     ds:dword_72708C, 0      //
        .text:0048D843 C7 05 90 70 72 00 00 00 00 00                 mov     ds:dword_727090, 0      //
        .text:0048D84D C7 05 94 70 72 00 00 00 00 00                 mov     ds:dword_727094, 0      //
        .text:0048D857 C7 05 98 70 72 00 00 00 00 00                 mov     ds:dword_727098, 0      //
        .text:0048D861 C7 05 9C 70 72 00 00 00 00 00                 mov     ds:dword_72709C, 0      //
        */
    }
}
