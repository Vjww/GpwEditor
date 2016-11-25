using System;
using System.Windows.Forms;
using Data.Patchers.CodeShifting;
using Data.Patchers.GlobalUnlockPatcher;
using Data.Patchers.JumpBypassPatcher;
using Data.Patchers.SwitchIdiomPatcher;
using GpwEditor.Properties;

namespace GpwEditor
{
    public partial class SettingsForm : Form
    {
        private string _filePath;

        public SettingsForm()
        {
            _filePath = @"C:\Gpw\gpw.exe";

            InitializeComponent();
            FilePathTextBox.Text = _filePath;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;
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
            ShowCompleteMessageBox("The executable file has been patched with the Switch Idiom Patcher.", "The changes made are only intended for disassembly.");
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
            ShowCompleteMessageBox("The executable file has been patched with the Jump Bypass Patcher.", "The changes made are only intended for disassembly.");
        }

        private void CodeShiftButton_Click(object sender, EventArgs e)
        {
            // Warning
            var dialogResult = ShowWarningMessageBox("Code shifting will move instructions around the executable, simplify code and generate space for new instructions.");
            if (dialogResult == DialogResult.No) return;

            // Act
            Cursor.Current = Cursors.WaitCursor;
            ApplyCodeShiftPatcher();
            Cursor.Current = Cursors.Default;

            // Complete
            ShowCompleteMessageBox("The executable file has been patched with the Code Shift Patcher.", "The changes made will overhaul the game!");
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
            ShowCompleteMessageBox("The executable file has been patched with all patchers.", "The changes made will overhaul the game!");
        }

        private void ApplySwitchIdiomPatcher()
        {
            var patcher = new SwitchIdiomPatcher(_filePath);
            patcher.Apply();
        }

        private void ApplyJumpBypassPatcher()
        {
            var patcher = new JumpBypassPatcher(_filePath);
            patcher.Apply();
        }

        private void ApplyGlobalUnlockPatcher()
        {
            var patcher = new GlobalUnlockPatcher(_filePath);
            patcher.Apply();
        }

        private void ApplyCodeShiftPatcher()
        {
            var patcher = new CodeShiftingPatcher(_filePath);
            patcher.Apply();
        }

        private void ApplyAllPatchers()
        {
            ApplySwitchIdiomPatcher();
            ApplyJumpBypassPatcher();
            ApplyGlobalUnlockPatcher();
            ApplyCodeShiftPatcher();
        }

        private void OffsetValueGeneratorToolButton_Click(object sender, EventArgs e)
        {
            var form = new OffsetValueGeneratorToolForm();
            form.ShowDialog(this);
        }
    }
}
