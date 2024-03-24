using System;
using System.IO;
using System.Reflection;
using App.BaseGameEditor.Infrastructure.Factories;

namespace App.BaseGameEditor.Application.Services
{
    public class EmbeddedResourceDeployer
    {
        private readonly FileResourceFactory _fileResourceFactory;
        private readonly Assembly _assembly;

        public EmbeddedResourceDeployer(FileResourceFactory fileResourceFactory)
        {
            _fileResourceFactory = fileResourceFactory ?? throw new ArgumentNullException(nameof(fileResourceFactory));
            _assembly = Assembly.GetExecutingAssembly();
        }

        public void DeployExecutableResourcesToGameFolder(string gameExecutableFilePath)
        {
            ExportEmbeddedResourceToFile(gameExecutableFilePath, "Resources.gpw.exe");                                           // Overwrite
        }

        public void DeployLanguageResourcesToGameFolder(string englishLanguageFilePath, string frenchLanguageFilePath, string germanLanguageFilePath)
        {
            ExportEmbeddedResourceToFile(englishLanguageFilePath, "Resources.english.txt");                                      // Overwrite
            ExportEmbeddedResourceToFile(frenchLanguageFilePath, "Resources.french.txt");                                        // New/Overwrite
            ExportEmbeddedResourceToFile(germanLanguageFilePath, "Resources.german.txt");                                        // New/Overwrite
        }

        public void DeployCommentaryResourcesToGameFolder(string gameFolderPath, string englishCommentaryFilePath, string frenchCommentaryFilePath, string germanCommentaryFilePath)
        {
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONOUT.wav"), "Resources.speeche.ANONOUT.wav"); // New
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP1.wav"), "Resources.speeche.ANONP1.wav");   // New
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP2.wav"), "Resources.speeche.ANONP2.wav");   // New
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONP3.wav"), "Resources.speeche.ANONP3.wav");   // New
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\ANONPIT.wav"), "Resources.speeche.ANONPIT.wav"); // New
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\P1C.wav"), "Resources.speeche.P1C.wav");         // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\P2A.wav"), "Resources.speeche.P2A.wav");         // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"speeche\P3A.wav"), "Resources.speeche.P3A.wav");         // Overwrite

            ExportEmbeddedResourceToFile(englishCommentaryFilePath, "Resources.text.COMME.TXT");                                 // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"text\COMMF.txt"), "Resources.text.Commf.txt");           // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"text\COMMG.txt"), "Resources.text.Commg.TXT");           // Overwrite
            ExportEmbeddedResourceToFile(frenchCommentaryFilePath, "Resources.textf.Commf.txt");                                 // Overwrite
            ExportEmbeddedResourceToFile(germanCommentaryFilePath, "Resources.textg.Commg.TXT");                                 // Overwrite
        }

        public void DeployDriverResourcesToGameFolder(string gameFolderPath)
        {
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\6.bmp"), "Resources.bmp.dheads.6.bmp");       // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\24.bmp"), "Resources.bmp.dheads.24.bmp");     // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\40.bmp"), "Resources.bmp.dheads.40.bmp");     // Overwrite
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"bmp\dheads\72.bmp"), "Resources.bmp.dheads.72.bmp");     // Overwrite
        }

        public void DeployTrackEditorResourcesToGameFolder(string gameFolderPath)
        {
            ExportEmbeddedResourceToFile(Path.Combine(gameFolderPath, @"tga\Backdrop\RaceTee.tga"), "Resources.tga.Backdrop.RaceTee.tga"); // New
        }

        private void ExportEmbeddedResourceToFile(string filePath, string caseSensitiveResourcePath)
        {
            var fileResource = _fileResourceFactory.Create();

            // Get project resource marked with a build action of "Embedded Resource" and import
            using (var resourceStream = _assembly.GetManifestResourceStream($"{_assembly.GetName().Name}.{caseSensitiveResourcePath}"))
            {
                fileResource.Import(resourceStream);
            }

            fileResource.Export(filePath);
        }
    }
}