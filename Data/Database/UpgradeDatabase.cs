using System;
using System.Diagnostics;
using Common.Enums;
using Data.Collections.Language;
using Data.FileConnection;
using Data.Patchers;
using Data.Patchers.CodeShifting;
using Data.Patchers.Enhancements.Units;

namespace Data.Database
{
    public class UpgradeDatabase
    {
        public bool IsGameCdFixApplied { get; private set; }
        public bool IsDisplayModeFixApplied { get; private set; }
        public bool IsSampleAppFixApplied { get; private set; }
        public bool IsGlobalUnlockFixApplied { get; private set; }
        public bool IsRaceSoundsFixApplied { get; private set; }
        //public bool IsPitExitPriorityFixApplied { get; private set; }
        public bool IsYellowFlagFixApplied { get; private set; }
        public bool IsCarDesignCalculationUpdateApplied { get; private set; }
        public bool IsCarHandlingPerformanceFixApplied { get; private set; }
        public bool IsPointsScoringSystemDefaultApplied { get; private set; }
        public bool IsPointsScoringSystemOption1Applied { get; private set; }
        public bool IsPointsScoringSystemOption2Applied { get; private set; }
        public bool IsPointsScoringSystemOption3Applied { get; private set; }

        public bool IsGameCdFixRequired { get; set; }
        public bool IsDisplayModeFixRequired { get; set; }
        public bool IsSampleAppFixRequired { get; set; }
        public bool IsGlobalUnlockFixRequired { get; set; }
        public bool IsRaceSoundsFixRequired { get; set; }
        //public bool IsPitExitPriorityFixRequired { get; set; }
        public bool IsYellowFlagFixRequired { get; set; }
        public bool IsCarDesignCalculationUpdateRequired { get; set; }
        public bool IsCarHandlingPerformanceFixRequired { get; set; }
        public bool IsPointsScoringSystemDefaultRequired { get; set; }
        public bool IsPointsScoringSystemOption1Required { get; set; }
        public bool IsPointsScoringSystemOption2Required { get; set; }
        public bool IsPointsScoringSystemOption3Required { get; set; }

        public IdentityCollection LanguageStrings { get; set; }

        public void ImportDataFromFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            // TODO validate language file
            // TODO ImportLanguageStrings(languageFileFilePath);

            // TODO validate exe
            // TODO ValidateGameExecutableAsValidExecutable();
            // TODO ValidateGameExecutableAsUpgradedExecutable();

            ImportUpgrades(gameExecutableFilePath);
            ImportOptions(gameExecutableFilePath);
        }

        private void ImportLanguageStrings(string languageFileFilePath)
        {
            LanguageConnection languageConnection = null;
            try
            {
                languageConnection = new LanguageConnection();
                languageConnection.Open(languageFileFilePath, StreamDirectionType.Read);
                LanguageStrings = languageConnection.Load();
            }
            finally
            {
                languageConnection?.Close();
            }
        }

        private void ImportUpgrades(string gameExecutableFilePath)
        {
            // TODO Implement
        }

        private void ImportOptions(string gameExecutableFilePath)
        {
            IsGameCdFixApplied = new GameCdFix(gameExecutableFilePath).IsCodeModified();
            IsDisplayModeFixApplied = new DisplayModeFix(gameExecutableFilePath).IsCodeModified();
            IsSampleAppFixApplied = new SampleAppFix(gameExecutableFilePath).IsCodeModified();
            IsGlobalUnlockFixApplied = new GlobalUnlockFix(gameExecutableFilePath).IsCodeModified();
            IsYellowFlagFixApplied = new YellowFlagFix(gameExecutableFilePath).IsCodeModified();
            IsRaceSoundsFixApplied = new RaceSoundsFix(gameExecutableFilePath).IsCodeModified();
            //IsPitExitPriorityFixApplied = new PitExitPriorityFix(gameExecutableFilePath).IsCodeModified();
            IsCarDesignCalculationUpdateApplied = new CarDesignCalculationUpdate(gameExecutableFilePath).IsCodeModified();
            IsCarHandlingPerformanceFixApplied = new CarHandlingPerformanceFix(gameExecutableFilePath).IsCodeModified();

            IsPointsScoringSystemDefaultApplied = new PointsSystemF119912002Update(gameExecutableFilePath).IsCodeModified();
            IsPointsScoringSystemOption1Applied = new PointsSystemF119811990Update(gameExecutableFilePath).IsCodeModified();
            IsPointsScoringSystemOption2Applied = new PointsSystemF120032009Update(gameExecutableFilePath).IsCodeModified();
            IsPointsScoringSystemOption3Applied = new PointsSystemF1201020xxUpdate(gameExecutableFilePath).IsCodeModified();
        }

