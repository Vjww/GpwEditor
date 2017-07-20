using System;
using System.Diagnostics;
using Data.Collections.Language;
using Data.Entities.Executable.Race;
using Data.FileConnection;
using Data.Patchers;
using Data.Patchers.Enhancements.Units;

namespace Data.Databases
{
    public class ConfigureGameDatabase
    {
        // Current state flags
        public bool IsGameCdFixApplied { get; private set; }
        public bool IsDisplayModeFixApplied { get; private set; }
        public bool IsSampleAppFixApplied { get; private set; }
        public bool IsRaceSoundsFixApplied { get; private set; }
        // TODO: public bool IsPitExitPriorityFixApplied { get; private set; }
        public bool IsYellowFlagFixApplied { get; private set; }
        public bool IsCarDesignCalculationUpdateApplied { get; private set; }
        public bool IsCarHandlingPerformanceFixApplied { get; private set; }
        public bool IsPointsScoringSystemDefaultApplied { get; private set; }
        public bool IsPointsScoringSystemOption1Applied { get; private set; }
        public bool IsPointsScoringSystemOption2Applied { get; private set; }
        public bool IsPointsScoringSystemOption3Applied { get; private set; }
        public bool IsCommentaryModifiedApplied { get; set; }

        // Future state flags
        public bool IsGameCdFixRequired { get; set; }
        public bool IsDisplayModeFixRequired { get; set; }
        public bool IsSampleAppFixRequired { get; set; }
        public bool IsRaceSoundsFixRequired { get; set; }
        // TODO: public bool IsPitExitPriorityFixRequired { get; set; }
        public bool IsYellowFlagFixRequired { get; set; }
        public bool IsCarDesignCalculationUpdateRequired { get; set; }
        public bool IsCarHandlingPerformanceFixRequired { get; set; }
        public bool IsPointsScoringSystemDefaultRequired { get; set; }
        public bool IsPointsScoringSystemOption1Required { get; set; }
        public bool IsPointsScoringSystemOption2Required { get; set; }
        public bool IsPointsScoringSystemOption3Required { get; set; }
        public bool IsCommentaryModifiedRequired { get; set; }

        public IdentityCollection LanguageStrings { get; set; }
        public PerformanceCurve PerformanceCurve { get; set; }

        public void ImportDataFromFile(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            ValidateGameFolder(gameFolderPath, "import");
            ValidateGameExecutable(gameExecutablePath, "import");
            ValidateLanguageFile(languageFilePath, "import");

            ImportLanguageStrings(languageFilePath);

            ImportGameConfiguration(gameExecutablePath);
            ImportPerformanceCurve(gameExecutablePath);
        }

        public void ExportDataToFile(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            ValidateGameFolder(gameFolderPath, "export");
            ValidateGameExecutable(gameExecutablePath, "export");
            ValidateLanguageFile(languageFilePath, "export");

            ExportGameConfiguration(gameExecutablePath);
            ExportPerformanceCurve(gameExecutablePath);

            ExportLanguageStrings(languageFilePath);
        }

        private void ExportLanguageStrings(string languageFilePath)
        {
            using (var languageConnection = new LanguageConnection(languageFilePath))
            {
                languageConnection.Save(LanguageStrings);
            }
        }

        private void ImportLanguageStrings(string languageFilePath)
        {
            using (var languageConnection = new LanguageConnection(languageFilePath))
            {
                LanguageStrings = languageConnection.Load();
            }
        }

