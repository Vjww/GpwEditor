using System;
using System.IO;
using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.Services;

namespace GpwEditor.Infrastructure.DataSources
{
    public class SaveGameDataSource : IDataSource<SaveGameConnectionStrings>
    {
        public StreamService<MemoryStream> SaveGame { get; }

        public SaveGameDataSource(StreamService<MemoryStream> saveGame)
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