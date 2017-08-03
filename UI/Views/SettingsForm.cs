using System;
using System.Windows.Forms;
using Data.Patchers.CodeShiftPatcher;
using Data.Patchers.GlobalUnlockPatcher;
using Data.Patchers.JumpBypassPatcher;
using Data.Patchers.SwitchIdiomPatcher;
using Data.Patchers.TrackEditorPatcher;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public partial class SettingsForm : EditorForm
    {
        private readonly string _filePath;

        public SettingsForm()
        {
            _filePath = GetGameExecutableMruOrDefault();

            InitializeComponent();
            FilePathTextBox.Text = _filePath;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Settings";
        }

        private void SwitchIdiomButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("All switch statements will be replaced with a new switch idiom to allow for successful disassembly.");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplySwitchIdiomPatcher();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with the Switch Idiom Patcher.", "The changes made will simplify disassembly.");
        }

        private void JumpBypassButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("All calls to jump functions will be modified to call the inner function directly and the redundant jump functions will be removed.");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplyJumpBypassPatcher();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with the Jump Bypass Patcher.", "The changes made will simplify disassembly and improve modding capabilities.");
        }

        private void CodeShiftButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("Code shift will move instructions around the executable, simplify code and generate space for new instructions.");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplyCodeShiftPatcher();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with the Code Shift Patcher.", "The changes made will improve modding capabilities.");
        }

        private void GlobalUnlockButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("Global unlock will create a new method and redirect tested GlobalUnlock calls to it instead.");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplyGlobalUnlockPatcher();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with the Global Unlock Patcher.", "The changes made will resolve compatibility issues.");
        }

        private void TrackEditorButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("Track editor will assign a keyboard shortcut to activate the track editor.");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplyTrackEditorPatcher();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with the Track Editor Patcher.", "The changes made will activate the track editor.");
        }

        private void ApplyAllButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("Apply all patchers?");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplyAllPatchers();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with all patchers.", "The changes made will overhaul the game experience!");
        }

        private void ApplySwitchIdiomPatcher()
        {
            new SwitchIdiomPatcher(_filePath).Apply();
        }

        private void ApplyJumpBypassPatcher()
        {
            new JumpBypassPatcher(_filePath).Apply();
        }

        private void ApplyCodeShiftPatcher()
        {
            new CodeShiftPatcher(_filePath).Apply();
        }

        private void ApplyGlobalUnlockPatcher()
        {
            new GlobalUnlockPatcher(_filePath).Apply();
        }

        private void ApplyTrackEditorPatcher()
        {
            new TrackEditorPatcher(_filePath).Apply();
        }

        private void ApplyAllPatchers()
        {
            ApplySwitchIdiomPatcher();
            ApplyJumpBypassPatcher();
            ApplyCodeShiftPatcher();
            ApplyGlobalUnlockPatcher();
            ApplyTrackEditorPatcher();
        }

        private void OffsetValueGeneratorToolButton_Click(object sender, EventArgs e)
        {
            var form = new OffsetValueGeneratorToolForm();
            form.ShowDialog(this);
        }

        private void CutCodeFromFunctionButton_Click(object sender, EventArgs e)
        {
            var form = new ReconstructFunctionForm(0x0047141F, 0x00478F19, 0x004718EA);
            form.ShowDialog(this);
        }

        private static DialogResult ShowWarningMessageBox(string contextMessage)
        {
            return MessageBox.Show(string.Format(
                "{0} This operation should only be carried out once on the unmodified original file.{1}{1}Are you sure you wish to proceed?",
                contextMessage, Environment.NewLine),
                Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        private static void ShowCompleteMessageBox(string contextMessage, string purposeMessage)
        {
            MessageBox.Show(string.Format("{0}{1}{1}{2}", contextMessage, Environment.NewLine, purposeMessage));
        }
    }
}