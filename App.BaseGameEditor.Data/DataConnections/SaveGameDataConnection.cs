using System;
using Common.Editor.Data.DataConnections;

namespace App.BaseGameEditor.Data.DataConnections
{
    public class SaveGameDataConnection : IDataConnection
    {
        public string SaveGameFilePath { get; }

        public SaveGameDataConnection(string saveGameFilePath)
        {
            if (string.IsNullOrWhiteSpace(saveGameFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(saveGameFilePath));

            SaveGameFilePath = saveGameFilePath;
        }
    }
}