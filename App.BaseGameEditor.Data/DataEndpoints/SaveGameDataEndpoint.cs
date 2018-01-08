using System;
using App.BaseGameEditor.Data.DataConnections;
using Common.Editor.Data.DataEndpoints;
using Common.Editor.Data.FileResources;

namespace App.BaseGameEditor.Data.DataEndpoints
{
    public class SaveGameDataEndpoint : IDataEndpoint<SaveGameDataConnection>
    {
        public IFileResource SaveGameResource { get; }

        public SaveGameDataEndpoint(IFileResource saveGameResource)
        {
            SaveGameResource = saveGameResource ?? throw new ArgumentNullException(nameof(saveGameResource));
        }

        public void Import(SaveGameDataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            SaveGameResource.Import(dataConnection.SaveGameFilePath);
        }

        public void Export(SaveGameDataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            SaveGameResource.Export(dataConnection.SaveGameFilePath);
        }
    }
}