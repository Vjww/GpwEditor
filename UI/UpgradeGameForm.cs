using System.Collections.Generic;
using System.Linq;
using Core.Helpers;
using Core.Properties;
using System;
using System.Windows.Forms;
using Data.Enums;
using Data.FileConnection;
using Data.Patchers;
using Data.Patchers.CodeShifting;
using Data.Patchers.Enhancements.Units;
using Data.Patchers.JumpBypassPatcher;
using Data.Patchers.SwitchIdiomPatcher;
using UI.Properties;

namespace UI
{
    public partial class UpgradeGameForm : Form
    {
        private bool isDisableGameCdCheckBoxApplied;
        private bool isDisableColourModeApplied;
        private bool isDisableYellowFlagPenaltiesApplied;
        private bool isDisableMemoryResetForRaceSoundsApplied;
        private bool isEnableCarHandlingDesignCalculationApplied;
        private bool isEnableCarPerformanceRaceCalcuationApplied;

        public UpgradeGameForm()
        {
            InitializeComponent();
        }

        private void UpgradeGameForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = string.Format(Text, Settings.Default.ApplicationName) + " - Upgrade Game";

            //// Retreive default paths
            //var defaultExecutableFilePath = Path.Combine(Settings.Default.UserGameFolderPath,
            //    Settings.Default.DefaultExecutableFileName);
            //var defaultLanguageFilePath = Path.Combine(Settings.Default.UserGameFolderPath,
            //    Settings.Default.DefaultLanguageFileName);
        }

        private void UpgradeGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!ConfirmCloseFormWithUnsavedChanges())
            //{
            //    // Abort event
            //    e.Cancel = true;
            //    return;
            //}

            // Save and close form
            Settings.Default.Save();
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            var filePath = String.Empty;

            // File connection
            ExecutableConnection executableConnection = null;

            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(filePath, StreamDirectionType.Read);

                // Switch idiom patcher is only intended for use when disassembling.
                // Code is included here if you wish to patch all users executables
                // during an upgrade but this may introduce defects into the game.
                //var switchIdiomPatcher = new SwitchIdiomPatcher();
                //switchIdiomPatcher.Apply(filePath);

                // Free up space in executable by removing redundant jumping functions
                // Required for upgrade to be successful and cannot be reversed
                var jumpBypassPatcher = new JumpBypassPatcher();
                jumpBypassPatcher.Apply(filePath);

                // Shift code around to consolidate and organise instructions and utilise free space
                // May add additional functionality to the game that cannot be reversed
                // Required for upgrade to be successful and cannot be reversed
                var codeShiftingPatcher = new CodeShiftingPatcher();
                codeShiftingPatcher.Apply(filePath);

                // Optional and can be reversed
                if (DisableGameCdCheckBox.Enabled)
                {
                    // Apply upgrade/downgrade
                    var enhancementUnit = new GameCdFix();
                    var enhancementUnitInstructions = DisableGameCdCheckBox.Checked ? enhancementUnit.GetModifiedInstructions() : enhancementUnit.GetUnmodifiedInstructions();
                    foreach (var instructionsTask in enhancementUnitInstructions)
                    {
                        var currentInstructions = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(instructionsTask.Position),instructionsTask.InstructionSet.Length);

                        // If current instructions do not equal upgrade/downgrade instructions
                        if (!currentInstructions.SequenceEqual(instructionsTask.InstructionSet))
                        {
                            // Apply new instructions
                        }
                    }
                }

                // Optional and can be reversed
                if (DisableColourModeCheckBox.Checked)
                {
                }

                // Optional and can be reversed
                if (DisableYellowFlagPenaltiesCheckBox.Checked)
                {
                }

                // Optional and can be reversed
                if (DisableMemoryResetForRaceSoundsCheckbox.Checked)
                {
                }

                // Optional and can be reversed
                if (DisablePitExitPriorityCheckBox.Checked)
                {
                }

                // Optional and can be reversed
                if (EnableCarHandlingDesignCalculationCheckbox.Checked)
                {
                }

                // Optional and can be reversed
                if (EnableCarPerformanceRaceCalcuationCheckbox.Checked)
                {
                }

                // File connection
                ExecutableConnection executableConnection = null;


                foreach (var item in enhancementUnits)
                {
                    var modifiedInstructions = item.GetModifiedInstructions();
                    foreach (var task in modifiedInstructions)
                    {
                        var currentInstructions =
                            executableConnection.ReadByteArray(
                                InstructionHelper.CalculateRealPositionFromVirtualPosition(task.Position),
                                task.InstructionSet.Length);
                        if (!currentInstructions.SequenceEqual(task.InstructionSet))
                        {
                            //return false;
                        }
                    }
                }
            }
            finally
            {
                if (executableConnection != null)
                {
                    executableConnection.Close();
                }
            }
        }

        private bool IsEnhancementUnitCurrentlyApplied(string filePath)
        {
            // File connection
            ExecutableConnection executableConnection = null;

            try
            {
                executableConnection = new ExecutableConnection();
                executableConnection.Open(filePath, StreamDirectionType.Read);

                var enhancementUnit = new GameCdFix();
                var modifiedInstructions = enhancementUnit.GetModifiedInstructions();
                foreach (var task in modifiedInstructions)
                {
                    // TODO
                    var currentInstructions = executableConnection.ReadByteArray(InstructionHelper.CalculateRealPositionFromVirtualPosition(task.Position), task.InstructionSet.Length);
                    if (!currentInstructions.SequenceEqual(task.InstructionSet))
                    {
                        isDisableGameCdCheckBoxApplied = false;
                    }
                }
            }
            finally
            {
                if (executableConnection != null)
                {
                    executableConnection.Close();
                }
            }
        }
    }
}
