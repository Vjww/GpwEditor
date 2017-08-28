using System;
using System.IO;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Services;

namespace ConsoleApplication.DataSources
{
    public class SaveGameDataSource : IDataSource<SaveGameConnectionStrings>
    {
        public IStreamService<MemoryStream> SaveGame { get; }

        public SaveGameDataSource(IStreamService<MemoryStream> saveGame)
        {
            if (saveGame == null) throw new ArgumentNullException(nameof(saveGame));

            SaveGame = saveGame;
        }

        public void Load(SaveGameConnectionStrings connectionStrings)
        {
            if (connectionStrings == null) throw new ArgumentNullException(nameof(connectionStrings));

            SaveGame.LoadFromFile(connectionStrings.SaveGame);
        }

        public void Save(SaveGameConnectionStrings connectionStrings)
        {
            if (connectionStrings == null) throw new ArgumentNullException(nameof(connectionStrings));

            SaveGame.SaveToFile(connectionStrings.SaveGame);
        }
    }
}