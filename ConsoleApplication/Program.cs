using System;
using System.IO;
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
            Console.WriteLine("CarNumberRepository");
            Console.WriteLine("-------------------");
            var carNumberEntities = gameDatabase.CarNumberRepository.Get();
            foreach (var entity in carNumberEntities)
            {
                Console.WriteLine($"Id:{entity.Id}, A:{entity.ValueA}, B:{entity.ValueB}");
            }

            // Display values
            Console.WriteLine();
            Console.WriteLine("ChassisHandlingRepository");
            Console.WriteLine("-------------------------");
            var chassisHandlingEntities = gameDatabase.ChassisHandlingRepository.Get();
            foreach (var entity in chassisHandlingEntities)
            {
                Console.WriteLine($"Id:{entity.Id}, A:{entity.Value}");
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