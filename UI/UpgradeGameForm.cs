using System;
using System.Windows.Forms;
using Core.Properties;
using Data.Patchers;
using Data.Patchers.CodeShifting;
using Data.Patchers.Enhancements.Units;
using Data.Patchers.GlobalUnlockPatcher;
using Data.Patchers.JumpBypassPatcher;
using Data.Patchers.SwitchIdiomPatcher;
using UI.Properties;

namespace UI
{
    public partial class UpgradeGameForm : Form
    {
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
            const string executableFilePath = @"C:\Gpw\gpw.exe";

            try
            {
                var gameCdFix = new GameCdFix(executableFilePath);
                var displayModeFix = new DisplayModeFix(executableFilePath);
                var sampleAppFix = new SampleAppFix(executableFilePath);
                var globalUnlockFix = new GlobalUnlockFix(executableFilePath);
                var yellowFlagFix = new YellowFlagFix(executableFilePath);
                var raceSoundsFix = new RaceSoundsFix(executableFilePath);
                var pitExitPriorityFix = new PitExitPriorityFix(executableFilePath);
                //var carDesignCalculationUpdate = new CarDesignCalculationUpdate(executableFilePath);
                //var carHandlingPerformanceFix = new CarHandlingPerformanceFix(executableFilePath);

                var isDisableGameCdApplied = IsModifiedCodeApplied(gameCdFix);
                var isDisableColourModeApplied = IsModifiedCodeApplied(displayModeFix);
                var isDisableSampleAppApplied = IsModifiedCodeApplied(sampleAppFix);
                var isDisableGlobalUnlockApplied = IsModifiedCodeApplied(globalUnlockFix);
                var isDisableYellowFlagPenaltiesApplied = IsModifiedCodeApplied(yellowFlagFix);
                var isDisableMemoryResetForRaceSoundsApplied = IsModifiedCodeApplied(raceSoundsFix);
                var isDisablePitExitPriorityApplied = IsModifiedCodeApplied(pitExitPriorityFix);
                //var isEnableCarHandlingDesignCalculationApplied = IsModifiedCodeApplied(carDesignCalculationUpdate);
                //var isEnableCarPerformanceRaceCalcuationApplied = IsModifiedCodeApplied(carHandlingPerformanceFix);

                //// Switch idiom patcher is only intended for use when disassembling.
                //// Code is included here if you wish to patch all users executables
                //// during an upgrade but this may introduce defects into the game.
                //var switchIdiomPatcher = new SwitchIdiomPatcher();
                //switchIdiomPatcher.Apply(executableFilePath);
                //
                //// Free up space in executable by removing redundant jumping functions
                //// Required for upgrade to be successful and cannot be reversed
                //var jumpBypassPatcher = new JumpBypassPatcher();
                //jumpBypassPatcher.Apply(executableFilePath);
                //
                //// Shift code around to consolidate and organise instructions and utilise free space
                //// May add additional functionality to the game that cannot be reversed
                //// Required for upgrade to be successful and cannot be reversed
                //var codeShiftingPatcher = new CodeShiftingPatcher();
                //codeShiftingPatcher.Apply(executableFilePath);

                if (isDisableGameCdApplied != DisableGameCdCheckBox.Checked)
                {
                    ApplyCode(new GameCdFix(executableFilePath), DisableGameCdCheckBox.Checked);
                }

                if (isDisableColourModeApplied != DisableColourModeCheckBox.Checked)
                {
                    ApplyCode(new DisplayModeFix(executableFilePath), DisableColourModeCheckBox.Checked);
                }

                if (isDisableSampleAppApplied != DisableSampleAppCheckBox.Checked)
                {
                    ApplyCode(new SampleAppFix(executableFilePath), DisableSampleAppCheckBox.Checked);
                }

                if (isDisableGlobalUnlockApplied != DisableGlobalUnlockCheckBox.Checked)
                {
                    ApplyCode(new GlobalUnlockFix(executableFilePath), DisableGlobalUnlockCheckBox.Checked);
                }

                if (isDisableYellowFlagPenaltiesApplied != DisableYellowFlagPenaltiesCheckBox.Checked)
                {
                    ApplyCode(new YellowFlagFix(executableFilePath), DisableYellowFlagPenaltiesCheckBox.Checked);
                }

                if (isDisableMemoryResetForRaceSoundsApplied != DisableMemoryResetForRaceSoundsCheckbox.Checked)
                {
                    ApplyCode(new RaceSoundsFix(executableFilePath), DisableMemoryResetForRaceSoundsCheckbox.Checked);
                }

                if (isDisablePitExitPriorityApplied != DisablePitExitPriorityCheckBox.Checked)
                {
                    ApplyCode(new PitExitPriorityFix(executableFilePath), DisablePitExitPriorityCheckBox.Checked);
                }

                //if (isEnableCarHandlingDesignCalculationApplied != EnableCarHandlingDesignCalculationCheckbox.Checked)
                //{
                //    ApplyCode(new CarDesignCalculationUpdate(executableFilePath), EnableCarHandlingDesignCalculationCheckbox.Checked);
                //}
                //
                //if (isEnableCarPerformanceRaceCalcuationApplied != EnableCarPerformanceRaceCalcuationCheckbox.Checked)
                //{
                //    ApplyCode(new CarHandlingPerformanceFix(executableFilePath), EnableCarPerformanceRaceCalcuationCheckbox.Checked);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured:" + Environment.NewLine + Environment.NewLine + ex.Message);
            }
            MessageBox.Show("Complete");
        }

        private static bool IsModifiedCodeApplied(IDataPatcherUnitBase dataPatcherUnitBase)
        {
            if (dataPatcherUnitBase.IsCodeUnmodified())
            {
                return false;
            }

            if (!dataPatcherUnitBase.IsCodeModified())
            {
                throw new Exception("Unknown code detected. Upgrade cancelled.");
            }

            // Therefore modified code is applied
            return true;
        }

        private static void ApplyCode(IDataPatcherUnitBase dataPatcherUnitBase, bool applyModified)
        {
            if (applyModified)
            {
                if (dataPatcherUnitBase.IsCodeUnmodified())
                {
                    dataPatcherUnitBase.ApplyModifiedCode();
                }
                else
                {
                    if (!dataPatcherUnitBase.IsCodeModified())
                    {
                        throw new Exception("Unknown code detected. Unable to apply modified code.");
                    }
                    throw new Exception("Modified code already applied.");
                }
            }
            else
            {
                if (dataPatcherUnitBase.IsCodeModified())
                {
                    dataPatcherUnitBase.ApplyUnmodifiedCode();
                }
                else
                {
                    if (!dataPatcherUnitBase.IsCodeUnmodified())
                    {
                        throw new Exception("Unknown code detected. Unable to apply unmodified code.");
                    }
                    throw new Exception("Unmodified code already applied.");
                }
            }
        }
    }
}
