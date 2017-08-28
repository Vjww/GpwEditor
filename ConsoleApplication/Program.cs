using System;
using System.IO;
using System.Linq;
using ConsoleApplication.DataSources;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Managers;
using ConsoleApplication.Services;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string gameFolder = @"C:\gpw";
            const string tempFolder = @"C:\temp\gpwtest";

            var gameDatabase = new BaseGameDatabase();

            var gameDataSource = new BaseGameDataSource(
                new StreamService<MemoryStream>(new MemoryStream()),
                new StreamService<MemoryStream>(new MemoryStream()),
                new StreamService<MemoryStream>(new MemoryStream()),
                new StreamService<MemoryStream>(new MemoryStream()),
                new StreamService<MemoryStream>(new MemoryStream()),
                new StreamService<MemoryStream>(new MemoryStream()),
                new StreamService<MemoryStream>(new MemoryStream()));

            // Source
            var sourceConnectionStrings = new BaseGameConnectionStrings
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
            gameDataSource.Load(sourceConnectionStrings);
            gameDatabase.Import(gameDataSource);

            // Display values
            var records = gameDatabase.CarNumberRepository.Get();
            foreach (var record in records)
            {
                Console.WriteLine($"Id:{record.Id}, A:{record.CarNumberA}, B:{record.CarNumberB}");
            }

            // Change values
            records.First(x => x.Id == 6).CarNumberA = 33;
            records.First(x => x.Id == 6).CarNumberB = 34;

            // Display changed values
            var changedRecords = gameDatabase.CarNumberRepository.Get();
            foreach (var changedRecord in changedRecords)
            {
                Console.WriteLine($"Id:{changedRecord.Id}, A:{changedRecord.CarNumberA}, B:{changedRecord.CarNumberB}");
            }

            // Destination
            var destinationConnectionStrings = new BaseGameConnectionStrings
            {
                GameFolder = $@"{tempFolder}",
                GameExecutable = $@"{tempFolder}\gpw.exe",
                EnglishLanguageResource = $@"{tempFolder}\english.txt",
                FrenchLanguageResource = $@"{tempFolder}\french.txt",
                GermanLanguageResource = $@"{tempFolder}\german.txt",
                EnglishCommentaryResource = $@"{tempFolder}\comme.txt",
                FrenchCommentaryResource = $@"{tempFolder}\commf.txt",
                GermanCommentaryResource = $@"{tempFolder}\commg.txt"
            };

            // Export
            gameDatabase.Export(gameDataSource);
            gameDataSource.Save(destinationConnectionStrings);

            // Wait
            Console.ReadLine();
        }
    }
}