        public void ExportDataToFile(string gameExecutableFilePath, string languageFileFilePath)
        {
            // TODO validate language file
            // TODO ExportLanguageStrings(languageFileFilePath);

            // TODO validate exe
            // TODO ValidateGameExecutableAsValidExecutable();
            // TODO ValidateGameExecutableAsUpgradedExecutable();

            ExportUpgrades(gameExecutableFilePath);
            ExportOptions(gameExecutableFilePath);
        }

        private void ExportLanguageStrings(string languageFileFilePath)
        {
            LanguageConnection languageConnection = null;
            try
            {
                languageConnection = new LanguageConnection();
                languageConnection.Open(languageFileFilePath, StreamDirectionType.Write);
                languageConnection.Save(LanguageStrings);
            }
            finally
            {
                languageConnection?.Close();
            }
        }

        private void ExportUpgrades(string gameExecutableFilePath)
        {
            //// Switch idiom patcher is only intended for use when disassembling.
            //// Code is included here if you wish to patch all users executables
            //// during an upgrade but this may introduce defects into the game.
            //var switchIdiomPatcher = new SwitchIdiomPatcher();
            //switchIdiomPatcher.Apply(gameExecutableFilePath);

            //// Free up space in executable by removing redundant jumping functions
            //// Required for upgrade to be successful and cannot be reversed
            //var jumpBypassPatcher = new JumpBypassPatcher();
            //jumpBypassPatcher.Apply(gameExecutableFilePath);

            //// Shift code around to consolidate and organise instructions and utilise free space
            //// May add additional functionality to the game that cannot be reversed
            // Required for upgrade to be successful and cannot be reversed
            var codeShiftingPatcher = new CodeShiftingPatcher();
            codeShiftingPatcher.Apply(gameExecutableFilePath);

            // Upgrade unmodified points scoring system with reworked code
            // to allow alternative point scoring systems to be used.
            var pointsScoringSystemUnmodified = new PointsSystemUnmodified(gameExecutableFilePath);
            var isUnmodifiedPointsScoringSystemInPlace = pointsScoringSystemUnmodified.IsCodeUnmodified();

            // If unmodified scoring system is still in place
            if (isUnmodifiedPointsScoringSystemInPlace)
            {
                // Apply default modified scoring system
                var pointsScoringSystemDefault = new PointsSystemF119912002Update(gameExecutableFilePath);
                ApplyIrreversibleCode(pointsScoringSystemDefault);
            }
        }

