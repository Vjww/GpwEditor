using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using Data.Helpers;
using Data.Patchers;
using Data.Patchers.CodeShiftPatcher;
using Data.Patchers.Enhancements.Units;
using Data.Patchers.GlobalUnlockPatcher;
using Data.Patchers.JumpBypassPatcher;
using Data.Patchers.SwitchIdiomPatcher;
using Data.Properties;

namespace Data.Databases
{
    public class UpgradeGameDatabase : DatabaseBase
    {
        public void Upgrade(string gameFolderPath, string gameExecutablePath, string englishLanguageFilePath, string frenchLanguageFilePath, string germanLanguageFilePath)
        {
            const string folderValidationMessageFormat = "The upgrader was unable to recognise the {0} as a valid path to upgrade. Please ensure the selected folder contains the required game folders and files, re-run this program as an administrator and try upgrading again.";
            const string fileValidationMessageFormat = "The upgrader was unable to recognise the {0} as a valid file to upgrade. Please ensure the file is not currently in use, re-run this program as an administrator and try upgrading again.";

            ValidateGameFolder(gameFolderPath, string.Format(folderValidationMessageFormat, "selected game folder"));

            DeployExecutableResourcesToGameFolder(gameExecutablePath);
            ValidateGameExecutable(gameExecutablePath, string.Format(fileValidationMessageFormat ,"game executable (gpw.exe)"));

            DeployLanguageResourcesToGameFolder(englishLanguageFilePath, frenchLanguageFilePath, germanLanguageFilePath);
            ValidateLanguageFile(englishLanguageFilePath, string.Format(fileValidationMessageFormat, "English language file (english.txt)"));
            ValidateLanguageFile(frenchLanguageFilePath, string.Format(fileValidationMessageFormat , "French language file (french.txt)"));
            ValidateLanguageFile(germanLanguageFilePath, string.Format(fileValidationMessageFormat, "German language file (german.txt)"));

            ImportLanguageResources(englishLanguageFilePath);

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

            ImportCommentaryIndicesDriver(gameExecutablePath);
            ImportCommentaryIndicesTeam(gameExecutablePath);

            // Enhancements
            DeployDriverResourcesToGameFolder(gameFolderPath);
            DeployCommentaryResourcesToGameFolder(gameFolderPath);
            ApplyCommentaryIndicesChanges();
            ApplyDriverNameChanges();

            ExportCommentaryIndicesDriver(gameExecutablePath);
            ExportCommentaryIndicesTeam(gameExecutablePath);

            ExportLanguageResources(englishLanguageFilePath);
        }

        private static void DeployCommentaryResourcesToGameFolder(string gameFolderPath)
        {
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONOUT.wav"), Resources.ANONOUT); // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP1.wav"), Resources.ANONP1);   // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP2.wav"), Resources.ANONP2);   // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP3.wav"), Resources.ANONP3);   // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONPIT.wav"), Resources.ANONPIT); // New
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\P1C.wav"), Resources.P1C); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\P2A.wav"), Resources.P2A); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"speeche\P3A.wav"), Resources.P3A); // Overwrite

            CopyResourceToFile(Path.Combine(gameFolderPath, @"text\COMME.txt"), Resources.CommE);           // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"text\COMMF.txt"), Resources.CommF_Redundant); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"text\COMMG.txt"), Resources.CommG_Redundant); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"textf\COMMF.txt"), Resources.CommF);          // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"textg\COMMG.txt"), Resources.CommG);          // Overwrite
        }

        private static void DeployDriverResourcesToGameFolder(string gameFolderPath)
        {
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\6.bmp"), Resources._06);   // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\24.bmp"), Resources._24); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\40.bmp"), Resources._40); // Overwrite
            CopyResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\72.bmp"), Resources._72); // Overwrite
        }

        private static void DeployExecutableResourcesToGameFolder(string gameExecutablePath)
        {
            CopyResourceToFile(gameExecutablePath, Resources.Gpw); // Overwrite
        }

        private static void DeployLanguageResourcesToGameFolder(string englishLanguageFilePath, string frenchLanguageFilePath, string germanLanguageFilePath)
        {
            CopyResourceToFile(englishLanguageFilePath, Resources.English); // Overwrite
            CopyResourceToFile(frenchLanguageFilePath, Resources.French); // New/Overwrite
            CopyResourceToFile(germanLanguageFilePath, Resources.German); // New/Overwrite
        }

        private void ApplyCommentaryIndicesChanges()
        {
            var commentary = new Commentary();

            // Update all drivers with reordered commentary indices
            var counter = 0;
            foreach (var item in CommentaryIndicesDriver)
            {
                item.CommentaryIndex = commentary.DefaultDriverIndices[counter];
                counter++;
            }

            // Update all teams with reordered commentary indices
            counter = 0;
            foreach (var item in CommentaryIndicesTeam)
            {
                item.CommentaryIndex = commentary.DefaultTeamIndices[counter];
                counter++;
            }
        }

        private void ApplyDriverNameChanges()
        {
            var drivers = new Dictionary<string, string>
            {
                {"SID005801", "Jacques Villeneuve"}, // Replaces "John Newhouse"
                {"SID005819", "Jason Watt"},         // Replaces "Driver Unknown"
                {"SID005835", "Juichi Wakisaka"},    // Replaces "Driver Unknown"
                {"SID005867", "Mário Haberfeld"}     // Replaces "Driver Unknown"
            };

            foreach (var driver in drivers)
            {
                ResourceHelper.SetResourceText(LanguageResources, driver.Key, driver.Value);
            }
        }

        private static void CopyResourceToFile(string filePath, Bitmap resource)
        {
            var imageConverter = new ImageConverter();
            File.WriteAllBytes(filePath, (byte[])imageConverter.ConvertTo(resource, typeof(byte[])));
        }

        private static void CopyResourceToFile(string filePath, byte[] resource)
        {
            File.WriteAllBytes(filePath, resource);
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