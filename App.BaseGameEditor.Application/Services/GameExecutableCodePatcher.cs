using System;
using System.Diagnostics;
using App.BaseGameEditor.Application.Patchers;
using App.BaseGameEditor.Application.Patchers.CodeShiftPatcher;
using App.BaseGameEditor.Application.Patchers.Enhancements.Units;
using App.BaseGameEditor.Application.Patchers.GlobalUnlockPatcher;
using App.BaseGameEditor.Application.Patchers.JumpBypassPatcher;
using App.BaseGameEditor.Application.Patchers.SwitchIdiomPatcher;
using App.BaseGameEditor.Domain.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class GameExecutableCodePatcher
    {
        private readonly CodeShiftPatcher _codeShiftPatcher;
        private readonly GlobalUnlockPatcher _globalUnlockPatcher;
        private readonly JumpBypassPatcher _jumpBypassPatcher;
        private readonly SwitchIdiomPatcher _switchIdiomPatcher;
        private readonly PointsSystemF119912002Update _pointsSystemF119912002Update;
        private readonly PointsSystemF119811990Update _pointsSystemF119811990Update;
        private readonly PointsSystemF120032009Update _pointsSystemF120032009Update;
        private readonly PointsSystemF1201020xxUpdate _pointsSystemF1201020XxUpdate;
        private readonly GameCdFix _gameCdFix;
        private readonly DisplayModeFix _displayModeFix;
        private readonly SampleAppFix _sampleAppFix;
        private readonly RaceSoundsFix _raceSoundsFix;
        private readonly YellowFlagFix _yellowFlagFix;
        private readonly CarDesignCalculationUpdate _carDesignCalculationUpdate;
        private readonly CarHandlingPerformanceFix _carHandlingPerformanceFix;

        public GameExecutableCodePatcher(
            CodeShiftPatcher codeShiftPatcher,
            GlobalUnlockPatcher globalUnlockPatcher,
            JumpBypassPatcher jumpBypassPatcher,
            SwitchIdiomPatcher switchIdiomPatcher,
            PointsSystemF119912002Update pointsSystemF119912002Update,
            PointsSystemF119811990Update pointsSystemF119811990Update,
            PointsSystemF120032009Update pointsSystemF120032009Update,
            PointsSystemF1201020xxUpdate pointsSystemF1201020XxUpdate,
            GameCdFix gameCdFix,
            DisplayModeFix displayModeFix,
            SampleAppFix sampleAppFix,
            RaceSoundsFix raceSoundsFix,
            YellowFlagFix yellowFlagFix,
            CarDesignCalculationUpdate carDesignCalculationUpdate,
            CarHandlingPerformanceFix carHandlingPerformanceFix)
        {
            _codeShiftPatcher = codeShiftPatcher ?? throw new ArgumentNullException(nameof(codeShiftPatcher));
            _globalUnlockPatcher = globalUnlockPatcher ?? throw new ArgumentNullException(nameof(globalUnlockPatcher));
            _jumpBypassPatcher = jumpBypassPatcher ?? throw new ArgumentNullException(nameof(jumpBypassPatcher));
            _switchIdiomPatcher = switchIdiomPatcher ?? throw new ArgumentNullException(nameof(switchIdiomPatcher));
            _pointsSystemF119912002Update = pointsSystemF119912002Update ?? throw new ArgumentNullException(nameof(pointsSystemF119912002Update));
            _pointsSystemF119811990Update = pointsSystemF119811990Update ?? throw new ArgumentNullException(nameof(pointsSystemF119811990Update));
            _pointsSystemF120032009Update = pointsSystemF120032009Update ?? throw new ArgumentNullException(nameof(pointsSystemF120032009Update));
            _pointsSystemF1201020XxUpdate = pointsSystemF1201020XxUpdate ?? throw new ArgumentNullException(nameof(pointsSystemF1201020XxUpdate));
            _gameCdFix = gameCdFix ?? throw new ArgumentNullException(nameof(gameCdFix));
            _displayModeFix = displayModeFix ?? throw new ArgumentNullException(nameof(displayModeFix));
            _sampleAppFix = sampleAppFix ?? throw new ArgumentNullException(nameof(sampleAppFix));
            _raceSoundsFix = raceSoundsFix ?? throw new ArgumentNullException(nameof(raceSoundsFix));
            _yellowFlagFix = yellowFlagFix ?? throw new ArgumentNullException(nameof(yellowFlagFix));
            _carDesignCalculationUpdate = carDesignCalculationUpdate ?? throw new ArgumentNullException(nameof(carDesignCalculationUpdate));
            _carHandlingPerformanceFix = carHandlingPerformanceFix ?? throw new ArgumentNullException(nameof(carHandlingPerformanceFix));
        }

        public void Upgrade(string gameExecutableFilePath)
        {
            // Replace switch statements with new idiom to allow for successful disassembly.
            // Required for upgrade to be successful and cannot be reversed.
            _switchIdiomPatcher.Apply(gameExecutableFilePath);

            // Free up space in executable by removing redundant jumping functions.
            // Required for upgrade to be successful and cannot be reversed.
            _jumpBypassPatcher.Apply(gameExecutableFilePath);

            // Shift code around to consolidate and organise instructions and generate free space.
            // Required for upgrade to be successful and cannot be reversed.
            _codeShiftPatcher.Apply(gameExecutableFilePath);

            // Reroute calls to GlobalUnlock through a custom function to resolve compatibility issues.
            // Required for upgrade to be successful and cannot be reversed.
            _globalUnlockPatcher.Apply(gameExecutableFilePath);

            // Upgrade unmodified points scoring system with reworked code.
            // to allow compatible alternative point scoring systems to be used.
            ApplyIrreversibleCode(_pointsSystemF119912002Update, gameExecutableFilePath);

            // Compatibility
            ApplyReversibleCode(_gameCdFix, true, gameExecutableFilePath);
            ApplyReversibleCode(_displayModeFix, true, gameExecutableFilePath);
            ApplyReversibleCode(_sampleAppFix, true, gameExecutableFilePath);
            ApplyReversibleCode(_raceSoundsFix, true, gameExecutableFilePath);

            // Gameplay
            ApplyReversibleCode(_yellowFlagFix, true, gameExecutableFilePath);
            ApplyReversibleCode(_carDesignCalculationUpdate, true, gameExecutableFilePath);
            ApplyReversibleCode(_carHandlingPerformanceFix, true, gameExecutableFilePath);
        }

        public void ExportConfiguration(DomainModelService domainModel, string gameExecutableFilePath)
        {
            // Scenarios for each reversible code module
            // Scenario 1: If currently applied and should not be applied, apply unmodified code
            // Scenario 2: If currently not applied and should be applied, apply modified code
            // Scenario 3: If currently applied and should be applied, do nothing
            // Scenario 4: If currently not applied and should not be applied, do nothing

            // Compatibility
            var isGameCdFixApplied = _gameCdFix.IsCodeModified(gameExecutableFilePath);
            var isGameCdFixRequired = domainModel.Configurations.DisableGameCd;
            if (isGameCdFixApplied != isGameCdFixRequired)
            {
                ApplyReversibleCode(_gameCdFix, isGameCdFixRequired, gameExecutableFilePath);
            }

            var isDisplayModeFixApplied = _displayModeFix.IsCodeModified(gameExecutableFilePath);
            var isDisplayModeFixRequired = domainModel.Configurations.DisableColourMode;
            if (isDisplayModeFixApplied != isDisplayModeFixRequired)
            {
                ApplyReversibleCode(_displayModeFix, isDisplayModeFixRequired, gameExecutableFilePath);
            }

            var isSampleAppFixApplied = _sampleAppFix.IsCodeModified(gameExecutableFilePath);
            var isSampleAppFixRequired = domainModel.Configurations.DisableSampleApp;
            if (isSampleAppFixApplied != isSampleAppFixRequired)
            {
                ApplyReversibleCode(_sampleAppFix, isSampleAppFixRequired, gameExecutableFilePath);
            }

            var isRaceSoundsFixApplied = _raceSoundsFix.IsCodeModified(gameExecutableFilePath);
            var isRaceSoundsFixRequired = domainModel.Configurations.DisableMemoryResetForRaceSounds;
            if (isRaceSoundsFixApplied != isRaceSoundsFixRequired)
            {
                ApplyReversibleCode(_raceSoundsFix, isRaceSoundsFixRequired, gameExecutableFilePath);
            }

            // var isPitExitPriorityFixApplied = _pitExitPriorityFix.IsCodeModified(gameExecutableFilePath);       // TODO: Not implemented yet
            // var isPitExitPriorityFixRequired = domainModel.Configurations.DisablePitExitPriority;               // TODO: Not implemented yet
            // if (isPitExitPriorityFixApplied != isPitExitPriorityFixRequired)                                    // TODO: Not implemented yet
            // {                                                                                                   // TODO: Not implemented yet
            //     ApplyReversibleCode(_pitExitPriorityFix, isPitExitPriorityFixRequired, gameExecutableFilePath); // TODO: Not implemented yet
            // }                                                                                                   // TODO: Not implemented yet

            // Gameplay
            var isYellowFlagFixApplied = _yellowFlagFix.IsCodeModified(gameExecutableFilePath);
            var isYellowFlagFixRequired = domainModel.Configurations.DisableYellowFlagPenalties;
            if (isYellowFlagFixApplied != isYellowFlagFixRequired)
            {
                ApplyReversibleCode(_yellowFlagFix, isYellowFlagFixRequired, gameExecutableFilePath);
            }

            var isCarDesignCalculationUpdateApplied = _carDesignCalculationUpdate.IsCodeModified(gameExecutableFilePath);
            var isCarDesignCalculationUpdateRequired = domainModel.Configurations.EnableCarHandlingDesignCalculation;
            if (isCarDesignCalculationUpdateApplied != isCarDesignCalculationUpdateRequired)
            {
                ApplyReversibleCode(_carDesignCalculationUpdate, isCarDesignCalculationUpdateRequired, gameExecutableFilePath);
            }

            var isCarHandlingPerformanceFixApplied = _carHandlingPerformanceFix.IsCodeModified(gameExecutableFilePath);
            var isCarHandlingPerformanceFixRequired = domainModel.Configurations.EnableCarPerformanceRaceCalcuation;
            if (isCarHandlingPerformanceFixApplied != isCarHandlingPerformanceFixRequired)
            {
                ApplyReversibleCode(_carHandlingPerformanceFix, isCarHandlingPerformanceFixRequired, gameExecutableFilePath);
            }

            // Scenarios for each irreversible code module
            // Scenario 1: If currently not applied and should be applied, apply modified code
            // Scenario 2: If currently not applied and should not be applied, do nothing
            // Scenario 3: If currently applied, do nothing

            // Points Scoring System
            var isPointsScoringSystemDefaultApplied = _pointsSystemF119912002Update.IsCodeModified(gameExecutableFilePath);
            var isPointsScoringSystemDefaultRequired = domainModel.Configurations.PointsScoringSystemDefault;
            if (!isPointsScoringSystemDefaultApplied && isPointsScoringSystemDefaultRequired)
            {
                ApplyIrreversibleCode(_pointsSystemF119912002Update, gameExecutableFilePath);
            }

            var isPointsScoringSystemOption1Applied = _pointsSystemF119811990Update.IsCodeModified(gameExecutableFilePath);
            var isPointsScoringSystemOption1Required = domainModel.Configurations.PointsScoringSystemOption1;
            if (!isPointsScoringSystemOption1Applied && isPointsScoringSystemOption1Required)
            {
                ApplyIrreversibleCode(_pointsSystemF119811990Update, gameExecutableFilePath);
            }

            var isPointsScoringSystemOption2Applied = _pointsSystemF120032009Update.IsCodeModified(gameExecutableFilePath);
            var isPointsScoringSystemOption2Required = domainModel.Configurations.PointsScoringSystemOption2;
            if (!isPointsScoringSystemOption2Applied && isPointsScoringSystemOption2Required)
            {
                ApplyIrreversibleCode(_pointsSystemF120032009Update, gameExecutableFilePath);
            }

            var isPointsScoringSystemOption3Applied = _pointsSystemF1201020XxUpdate.IsCodeModified(gameExecutableFilePath);
            var isPointsScoringSystemOption3Required = domainModel.Configurations.PointsScoringSystemOption3;
            if (!isPointsScoringSystemOption3Applied && isPointsScoringSystemOption3Required)
            {
                ApplyIrreversibleCode(_pointsSystemF1201020XxUpdate, gameExecutableFilePath);
            }
        }

        public void ImportConfiguration(DomainModelService domainModel, string gameExecutableFilePath)
        {
            // Compatibility
            domainModel.Configurations.DisableGameCd = _gameCdFix.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.DisableColourMode = _displayModeFix.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.DisableSampleApp = _sampleAppFix.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.DisableMemoryResetForRaceSounds = _raceSoundsFix.IsCodeModified(gameExecutableFilePath);
            // domainModel.Configurations.DisablePitExitPriority = _pitExitPriorityFix.IsCodeModified(gameExecutableFilePath); // TODO: Not implemented yet

            // Gameplay
            domainModel.Configurations.DisableYellowFlagPenalties = _yellowFlagFix.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.EnableCarHandlingDesignCalculation = _carDesignCalculationUpdate.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.EnableCarPerformanceRaceCalcuation = _carHandlingPerformanceFix.IsCodeModified(gameExecutableFilePath);

            // Points Scoring System
            domainModel.Configurations.PointsScoringSystemDefault = _pointsSystemF119912002Update.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.PointsScoringSystemOption1 = _pointsSystemF119811990Update.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.PointsScoringSystemOption2 = _pointsSystemF120032009Update.IsCodeModified(gameExecutableFilePath);
            domainModel.Configurations.PointsScoringSystemOption3 = _pointsSystemF1201020XxUpdate.IsCodeModified(gameExecutableFilePath);
        }

        private static void ApplyReversibleCode(IDataPatcherUnitBase dataPatcherUnitBase, bool applyModified, string gameExecutableFilePath)
        {
            if (applyModified)
            {
                // If unmodified code is applied, apply modified code
                if (dataPatcherUnitBase.IsCodeUnmodified(gameExecutableFilePath))
                {
                    Debug.WriteLine("Applying reversible modified code.");
                    dataPatcherUnitBase.ApplyModifiedCode(gameExecutableFilePath);
                }
                else
                {
                    if (!dataPatcherUnitBase.IsCodeModified(gameExecutableFilePath))
                    {
                        throw new Exception("Unknown code detected. Unable to apply modified code.");
                    }
                    throw new Exception("Modified code already applied.");
                }
            }
            else
            {
                // If modified code is applied, apply unmodified code
                if (dataPatcherUnitBase.IsCodeModified(gameExecutableFilePath))
                {
                    Debug.WriteLine("Applying reversible unmodified code.");
                    dataPatcherUnitBase.ApplyUnmodifiedCode(gameExecutableFilePath);
                }
                else
                {
                    if (!dataPatcherUnitBase.IsCodeUnmodified(gameExecutableFilePath))
                    {
                        throw new Exception("Unknown code detected. Unable to apply unmodified code.");
                    }
                    throw new Exception("Unmodified code already applied.");
                }
            }
        }

        private static void ApplyIrreversibleCode(IDataPatcherUnitBase dataPatcherUnitBase, string gameExecutableFilePath)
        {
            // TODO: should we confirm unmodified code exists? but would that affect differing versions?

            Debug.WriteLine("Applying irreversible modified code.");
            dataPatcherUnitBase.ApplyModifiedCode(gameExecutableFilePath);
        }
    }
}