        private void ExportGameConfiguration(string gameExecutablePath)
        {
            // Scenarios for each reversible code module
            // Scenario 1: If currently applied and should not be applied, apply unmodified code
            // Scenario 2: If currently not applied and should be applied, apply modified code
            // Scenario 3: If currently applied and should be applied, do nothing
            // Scenario 4: If currently not applied and should not be applied, do nothing

            var gameCdFix = new GameCdFix(gameExecutablePath);
            var isGameCdFixApplied = gameCdFix.IsCodeModified();
            if (isGameCdFixApplied != IsGameCdFixRequired)
            {
                ApplyReversibleCode(gameCdFix, IsGameCdFixRequired);
            }

            var displayModeFix = new DisplayModeFix(gameExecutablePath);
            var isDisplayModeFixApplied = displayModeFix.IsCodeModified();
            if (isDisplayModeFixApplied != IsDisplayModeFixRequired)
            {
                ApplyReversibleCode(displayModeFix, IsDisplayModeFixRequired);
            }

            var sampleAppFix = new SampleAppFix(gameExecutablePath);
            var isSampleAppFixApplied = sampleAppFix.IsCodeModified();
            if (isSampleAppFixApplied != IsSampleAppFixRequired)
            {
                ApplyReversibleCode(sampleAppFix, IsSampleAppFixRequired);
            }

            var raceSoundsFix = new RaceSoundsFix(gameExecutablePath);
            var isRaceSoundsFixApplied = raceSoundsFix.IsCodeModified();
            if (isRaceSoundsFixApplied != IsRaceSoundsFixRequired)
            {
                ApplyReversibleCode(raceSoundsFix, IsRaceSoundsFixRequired);
            }

            // TODO: var pitExitPriorityFix = new PitExitPriorityFix(gameExecutablePath);
            // TODO: var isPitExitPriorityFixApplied = pitExitPriorityFix.IsCodeModified();
            // TODO: if (isPitExitPriorityFixApplied != IsPitExitPriorityFixRequired)
            // TODO: {
            // TODO:     ApplyReversibleCode(pitExitPriorityFix, IsPitExitPriorityFixRequired);
            // TODO: }

            var yellowFlagFix = new YellowFlagFix(gameExecutablePath);
            var isYellowFlagFixApplied = yellowFlagFix.IsCodeModified();
            if (isYellowFlagFixApplied != IsYellowFlagFixRequired)
            {
                ApplyReversibleCode(yellowFlagFix, IsYellowFlagFixRequired);
            }

            var carDesignCalculationUpdate = new CarDesignCalculationUpdate(gameExecutablePath);
            var isEnableCarHandlingDesignCalculationApplied = carDesignCalculationUpdate.IsCodeModified();
            if (isEnableCarHandlingDesignCalculationApplied != IsCarDesignCalculationUpdateRequired)
            {
                ApplyReversibleCode(carDesignCalculationUpdate, IsCarDesignCalculationUpdateRequired);
            }

            var carHandlingPerformanceFix = new CarHandlingPerformanceFix(gameExecutablePath);
            var isEnableCarPerformanceRaceCalcuationApplied = carHandlingPerformanceFix.IsCodeModified();
            if (isEnableCarPerformanceRaceCalcuationApplied != IsCarHandlingPerformanceFixRequired)
            {
                ApplyReversibleCode(carHandlingPerformanceFix, IsCarHandlingPerformanceFixRequired);
            }

            // Scenarios for each irreversible code module
            // Scenario 1: If currently not applied and should be applied, apply modified code
            // Scenario 2: If currently not applied and should not be applied, do nothing
            // Scenario 3: If currently applied, do nothing

            var pointsScoringSystemDefault = new PointsSystemF119912002Update(gameExecutablePath);
            var isPointsScoringSystemDefaultApplied = pointsScoringSystemDefault.IsCodeModified();
            if (!isPointsScoringSystemDefaultApplied && IsPointsScoringSystemDefaultRequired)
            {
                ApplyIrreversibleCode(pointsScoringSystemDefault);
            }

            var pointsScoringSystemOption1 = new PointsSystemF119811990Update(gameExecutablePath);
            var isPointsScoringSystemOption1Applied = pointsScoringSystemOption1.IsCodeModified();
            if (!isPointsScoringSystemOption1Applied && IsPointsScoringSystemOption1Required)
            {
                ApplyIrreversibleCode(pointsScoringSystemOption1);
            }

            var pointsScoringSystemOption2 = new PointsSystemF120032009Update(gameExecutablePath);
            var isPointsScoringSystemOption2Applied = pointsScoringSystemOption2.IsCodeModified();
            if (!isPointsScoringSystemOption2Applied && IsPointsScoringSystemOption2Required)
            {
                ApplyIrreversibleCode(pointsScoringSystemOption2);
            }

            var pointsScoringSystemOption3 = new PointsSystemF1201020xxUpdate(gameExecutablePath);
            var isPointsScoringSystemOption3Applied = pointsScoringSystemOption3.IsCodeModified();
            if (!isPointsScoringSystemOption3Applied && IsPointsScoringSystemOption3Required)
            {
                ApplyIrreversibleCode(pointsScoringSystemOption3);
            }
        }