        private void ExportOptions(string gameExecutableFilePath)
        {
            // Scenarios for each reversible code module
            // Scenario 1: If currently applied and should not be applied, apply unmodified code
            // Scenario 2: If currently not applied and should be applied, apply modified code
            // Scenario 3: If currently applied and should be applied, do nothing
            // Scenario 4: If currently not applied and should not be applied, do nothing

            var gameCdFix = new GameCdFix(gameExecutableFilePath);
            var isGameCdFixApplied = gameCdFix.IsCodeModified();
            if (isGameCdFixApplied != IsGameCdFixRequired)
            {
                ApplyReversibleCode(gameCdFix, IsGameCdFixRequired);
            }

            var displayModeFix = new DisplayModeFix(gameExecutableFilePath);
            var isDisplayModeFixApplied = displayModeFix.IsCodeModified();
            if (isDisplayModeFixApplied != IsDisplayModeFixRequired)
            {
                ApplyReversibleCode(displayModeFix, IsDisplayModeFixRequired);
            }

            var sampleAppFix = new SampleAppFix(gameExecutableFilePath);
            var isSampleAppFixApplied = sampleAppFix.IsCodeModified();
            if (isSampleAppFixApplied != IsSampleAppFixRequired)
            {
                ApplyReversibleCode(sampleAppFix, IsSampleAppFixRequired);
            }

            var globalUnlockFix = new GlobalUnlockFix(gameExecutableFilePath);
            var isGlobalUnlockFixApplied = globalUnlockFix.IsCodeModified();
            if (isGlobalUnlockFixApplied != IsGlobalUnlockFixRequired)
            {
                ApplyReversibleCode(globalUnlockFix, IsGlobalUnlockFixRequired);
            }

            var yellowFlagFix = new YellowFlagFix(gameExecutableFilePath);
            var isYellowFlagFixApplied = yellowFlagFix.IsCodeModified();
            if (isYellowFlagFixApplied != IsYellowFlagFixRequired)
            {
                ApplyReversibleCode(yellowFlagFix, IsYellowFlagFixRequired);
            }

            var raceSoundsFix = new RaceSoundsFix(gameExecutableFilePath);
            var isRaceSoundsFixApplied = raceSoundsFix.IsCodeModified();
            if (isRaceSoundsFixApplied != IsRaceSoundsFixRequired)
            {
                ApplyReversibleCode(raceSoundsFix, IsRaceSoundsFixRequired);
            }

            //var pitExitPriorityFix = new PitExitPriorityFix(gameExecutableFilePath);
            //var isPitExitPriorityFixApplied = pitExitPriorityFix.IsCodeModified();
            //if (isPitExitPriorityFixApplied != IsPitExitPriorityFixRequired)
            //{
            //    ApplyReversibleCode(pitExitPriorityFix, IsPitExitPriorityFixRequired);
            //}

            var carDesignCalculationUpdate = new CarDesignCalculationUpdate(gameExecutableFilePath);
            var isEnableCarHandlingDesignCalculationApplied = carDesignCalculationUpdate.IsCodeModified();
            if (isEnableCarHandlingDesignCalculationApplied != IsCarDesignCalculationUpdateRequired)
            {
                ApplyReversibleCode(carDesignCalculationUpdate, IsCarDesignCalculationUpdateRequired);
            }

            var carHandlingPerformanceFix = new CarHandlingPerformanceFix(gameExecutableFilePath);
            var isEnableCarPerformanceRaceCalcuationApplied = carHandlingPerformanceFix.IsCodeModified();
            if (isEnableCarPerformanceRaceCalcuationApplied != IsCarHandlingPerformanceFixRequired)
            {
                ApplyReversibleCode(carHandlingPerformanceFix, IsCarHandlingPerformanceFixRequired);
            }

            // Scenarios for each irreversible code module
            // Scenario 1: If currently not applied and should be applied, apply modified code
            // Scenario 2: If currently not applied and should not be applied, do nothing
            // Scenario 3: If currently applied, do nothing

            var pointsScoringSystemDefault = new PointsSystemF119912002Update(gameExecutableFilePath);
            var isPointsScoringSystemDefaultApplied = pointsScoringSystemDefault.IsCodeModified();
            if (!isPointsScoringSystemDefaultApplied && IsPointsScoringSystemDefaultRequired)
            {
                ApplyIrreversibleCode(pointsScoringSystemDefault);
            }

            var pointsScoringSystemOption1 = new PointsSystemF119811990Update(gameExecutableFilePath);
            var isPointsScoringSystemOption1Applied = pointsScoringSystemOption1.IsCodeModified();
            if (!isPointsScoringSystemOption1Applied && IsPointsScoringSystemOption1Required)
            {
                ApplyIrreversibleCode(pointsScoringSystemOption1);
            }

            var pointsScoringSystemOption2 = new PointsSystemF120032009Update(gameExecutableFilePath);
            var isPointsScoringSystemOption2Applied = pointsScoringSystemOption2.IsCodeModified();
            if (!isPointsScoringSystemOption2Applied && IsPointsScoringSystemOption2Required)
            {
                ApplyIrreversibleCode(pointsScoringSystemOption2);
            }

            var pointsScoringSystemOption3 = new PointsSystemF1201020xxUpdate(gameExecutableFilePath);
            var isPointsScoringSystemOption3Applied = pointsScoringSystemOption3.IsCodeModified();
            if (!isPointsScoringSystemOption3Applied && IsPointsScoringSystemOption3Required)
            {
                ApplyIrreversibleCode(pointsScoringSystemOption3);
            }
        }

        private static void ApplyReversibleCode(IDataPatcherUnitBase dataPatcherUnitBase, bool applyModified)
        {
            if (applyModified)
            {
                // If unmodified code is applied, apply modified code
                if (dataPatcherUnitBase.IsCodeUnmodified())
                {
                    Debug.WriteLine("Applying reversible modified code.");
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
                    Debug.WriteLine("Applying reversible unmodified code.");
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

        private static void ApplyIrreversibleCode(IDataPatcherUnitBase dataPatcherUnitBase)
        {
            Debug.WriteLine("Applying irreversible modified code.");
            dataPatcherUnitBase.ApplyModifiedCode();
        }
    }
}
