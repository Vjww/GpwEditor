using Core.Properties;
using Data.Patchers;
using Data.Patchers.Enhancements.Units;
using System;
using System.Diagnostics;
using System.Windows.Forms;
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
                ApplyUpgrades(executableFilePath);
                ApplyOptions(executableFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured. Process aborted." + Environment.NewLine + Environment.NewLine + ex.Message);
            }
            MessageBox.Show("Complete!");
        }

        private void ApplyUpgrades(string executableFilePath)
        {
            //// Switch idiom patcher is only intended for use when disassembling.
            //// Code is included here if you wish to patch all users executables
            //// during an upgrade but this may introduce defects into the game.
            //var switchIdiomPatcher = new SwitchIdiomPatcher();
            //switchIdiomPatcher.Apply(executableFilePath);

            //// Free up space in executable by removing redundant jumping functions
            //// Required for upgrade to be successful and cannot be reversed
            //var jumpBypassPatcher = new JumpBypassPatcher();
            //jumpBypassPatcher.Apply(executableFilePath);

            //// Shift code around to consolidate and organise instructions and utilise free space
            //// May add additional functionality to the game that cannot be reversed
            //// Required for upgrade to be successful and cannot be reversed
            //var codeShiftingPatcher = new CodeShiftingPatcher();
            //codeShiftingPatcher.Apply(executableFilePath);

            // Upgrade unmodified points scoring system with reworked code
            // to allow alternative point scoring systems to be used.
            var pointsScoringSystemUnmodified = new PointsSystemUnmodified(executableFilePath);
            var isUnmodifiedPointsScoringSystemInPlace = pointsScoringSystemUnmodified.IsCodeUnmodified();

            // If unmodified scoring system is still in place
            if (isUnmodifiedPointsScoringSystemInPlace)
            {
                // Apply default modified scoring system
                var pointsScoringSystemDefault = new PointsSystemF119912002Update(executableFilePath);
                ApplyIrreversableCode(pointsScoringSystemDefault);
            }
        }

        private void ApplyOptions(string executableFilePath)
        {
            // Scenarios for each reversable code module
            // Scenario 1: If currently applied and should not be applied, apply unmodified code
            // Scenario 2: If currently not applied and should be applied, apply modified code
            // Scenario 3: If currently applied and should be applied, do nothing
            // Scenario 4: If currently not applied and should not be applied, do nothing

            var gameCdFix = new GameCdFix(executableFilePath);
            var isDisableGameCdApplied = gameCdFix.IsCodeModified();
            if (isDisableGameCdApplied != DisableGameCdCheckBox.Checked)
            {
                ApplyReversableCode(gameCdFix, DisableGameCdCheckBox.Checked);
            }

            var displayModeFix = new DisplayModeFix(executableFilePath);
            var isDisableColourModeApplied = displayModeFix.IsCodeModified();
            if (isDisableColourModeApplied != DisableColourModeCheckBox.Checked)
            {
                ApplyReversableCode(displayModeFix, DisableColourModeCheckBox.Checked);
            }

            var sampleAppFix = new SampleAppFix(executableFilePath);
            var isDisableSampleAppApplied = sampleAppFix.IsCodeModified();
            if (isDisableSampleAppApplied != DisableSampleAppCheckBox.Checked)
            {
                ApplyReversableCode(sampleAppFix, DisableSampleAppCheckBox.Checked);
            }

            var globalUnlockFix = new GlobalUnlockFix(executableFilePath);
            var isDisableGlobalUnlockApplied = globalUnlockFix.IsCodeModified();
            if (isDisableGlobalUnlockApplied != DisableGlobalUnlockCheckBox.Checked)
            {
                ApplyReversableCode(globalUnlockFix, DisableGlobalUnlockCheckBox.Checked);
            }

            var yellowFlagFix = new YellowFlagFix(executableFilePath);
            var isDisableYellowFlagPenaltiesApplied = yellowFlagFix.IsCodeModified();
            if (isDisableYellowFlagPenaltiesApplied != DisableYellowFlagPenaltiesCheckBox.Checked)
            {
                ApplyReversableCode(yellowFlagFix, DisableYellowFlagPenaltiesCheckBox.Checked);
            }

            var raceSoundsFix = new RaceSoundsFix(executableFilePath);
            var isDisableMemoryResetForRaceSoundsApplied = raceSoundsFix.IsCodeModified();
            if (isDisableMemoryResetForRaceSoundsApplied != DisableMemoryResetForRaceSoundsCheckbox.Checked)
            {
                ApplyReversableCode(raceSoundsFix, DisableMemoryResetForRaceSoundsCheckbox.Checked);
            }

            //var pitExitPriorityFix = new PitExitPriorityFix(executableFilePath);
            //var isDisablePitExitPriorityApplied = pitExitPriorityFix.IsCodeModified();
            //if (isDisablePitExitPriorityApplied != DisablePitExitPriorityCheckBox.Checked)
            //{
            //    ApplyReversableCode(pitExitPriorityFix, DisablePitExitPriorityCheckBox.Checked);
            //}

            var carDesignCalculationUpdate = new CarDesignCalculationUpdate(executableFilePath);
            var isEnableCarHandlingDesignCalculationApplied = carDesignCalculationUpdate.IsCodeModified();
            if (isEnableCarHandlingDesignCalculationApplied != EnableCarHandlingDesignCalculationCheckbox.Checked)
            {
                ApplyReversableCode(carDesignCalculationUpdate, EnableCarHandlingDesignCalculationCheckbox.Checked);
            }

            var carHandlingPerformanceFix = new CarHandlingPerformanceFix(executableFilePath);
            var isEnableCarPerformanceRaceCalcuationApplied = carHandlingPerformanceFix.IsCodeModified();
            if (isEnableCarPerformanceRaceCalcuationApplied != EnableCarPerformanceRaceCalcuationCheckbox.Checked)
            {
                ApplyReversableCode(carHandlingPerformanceFix, EnableCarPerformanceRaceCalcuationCheckbox.Checked);
            }

            // Scenarios for each irreversable code module
            // Scenario 1: If currently not applied and should be applied, apply modified code
            // Scenario 2: If currently not applied and should not be applied, do nothing
            // Scenario 3: If currently applied, do nothing

            var pointsScoringSystemDefault = new PointsSystemF119912002Update(executableFilePath);
            var isPointsScoringSystemDefaultApplied = pointsScoringSystemDefault.IsCodeModified();
            if (!isPointsScoringSystemDefaultApplied && PointsScoringSystemDefaultRadioButton.Checked)
            {
                ApplyIrreversableCode(pointsScoringSystemDefault);
            }

            var pointsScoringSystemOption1 = new PointsSystemF119811990Update(executableFilePath);
            var isPointsScoringSystemOption1Applied = pointsScoringSystemOption1.IsCodeModified();
            if (!isPointsScoringSystemOption1Applied && PointsScoringSystemOption1RadioButton.Checked)
            {
                ApplyIrreversableCode(pointsScoringSystemOption1);
            }

            var pointsScoringSystemOption2 = new PointsSystemF120032009Update(executableFilePath);
            var isPointsScoringSystemOption2Applied = pointsScoringSystemOption2.IsCodeModified();
            if (!isPointsScoringSystemOption2Applied && PointsScoringSystemOption2RadioButton.Checked)
            {
                ApplyIrreversableCode(pointsScoringSystemOption2);
            }

            var pointsScoringSystemOption3 = new PointsSystemF1201020xxUpdate(executableFilePath);
            var isPointsScoringSystemOption3Applied = pointsScoringSystemOption3.IsCodeModified();
            if (!isPointsScoringSystemOption3Applied && PointsScoringSystemOption3RadioButton.Checked)
            {
                ApplyIrreversableCode(pointsScoringSystemOption3);
            }
        }

        private static void ApplyReversableCode(IDataPatcherUnitBase dataPatcherUnitBase, bool applyModified)
        {
            if (applyModified)
            {
                // If unmodified code is applied, apply modified code
                if (dataPatcherUnitBase.IsCodeUnmodified())
                {
                    Debug.WriteLine("Applying reversable modified code.");
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
                // If modified code is applied, apply unmodified code
                if (dataPatcherUnitBase.IsCodeModified())
                {
                    Debug.WriteLine("Applying reversable unmodified code.");
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

        private static void ApplyIrreversableCode(IDataPatcherUnitBase dataPatcherUnitBase)
        {
            Debug.WriteLine("Applying irreversable modified code.");
            dataPatcherUnitBase.ApplyModifiedCode();
        }
    }
}
