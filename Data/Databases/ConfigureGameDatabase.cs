using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Data.Collections.Language;
using Data.Entities.Commentary;
using Data.Entities.Executable.Race;
using Data.Entities.Generic;
using Data.FileConnection;
using Data.Patchers;
using Data.Patchers.Enhancements.Units;
using CommentaryEntities = Data.Entities.Commentary;
using CommentaryMapping = Data.ValueMapping.Commentary;

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

        public IdentityCollection LanguageResources { get; set; }
        public Collection<CommentaryResource> CommentaryResources { get; set; }
        public Collection<CommentaryDriverIndex> CommentaryIndicesDriver { get; set; }
        public Collection<CommentaryTeamIndex> CommentaryIndicesTeam { get; set; }
        public Collection<CommentaryResource> CommentaryResourcesDriverPrefixes { get; set; }
        public Collection<CommentaryResource> CommentaryResourcesTeamPrefixes { get; set; }
        public Collection<StringValue> CommentaryResourcesWavSoundFiles { get; set; }
        public PerformanceCurve PerformanceCurve { get; set; }

        public void ImportDataFromFile(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            ValidateGameFolder(gameFolderPath, "import");
            ValidateGameExecutable(gameExecutablePath, "import");
            ValidateLanguageFile(languageFilePath, "import");

            ImportLanguageResources(languageFilePath);
            ImportCommentaryResources(gameFolderPath, Path.Combine(gameFolderPath, @"text\comme.txt"));

            ImportGameConfiguration(gameExecutablePath);
            ImportCommentaryIndicesDriver(gameExecutablePath);
            ImportCommentaryIndicesTeam(gameExecutablePath);
            ImportPerformanceCurve(gameExecutablePath);
        }

        public void ExportDataToFile(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            ValidateGameFolder(gameFolderPath, "export");
            ValidateGameExecutable(gameExecutablePath, "export");
            ValidateLanguageFile(languageFilePath, "export");

            ExportGameConfiguration(gameExecutablePath);
            ExportCommentaryIndicesDriver(gameExecutablePath);
            ExportCommentaryIndicesTeam(gameExecutablePath);
            ExportPerformanceCurve(gameExecutablePath);

            ExportCommentaryResources(Path.Combine(gameFolderPath, @"text\comme.txt"));
            ExportLanguageResources(languageFilePath);
        }

        private void ExportCommentaryResources(string filePath)
        {
            MergeCommentaryResourcesCollections();

            using (var connection = new CommentaryResourceConnection(filePath))
            {
                connection.Save(CommentaryResources);
            }
        }

        private void ImportCommentaryResources(string gameFolderPath, string commentaryResourceFilePath)
        {
            using (var connection = new CommentaryResourceConnection(commentaryResourceFilePath))
            {
                CommentaryResources = connection.Load();
            }

            CommentaryResourcesDriverPrefixes = new Collection<CommentaryResource>();
            foreach (var item in CommentaryResources.Where(x => x.Id >= 67 && x.Id <= 107))
            {
                CommentaryResourcesDriverPrefixes.Add(item);
            }

            CommentaryResourcesTeamPrefixes = new Collection<CommentaryResource>();
            foreach (var item in CommentaryResources.Where(x => x.Id >= 231 && x.Id <= 241))
            {
                CommentaryResourcesTeamPrefixes.Add(item);
            }

            CommentaryResourcesWavSoundFiles = new Collection<StringValue>(GetCommentaryResourcesWavSoundFiles(gameFolderPath));
        }

        private void ExportCommentaryIndicesDriver(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, CommentaryIndicesDriver);
        }

        private void ImportCommentaryIndicesDriver(string gameExecutablePath)
        {
            CommentaryIndicesDriver = new Collection<CommentaryEntities.CommentaryDriverIndex>
            {
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(0), 0),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(1), 1),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(2), 2),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(3), 3),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(4), 4),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(5), 5),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(6), 6),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(7), 7),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(8), 8),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(9), 9),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(10), 10),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(11), 11),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(12), 12),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(13), 13),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(14), 14),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(15), 15),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(16), 16),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(17), 17),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(18), 18),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(19), 19),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(20), 20),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(21), 21),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(22), 22),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(23), 23),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(24), 24),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(25), 25),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(26), 26),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(27), 27),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(28), 28),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(29), 29),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(30), 30),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(31), 31),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(32), 32),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(33), 33),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(34), 34),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(35), 35),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(36), 36),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(37), 37),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(38), 38),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(39), 39),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(40), 40),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(41), 41),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(42), 42),
                new CommentaryEntities.CommentaryDriverIndex(new CommentaryMapping.CommentaryDriverIndex(43), 43)
            };
            ImportData(gameExecutablePath, CommentaryIndicesDriver);
        }

        private void ExportCommentaryIndicesTeam(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, CommentaryIndicesTeam);
        }

        private void ImportCommentaryIndicesTeam(string gameExecutablePath)
        {
            CommentaryIndicesTeam = new Collection<CommentaryEntities.CommentaryTeamIndex>
            {
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(0), 0),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(1), 1),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(2), 2),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(3), 3),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(4), 4),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(5), 5),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(6), 6),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(7), 7),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(8), 8),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(9), 9),
                new CommentaryEntities.CommentaryTeamIndex(new CommentaryMapping.CommentaryTeamIndex(10), 10)
            };
            ImportData(gameExecutablePath, CommentaryIndicesTeam);
        }

        private void ExportLanguageResources(string filePath)
        {
            using (var connection = new LanguageResourceConnection(filePath))
            {
                connection.Save(LanguageResources);
            }
        }

        private void ImportLanguageResources(string filePath)
        {
            using (var connection = new LanguageResourceConnection(filePath))
            {
                LanguageResources = connection.Load();
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

        private void ExportPerformanceCurve(string gameExecutablePath)
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                PerformanceCurve.ExportData(executableConnection, LanguageResources);
            }
        }

        private void ImportPerformanceCurve(string gameExecutablePath)
        {
            PerformanceCurve = new PerformanceCurve();
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                PerformanceCurve.ImportData(executableConnection, LanguageResources);
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

        private static IEnumerable<StringValue> BuildFileNames(IEnumerable<string> list)
        {
            return list.Select(t => new StringValue(Path.GetFileName(t))).ToList();
        }

        private static List<StringValue> GetCommentaryResourcesWavSoundFiles(string gameFolderPath)
        {
            // Select files from folder
            var speecheFolderPath = $@"{gameFolderPath}\SPEECHE";
            var p1WavFiles = Directory.GetFiles(speecheFolderPath, "*P1.WAV");
            var p2WavFiles = Directory.GetFiles(speecheFolderPath, "*P2.WAV");
            var p3WavFiles = Directory.GetFiles(speecheFolderPath, "*P3.WAV");
            var outWavFiles = Directory.GetFiles(speecheFolderPath, "*OUT.WAV");
            var pitWavFiles = Directory.GetFiles(speecheFolderPath, "*PIT.WAV");

            // Add selected files to list, remove invalid selections, and sort
            var fileList = new List<StringValue>();
            fileList.AddRange(BuildFileNames(p1WavFiles));
            fileList.AddRange(BuildFileNames(p2WavFiles));
            fileList.AddRange(BuildFileNames(p3WavFiles));
            fileList.AddRange(BuildFileNames(outWavFiles));
            fileList.AddRange(BuildFileNames(pitWavFiles));
            RemoveInvalidFiles(fileList, new List<StringValue>
            {
                new StringValue("AUTOPIT.WAV"),
                new StringValue("FLYLAP1.WAV"),
                new StringValue("FLYLAP2.WAV"),
                new StringValue("FLYLAP3.WAV"),
                new StringValue("IMOUT.WAV"),
                new StringValue("WEREOUT.WAV")
            });
            fileList.Sort((x, y) => string.Compare(x.Value, y.Value, StringComparison.Ordinal));
            return fileList;
        }

        private void ExportData<T>(string gameExecutablePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                foreach (var item in collection)
                {
                    item.ExportData(executableConnection, LanguageResources);
                }
            }
        }

        private void ImportData<T>(IEnumerable<T> collection) where T : IDataConnection
        {
            foreach (var item in collection)
            {
                item.ImportData(null, LanguageResources);
            }
        }

        private void ImportData<T>(string gameExecutablePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                foreach (var item in collection)
                {
                    item.ImportData(executableConnection, LanguageResources);
                }
            }
        }

        private void MergeCommentaryResourcesCollections()
        {
            // Update commentary resources collection with changes to driver prefixes for 67-231, 244-284
            foreach (var item in CommentaryResourcesDriverPrefixes)
            {
                var transcriptPrefix = CommentaryIndicesDriver.First(x => x.CommentaryIndex == item.Id).ResourceText;

                // P1
                var p1Destination = CommentaryResources.Single(x => x.Id == item.Id); // 67
                p1Destination.FileNamePrefix = item.FileNamePrefix;
                p1Destination.TranscriptPrefix = transcriptPrefix;

                // P2
                var p2Destination = CommentaryResources.Single(x => x.Id == item.Id + 41); // 108
                p2Destination.FileNamePrefix = item.FileNamePrefix;
                p2Destination.TranscriptPrefix = transcriptPrefix;

                // P3
                var p3Destination = CommentaryResources.Single(x => x.Id == item.Id + 82); // 149
                p3Destination.FileNamePrefix = item.FileNamePrefix;
                p3Destination.TranscriptPrefix = transcriptPrefix;

                // Out
                var outDestination = CommentaryResources.Single(x => x.Id == item.Id + 123); // 190
                outDestination.FileNamePrefix = item.FileNamePrefix;
                outDestination.TranscriptPrefix = transcriptPrefix;

                // Pits
                var pitsDestination = CommentaryResources.Single(x => x.Id == item.Id + 176); // 243
                pitsDestination.FileNamePrefix = item.FileNamePrefix;
                pitsDestination.TranscriptPrefix = transcriptPrefix;
            }

            // Update commentary resources collection with changes to team prefixes for 231-241
            foreach (var item in CommentaryResourcesTeamPrefixes)
            {
                var transcriptPrefix = CommentaryIndicesTeam.First(x => x.CommentaryIndex == item.Id).ResourceText;

                // Out
                var outDestination = CommentaryResources.Single(x => x.Id == item.Id); // 231
                outDestination.FileNamePrefix = item.FileNamePrefix;
                outDestination.TranscriptPrefix = transcriptPrefix;
            }
        }

        private static void RemoveInvalidFiles(IList<StringValue> fileList, IReadOnlyList<StringValue> invalidFileList)
        {
            for (var i = 0; i < fileList.Count; i++)
            {
                var file = fileList[i];
                for (var j = 0; j < invalidFileList.Count; j++)
                {
                    var invalidFile = invalidFileList[j];
                    if (file.Value.Equals(invalidFile.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        fileList.Remove(file);
                    }
                }
            }
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