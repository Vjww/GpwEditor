using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using Data.FileConnection;
using Data.Helpers;
using Data.Patchers;
using Data.Patchers.CodeShiftPatcher;
using Data.Patchers.Enhancements.Units;
using Data.Patchers.GlobalUnlockPatcher;
using Data.Patchers.JumpBypassPatcher;
using Data.Patchers.SwitchIdiomPatcher;
using Data.Properties;
using Data.ValueMapping.Executable.Team;

namespace Data.Databases
{
    public class UpgradeGameDatabase : DatabaseBase
    {
        public void Upgrade(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            ValidateGameFolder(gameFolderPath, "Please ensure the selected folder contains the game folders and files to upgrade successfully.");
            ValidateGameExecutable(gameExecutablePath, "Please ensure the official v1.01b patch has been applied to the game and select a compatible v1.01b game executable to upgrade successfully.");
            ValidateLanguageFile(languageFilePath, "Please ensure the official v1.01b patch has been applied to the game and select a compatible v1.01b language file to upgrade successfully.");

            ImportLanguageResources(languageFilePath);

            // Replace switch statements with new idiom to allow for successful disassembly.
            // Required for upgrade to be successful and cannot be reversed.
            new SwitchIdiomPatcher(gameExecutablePath).Apply();

            // Free up space in executable by removing redundant jumping functions.
            // Required for upgrade to be successful and cannot be reversed.
            new JumpBypassPatcher(gameExecutablePath).Apply();

            // Shift code around to consolidate and organise instructions and generate free space.
            // Required for upgrade to be successful and cannot be reversed.
            new CodeShiftPatcher(gameExecutablePath).Apply();

            // Reroute calls to GlobalUnlock through a custom function to resolve compatibility issues.
            // Required for upgrade to be successful and cannot be reversed.
            new GlobalUnlockPatcher(gameExecutablePath).Apply();

            // Upgrade unmodified points scoring system with reworked code.
            // to allow compatible alternative point scoring systems to be used.
            ApplyIrreversibleCode(new PointsSystemF119912002Update(gameExecutablePath));

            // Compatibility
            ApplyReversibleCode(new GameCdFix(gameExecutablePath), true);
            ApplyReversibleCode(new DisplayModeFix(gameExecutablePath), true);
            ApplyReversibleCode(new SampleAppFix(gameExecutablePath), true);
            ApplyReversibleCode(new RaceSoundsFix(gameExecutablePath), true);

            // Gameplay
            ApplyReversibleCode(new YellowFlagFix(gameExecutablePath), true);
            ApplyReversibleCode(new CarDesignCalculationUpdate(gameExecutablePath), true);
            ApplyReversibleCode(new CarHandlingPerformanceFix(gameExecutablePath), true);

            // Enhancements
            ApplyDriverResourcesToGameFolder(gameFolderPath);
            ApplyCommentaryResourcesToGameFolder(gameFolderPath);
            ApplyCommentarySoundIndexFix(gameExecutablePath);
            ApplyJacquesVilleneuveNameFix();
            ApplyMissingTestDriverNameFix();

            ExportLanguageResources(languageFilePath);
        }

        private static void ApplyCommentaryResourcesToGameFolder(string gameFolderPath)
        {
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONOUT.wav"), Resources.ANONOUT); // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP1.wav"), Resources.ANONP1);   // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP2.wav"), Resources.ANONP2);   // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP3.wav"), Resources.ANONP3);   // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONPIT.wav"), Resources.ANONPIT); // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\P1C.wav"), Resources.P1C);  // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\P2A.wav"), Resources.P2A);  // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\P3A.wav"), Resources.P3A);  // Overwrite

            CopyResourceToFile(Path.Combine(gameFolderPath, @"text\COMME.txt"), Resources.COMME); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"text\COMMF.txt"), Resources.COMME); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"text\COMMG.txt"), Resources.COMME); // Overwrite
        }

        private static void ApplyCommentarySoundIndexFix(string gameExecutablePath)
        {
            const int indexValue = 67;

            // Apply index fix to new additional drivers
            var f1AdditionalDriverValueMappings = new Collection<F1Driver>
            {
                new F1Driver(8),  // Team 3, Driver 3
                new F1Driver(14), // Team 5, Driver 3
                new F1Driver(26)  // Team 9, Driver 3
            };

            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                foreach (var valueMapping in f1AdditionalDriverValueMappings)
                {
                    executableConnection.WriteInteger(valueMapping.CommentaryIndex, indexValue);
                }
            }
        }

        private static void ApplyDriverResourcesToGameFolder(string gameFolderPath)
        {
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\6.bmp"), Resources._6);   // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\24.bmp"), Resources._24); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\40.bmp"), Resources._40); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\72.bmp"), Resources._72); // Overwrite
        }

        private void ApplyJacquesVilleneuveNameFix()
        {
            var drivers = new Dictionary<string, string>
            {
                {"SID005801", "Jacques Villeneuve"}
            };

            foreach (var driver in drivers)
            {
                const string originalText = "John Newhouse";
                if (ResourceHelper.GetResourceText(LanguageResources, driver.Key) == originalText)
                {
                    // Only update text if the original text is still in place
                    ResourceHelper.SetResourceText(LanguageResources, driver.Key, driver.Value);
                }
            }
        }

        private void ApplyMissingTestDriverNameFix()
        {
            var drivers = new Dictionary<string, string>
            {
                {"SID005819", "Jason Watt"},
                {"SID005835", "Juichi Wakisaka"},
                {"SID005867", "Mário Haberfeld"}
            };

            foreach (var driver in drivers)
            {
                const string originalText = "Driver Unknown";
                if (ResourceHelper.GetResourceText(LanguageResources, driver.Key) == originalText)
                {
                    // Only update text if the original text is still in place
                    ResourceHelper.SetResourceText(LanguageResources, driver.Key, driver.Value);
                }
            }
        }

        private static void CopyResourceToFile(string filePath, Bitmap resource)
        {
            var imageConverter = new ImageConverter();
            File.WriteAllBytes(filePath, (byte[])imageConverter.ConvertTo(resource, typeof(byte[])));
        }

        private static void CopyResourceToFile(string filePath, string resource)
        {
            // https://stackoverflow.com/a/17269952
            File.WriteAllText(filePath, resource, Encoding.GetEncoding(1252)); // Western European (Windows)
        }

        private static void CopyResourceToFile(string filePath, Stream resource)
        {
            using (var fileStream = File.Create(filePath))
            {
                resource.Seek(0, SeekOrigin.Begin);
                resource.CopyTo(fileStream);
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
    }
}