        private void ImportGameConfiguration(string gameExecutablePath)
        {
            IsGameCdFixApplied = new GameCdFix(gameExecutablePath).IsCodeModified();
            IsDisplayModeFixApplied = new DisplayModeFix(gameExecutablePath).IsCodeModified();
            IsSampleAppFixApplied = new SampleAppFix(gameExecutablePath).IsCodeModified();
            IsRaceSoundsFixApplied = new RaceSoundsFix(gameExecutablePath).IsCodeModified();
            // TODO: IsPitExitPriorityFixApplied = new PitExitPriorityFix(gameExecutablePath).IsCodeModified();

            IsYellowFlagFixApplied = new YellowFlagFix(gameExecutablePath).IsCodeModified();
            IsCarDesignCalculationUpdateApplied = new CarDesignCalculationUpdate(gameExecutablePath).IsCodeModified();
            IsCarHandlingPerformanceFixApplied = new CarHandlingPerformanceFix(gameExecutablePath).IsCodeModified();

            IsPointsScoringSystemDefaultApplied = new PointsSystemF119912002Update(gameExecutablePath).IsCodeModified();
            IsPointsScoringSystemOption1Applied = new PointsSystemF119811990Update(gameExecutablePath).IsCodeModified();
            IsPointsScoringSystemOption2Applied = new PointsSystemF120032009Update(gameExecutablePath).IsCodeModified();
            IsPointsScoringSystemOption3Applied = new PointsSystemF1201020xxUpdate(gameExecutablePath).IsCodeModified();

            // TODO: IsCommentaryModifiedApplied = ???;
        }

        private void ImportPerformanceCurve(string gameExecutablePath)
        {
            PerformanceCurve = new PerformanceCurve();
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                PerformanceCurve.ImportData(executableConnection, LanguageStrings);
            }
        }

        private void ExportPerformanceCurve(string gameExecutablePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                PerformanceCurve.ExportData(executableConnection, LanguageStrings);
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
            // TODO: should we confirm unmodified code exists? but would that affect differing versions?

            Debug.WriteLine("Applying irreversible modified code.");
            dataPatcherUnitBase.ApplyModifiedCode();
        }

        private static void ValidateGameFolder(string gameFolderPath, string context)
        {
            string verificationMessage;
            var isValid = new GameFolderVerification().IsFolderSupported(gameFolderPath, out verificationMessage);

            if (isValid) return;
            var resolutionMessage = $"Please ensure the selected folder contains the game folders and files to {context} successfully.";
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        private static void ValidateGameExecutable(string gameExecutablePath, string context)
        {
            string verificationMessage;
            var isValid = new GameExecutableVerification().IsFileSupported(gameExecutablePath, out verificationMessage);

            if (isValid) return;
            var resolutionMessage = $"Please ensure the selected file is a compatible v1.01b game executable to {context} successfully.";
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        private static void ValidateLanguageFile(string languageFilePath, string context)
        {
            string verificationMessage;
            var isValid = new LanguageFileVerification().IsFileSupported(languageFilePath, out verificationMessage);

            if (isValid) return;
            var resolutionMessage = $"Please ensure the selected file is a compatible v1.01b language file to {context} successfully.";
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }
    }
}