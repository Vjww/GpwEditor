using System;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Managers;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string gameFolder = @"C:\gpw";
            const string tempFolder = @"C:\temp\gpwtest";

            var repositoryManager = new RepositoryManager();

            // Source
            var connectionStrings = new ConnectionStrings
            {
                GameFolder = $@"{gameFolder}",
                GameExecutable = $@"{gameFolder}\gpw.exe",
                EnglishLanguageResource = $@"{gameFolder}\english.txt",
                FrenchLanguageResource = $@"{gameFolder}\french.txt",
                GermanLanguageResource = $@"{gameFolder}\german.txt",
                EnglishCommentaryResource = $@"{gameFolder}\text\comme.txt",
                FrenchCommentaryResource = $@"{gameFolder}\textf\commf.txt",
                GermanCommentaryResource = $@"{gameFolder}\textg\commg.txt"
            };
            // Import
            repositoryManager.ImportRepositoryFromGameFiles(connectionStrings);

            // Destination
            connectionStrings.GameExecutable = $@"{tempFolder}\gpw.exe";
            connectionStrings.EnglishLanguageResource = $@"{tempFolder}\english.txt";
            connectionStrings.FrenchLanguageResource = $@"{tempFolder}\french.txt";
            connectionStrings.GermanLanguageResource = $@"{tempFolder}\german.txt";
            connectionStrings.EnglishCommentaryResource = $@"{tempFolder}\comme.txt";
            connectionStrings.FrenchCommentaryResource = $@"{tempFolder}\commf.txt";
            connectionStrings.GermanCommentaryResource = $@"{tempFolder}\commg.txt";
            // Export
            repositoryManager.ExportRepositoryToGameFiles(connectionStrings);

            var records = repositoryManager.CarNumberRepository.Get();

            foreach (var record in records)
            {
                Console.WriteLine($"Id:{record.Id}, A:{record.CarNumberA}, B:{record.CarNumberB}");
            }
            Console.ReadLine();
        }
    }
}