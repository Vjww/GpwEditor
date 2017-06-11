using Data.FileConnection;
using Data.Helpers;

namespace Data.Patchers.TrackEditorPatcher
{
    /// <summary>
    /// The Track Editor Patcher class makes changes to the instruction set/pattern
    /// in the gpw.exe v1.01b executable file to toggle the track editor flag.
    /// 
    /// Changes are made to the instruction set in the WndProc on the WM_KEYDOWN
    /// message when the virtual key equals VK_F8. Instead of calling a function
    /// to reduce race speed when VK_F8 is pressed, a custom function is called
    /// that toggles the track editor flag value. Currently no toggle is available
    /// and toggle may be redundant if the F12 key exists the track editor.
    /// 
    /// Code logic
    /// - Calls custom function to toggle the value of dword_15F31DC to 0/1
    /// </summary>
    public class TrackEditorPatcher
    {
        private readonly string _executableFilePath;

        public TrackEditorPatcher(string executableFilePath)
        {
            _executableFilePath = executableFilePath;
        }

        /// <summary>
        /// Applies the changes to enter the track editor in the race screen.
        /// This method is only intended for use with gpw.exe v1.01b.
        /// This method requires the Jump Bypass Patcher to be applied beforehand.
        /// Do not invoke this method more than once on the same file.
        /// </summary>
        public void Apply()
        {
            const int replacementWndProcLocation = 0x44F2B0;
            var replacementWndProcInstructions = new byte[]
            {
                0xE8, 0x94, 0x59, 0x02, 0x00
            };

            const int newTrackEditorToggleLocation = 0x00474C49;
            var newTrackEditorToggleInstructions = new byte[]
            {
                0x55,
                0x8B, 0xEC,
                0x53,
                0x56,
                0x57,
                0x83, 0x3D, 0xDC, 0x31, 0x5F, 0x01, 0x00,
                0x0F, 0x85, 0x0F, 0x00, 0x00, 0x00,
                0xC7, 0x05, 0xDC, 0x31, 0x5F, 0x01, 0x01, 0x00, 0x00, 0x00,
                0xE9, 0x0A, 0x00, 0x00, 0x00,
                0xC7, 0x05, 0xDC, 0x31, 0x5F, 0x01, 0x00, 0x00, 0x00, 0x00,
                0x5F,
                0x5E,
                0x5B,
                0xC9,
                0xC3
            };

            // Open file and write
            using (var executableConnection = new ExecutableConnection(_executableFilePath))
            {
                // Replace code in WndProc to respond to WM_KEYDOWN for VK_F8 (0x77)
                // Overwrites existing functionality to reduce race speed with the F8 key
                executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(replacementWndProcLocation), replacementWndProcInstructions);

                // Apply new function to toggle track editor flag value
                executableConnection.WriteByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(newTrackEditorToggleLocation), newTrackEditorToggleInstructions);
            }
        }
    }
}