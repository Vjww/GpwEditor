using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data.Collections.Language;
using Data.Entities.Commentary;
using Data.FileConnection;
using Data.FileVerification;

namespace Data.Databases
{
    public class DatabaseBase
    {
        public IdentityCollection LanguageResources { get; set; }
        public Collection<CommentaryDriverIndex> CommentaryIndicesDriver { get; set; }
        public Collection<CommentaryTeamIndex> CommentaryIndicesTeam { get; set; }

        protected void ExportLanguageResources(string filePath)
        {
            using (var connection = new LanguageResourceConnection(filePath))
            {
                connection.Save(LanguageResources);
            }
        }

        protected void ImportLanguageResources(string filePath)
        {
            using (var connection = new LanguageResourceConnection(filePath))
            {
                LanguageResources = connection.Load();
            }
        }

        protected void ExportCommentaryIndicesDriver(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, CommentaryIndicesDriver);
        }

        protected void ImportCommentaryIndicesDriver(string gameExecutablePath)
        {
            CommentaryIndicesDriver = new Collection<Entities.Commentary.CommentaryDriverIndex>
            {
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(0), 0),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(1), 1),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(2), 2),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(3), 3),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(4), 4),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(5), 5),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(6), 6),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(7), 7),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(8), 8),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(9), 9),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(10), 10),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(11), 11),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(12), 12),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(13), 13),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(14), 14),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(15), 15),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(16), 16),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(17), 17),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(18), 18),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(19), 19),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(20), 20),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(21), 21),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(22), 22),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(23), 23),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(24), 24),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(25), 25),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(26), 26),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(27), 27),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(28), 28),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(29), 29),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(30), 30),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(31), 31),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(32), 32),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(33), 33),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(34), 34),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(35), 35),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(36), 36),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(37), 37),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(38), 38),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(39), 39),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(40), 40),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(41), 41),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(42), 42),
                new Entities.Commentary.CommentaryDriverIndex(new ValueMapping.Commentary.CommentaryDriverIndex(43), 43)
            };
            ImportData(gameExecutablePath, CommentaryIndicesDriver);
        }

        protected void ExportCommentaryIndicesTeam(string gameExecutablePath)
        {
            ExportData(gameExecutablePath, CommentaryIndicesTeam);
        }

        protected void ImportCommentaryIndicesTeam(string gameExecutablePath)
        {
            CommentaryIndicesTeam = new Collection<Entities.Commentary.CommentaryTeamIndex>
            {
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(0), 0),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(1), 1),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(2), 2),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(3), 3),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(4), 4),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(5), 5),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(6), 6),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(7), 7),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(8), 8),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(9), 9),
                new Entities.Commentary.CommentaryTeamIndex(new ValueMapping.Commentary.CommentaryTeamIndex(10), 10)
            };
            ImportData(gameExecutablePath, CommentaryIndicesTeam);
        }

        protected void ExportData<T>(string gameExecutablePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                foreach (var item in collection)
                {
                    item.ExportData(executableConnection, LanguageResources);
                }
            }
        }

        protected void ImportData<T>(IEnumerable<T> collection) where T : IDataConnection
        {
            foreach (var item in collection)
            {
                item.ImportData(null, LanguageResources);
            }
        }

        protected void ImportData<T>(string gameExecutablePath, IEnumerable<T> collection) where T : IDataConnection
        {
            using (var executableConnection = new ExecutableConnection(gameExecutablePath))
            {
                foreach (var item in collection)
                {
                    item.ImportData(executableConnection, LanguageResources);
                }
            }
        }

        protected static void ValidateGameFolder(string gameFolderPath, string resolutionMessage)
        {
            string verificationMessage;
            var isValid = new GameFolderVerification().IsFolderSupported(gameFolderPath, out verificationMessage);

            if (isValid) return;
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        protected static void ValidateGameExecutable(string gameExecutablePath, string resolutionMessage)
        {
            string verificationMessage;
            var isValid = new GameExecutableVerification().IsFileSupported(gameExecutablePath, out verificationMessage);

            if (isValid) return;
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        protected static void ValidateLanguageFile(string languageFilePath, string resolutionMessage)
        {
            string verificationMessage;
            var isValid = new LanguageFileVerification().IsFileSupported(languageFilePath, out verificationMessage);

            if (isValid) return;
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }
    }
}