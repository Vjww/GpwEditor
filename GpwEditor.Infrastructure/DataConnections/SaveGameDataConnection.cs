using Common.Editor.Infrastructure.DataConnections;

namespace GpwEditor.Infrastructure.DataConnections
{
    public class SaveGameDataConnection : IDataConnection
    {
        public string SaveGameFilePath { get; }

        public SaveGameDataConnection(string saveGameFilePath)
        {
            SaveGameFilePath = saveGameFilePath;
        }
    }
}